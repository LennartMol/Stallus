#include <Servo.h>
Servo myservo;  // create servo object to control a servo


int pos = 0;    // variable to store the servo position

void setup() {
  // put your setup code here, to run once:4

  myservo.attach(8);  // attaches the servo on pin 9 to the servo object
  Serial.setTimeout(20);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
servoLock();
servoUnLock();
}
