void servoLock()
{
  bikeLock.attach(SERVOPIN);
  for (pos = 0; pos <= 180; pos += 2) { // goes from 0 degrees to 180 degrees
    // in steps of 2 degree
    bikeLock.write(pos);                 // tell servo to go to position in variable 'pos'
    delay(15);
  }
  isLocked = true;
  bikeLock.detach();
}

void servoUnLock()
{
  bikeLock.attach(SERVOPIN);
  for (pos = 180; pos >= 0; pos -= 2) { // goes from 180 degrees to 0 degrees
    bikeLock.write(pos);                 // tell servo to go to position in variable 'pos'
    delay(15);    
  }
  isLocked = false;
  timeAvailable = millis();
  bikeLock.detach();
}
