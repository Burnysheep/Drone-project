//Hàm cài đặt wifi
void WifiConnect() {
  WiFi.begin(ssid, password);
  Serial.println("");

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.print("Connected to ");
  Serial.println(ssid);
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());
  
  //This initializes udp and transfer buffer
  udp.begin(port);
}

//Hàm gửi nhận wifi
void PC_update(void) {
  packetSize = udp.parsePacket();
  
  if (packetSize > 0) {
    udp.read(incomingData, packetSize);
    memcpy(packet, incomingData, sizeof(packet));
    packetID = packet[0];

    switch (packetID) {
      case 1: newSPData = true; break;
      case 2: newAngleData = true; break;
      case 3: newRateData = true; break;
      case 4: newEmerData = true; break;
      case 5: newGPSData = true; break;
      case 6: newHomeData = true; break;
    }
  }
}

// Hàm xử lý dữ liệu mới
void processNewData(void) {
  if (newGPSData) {
    for (int i = 0; i < 7; i++) {
      gpsPositions[i] = packet[i];
      flight_waypoint = true;
      // Serial.println(gpsPositions[i], 8);
    }

    newGPSData = false;
  }
  if (newHomeData) {
    goHome = packet[0];
    latitude_sp = packet[1];
    longitude_sp = packet[2];
    // Serial.println(latitude_sp, 8);
    // Serial.println(longitude_sp, 8);

    newHomeData = false;
  }
  if (newSPData) {
    angle_Roll_sp = packet[1];
    angle_Pitch_sp = packet[2];
    angle_Yaw_sp = packet[3];
    InputThrottle = packet[4];

    newSPData = false;
  }
  if (newAngleData) {
    // angle_Roll_kp = packet[1];
    // angle_Roll_ki = packet[2];
    // angle_Roll_kd = packet[3];

    // angle_Pitch_kp = packet[1];
    // angle_Pitch_ki = packet[2];
    // angle_Pitch_kd = packet[3];
    
    altitude_kp = packet[1];
    altitude_ki = packet[2];
    altitude_kd = packet[3];

    angle_Yaw_kp = packet[4];
    angle_Yaw_ki = packet[5];
    angle_Yaw_kd = packet[6];

    // Serial.println(altitude_kp);
    // Serial.println(altitude_ki);
    // Serial.println(altitude_kd);
    // Serial.println(angle_Yaw_kp);
    // Serial.println(angle_Yaw_ki);
    // Serial.println(angle_Yaw_kd);

    newAngleData = false;
  }
  if (newRateData) {
    // rate_Roll_kp = packet[1];
    // rate_Roll_ki = packet[2];
    // rate_Roll_kd = packet[3];

    // rate_Pitch_kp = packet[1];
    // rate_Pitch_ki = packet[2];
    // rate_Pitch_kd = packet[3];
    latitude_kp = packet[1];
    latitude_ki = packet[2];
    latitude_kd = packet[3];

    longitude_kp = packet[1];
    longitude_ki = packet[2];
    longitude_kd = packet[3]; 

    rate_Yaw_kp = packet[4];
    rate_Yaw_ki = packet[5];
    rate_Yaw_kd = packet[6];

    // Serial.println(latitude_kp);
    // Serial.println(latitude_ki);
    // Serial.println(latitude_kd);
    // Serial.println(rate_Yaw_kp);
    // Serial.println(rate_Yaw_ki);
    // Serial.println(rate_Yaw_kd);

    newRateData = false;
  }
  if (newEmerData) {
    angle_Roll_e = 0;
    angle_Pitch_e = 0;
    angle_Yaw_e = 0;

    angle_Roll_pre_e = 0;
    angle_Pitch_pre_e = 0;
    angle_Yaw_pre_e = 0;

    angle_Roll_pre_I = 0;
    angle_Pitch_pre_I = 0;
    angle_Yaw_pre_I = 0;

    rate_Roll_e = 0;
    rate_Pitch_e = 0;
    rate_Yaw_e = 0;

    rate_Roll_pre_e = 0;
    rate_Pitch_pre_e = 0;
    rate_Yaw_pre_e = 0;

    rate_Roll_pre_I = 0;
    rate_Pitch_pre_I = 0;
    rate_Yaw_pre_I = 0;

    altitude_e = 0;

    InputRoll = 0;
    InputPitch  = 0;
    InputYaw = 0;
    InputThrottle = 0;

    newEmerData = false;
  }
}

// Hàm gửi dữ liệu
void processSendData(void) {
  if (sendAngleData) {
    sendDataPacket(angleValues, 7);
    sendAngleData = false;
  }
  if (sendRateData) {
    sendDataPacket(rateValues, 7);
    sendRateData = false;
  }
  if (sendGPSData) {
    sendDataPacket(gpsValues, 7);
    sendGPSData = false;
  }
}

// Hàm để gửi gói tin UDP
void sendDataPacket(float* packet, size_t length) {
  udp.beginPacket(host, port);
  udp.write((uint8_t*)packet, length * sizeof(float));  // Gửi dữ liệu dưới dạng byte
  udp.endPacket();
}