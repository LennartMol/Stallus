#include <SoftwareSerial.h>

SoftwareSerial mySerial(2, 3); // RX, TX

char mystr[8] = "12345678"; //String data

void setup() {
  // Begin the Serial at 9600 Baud
  Serial.begin(9600);
  mySerial.begin(9600);
  Serial.println("Hello, world?");
}

void loop() {
  Serial.println(mystr); //Write the serial data
  delay(1000);
}
