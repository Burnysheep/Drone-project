/*
#################################################################
#                             _`				                        #
#                          _ooOoo_				                      #
#                         o8888888o				                      #
#                         88" . "88				                      #
#                         (| -_- |)				                      #
#                         O\  =  /O				                      #
#                      ____/`---'\____				                  #
#                    .'  \\|     |//  `.			                  #
#                   /  \\|||  :  |||//  \			                  #
#                  /  _||||| -:- |||||_  \			                #
#                  |   | \\\  -  /'| |   |			                #
#                  | \_|  `\`---'//  |_/ |			                #
#                  \  .-\__ `-. -'__/-.  /			                #
#                ___`. .'  /--.--\  `. .'___			              #
#             ."" '<  `.___\_<|>_/___.' _> \"".			            #
#            | | :  `- \`. ;`. _/; .'/ /  .' ; |		            #
#            \  \ `-.   \_\_`. _.'_/_/  -' _.' /		            #
#=============`-.`___`-.__\ \___  /__.-'_.'_.-'=================#
                           `= --= -'                    

            TRỜI PHẬT PHÙ HỘ CODE CON KHÔNG BI BUG

          _.-/`)
         // / / )
      .=// / / / )
     //`/ / / / /
     // /     ` /
   ||         /
    \\       /
     ))    .'
         //    /
         /

*/

#include <WiFi.h>
#include <WiFiUdp.h>
#include <Wire.h>
#include <ESP32Servo.h>
#include "HardwareSerial.h"

// Sử dụng UART1 cho GPS
HardwareSerial gpsSerial(1);
// Cấu hình UART2 cho ELRS
HardwareSerial ELRS_UART(2);

// Các hằng số CRSF
const uint8_t CRSF_MAX_PAYLOAD_SIZE = 64;
const uint8_t CRSF_HEADER = 0xC8;  // Header của CRSF
const uint8_t CRSF_FRAME_LENGTH_MIN = 10;  // Độ dài tối thiểu của khung CRSF

// Bộ đệm cho dữ liệu CRSF
uint8_t crsfBuffer[CRSF_MAX_PAYLOAD_SIZE];
uint8_t crsfIndex = 0;
bool crsfFrameStarted = false;

uint16_t channels[8];
int flight_mode = 0, flight_pre_mode = 0;

//Wifi
const char* ssid = "Active 1";
const char* password = "12345678";
const char* host = "123.456.789.0";
const int port = 8080;

char incomingData[255];         // Bộ đệm nhận dữ liệu
float angleValues[7], rateValues[7], gpsValues[7];
double packet[10];
double gpsPositions[7];
int packetSize;
uint8_t packetID;
bool newSPData = false, newAngleData = false, newRateData = false, newEmerData = false, newGPSData = false, newHomeData = false, sendAngleData = false, sendRateData = false, sendGPSData = false;

//create UDP instance
WiFiUDP udp;

// Khai báo bộ lọc trung bình động (Moving Average Filter)
#define MA_WINDOW_SIZE 20
float latitude_values[MA_WINDOW_SIZE] = {0};
float longitude_values[MA_WINDOW_SIZE] = {0};
int ma_index = 0;

//GPS
#define EARTH_RADIUS 6371000.0  // mét
String gpsBuffer = "";
double latitude, longitude, latitude_pre = 0.0, longitude_pre = 0.0;
char lat_dir, lon_dir;
uint8_t latitude_north, longiude_east, gps_new_data_counter, goHome, flight_waypoint = false;
bool validGPS = false;
int32_t gps_lat_total_avarage, gps_lon_total_avarage;
uint8_t gps_rotating_mem_location;
int32_t gps_lat_rotating_mem[40], gps_lon_rotating_mem[40];
float gps_lat_error_previous, gps_lon_error_previous, latitude_e_cm, longitude_e_cm;
double l_lat_gps, l_lon_gps, latitude_add, longitude_add;

//MPU
#define MPU6050_ADDR 0x68  // Địa chỉ I2C của MPU6050
float RateRoll, RatePitch, RateYaw, AccX, AccY, AccZ;
int16_t Acc_rawX, Acc_rawY, Acc_rawZ, temperature, Gyr_rawX, Gyr_rawY, Gyr_rawZ;
float RateCalibrationangle_Roll, RateCalibrationangle_Pitch, RateCalibrationangle_Yaw, CalibrationAltitude;
int RateCalibrationNumber, CalibrationAltitudeCounter = 0;
float AngleRoll, AnglePitch;

float rad_to_deg = 180 / PI;
float deg_to_rad = PI / 180;

float KalmanAngleRoll=0, KalmanUncertaintyAngleRoll=2*2;
float KalmanAnglePitch=0, KalmanUncertaintyAnglePitch=2*2;
float Kalman1DOutput[]={0,0};

//HMC
#define HMC5883L_ADDR 0x1E  // Địa chỉ I2C của HMC5883L
int16_t Mag_rawX, Mag_rawY, Mag_rawZ;
float magX_comp, magY_comp;
float heading, AngleYaw, angle_Yaw_hand;
int16_t minX = 32767, maxX = -32768;
int16_t minY = 32767, maxY = -32768;
int16_t offsetX = 0, offsetY = 0;

//MS
#define MS5611_ADDR 0x77  // Địa chỉ I2C của MS5611
#define OSR_CMD_PRESSURE 0x48  // OSR=4096 (~8.22ms)
#define OSR_CMD_TEMPERATURE 0x58

uint16_t C[7]; // Hệ số hiệu chuẩn
uint32_t D1 = 0, D2 = 0;
bool readingPressure = true;
unsigned long lastConversionTime = 0; // Thời gian bắt đầu đo
const int conversionDelay = 8000; // Thời gian cần để MS5611 hoàn thành chuyển đổi (8ms)
float temperature_MS, pressure, altitude;
bool dataReady = false, altitude_PID = false;

float pressure_rotating_mem[20] = {0};
uint8_t pressure_rotating_mem_location = 0;
int32_t pressure_total_average = 0;

#define BUFFER_SIZE 30
float pressure_buffer[BUFFER_SIZE];
float pressure_diff_total = 0;
int buffer_index = 0;
float pressure_prev = 0;

float rawThrottle, angle_rad, sin_a2, k_bu, throttle_correction;

// Biến lưu trữ giá trị lọc
float actual_pressure_slow = 1013.25;
float actual_pressure_fast = 1013.25;
float actual_pressure_diff = 0;

//Chân PWM cho động cơ
const int motorPin1 = 33; // Kết nối với S1 trên ESC 25
const int motorPin2 = 32; // Kết nối với S2 trên ESC 26
const int motorPin3 = 25; // Kết nối với S3 trên ESC 32
const int motorPin4 = 26; // Kết nối với S4 trên ESC 33

Servo motor1, motor2, motor3, motor4;

// Sampling times
unsigned long currentTime = 0;
uint32_t lastTempReadTime = 0;
uint32_t lastPressReadTime = 0;
uint32_t now = 0;

//PID
float altitude_sp, altitude_e, altitude_pre_e;
float altitude_P, altitude_I, altitude_D, altitude_U;

double latitude_sp, latitude_e;
float latitude_P, latitude_I, latitude_D, latitude_U, gps_pitch_adjust;

double longitude_sp, longitude_e;
float longitude_P, longitude_I, longitude_D, longitude_U, gps_roll_adjust;

float roll_value, pitch_value, yaw_value;
float angle_Roll_sp, angle_Pitch_sp, angle_Yaw_sp;
float angle_Roll_e, angle_Pitch_e, angle_Yaw_e;
float angle_Roll_pre_e, angle_Pitch_pre_e, angle_Yaw_pre_e;

float angle_Roll_P, angle_Roll_I, angle_Roll_D;
float angle_Pitch_P, angle_Pitch_I, angle_Pitch_D;
float angle_Yaw_P, angle_Yaw_I, angle_Yaw_D;
float angle_Roll_pre_I, angle_Pitch_pre_I, angle_Yaw_pre_I;

float InputRoll, InputPitch, InputYaw, InputThrottle;
float rate_Roll_sp, rate_Pitch_sp, rate_Yaw_sp;
float rate_Roll_e, rate_Pitch_e, rate_Yaw_e;
float rate_Roll_pre_e, rate_Pitch_pre_e, rate_Yaw_pre_e;

float rate_Roll_P, rate_Roll_I, rate_Roll_D;
float rate_Pitch_P, rate_Pitch_I, rate_Pitch_D;
float rate_Yaw_P, rate_Yaw_I, rate_Yaw_D;
float rate_Roll_pre_I, rate_Pitch_pre_I, rate_Yaw_pre_I;

float altitude_kp = 1.2, altitude_ki = 1.5, altitude_kd = 0.5;
float latitude_kp = 1.5, latitude_ki = 0, latitude_kd = 0.5;
float longitude_kp = 1.5, longitude_ki = 0, longitude_kd = 0.5; 

float angle_Roll_kp = 2, angle_Roll_ki = 0, angle_Roll_kd = 0;
float angle_Pitch_kp = 2, angle_Pitch_ki = 0, angle_Pitch_kd = 0;
float angle_Yaw_kp = 2, angle_Yaw_ki = 0, angle_Yaw_kd = 0;

float rate_Roll_kp = 0.5, rate_Roll_ki = 3, rate_Roll_kd = 0.02;
float rate_Pitch_kp = 0.5, rate_Pitch_ki = 3, rate_Pitch_kd = 0.02;
float rate_Yaw_kp = 3, rate_Yaw_ki = 0, rate_Yaw_kd = 0.01;

struct RateOutputs {
  float angle_Roll_u;
  float angle_Pitch_u;
  float angle_Yaw_u;
};

struct PWMoutputs {
  int motorInput1;
  int motorInput2;
  int motorInput3;
  int motorInput4;
};

// Hàm xử lý ngắt UART ELRS
void IRAM_ATTR onUARTData() {
  while (ELRS_UART.available()) {
    uint8_t byteReceived = ELRS_UART.read();
    processCRSF(byteReceived);
  }
}

// Hàm xử lý ngắt UART GPS
void IRAM_ATTR onUARTGPS() {
  while (gpsSerial.available()) {
    char c = gpsSerial.read();
    if (c == '\n') { 
      processGPSData(gpsBuffer);
      gpsBuffer = ""; 
    } else {
      gpsBuffer += c;
    }
  }
}

void setup() {
  // Serial.begin(115200);
  Motor_Setup();
  WifiConnect();
  MPU_setup();
  MS_setup();
  HMC_setup();
  Calib_sensors();

  // Khởi tạo servo
  ESP32PWM::allocateTimer(0);
  ESP32PWM::allocateTimer(1);
  ESP32PWM::allocateTimer(2);
  ESP32PWM::allocateTimer(3);

  // Cấu hình ngắt UART1 cho GPS
  gpsSerial.begin(38400, SERIAL_8N1, 13, 15);
  gpsSerial.onReceive(onUARTGPS);

  // Khởi tạo UART2 cho ELRS
  ELRS_UART.begin(420000, SERIAL_8N1, 16, 17);
  ELRS_UART.onReceive(onUARTData);

  currentTime = micros();
  // lastPrintTime = micros();
}

void loop() {
  // Nhận chế độ điều khiển
  flightModeSignals();
  
  // Nhận dữ liệu và xử lý dữ liệu mới
  PC_update();
  processNewData();

  // Đọc Roll, Pitch
  MPU_signals();
  Filter_MPU_sensors();

  // Đọc độ cao
  MS_signals();
  Filter_MS_sensors();

  // Đọc góc yaw
  calib_HMC5883L();
  HMC_signals();
  Filter_HMC_sensors();

  // Xử lý đầu vào các bộ PID
  setpoint_Calculate();

  // Xử lý PID
  PID_altitude();
  PID_gps();
  Motor_Control();

  // Serial.println(altitude_U);

  sendGPSData = true;
  gpsValues[0] = 3;
  gpsValues[1] = latitude;
  gpsValues[2] = longitude;
  gpsValues[3] = AngleYaw;
  gpsValues[4] = altitude;
  gpsValues[5] = temperature_MS;

  // Gửi dữ liệu
  processSendData();

  // In dữ liệu kênh ra Serial (chỉ in mỗi 100ms để giảm tải)
  // static unsigned long lastPrintTime = 0;
  // if (millis() - lastPrintTime >= 100) {
  //   lastPrintTime = millis();
  //   Serial.println("Received CRSF Channels:");
  //   for (int i = 0; i < 8; i++) {
  //     Serial.print("Channel ");
  //     Serial.print(i + 1);
  //     Serial.print(": ");
  //     Serial.println(channels[i]);
  //   }
  // }

  // Serial.print("altitude e: ");
  // Serial.print(altitude_e);
  // Serial.print("\t");
  // Serial.print("pressure_diff_total: ");
  // Serial.print(pressure_diff_total);
  // Serial.print("\t");
  // Serial.print("altitude_I: ");
  // Serial.print(altitude_I);
  // Serial.print("\t");
  // Serial.print("altitude_U: ");
  // Serial.print(altitude_U);
  // Serial.println();

  // Serial.print("latitude e: ");
  // Serial.print(latitude_e_cm);
  // Serial.print("\t");
  // Serial.print("longitude e: ");
  // Serial.print(longitude_e_cm);
  // Serial.print("\t");
  // Serial.print("l_lat_gps: ");
  // Serial.print(gps_roll_adjust);
  // Serial.print("\t");
  // Serial.print("latitude_e: ");
  // Serial.print(gps_pitch_adjust);
  // Serial.print("\t");
  // Serial.print("l_lon_gps: ");
  // Serial.print(l_lon_gps);
  // Serial.print("\t");
  // Serial.print("longitude_sp: ");
  // Serial.print(longitude_e);
  // Serial.println();

  // Serial.print("InputThrottle: ");
  // Serial.print(InputThrottle);
  // Serial.println();

  // if (validGPS) {
  //   Serial.print("Latitude: "); Serial.print(latitude, 8); Serial.print(" "); Serial.println(lat_dir);
  //   Serial.print("Longitude: "); Serial.print(longitude, 8); Serial.print(" "); Serial.println(lon_dir);
  // }

  // Serial.println(gpsBuffer);

  while (micros() - currentTime < 4000);
  // Serial.println(((micros() - currentTime) / 1000000.0),4);
  currentTime = micros();  
}