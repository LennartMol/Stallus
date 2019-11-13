String message = "";
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
      MessageHandler(message);
      message = "";
    }
    else if (messageState == true)
    {
      message += readChar;
    }
  }  
}

void MessageHandler(String message) {
  Serial.println(message);
  if (message == "unlockBicycleStand")
  {
    servoUnLock();
    Serial.println("bicycleIsUnlocked%");
  }
  if (message == "lockBicycleStand")
  {
    servoLock();
    Serial.println("bicycleIslocked%");
  }
}
