String message = "";
String* messagePtr = &message;
bool messageState = false;

void CheckForSerialCom() {
  if (Serial.available() > 0)
  {
    char readChar = (char)Serial.read();
    if (readChar == '#')
    {
      messageState = true;
    }
    else if (readChar == '%')
    {
      messageState = false;
      MessageHandler(messagePtr);
      *messagePtr = "";
    }
    else if (messageState == true)
    {
      *messagePtr += readChar;
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
