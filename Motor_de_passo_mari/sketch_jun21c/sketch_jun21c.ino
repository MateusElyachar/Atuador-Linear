#include <AccelStepper.h>

#define directionPin 9
#define stepPin 8
#define sensorPin A0

AccelStepper stepper(AccelStepper::DRIVER, stepPin, directionPin);

const int stepsPerRevolution = 1000;
const int numRotations = 2;

const int numReadings = 10;
const float coeficiente_angular = 0.00996;
const float coeficiente_linear = 0;

float readings[numReadings];
int index = 0;
float total = 0.0;
float position_mm = 0.0;

void setup() {
  Serial.begin(9600);
  pinMode(directionPin, OUTPUT);
  pinMode(stepPin, OUTPUT);
  pinMode(sensorPin, INPUT);

  stepper.setMaxSpeed(1000);
  stepper.setAcceleration(1000);
}

void loop() {
  posicao_sensor();
  metodo();

  
}

void metodo() {
  if (position_mm > 5.0) {
    //if (abs(stepper.currentPosition()) < position_mm) { //abs() is needed because of the '<'
    stepper.setSpeed(1000);
    stepper.moveTo(400);
    stepper.runSpeedToPosition();
    stepper.moveTo(0);

      //stepper.runToNewPosition(0);
      //stepper.runToNewPosition(200);
      //stepper.runToNewPosition(100);
   // }
  }
}

void posicao_sensor() {
  static unsigned long time_now = 0;
  const unsigned long interval = 50;

  unsigned long currentMillis = millis();
  if (currentMillis - time_now >= interval) {
    time_now = currentMillis;

    int reading = analogRead(sensorPin);

    total = total - readings[index] + reading;
    readings[index] = reading;
    index = (index + 1) % numReadings;

    float average = total / numReadings;
    position_mm = (average * coeficiente_angular + coeficiente_linear) * 10.0;

    Serial.print("Distância: ");
    Serial.println(position_mm);
  }
}