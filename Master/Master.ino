#include <Wire.h>
String message = "";
String* messagePtr = &message;
bool messageState = false;

void setup() {
  Wire.begin();        // join i2c bus (address optional for master)
  Serial.begin(9600);  // start serial for output
}

void loop() {
  Wire.requestFrom(8, 7);    // request 6 bytes from slave device #8

  while (Wire.available()) { // slave may send less than requested
    char readChar = (char)Wire.read();
    if (readChar == '#')
    {
      messageState = true;
    }
    else if (readChar == '%')
    {
      messageState = false;
      Serial.println(*messagePtr);
      //MessageHandler(messagePtr);
      *messagePtr = "";
    }
    else if (messageState == true)
    {
      *messagePtr += readChar;
    }
  }

  delay(500);
}
