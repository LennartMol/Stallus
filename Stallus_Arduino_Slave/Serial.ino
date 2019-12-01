String message = "";
bool messageState = false;

void CheckForSerialCom() {
  if (Serial.available() > 0)
  {
    char readChar = (char)Serial.read();
    if (readChar == '#')
    {
      message += readChar;
      messageState = true;
    }
    else if (readChar == '%')
    {
      message += readChar;
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

void MessageHandler(String command) {
  Serial.println(command);
  char sendLine[command.length()];
  command.toCharArray(sendLine, command.length()+1);
  for(int x = 0; x < command.length(); x++){
    Serial.print(sendLine[x]);
    //Wire.write(sendLine[x]);
  }
  Serial.println("");
  Wire.write(sendLine);
}
