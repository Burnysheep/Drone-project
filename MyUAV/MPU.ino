//MPU setup
void MPU_setup(void) {
  Wire.setClock(400000);
  Wire.begin();
  delay(250);

  Wire.beginTransmission(MPU6050_ADDR);
  Wire.write(0x6B);
  Wire.write(0x80);  
  Wire.endTransmission();
  delay(100);

  Wire.beginTransmission(MPU6050_ADDR);
  Wire.write(0x6B);
  Wire.write(0x00);
  Wire.endTransmission();

  Wire.beginTransmission(MPU6050_ADDR);
  Wire.write(0x1B);
  Wire.write(0x08);
  Wire.endTransmission();

  Wire.beginTransmission(MPU6050_ADDR);
  Wire.write(0x1C);
  Wire.write(0x10);
  Wire.endTransmission();
  
  Wire.beginTransmission(MPU6050_ADDR);
  Wire.write(0x1A);
  Wire.write(0x05);
  Wire.endTransmission();

  Wire.beginTransmission(MPU6050_ADDR);
  Wire.write(0x37);
  Wire.write(0x02);
  Wire.endTransmission();

  Wire.beginTransmission(MPU6050_ADDR);
  Wire.write(0x6A);
  Wire.write(0x00);
  Wire.endTransmission();
}

//Đọc MPU
void MPU_signals(void) 
{
  Wire.beginTransmission(MPU6050_ADDR);
  Wire.write(0x3B);
  Wire.endTransmission();
  Wire.requestFrom(MPU6050_ADDR, 14);

  Acc_rawX = Wire.read() << 8 | Wire.read();
  Acc_rawY = Wire.read() << 8 | Wire.read();
  Acc_rawZ = Wire.read() << 8 | Wire.read();

  temperature = Wire.read() << 8 | Wire.read();

  Gyr_rawX = Wire.read() << 8 | Wire.read();
  Gyr_rawY = Wire.read() << 8 | Wire.read();
  Gyr_rawZ = Wire.read() << 8 | Wire.read();

  RateRoll = (float)Gyr_rawX/65.5;
  RatePitch = (float)Gyr_rawY/65.5;
  RateYaw = (float)Gyr_rawZ/65.5;

  AccX = (float)Acc_rawX/4096 - 0.01;
  AccY = (float)Acc_rawY/4096 + 0.02;
  AccZ = (float)Acc_rawZ/4096 - 0.14;

  AngleRoll = atan2(AccY, sqrt(pow(AccX, 2) + pow(AccZ, 2))) * rad_to_deg;
  AnglePitch = atan2(-1 * AccX, sqrt(pow(AccY, 2) + pow(AccZ, 2))) * rad_to_deg;

  // Serial.print("Acc x: ");
  // Serial.print(AccX);
  // Serial.print("\t");
  // Serial.print("Acc y: ");
  // Serial.print(AccY);
  // Serial.print("\t");
  // Serial.print("Acc z: ");
  // Serial.print(AccZ);
  // Serial.println();
}