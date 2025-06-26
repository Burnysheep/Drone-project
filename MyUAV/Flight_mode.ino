void flightModeSignals(void) {
  flight_pre_mode = flight_mode;
  // Mode 1 = Bay tự do, Mode 2 = Giữ độ cao, Mode 3 = GPS + giữ độ cao
  if (channels[6] > 1400) flight_mode = 3;  //191 - 997 - 1792
  else if (channels[6] > 500 && channels[6] < 1400) flight_mode = 2;
  else flight_mode = 1;

  // Serial.print(flight_mode);
  // Serial.print("\t");
  // Serial.print(flight_pre_mode);
  // Serial.println();
}

void setpoint_Calculate(void) {
  if ((flight_mode == 2 && flight_pre_mode == 1) || (flight_mode == 2 && flight_pre_mode == 3)) altitude_sp = pressure;

  if ((flight_mode == 3 && flight_pre_mode == 2) && flight_waypoint == false) {
    latitude_sp = latitude;
    longitude_sp = longitude;
  }
  else if (flight_mode == 3 && flight_waypoint == true) {
    latitude_sp = gpsPositions[1];
    longitude_sp = gpsPositions[2];

    flight_waypoint = false;
  }
  
  if (flight_mode < 3) {
    angle_Roll_sp  = -(100 * (channels[0] - 992.5)) / 1637;
    if (angle_Roll_sp < 0.5 && angle_Roll_sp > -0.5) angle_Roll_sp = 0;

    angle_Pitch_sp = -(100 * (channels[1] - 992.5)) / 1637;
    if (angle_Pitch_sp < 0.5 && angle_Pitch_sp > -0.5) angle_Pitch_sp = 0;
  } else if (flight_mode == 3) {
    roll_value  = -(100 * (channels[0] - 992.5)) / 1637;
    if (roll_value < 0.5 && roll_value > -0.5) roll_value = 0;
    angle_Roll_sp = -gps_roll_adjust + roll_value;

    pitch_value = -(100 * (channels[1] - 992.5)) / 1637;
    if (pitch_value < 0.5 && pitch_value > -0.5) pitch_value = 0;
    angle_Pitch_sp = -gps_pitch_adjust + pitch_value;
  }

  if(flight_mode == 1) InputThrottle = 1500 + (200 * (channels[2] - 1401.5) / 273);
  else if (flight_mode >= 2) {
    rawThrottle = 1500 + altitude_U + (200 * (channels[2] - 1401.5) / 273);
    angle_rad = sqrt(KalmanAngleRoll * KalmanAngleRoll + KalmanAnglePitch * KalmanAnglePitch) * deg_to_rad;
    sin_a2 = sin(angle_rad) * sin(angle_rad);
    k_bu = 0.8;
    throttle_correction = 1.0 + k_bu * sin_a2;
    if (throttle_correction > 1.4) throttle_correction = 1.4;
    InputThrottle = rawThrottle * throttle_correction;
  }

  angle_Yaw_hand = -(100 * (channels[3] - 992.5)) / 1637;
  if (angle_Yaw_hand < 0.5 && angle_Yaw_hand > -0.5) angle_Yaw_hand = 0;
  angle_Yaw_sp += angle_Yaw_hand * 0.008;

  if (angle_Yaw_sp < 0) angle_Yaw_sp += 360;
  else if (angle_Yaw_sp >= 360) angle_Yaw_sp -= 360;
}