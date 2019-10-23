void DetectBicycle()
{
  // read the state of the pushbutton value:
  buttonState = digitalRead(buttonPin);

  // check if the pushbutton is pressed. If it is, the buttonState is HIGH:
  if (buttonState == HIGH)
  {
    Serial.println("HIGH");

  } else
  {
    Serial.println("LOW");
  }
}
