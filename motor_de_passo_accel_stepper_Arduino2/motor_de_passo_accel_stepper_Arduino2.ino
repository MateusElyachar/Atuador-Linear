#include <AccelStepper.h>

long receivedMMdistance = 0; //distance in mm from the computer
long receivedDelay = 0; //delay between two steps, received from the computer
long receivedAcceleration = 0; //acceleration value from computer
char receivedCommand; //character for commands

int direcao = 1; // Direção = 1 (CCW) Direção = -1 (CW)
int driverEn = 7; //en- pin 
int sensorProximidadeD = 2; 
int sensorProximidadeE = 3; 
int modo; //modo = 0 (velocidade constante), modo = 1 (aceleração)
String x; 
int y;
int c = 0;  
int velocidadeLinear;
float posicao_calculada =0;
String posicao_calculadaStr;
float posicao_calculada_sensor;
int sensor_posicao = A2;
unsigned long time_now = -1;
float zero_laser = 0;
int MotorSeMovendo = 0; //variavel para saber o estado do motor; se o motor não está se movendo = 0; se o motor está se movendo = 1
int conecao1 = 5;
int conecao2 = 3;


bool newData, runallowed = false; // booleans for new data from serial, and runallowed flag
 
 
 
// Direção - = Digital 10 (CCW), Pulsos - = Digital 8 (CLK)
AccelStepper stepper(1, 8, 10);

String data;
char d1; 


void setup() {
  Serial.begin(9600);

  pinMode(driverEn, OUTPUT);
  pinMode(sensorProximidadeD, INPUT);
  pinMode(sensorProximidadeE, INPUT);
  pinMode(sensor_posicao, INPUT);
  pinMode(conecao1, OUTPUT);
  pinMode(conecao2, OUTPUT);
  
  //setting up some default values for maximum speed and maximum acceleration
  stepper.setMaxSpeed(8000); //SPEED = Steps / second
  stepper.setAcceleration(1000); //ACCELERATION = Steps /(second)^2
 
  stepper.disableOutputs(); //disable outputs, so the motor is not getting warm (no current)
  
}

void loop() {
  
  checkSerial();
  continuousRun2();
  posicao_sensor();

}

void continuousRun2() //method for the motor
{
  if (runallowed == true)
  {
    if (abs(stepper.currentPosition()) < receivedMMdistance) //abs() is needed because of the '<'
    {
      //MotorSeMovendo = 1;
      stepper.enableOutputs(); //enable pins
      stepper.run(); //step the motor (this will step the motor by 1 step at each loop)
    }
    
    else if ((abs(stepper.currentPosition()) < receivedMMdistance) && (modo == 1)) //abs() is needed because of the '<'
    { 
      //MotorSeMovendo = 1;
      stepper.enableOutputs(); //enable pins
      stepper.runSpeedToPosition(); //step the motor (this will step the motor by 1 step at each loop)
    }
    else //program enters this part if the required distance is completed
    {
      posicao_calculada();
      runallowed = false; //disable running -> the program will not try to enter this if-else anymore
      stepper.disableOutputs(); // disable power
      stepper.setCurrentPosition(0); //reset the position to zero
      //MotorSeMovendo = 0;
    }
 
 
  }
  else //program enters this part if the runallowed is FALSE, we do not do anything
  {
    
    return;
 
  }
}

void checkSerial() //method for receiving the commands
{
    if(Serial.available()){
    data = Serial.readString();
    d1 = data.charAt(0);

    switch(d1){         //select action based on the first character

      case 'A':         //first character is an a = turn off/ de-energize motor
      digitalWrite(driverEn, 1);
      Serial.println("Motor ligado!");
      break;

      case 'a':         //first character is an a = turn off/ de-energize motor
      digitalWrite(driverEn, 0);
      Serial.println("Motor desligado!");
      break;
      
      case 'C':         //First character is an C = The equipment goes up
      Serial.println("Direcao: Para cima");
      direcao = -1;
      break;

      case 'B':        //First character is an C = The equipment goes down
      Serial.println("Direcao: Para baixo");
      direcao = 1;
      break;

      case 'P':         //First character is an P = set qntd of pulses to send
      // a cada pulso se movimenta 0,6 mm -> conta: (1,8 \ (3 * 4)) * 4mm do passo
      x = data.substring(1);
      receivedMMdistance = x.toFloat(); //value for the steps
      Serial.print("Pulsos: ");
      Serial.println(receivedMMdistance);
      break;

      case 'G':     //First character is an G = motor accelerates
      Serial.println("O motor está se movendo com aceleração!");
      runallowed = true; //allow running
      modo = 0;
      stepper.setMaxSpeed(receivedDelay); //set speed
      stepper.move(receivedMMdistance*direcao); //set distance
      
      break;

      case 'H':     //First character is an H = motor spins with constant speed
      Serial.println("O motor está se movendo com velocidade constante!");
      stepper.setMaxSpeed(receivedDelay); //set speed
      stepper.setSpeed(receivedDelay);
      stepper.move(receivedMMdistance*direcao); //set distance
      runallowed = true; //allow running
      modo = 1;
      break;
      
      case 'V':         //First character is an V = set velocity
      x = data.substring(1);
      receivedDelay = x.toFloat();
      
      if( receivedDelay <= 8000){
        
        Serial.print("Velocidade: ");
        Serial.println(receivedDelay);
        
        //receivedDelay = (1000000 * 0.6)/(2* velocidadeLinear * 360);
        // vel linear da bucha max = 2,083333...mm/seg
        // vel linear da bucha min = 0,1041666... mm/seg
       
      }
      else{
      Serial.println("Valor invalido. Digite um valor entre até 8000");
      }
      break;

      case 'n': //para o motor
      runallowed = false; //disable running
      posicao_calculada();
      stepper.setCurrentPosition(0); // reset position
      Serial.println("STOP "); //print action
      stepper.stop(); //stop motor
      stepper.disableOutputs(); //disable power
      digitalWrite(driverEn, 0);
      Serial.println("Motor desligado!");
      MotorSeMovendo = 0;
      break;

      case 'O': // sets position
      delayMicroseconds(1000); 
      x = data.substring(1);
      posicao_calculada = x.toFloat();
      delayMicroseconds(1000); 
      posicao_calculadaStr  = String(posicao_calculada);
      Serial.println('p'+ posicao_calculadaStr);
      break;

      case 'J': //sets intercept of the laser

      x = data.substring(1);
      x = data.substring(1);
      zero_laser = x.toFloat();
      
      case 'U':
      digitalWrite(conecao2, 0);
      digitalWrite(conecao1, 1);
      Serial.println("conexão 1, transistores marrom");
      break;
      
      case 'D':
      digitalWrite(conecao1, 0);
      digitalWrite(conecao2, 1);
      Serial.println ("conexão 2, transistores amarelo");
      break;
      
      
    }

    
  }
}

void posicao_sensor(){
  if(time_now == -1){
    time_now = millis();
    }
  
  if(millis() >= time_now + 250){
     time_now = -1;
     posicao_calculada_sensor = -zero_laser + analogRead(sensor_posicao)/4.397818611; //zero_laser geralmente é 26
     //Serial.println('L' + posicao_calculada_sensor);
     
    } 
}


void posicao_calculada(){
  posicao_calculada += stepper.currentPosition() * (-0.000415);
  posicao_calculadaStr  = String(posicao_calculada);
  Serial.println('p'+ posicao_calculadaStr);
}

//void calibracao(float velocidade){
//  receivedMMdistance = 1000;
//  receivedDelay = velocidade;
// direcao = 1;
//  
  
  

//  if(MotorSeMovendo == 0){

//  }
  
    
  
//}