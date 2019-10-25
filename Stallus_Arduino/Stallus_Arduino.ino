#include <Servo.h>
Servo myservo;  // create servo object to control a servo


int pos = 0;    // variable to store the servo position
const int buttonPin = 2;     // the number of the pushbutton pin
bool isLocked = false;
long pressedDown;

// variables will change:
//int buttonState = 0;         // variable for reading the pushbutton status

void setup() {
  // put your setup code here, to run once:4
  pinMode(buttonPin, INPUT);
  myservo.attach(8);  // attaches the servo on pin 8 to the servo object
  Serial.setTimeout(20);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  CheckForSerialCom();
  DetectBicycle();
}
