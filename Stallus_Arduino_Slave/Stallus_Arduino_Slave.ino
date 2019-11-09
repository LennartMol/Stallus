#include <Wire.h>

void setup() {
  Serial.begin(9600);
  Serial.setTimeout(20);
  Wire.begin(1);                // join i2c bus with address #1
  Wire.onRequest(requestEvent); // register event
}

void loop() {
  // put your main code here, to run repeatedly:
  // CheckForSerialCom();
}

void requestEvent(){
  CheckForSerialCom();
}
