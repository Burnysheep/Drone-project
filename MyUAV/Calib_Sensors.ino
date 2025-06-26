void kalman_1d(float KalmanState, float KalmanUncertainty, float KalmanInput, float KalmanMeasurement) {
  KalmanState = KalmanState+0.004*KalmanInput;
  KalmanUncertainty = KalmanUncertainty + 0.004 * 0.004 * 4 * 4;
  float KalmanGain = KalmanUncertainty * 1/ (1*KalmanUncertainty + 3 * 3);
  KalmanState = KalmanState + KalmanGain * (KalmanMeasurement - KalmanState);
  KalmanUncertainty = (1 - KalmanGain) * KalmanUncertainty;
  Kalman1DOutput[0] = KalmanState; 
  Kalman1DOutput[1] = KalmanUncertainty;
}

void Calib_sensors(void) {
  for (RateCalibrationNumber=0; RateCalibrationNumber<5000; RateCalibrationNumber++) {
    MPU_signals();
    RateCalibrationangle_Roll += RateRoll;
    RateCalibrationangle_Pitch += RatePitch;
    RateCalibrationangle_Yaw += RateYaw;
    // MS_signals();
    // if (dataReady) {
    //   CalibrationAltitude += altitude;
    //   CalibrationAltitudeCounter++;
    // }
    delay(1);
  }

  RateCalibrationangle_Roll /= 5000;
  RateCalibrationangle_Pitch /= 5000;
  RateCalibrationangle_Yaw /= 5000;
  // CalibrationAltitude /= CalibrationAltitudeCounter;
}

void calib_HMC5883L(void) {
  while (channels[4] > 1400) {
    HMC_signals();

    if (Mag_rawX < minX) minX = Mag_rawX;
    if (Mag_rawX > maxX) maxX = Mag_rawX;
    if (Mag_rawY < minY) minY = Mag_rawY;
    if (Mag_rawY > maxY) maxY = Mag_rawY;
    
    offsetX = (maxX + minX) / 2;
    offsetY = (maxY + minY) / 2;

    Filter_HMC_sensors();
    angle_Yaw_sp = AngleYaw;
  }
}

void Filter_MPU_sensors(void) {
  RateRoll -= RateCalibrationangle_Roll;
  RatePitch -= RateCalibrationangle_Pitch;
  RateYaw -= RateCalibrationangle_Yaw;

  kalman_1d(KalmanAngleRoll, KalmanUncertaintyAngleRoll, RateRoll, AngleRoll);
  KalmanAngleRoll = Kalman1DOutput[0];
  KalmanUncertaintyAngleRoll = Kalman1DOutput[1];
  kalman_1d(KalmanAnglePitch, KalmanUncertaintyAnglePitch, RatePitch, AnglePitch);
  KalmanAnglePitch = Kalman1DOutput[0];
  KalmanUncertaintyAnglePitch = Kalman1DOutput[1];
}

void Filter_HMC_sensors(void) {
  Mag_rawX -= offsetX;
  Mag_rawY -= offsetY;

  magX_comp = Mag_rawX * cos(KalmanAnglePitch * deg_to_rad) + Mag_rawZ * sin(KalmanAnglePitch * deg_to_rad);
  magY_comp = Mag_rawX * sin(KalmanAngleRoll * deg_to_rad) * sin(KalmanAnglePitch * deg_to_rad) + Mag_rawY * cos(KalmanAngleRoll * deg_to_rad) - Mag_rawZ * sin(KalmanAngleRoll * deg_to_rad) * cos(KalmanAnglePitch * deg_to_rad);

  heading = atan2(-magY_comp, magX_comp) * rad_to_deg;
  if (heading < 0) heading += 360;
  
  AngleYaw = 0.95 * (AngleYaw + RateYaw * 0.004) + 0.05 * heading;
}

void Filter_MS_sensors(void) {
  if (dataReady) {
    // altitude -= CalibrationAltitude;

    pressure_diff_total -= pressure_buffer[buffer_index];
    pressure_buffer[buffer_index] = pressure * 10 - pressure_prev;
    pressure_diff_total += pressure_buffer[buffer_index];
    pressure_prev = pressure * 10;
    buffer_index++;
    if (buffer_index == BUFFER_SIZE) buffer_index = 0;

    altitude_PID = true;
    dataReady = false;
  }
}