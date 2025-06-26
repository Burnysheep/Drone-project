//HMC setup
void HMC_setup(void) {
  // Khởi tạo HMC5883L
  Wire.beginTransmission(HMC5883L_ADDR);
  Wire.write(0x00);
  Wire.write(0x78);  // 75Hz
  Wire.write(0x20);  // Gain = ±1.3 Gauss
  Wire.write(0x00);
  Wire.endTransmission();
}

//Đọc HMC
void HMC_signals(void) {
  Wire.beginTransmission(HMC5883L_ADDR);
  Wire.write(0x03);  // Bắt đầu đọc từ thanh ghi X MSB
  Wire.endTransmission();
  Wire.requestFrom(HMC5883L_ADDR, 6);  // Đọc 6 byte (X, Z, Y)

  Mag_rawX = (Wire.read() << 8) | Wire.read();
  Mag_rawZ = (Wire.read() << 8) | Wire.read();
  Mag_rawY = (Wire.read() << 8) | Wire.read();
}