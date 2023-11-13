int driverEn = 7;
int driverPUL = 11;    // PUL- pin
int driverDIR = 9;    // DIR- pin
String data;
 
// Variables
 
int pd = 100;       // Pulse Delay period
boolean setdir = HIGH; // Set Direction
 
// Interrupt Handler
 
void revmotor (){
 
  setdir = !setdir;
  
}
 
 
void setup() {
 
  pinMode (driverPUL, OUTPUT);
  pinMode (driverDIR, OUTPUT);
  
}
 
void loop() { 

    digitalWrite(driverDIR, setdir);
    digitalWrite(driverPUL,HIGH);
    delayMicroseconds(pd);
    digitalWrite(driverPUL,LOW);
    delayMicroseconds(pd);
 
}
