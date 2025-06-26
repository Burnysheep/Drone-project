RateOutputs PID_angle(void) {
  RateOutputs outputs;
  
  angle_Roll_e = angle_Roll_sp - KalmanAngleRoll;
  angle_Pitch_e = angle_Pitch_sp - KalmanAnglePitch;
  angle_Yaw_e = fmod(angle_Yaw_sp - AngleYaw + 540, 360) - 180;
  
  // angle_Roll_e = 0;
  // angle_Pitch_e = 0;
  // angle_Yaw_e = 0;

  angle_Roll_P = angle_Roll_kp * angle_Roll_e; 
  angle_Roll_I = angle_Roll_pre_I + angle_Roll_ki * (angle_Roll_e + angle_Roll_pre_e) * 0.002;
  if (angle_Roll_I > 400) angle_Roll_I = 400;
  else if (angle_Roll_I < -400) angle_Roll_I = -400;
  angle_Roll_D = angle_Roll_kd * (angle_Roll_e - angle_Roll_pre_e) / 0.004;
  outputs.angle_Roll_u = angle_Roll_P + angle_Roll_I + angle_Roll_D;
  
  outputs.angle_Roll_u = constrain(outputs.angle_Roll_u, -400, 400);

  angle_Pitch_P = angle_Pitch_kp * angle_Pitch_e; 
  angle_Pitch_I = angle_Pitch_pre_I + angle_Pitch_ki * (angle_Pitch_e + angle_Pitch_pre_e) * 0.002;
  if (angle_Pitch_I > 400) angle_Pitch_I = 400;
  else if (angle_Pitch_I < -400) angle_Pitch_I = -400;
  angle_Pitch_D = angle_Pitch_kd * (angle_Pitch_e - angle_Pitch_pre_e) / 0.004;
  outputs.angle_Pitch_u = angle_Pitch_P + angle_Pitch_I + angle_Pitch_D;
  
  outputs.angle_Pitch_u  = constrain(outputs.angle_Pitch_u, -400, 400);

  angle_Yaw_P = angle_Yaw_kp * angle_Yaw_e; 
  angle_Yaw_I = angle_Yaw_pre_I + angle_Yaw_ki * (angle_Yaw_e + angle_Yaw_pre_e) * 0.002;
  if (angle_Yaw_I > 400) angle_Yaw_I = 400;
  else if (angle_Yaw_I < -400) angle_Yaw_I = -400;
  angle_Yaw_D = angle_Yaw_kd * (angle_Yaw_e - angle_Yaw_pre_e) / 0.004;
  outputs.angle_Yaw_u = angle_Yaw_P + angle_Yaw_I + angle_Yaw_D;
  
  outputs.angle_Yaw_u  = constrain(outputs.angle_Yaw_u, -400, 400);

  sendAngleData = true;
  angleValues[0] = 1;
  angleValues[1] = altitude_sp;
  // angleValues[0] = latitude;
  // angleValues[1] = longitude;
  // angleValues[1] = angle_Roll_sp;
  // angleValues[2] = angle_Pitch_sp;
  angleValues[2] = gps_pitch_adjust;
  angleValues[3] = angle_Yaw_sp;
  angleValues[4] = pressure;
  // angleValues[4] = KalmanAngleRoll;
  angleValues[5] = gps_roll_adjust;
  angleValues[6] = AngleYaw;

  angle_Roll_pre_I = angle_Roll_I;
  angle_Roll_pre_e = angle_Roll_e;

  angle_Pitch_pre_I = angle_Pitch_I;
  angle_Pitch_pre_e = angle_Pitch_e;

  angle_Yaw_pre_I = angle_Yaw_I;
  angle_Yaw_pre_e = angle_Yaw_e;

  return outputs;
}

PWMoutputs PID_Omega(const RateOutputs &rateOutputs) {
  PWMoutputs outPWMs;

  rate_Roll_e = rateOutputs.angle_Roll_u - RateRoll;
  rate_Pitch_e = rateOutputs.angle_Pitch_u - RatePitch;
  rate_Yaw_e = rateOutputs.angle_Yaw_u - RateYaw;

  // rate_Roll_e = 0;
  // rate_Pitch_e = 0;
  // rate_Yaw_e = 0;

  rate_Roll_P = rate_Roll_kp * rate_Roll_e; 
  rate_Roll_I = rate_Roll_pre_I + rate_Roll_ki * (rate_Roll_e + rate_Roll_pre_e) * 0.002;
  if (rate_Roll_I > 400) rate_Roll_I = 400;
  else if (rate_Roll_I < -400) rate_Roll_I = -400;
  rate_Roll_D = rate_Roll_kd * (rate_Roll_e - rate_Roll_pre_e) / 0.004;
  InputRoll = rate_Roll_P + rate_Roll_I + rate_Roll_D;
  
  InputRoll = constrain(InputRoll, -400, 400);

  rate_Pitch_P = rate_Pitch_kp * rate_Pitch_e; 
  rate_Pitch_I = rate_Pitch_pre_I + rate_Pitch_ki * (rate_Pitch_e + rate_Pitch_pre_e) * 0.002;
  if (rate_Pitch_I > 400) rate_Pitch_I = 400;
  else if (rate_Pitch_I < -400) rate_Pitch_I = -400;
  rate_Pitch_D = rate_Pitch_kd * (rate_Pitch_e - rate_Pitch_pre_e) / 0.004;
  InputPitch = rate_Pitch_P + rate_Pitch_I + rate_Pitch_D;
  
  InputPitch = constrain(InputPitch, -400, 400);

  rate_Yaw_P = rate_Yaw_kp * rate_Yaw_e; 
  rate_Yaw_I = rate_Yaw_pre_I + rate_Yaw_ki * (rate_Yaw_e + rate_Yaw_pre_e) * 0.002;
  if (rate_Yaw_I > 400) rate_Yaw_I = 400;
  else if (rate_Yaw_I < -400) rate_Yaw_I = -400;
  rate_Yaw_D = rate_Yaw_kd * (rate_Yaw_e - rate_Yaw_pre_e) / 0.004;
  InputYaw = (rate_Yaw_P + rate_Yaw_I + rate_Yaw_D);

  InputYaw = constrain(InputYaw, -400, 400);

  sendRateData = true;
  rateValues[0] = 2;
  rateValues[1] = rateOutputs.angle_Roll_u;
  rateValues[2] = rateOutputs.angle_Pitch_u;
  rateValues[3] = rateOutputs.angle_Yaw_u;
  rateValues[4] = RateRoll;
  rateValues[5] = RatePitch;
  rateValues[6] = RateYaw;

  rate_Roll_pre_I = rate_Roll_I;
  rate_Roll_pre_e = rate_Roll_e;

  rate_Pitch_pre_I = rate_Pitch_I;
  rate_Pitch_pre_e = rate_Pitch_e;

  rate_Yaw_pre_I = rate_Yaw_I;
  rate_Yaw_pre_e = rate_Yaw_e;

  if(InputThrottle > 1800) InputThrottle = 1800;

  outPWMs.motorInput1 = 1.024*(InputThrottle - InputRoll - InputPitch - InputYaw);
  outPWMs.motorInput2 = 1.024*(InputThrottle - InputRoll + InputPitch + InputYaw);
  outPWMs.motorInput3 = 1.024*(InputThrottle + InputRoll + InputPitch - InputYaw);
  outPWMs.motorInput4 = 1.024*(InputThrottle + InputRoll - InputPitch + InputYaw);

  outPWMs.motorInput1 = constrain(outPWMs.motorInput1, 1180, 1999);
  outPWMs.motorInput2 = constrain(outPWMs.motorInput2, 1180, 1999);
  outPWMs.motorInput3 = constrain(outPWMs.motorInput3, 1180, 1999);
  outPWMs.motorInput4 = constrain(outPWMs.motorInput4, 1180, 1999);

  if (channels[2] < 995) {
    outPWMs.motorInput1 = 995;
    outPWMs.motorInput2 = 995;
    outPWMs.motorInput3 = 995;
    outPWMs.motorInput4 = 995;
    reset_pid();
  }

  return outPWMs;
}

void PID_altitude(void) {
  if (flight_mode >= 2 && altitude_PID == true) {
    if (altitude_sp == 0) altitude_sp = pressure;
    altitude_e = pressure - altitude_sp;

    float altitude_error_gain = 0;
    if (altitude_e > 10 || altitude_e < -10) {
      altitude_error_gain = (abs(altitude_e) - 10) / 20.0;
      if (altitude_error_gain > 3) altitude_error_gain = 3;
    }

    altitude_I += (altitude_ki / 100) * altitude_e;
    if (altitude_I > 400) altitude_I = 400;
    else if (altitude_I < -400) altitude_I = -400;

    altitude_D = altitude_kd * pressure_diff_total;

    altitude_U = (altitude_kp + altitude_error_gain) * altitude_e + altitude_I + altitude_D;
    altitude_U = constrain(altitude_U, -400, 400);

    altitude_PID = false;
  }
  else if (flight_mode == 1) {
    altitude_e = 0;
    altitude_U = 0;
  }
}

void PID_gps() {
  static double lat_ref = 0, lon_ref = 0;
  static bool ref_set = false;

  if (validGPS) {
    latitude_north = (lat_dir == 'N') ? 1 : 0;
    longiude_east  = (lon_dir == 'E') ? 1 : 0;

    double lat_now = latitude;
    double lon_now = longitude;

    if (!ref_set) {
      lat_ref = lat_now;
      lon_ref = lon_now;
      ref_set = true;
    }

    double lat_err = (lat_now - lat_ref) * 11132000.0; // cm
    double lon_err = (lon_now - lon_ref) * 11132000.0 * cos(lat_ref * deg_to_rad);

    latitude_add  = (lat_now - latitude_pre) * 11132000.0 / 0.1; // cm/s
    longitude_add = (lon_now - longitude_pre) * 11132000.0 * cos(lat_ref * deg_to_rad) / 0.1;

    latitude_pre  = lat_now;
    longitude_pre = lon_now;

    l_lat_gps = lat_err;
    l_lon_gps = lon_err;

    gps_new_data_counter = 0;
    validGPS = false;
  }

  if (gps_new_data_counter < 25) {
    l_lat_gps += latitude_add / 25.0;
    l_lon_gps += longitude_add / 25.0;
    gps_new_data_counter++;
  }

  if (flight_mode == 3) {
    if (!latitude_sp && !longitude_sp) {
      latitude_sp = l_lat_gps;
      longitude_sp = l_lon_gps;
    }

    latitude_e_cm  = l_lat_gps - latitude_sp;
    longitude_e_cm = l_lon_gps - longitude_sp;

    gps_lat_total_avarage -= gps_lat_rotating_mem[gps_rotating_mem_location];
    gps_lat_rotating_mem[gps_rotating_mem_location] = latitude_e_cm - gps_lat_error_previous;
    gps_lat_total_avarage += gps_lat_rotating_mem[gps_rotating_mem_location];

    gps_lon_total_avarage -= gps_lon_rotating_mem[gps_rotating_mem_location];
    gps_lon_rotating_mem[gps_rotating_mem_location] = longitude_e_cm - gps_lon_error_previous;
    gps_lon_total_avarage += gps_lon_rotating_mem[gps_rotating_mem_location];

    gps_rotating_mem_location = (gps_rotating_mem_location + 1) % 35;

    gps_lat_error_previous = latitude_e_cm;
    gps_lon_error_previous = longitude_e_cm;

    float lat_acc_cmd = (latitude_kp * latitude_e_cm + latitude_kd * gps_lat_total_avarage) * throttle_correction;
    float lon_acc_cmd = (longitude_kp * longitude_e_cm + longitude_kd * gps_lon_total_avarage) * throttle_correction;

    float yaw_rad = AngleYaw * deg_to_rad;
    float acc_x =  lon_acc_cmd * cos(yaw_rad) + lat_acc_cmd * sin(yaw_rad);
    float acc_y = -lon_acc_cmd * sin(yaw_rad) + lat_acc_cmd * cos(yaw_rad);

    gps_pitch_adjust = atan(acc_y / 980.0) * rad_to_deg;
    gps_roll_adjust  = atan(acc_x / 980.0) * rad_to_deg;

    gps_pitch_adjust = constrain(gps_pitch_adjust, -5, 5);
    gps_roll_adjust  = constrain(gps_roll_adjust, -5, 5);
  }
  else if (flight_mode < 3) {
    latitude_sp = longitude_sp = 0;
    gps_lat_error_previous = gps_lon_error_previous = 0;
    gps_lat_total_avarage = gps_lon_total_avarage = 0;
    gps_roll_adjust = gps_pitch_adjust = 0;

    gps_lat_rotating_mem[gps_rotating_mem_location] = 0;
    gps_lon_rotating_mem[gps_rotating_mem_location] = 0;
    gps_rotating_mem_location = (gps_rotating_mem_location + 1) % 35;
  }
}

void reset_pid(void) {
  rate_Roll_pre_I = 0;
  rate_Roll_pre_e = 0;

  rate_Pitch_pre_I = 0;
  rate_Pitch_pre_e = 0;

  rate_Yaw_pre_I = 0;
  rate_Yaw_pre_e = 0;

  angle_Roll_pre_I = 0;
  angle_Roll_pre_e = 0;

  angle_Pitch_pre_I = 0;
  angle_Pitch_pre_e = 0;

  angle_Yaw_pre_I = 0;
  angle_Yaw_pre_e = 0;
}