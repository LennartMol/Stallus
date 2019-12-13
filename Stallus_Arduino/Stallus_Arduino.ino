#include <Servo.h>
#include <Stream.h>
#include <Wire.h>

Servo bikeLock;

#define SENSORPIN 4 
#define SERVOPIN 8 

int pos = 0;
bool isLocked = false;
long timeAvailable;

void setup() {
  pinMode(SENSORPIN, INPUT);     
  digitalWrite(SENSORPIN, HIGH); 
  
  bikeLock.attach(SERVOPIN); 
  bikeLock.write(pos);   
  
  Serial.begin(9600);
  Wire.begin();
}

void loop() {
  CheckForSerialCom();
  CheckForSlaveCom();
  DetectBicycleAvailable_TimeExpired();
}
