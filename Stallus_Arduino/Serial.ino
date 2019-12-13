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
  sendMessageToServer(message);
  if (message == "unlockBicycleStand")
  {
    servoUnLock();
    sendMessageToServer("bicycleIsUnlocked");
  }
  if (message == "lockBicycleStand")
  {
    servoLock();
    sendMessageToServer("bicycleIslocked");
  }
}

void sendMessageToServer(String message){
  Serial.println(message);
}
