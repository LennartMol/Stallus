int currentState = 0;
int previousState = 0;
long wait = 30000;

void DetectBicycle()
{
  currentState = digitalRead(SENSORPIN);
  if(currentState == HIGH){
  }
  if (currentState != previousState && digitalRead(SENSORPIN) == LOW) { // bycicle present
    pressedDown = millis();
  }
  if (digitalRead(SENSORPIN) == LOW && millis() % 2000 == 0) {
    Serial.println("#ARD_DISCONNECTED%");
  }
  if (currentState == previousState && digitalRead(SENSORPIN) == HIGH) { // no bycicle avedeble
    pressedDown = millis();
  }
  if ((millis() - pressedDown) > wait) {
    TakeAction();
  }
  previousState = currentState;
}

void TakeAction() {
  if (isLocked == false)
  {
    Serial.println("#DB_BIKE_AUTOLOCKED:1%");
    servoLock();
  }
}
