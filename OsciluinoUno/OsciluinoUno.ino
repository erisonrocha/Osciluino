int analogPin = 0;
unsigned long tempo;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
}

void loop() {

  if (Serial.available() > 0) {
    Serial.read();

    tempo = millis();
    // put your main code here, to run repeatedly:
    int valor = analogRead(analogPin);
    // byte data = (valor >> 2);
    // Serial.write(data);
    Serial.print("x");
    Serial.print(tempo);
    Serial.print("y");
    Serial.print(valor);
    Serial.print("z");
      
  }

}
