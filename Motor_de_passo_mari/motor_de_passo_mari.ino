#include <AccelStepper.h>

// Definição dos pinos de direção e passo do motor de passo, e do pino do sensor
#define directionPin 9
#define stepPin 8
int driverEn1 = 10; //en- pin
#define sensorPin A0

// Inicializa o objeto stepper com a biblioteca AccelStepper
AccelStepper stepper(AccelStepper::DRIVER, stepPin, directionPin);
char receivedCommand;
bool newData = false; 

const int stepsPerRevolution = 1200; // Número de passos por revolução do motor
const int numRotations = 2; // Número de rotações

const int numReadings = 10; // Número de leituras para calcular a média
const float coeficiente_angular = 0.00996; // Coeficiente angular para a conversão de leitura do sensor
const float coeficiente_linear = 0; // Coeficiente linear para a conversão de leitura do sensor

// Arrays e variáveis para armazenamento de leituras e cálculo da posição
float readings[numReadings];
int index = 0;
float total = 0.0;
float position_mm = 0.0;

// Variáveis de estado para controlar se o movimento já foi executado
bool move1Executed = false;
bool move2Executed = false;
bool move3Executed = false;

void setup() {
  Serial.begin(9600); 
  pinMode(directionPin, OUTPUT); 
  pinMode(stepPin, OUTPUT); 
  pinMode(driverEn1, OUTPUT);
  pinMode(sensorPin, INPUT); 
  digitalWrite(driverEn1, HIGH);

  // Configura a velocidade máxima e a aceleração do motor de passo
  stepper.setMaxSpeed(60000);
  stepper.setAcceleration(3600000);
}

void loop() {
  posicao_sensor(); // Atualiza a posição do sensor
  checkSerial(); // Verifica se há comandos recebidos via serial
  metodo2(); // Remover a chamada de metodo2() daqui, para que seja chamado apenas no case 'N'

}

// Função que movimenta o motor para frente e para trás (2 voltas completas)
void metodo1() {
  // Movimento no sentido positivo
  stepper.moveTo(stepsPerRevolution);
  stepper.runToPosition();
  delay(50); 

  // Movimento no sentido negativo
  stepper.moveTo(-stepsPerRevolution);
  stepper.runToPosition();
  delay(50); 
}

// Função que movimenta o motor de acordo com a posição do sensor
void metodo2() {
  if (position_mm >= 0 && position_mm <= 6.5) { // Verifica se a posição está no intervalo desejado
    
    //float inter = 0.5;

    //for (int i = 0; i < 5; i++){
      //float lowerInter = i*(inter);
      //float upperInter = lowerInter + (inter);
    //} 

    if (position_mm > 0.5 && position_mm < 1.0 && !move1Executed) {
      stepper.runToNewPosition(200); // Move o motor para a nova posição
      stepper.runToNewPosition(0); // Retorna o motor à posição original
      move1Executed = true; // Marca que o movimento foi executado
    } 
    else if (position_mm < 0.5 || position_mm >= 1.0) {
      move1Executed = false; // Reseta o estado se fora do intervalo
    }

    if (position_mm > 1.2 && position_mm < 1.7 && !move2Executed) {
      stepper.runToNewPosition(200);
      stepper.runToNewPosition(0);
      move2Executed = true;
    } 
    else if (position_mm < 1.2 || position_mm >= 1.7) {
      move2Executed = false;
    }

    if (position_mm > 1.8 && position_mm < 2.3 && !move3Executed) {
      stepper.runToNewPosition(200);
      stepper.runToNewPosition(0);
      move3Executed = true;
    } 
    else if (position_mm < 1.8 || position_mm >= 2.3) {
      move3Executed = false;
    }
  }
}


// Função que movimenta o motor em pequenos passos
void metodo3() {

  for(int i = 0; i<100; i++){
    // Movimento no sentido positiv
    stepper.moveTo(stepsPerRevolution/5);
    stepper.runToPosition();

    // Movimento no sentido negativo
    stepper.moveTo(-stepsPerRevolution/5);
    stepper.runToPosition();
    
    checkSerial();

  }
}

// Função que movimenta o motor em pequenos passos com delay
void metodo4() {

  for(int i = 0; i<100; i++){
    // Movimento no sentido positiv
    stepper.moveTo(stepsPerRevolution/5);
    stepper.runToPosition();

    // Movimento no sentido negativo
    stepper.moveTo(-stepsPerRevolution/5);
    stepper.runToPosition();

    delay(150);
    
    checkSerial();

  }
}


// Função para receber comandos via serial
void checkSerial() 
{  
    if (Serial.available() > 0) // Se há dados disponíveis na porta serial
    {
        receivedCommand = Serial.read(); // Lê o comando recebido
        newData = true; // Indica que há um novo comando disponível
 
        if (newData == true) // Se há um novo comando
        {
            switch (receivedCommand) // Verifica qual comando foi recebido
            {
            case 'M': // Executa metodo1 se o comando for 'M'
               metodo1(); 

               break;

            case 'N': 
               metodo3(); // Executa metodo3 se o comando for 'O'     

               break;

            case 'O': 
               metodo4(); // Executa metodo3 se o comando for 'O'     

               break;

            case 'P': // Plota a posição do sensor se o comando for 'P'
                posicao_sensor(); 
                            
                break;

            case 'S': // Para o motor e as leituras do sensor se o comando for 'S'
               Serial.println("Stop motor and sensor");
               
               while(true){
                checkSerial();

               }

               break;
         
            }
        }
        newData = false; // Reseta o indicador de novo comando
    }
}

// Função para ler a posição do sensor
void posicao_sensor() {
  static unsigned long time_now = 0;
  const unsigned long interval = 50; // Intervalo de 50 milissegundos

  unsigned long currentMillis = millis();
  if (currentMillis - time_now >= interval) {
    time_now = currentMillis;

    int reading = analogRead(sensorPin); // Lê o valor do sensor

    total = total - readings[index] + reading; // Atualiza a soma total das leituras
    readings[index] = reading; // Armazena a nova leitura no array
    index = (index + 1) % numReadings; // Atualiza o índice do array circular

    float average = total / numReadings; // Calcula a média das leituras
    position_mm = (average * coeficiente_angular + coeficiente_linear) * 10.0; // Converte a média para milímetros

    Serial.print("Distância: ");
    Serial.println(position_mm); // Imprime a distância calculada na serial
  }
}
