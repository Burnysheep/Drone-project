# Drone project 🚁

This project is a custom-developed drone flight controller utilizing the ESP32, which integrates real-time sensor fusion, PID control, and wireless communication. It supports IMU (MPU6050), magnetometer (HMC5883L), barometer (MS5611), and GPS (BN-220) modules.

## Features
- Real-time sensor fusion (accelerometer, gyroscope, magnetometer, barometer, GPS)
- Multi-stage PID control (position → angle → rate → motor)
- Communication via custom RF (E01-2G4M27D) and telemetry (I don't have enough time to do it, so I use a radiomaster controller)
- Altitude hold, manual & GPS position hold modes (GPS position hold modes can be wrong, i tested it in practice but it seems that the PID parameters for the angle controller and the angular speed are not correct which makes my drone not change immediately so in this mode my drone always flies around the gps point that needs to stay still)
- Designed for modularity and extensibility

## Technologies Used
- ESP32 (dual-core FreeRTOS)
- C/C++
- Custom radio protocol (RF module over UART - I wish I could =))), I couldn't handle the RF data noise, so I used wifi, that's also why I chose ESP32 for this project)
- Radiomaster controller
- Low-level sensor interfacing via I2C/SPI
- Real-time task scheduling
- Computer application for control and parameter setting

## Getting Started
To run this project, you’ll need:
- ESP32 board
- GY-86 sensor module
- GPS BN-220 module
- RF modules (E01-2G4M27D, you can use wifi if you can use wifi if you cant handle RF signals like me)
- Compatible 4-in-1 ESC and BLDC motors
- Radiomaster controller
- Radiomaster receiver

## Developer
Hi, I'm **Nguyen Thanh Phu Thinh** – an embedded systems enthusiast with a strong interest in real-time control, sensor fusion, and low-level firmware. I enjoy building systems where hardware and algorithms work together in real-world environments.

You can find more of my projects and contact info on my [GitHub profile](https://github.com/Burnysheep).

## Note
I have not finished this project yet, and there are still some bugs in data transmission and in the desktop application. If you can complete this project, please let me know. I always want to see if my code for GPS location holding actually works. If you have any questions, please get in touch with me. I will help if I can.
