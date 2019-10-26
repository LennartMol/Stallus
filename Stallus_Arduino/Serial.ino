String message = "";
String* messagePtr = &message;
byte bytes = 0b0;
byte* bytesPtr = &bytes;
bool messageState = false;
bool bytesState = false;

void CheckForSerialCom() {
  if (Serial.available() > 0)
  {
    char readChar = (char)Serial.read();
    if (readChar == '#')
    {
      messageState = true;
    }
    else if (readChar == '@') {
      bytesState = true;
    }
    else if (readChar == '%')
    {
      messageState = false;
      MessageHandler(messagePtr);
      *messagePtr = "";
    }
    else if (readChar == '&') {
      bytesState = false;
      BytesHandler(bytesPtr);
      *bytesPtr = 0b0;
    }
    else if (messageState == true)
    {
      *messagePtr += readChar;
    }
    else if (bytesState == true) {
      *bytesPtr += readBit;
    }
  }  
}

void MessageHandler(String* messagePtr) {
  Serial.println(*messagePtr);
  if (*messagePtr == "unlockBicycleStand")
  {
    servoUnLock();
    Serial.println("bicycleIsUnlocked");
  }
  if (*messagePtr == "lockBicycleStand")
  {
    servoLock();
    Serial.println("bicycleIslocked");
  }
}

void BytesHandler(byte* bytesPtr) {
  Serial.println(*bytesPtr);
}
