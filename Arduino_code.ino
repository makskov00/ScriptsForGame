#include<Uduino.h>
Uduino uduino("EMGMuscleSensor"); // Declare and name your object

void setup()
{
  Serial.begin(9600);

#if defined (__AVR_ATmega32U4__) // Leonardo (arduino board)
  while (!Serial) {}
#elif defined(__PIC32MX__)
  delay(1000);
#endif

  uduino.addCommand("r", ReadAnalogPin);
}

  void ReadAnalogPin() {
  int pinToRead = -1;
  char *arg = NULL;
  arg = uduino.next();
  if (arg != NULL)
  {
    pinToRead = atoi(arg);
    if (pinToRead != -1)
      printValue(pinToRead, analogRead(pinToRead));
  }
}
void printValue(int pin, int targetValue) {
  uduino.print(pin);
  uduino.print(" "); 
  uduino.println(targetValue);
  
}
void loop()
{
  uduino.update();
  delay(10);
}
