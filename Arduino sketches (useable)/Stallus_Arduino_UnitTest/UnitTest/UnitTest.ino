#line 2 "sketch.ino"
#include <ArduinoUnit.h>

test(ok)
{
  int x = 3;
  int y = 3;
  assertEqual(x, y);
}

test(bad)
{
  int x = 3;
  int y = 3;
  assertNotEqual(x, y);
}
test(ServoLock)
{
  servoLock();
  assertEqual(pos, 180);
}
test(ServoUnLock)
{
  servoUnLock();
  assertEqual(pos, 0);
}

void setup()
{
  Serial.begin(9600);
  while (!Serial) {} // Portability for Leonardo/Micro
}

void loop()
{
  Test::run();
}
