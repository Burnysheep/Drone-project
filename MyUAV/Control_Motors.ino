void Motor_Setup(void) {
  // Khởi tạo các động cơ (PWM từ 1000 đến 2000 là khoảng ESC nhận)
  motor1.attach(motorPin1, 1000, 2000);
  motor2.attach(motorPin2, 1000, 2000);
  motor3.attach(motorPin3, 1000, 2000);
  motor4.attach(motorPin4, 1000, 2000);

  // Khởi động động cơ với giá trị thấp nhất (ngăn ESC khỏi kích hoạt failsafe)
  motor1.writeMicroseconds(1000);
  motor2.writeMicroseconds(1000);
  motor3.writeMicroseconds(1000);
  motor4.writeMicroseconds(1000);

  delay(2000); // Chờ ESC khởi động
}

void Motor_Control(void) {
  RateOutputs rateOutputs = PID_angle();
  PWMoutputs outPWMs = PID_Omega(rateOutputs);

  // Serial.print("1: ");
  // Serial.print(outPWMs.motorInput1);
  // Serial.print("\t");
  // Serial.print("2: ");
  // Serial.print(outPWMs.motorInput2);
  // Serial.print("\t");
  // Serial.print("3: ");
  // Serial.print(outPWMs.motorInput3);
  // Serial.print("\t");
  // Serial.print("4: ");
  // Serial.print(outPWMs.motorInput4);
  // Serial.println();

  motor1.writeMicroseconds(outPWMs.motorInput1);
  motor2.writeMicroseconds(outPWMs.motorInput2);
  motor3.writeMicroseconds(outPWMs.motorInput3);
  motor4.writeMicroseconds(outPWMs.motorInput4);
}