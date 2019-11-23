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
      String userid = (String)(StringToUInt64(messageQR) >> 16);
      String key = (String)(StringToUInt64(messageQR) & 0b01111111111111111);
      Serial.println("#DB_USER_UNLOCKED:" + key + "/" + userid + "%");
      messageQR = "";
    }
    else if (messageStateQR == true)
    {
      messageQR += readChar;
    }
  }
}

uint32_t StringToUInt64(String stringToConvert) {
  uint32_t returnValue = 0;
  for (int i = 0; i < stringToConvert.length(); i++) {
     returnValue = returnValue * 10;
     returnValue = returnValue + stringToConvert[i] - '0';
  }
  return returnValue;
}
