int previousState = 0;

void DetectBicycleAvailable_TimeExpired()
{
  const long wait = 30000;
  int currentState = digitalRead(SENSORPIN);
  
  if (currentState != previousState && digitalRead(SENSORPIN) == LOW) { // bycicle present
    timeAvailable = millis();
  }
  if (digitalRead(SENSORPIN) == LOW && isLocked == false && millis() % 1000 <= 1) {
    sendMessageToServer("#DB_STAND_DISCONNECTED:1%");
  }
  if (currentState == previousState && digitalRead(SENSORPIN) == HIGH) { // no bycicle available
    timeAvailable = millis();
  }
  if ((millis() - timeAvailable) > wait) {
    LockBicycle();
  }
  previousState = currentState;
}

void LockBicycle() {
  if (isLocked == false)
  {
    sendMessageToServer("#DB_BIKE_AUTOLOCKED:1%");
    servoLock();
  }
}
