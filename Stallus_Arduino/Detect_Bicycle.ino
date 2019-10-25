//const int bounceTime = 300;
//unsigned long lastBounceTime = 0;
//bool bicycleOnStand = false;
//unsigned long moment = 0;
int currentState = 0;
int previousState = 0;
long pressedDown;
long wait = 5000;

void DetectBicycle()
{
  currentState = digitalRead(buttonPin);
  if(currentState != previousState && digitalRead(buttonPin) == HIGH){
    Serial.println("down");
    pressedDown = millis();
  }
  
  if(currentState == previousState && digitalRead(buttonPin) == LOW){
    Serial.println("up");
    pressedDown = millis();
  }
  
  if((millis() - pressedDown) > wait){
    TakeAction();
  }
  previousState = currentState;
  Serial.println(millis() - pressedDown);
}

void TakeAction() {
  Serial.println("close");
  servoLock();
}
