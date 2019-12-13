// bron: https://learn.adafruit.com/ir-breakbeam-sensors/arduino

#include <Servo.h>
#include <Stream.h>
#include <Wire.h>
Servo myservo;  // create servo object to control a servo

#define SENSORPIN 4

int pos =0; // variable to store the servo position
const int buttonPin = 2;  // the number of the pushbutton pin
bool isLocked = false;
long pressedDown;

/*void setup() {
  // put your setup code here, to run once:
  pinMode(buttonPin, INPUT);
  pinMode(SENSORPIN, INPUT);     
  digitalWrite(SENSORPIN, HIGH); // turn on the pullup
  myservo.attach(8);  // attaches the servo on pin 8 to the servo object
  myservo.write(pos);   
  Serial.setTimeout(20);
  Serial.begin(9600);
  //use pins A4 & A5
  Wire.begin();        // join i2c bus (address optional for master)
}

void loop() {
  // put your main code here, to run repeatedly:
  CheckForSerialCom();
  CheckForSlaveCom();
  DetectBicycle();
}*/
