String message = "";
String* messagePtr = &message;
bool messageState = false;

void CheckForSerialCom() {
  if (Serial.available() > 0)
  {
    char readChar = (char)Serial.read();
    if (readChar == '#')
    {
      *messagePtr += readChar;
      messageState = true;
    }
    else if (readChar == '%')
    {
      *messagePtr += readChar;
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
  char sendLine[10];
  message.toCharArray(sendLine, 11);
  for(int x = 0; x < 10; x++){
    Serial.print(sendLine[x]);
  }
  Serial.println("");
  Wire.write(sendLine);
}
