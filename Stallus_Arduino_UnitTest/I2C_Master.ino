String messageQR = "";
bool messageStateQR = false;

void CheckForSlaveCom() {
  Wire.requestFrom(1, 10);    // request 10 bytes from slave device #1
  while (Wire.available())
  {
    char readChar = (char)Wire.read();
    if (readChar == '#')
    {
      messageStateQR = true;
    }
    else if (readChar == '%')
    {
      messageStateQR = false;
      Serial.println(messageQR);
      //Serial.write(messageQR);
      messageQR = "";
    }
    else if (messageStateQR == true)
    {
      messageQR += readChar;
    }
  }
}
