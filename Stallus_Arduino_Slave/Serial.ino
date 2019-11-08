String message = "";
String* messagePtr = &message;
bool messageState = false;

//The code to read the QR-scanner
void CheckForSerialCom() {
  if (Serial.available() > 0)
  {
    char readChar = (char)Serial.read();
    if (readChar == '@')
    {
      *messagePtr += readChar;
      messageState = true;
    }
    else if (readChar == '&')
    {
      *messagePtr += readChar;
      messageState = false;
      char sendLine[10];
      message.toCharArray(sendLine, 10);
      Wire.write(sendLine);  
      *messagePtr = "";
    }
    else if (messageState == true)
    {
      *messagePtr += readChar;
    }
  }  
}
