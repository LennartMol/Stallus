void servoLock()
{
  myservo.attach(8);
  Serial.print("Verified ID:");
  for (pos = 0; pos <= 90; pos += 1) { // goes from 0 degrees to 180 degrees
    // in steps of 1 degree
    myservo.write(pos);              // tell servo to go to position in variable 'pos'
    delay(15);
    myservo.detach();
  }
}
void servoUnLock()
{
  myservo.attach(8);
  for (pos = 90; pos >= 0; pos -= 1) { // goes from 180 degrees to 0 degrees
    myservo.write(pos);              // tell servo to go to position in variable 'pos'
    delay(15);
    myservo.detach();
  }
}
