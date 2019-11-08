String messageQR = "";
String* messagePtrQR = &messageQR;
bool messageStateQR = false;

void CheckForSlaveCom() {
  Wire.requestFrom(1, 10);    // request 10 bytes from slave device #1
  while (Wire.available())
  {
    char readChar = (char)Wire.read();
    if (readChar == '@')
    {
      messageStateQR = true;
    }
    else if (readChar == '&')
    {
      messageStateQR = false;
      Serial.println(*messagePtrQR);
      *messagePtrQR = "";
    }
    else if (messageStateQR == true)
    {
      *messagePtrQR += readChar;
    }
  }
}
