bool messageState = false;
String message = "";

void setup() {
  Serial.begin(9600);

}

void loop() {
  CheckForSerialCom();
}

void CheckForSerialCom() {
  if (Serial.available() > 0)
  {
    char readChar = (char)Serial.read();
    if (readChar == '@')
    {
      messageState = true;
    }
    else if (readChar == '&')
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

void MessageHandler(String command) {
  Serial.println(command);
  uint64_t command_uint64 = StringToUInt64(command);
  uint8_t user_id = command_uint64 >> 33;
  uint8_t D,M,Y,h,m,s;
  GetTimeSettingsFromUInt64(command_uint64, &h, &m, &s);
  GetDateSettingsFromUInt64(command_uint64, &D, &M, &Y);
  String dateSetting = UIntToStringCorrection(D) + "/" + UIntToStringCorrection(M) + "/" + (String)(Y+2000);
  String timeSetting = UIntToStringCorrection(h) + ":" + UIntToStringCorrection(m) + ":" + UIntToStringCorrection(s);
  PrintDecodedCommand((String)user_id, dateSetting, timeSetting);
}

String UIntToStringCorrection(uint8_t value) {
  if (value < 10) {
    return "0" + (String)value;
  }
  return (String)value;
}

uint64_t StringToUInt64(String stringToConvert) {
  uint64_t returnValue = 0;
  for (int i = 0; i < stringToConvert.length(); i++) {
     returnValue = returnValue * 10;
     returnValue = returnValue + stringToConvert[i] - '0';
  }
  return returnValue;
}

void GetTimeSettingsFromUInt64(uint64_t bits, uint8_t* hoursPtr, uint8_t* minutesPtr, uint8_t* secondsPtr) {
  if (hoursPtr == NULL || minutesPtr == NULL || secondsPtr == NULL) {
    return;
  }
  *hoursPtr = (bits & 0b11111000000000000) >> 12;
  *minutesPtr = (bits & 0b111111000000) >> 6;
  *secondsPtr = (bits & 0b111111);
}

void GetDateSettingsFromUInt64(uint64_t bits, uint8_t* dayPtr, uint8_t* monthPtr, uint8_t* yearPtr) {
  if (dayPtr == NULL || monthPtr == NULL || yearPtr == NULL) {
    return;
  }
  uint64_t temp = bits >> 17;
  *dayPtr = (temp & 0b1111100000000000) >> 11;
  *monthPtr = (temp & 0b11110000000) >> 7;
  *yearPtr = temp & 0b111111;
}

void PrintDecodedCommand(String userId, String dateSetting, String timeSetting) {
  Serial.println("#USER_ID:" + userId + ";DATE:" + dateSetting + ";TIME:" + timeSetting + "%");
}
