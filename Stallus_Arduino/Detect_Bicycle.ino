int currentState = 0;
int previousState = 0;
long wait = 5000;

void DetectBicycle()
{
  currentState = digitalRead(SENSORPIN);
  if(currentState == HIGH){
  }
  if (currentState != previousState && digitalRead(SENSORPIN) == LOW) { // bycicle present
    pressedDown = millis();
  }
  if (currentState == previousState && digitalRead(SENSORPIN) == HIGH) { // no bycicle avedeble
    //Serial.println("up");
    pressedDown = millis();
  }
  if ((millis() - pressedDown) > wait) {
    TakeAction();
  }
  previousState = currentState;
}

void TakeAction() {
  Serial.println("close%");
  if (isLocked == false)
  {
    servoLock();
  }
}
