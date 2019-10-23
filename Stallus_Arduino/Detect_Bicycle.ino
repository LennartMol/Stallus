const int bounceTime = 300;
unsigned long lastBounceTime = 0;
bool bicycleOnStand = false;
unsigned long moment = 0;

void DetectBicycle()
{
  if (digitalRead(buttonPin) == true) {
    if ((millis() - lastBounceTime) > bounceTime) {
      lastBounceTime = millis();
      moment = millis() + 5000;
      TakeAction();
    }
  }
}

void TakeAction() {
  while (true) {
    if (millis() > moment && !bicycleOnStand) {
      bicycleOnStand = true;
      Serial.println("#BICYCLE_ONLOCK%");
    }    
  }
}
