// Hàm xử lý dữ liệu GPS
void processGPSData(String nmea) {
  if (nmea.startsWith("$GNRMC") || nmea.startsWith("$GPRMC")) {
    parseGNRMC(nmea);
  }
}

// Hàm phân tích NMEA GNRMC
void parseGNRMC(String nmea) {
  int fieldIndex = 0;
  String data;
  validGPS = false; // Mặc định GPS không hợp lệ

  int startIndex = 0;
  int endIndex = nmea.indexOf(',');

  while (endIndex != -1) {
    data = nmea.substring(startIndex, endIndex);
    startIndex = endIndex + 1;
    endIndex = nmea.indexOf(',', startIndex);
    fieldIndex++;

    switch (fieldIndex) {
      case 4: latitude = convertToDecimalDegrees(data.toDouble()); break;
      case 5: lat_dir = data.charAt(0); break;
      case 6: longitude = convertToDecimalDegrees(data.toDouble()); break;
      case 7: lon_dir = data.charAt(0); break;
      case 3: if (data.charAt(0) == 'A') validGPS = true; break;
    }
  }
}

// Hàm chuyển đổi sang độ thập phân
double convertToDecimalDegrees(double raw) {
  int degrees = (int)(raw / 100);
  double minutes = raw - (degrees * 100);
  return degrees + (minutes / 60.0);
}

// Hàm tính khoảng cách GPS (Haversine) theo cm
double haversine_distance_cm(double lat1, double lon1, double lat2, double lon2) {
  lat1 = lat1 * deg_to_rad;
  lon1 = lon1 * deg_to_rad;
  lat2 = lat2 * deg_to_rad;
  lon2 = lon2 * deg_to_rad;

  double dLat = lat2 - lat1;
  double dLon = lon2 - lon1;

  double a = sin(dLat / 2) * sin(dLat / 2) + cos(lat1) * cos(lat2) * sin(dLon / 2) * sin(dLon / 2);
  double c = 2 * atan2(sqrt(a), sqrt(1 - a));
  double distance_m = EARTH_RADIUS * c;

  return distance_m * 100.0;  // Trả về khoảng cách theo cm
}
