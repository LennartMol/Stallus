void servoLock()
{
  myservo.attach(8);
  for (pos = 0; pos < 180; pos += 2) { // goes from 0 degrees to 180 degrees
    // in steps of 2 degree
    myservo.write(pos);                 // tell servo to go to position in variable 'pos'
    delay(15);
  }
  isLocked = true;
  myservo.detach();
}

void servoUnLock()
{
  myservo.attach(8);
  for (pos = 180; pos > 0; pos -= 2) { // goes from 180 degrees to 0 degrees
    myservo.write(pos);                 // tell servo to go to position in variable 'pos'
    delay(15);    
  }
  isLocked = false;
  pressedDown = millis();
  myservo.detach();
}
