// Khởi động MS5611 & đọc hệ số hiệu chỉnh từ PROM
void MS_setup() {
  Wire.beginTransmission(MS5611_ADDR);
  Wire.write(0x1E); // Reset cảm biến
  Wire.endTransmission();
  delay(10);

  for (uint8_t i = 0; i < 6; i++) {
    Wire.beginTransmission(MS5611_ADDR);
    Wire.write(0xA2 + (i * 2));
    Wire.endTransmission();
    Wire.requestFrom(MS5611_ADDR, 2);
    C[i] = (Wire.read() << 8) | Wire.read();
  }

  // Bắt đầu đo áp suất
  Wire.beginTransmission(MS5611_ADDR);
  Wire.write(OSR_CMD_PRESSURE);
  Wire.endTransmission();
  lastConversionTime = micros();
}

uint32_t MS5611_readADC() {
  Wire.beginTransmission(MS5611_ADDR);
  Wire.write(0x00);
  Wire.endTransmission();
  Wire.requestFrom(MS5611_ADDR, 3);
  return ((uint32_t)Wire.read() << 16) | ((uint32_t)Wire.read() << 8) | Wire.read();
}

// Đọc dữ liệu từ cảm biến theo vòng lặp 4ms
void MS_signals() {
  if ((micros() - lastConversionTime) >= conversionDelay) {  // Kiểm tra nếu đủ 8ms
    if (readingPressure) {
      D1 = MS5611_readADC();  // Đọc giá trị áp suất
      Wire.beginTransmission(MS5611_ADDR);
      Wire.write(OSR_CMD_TEMPERATURE);
      Wire.endTransmission();

      // Chỉ tính toán khi cả D1 và D2 đều có giá trị hợp lệ
      if (D2 != 0) {
        int32_t dT = D2 - ((int32_t)C[4] << 8);
        int32_t TEMP = 2000 + ((int64_t)dT * C[5]) / 8388608;
        int64_t OFF = ((int64_t)C[1] << 16) + (((int64_t)C[3] * dT) >> 7);
        int64_t SENS = ((int64_t)C[0] << 15) + (((int64_t)C[2] * dT) >> 8);
        int32_t P = (((D1 * SENS) >> 21) - OFF) >> 15;

        temperature_MS = TEMP / 100.0;
        // actual_pressure_fast = P / 100.0;

        pressure_total_average -= pressure_rotating_mem[pressure_rotating_mem_location]; 
        pressure_rotating_mem[pressure_rotating_mem_location] = P;
        pressure_total_average += pressure_rotating_mem[pressure_rotating_mem_location];
        pressure_rotating_mem_location++;
        if (pressure_rotating_mem_location == 20) pressure_rotating_mem_location = 0;
        actual_pressure_fast = (float)pressure_total_average / 20.0;

        // Áp dụng bộ lọc bổ trợ
        actual_pressure_slow = actual_pressure_slow * 0.985 + actual_pressure_fast * 0.015;
        actual_pressure_diff = actual_pressure_slow - actual_pressure_fast;
        if (actual_pressure_diff > 8) actual_pressure_diff = 8;
        if (actual_pressure_diff < -8) actual_pressure_diff = -8;
        if (actual_pressure_diff > 1 || actual_pressure_diff < -1) actual_pressure_slow -= actual_pressure_diff / 6.0;
        pressure = actual_pressure_slow;
        
        // Tính toán độ cao từ áp suất đã lọc
        // altitude = 44330.0 * (1.0 - pow(pressure / 1013.25, 1/5.255)) * 100;
        dataReady = true;
      }
    } else {
      D2 = MS5611_readADC();  // Đọc giá trị nhiệt độ
      Wire.beginTransmission(MS5611_ADDR);
      Wire.write(OSR_CMD_PRESSURE);
      Wire.endTransmission();
    }

    lastConversionTime = micros();
    readingPressure = !readingPressure;  // Chuyển đổi giữa đo áp suất và nhiệt độ
  }
}