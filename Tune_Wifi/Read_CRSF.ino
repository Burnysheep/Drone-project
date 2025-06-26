// Hàm xử lý từng byte CRSF
// void processCRSF(uint8_t byte) {
//   if (!crsfFrameStarted) {
//     // Tìm byte bắt đầu của CRSF (header)
//     if (byte == CRSF_HEADER) {
//       crsfFrameStarted = true;
//       crsfIndex = 0;
//       crsfBuffer[crsfIndex++] = byte;  // Lưu header vào bộ đệm
//     }
//   } else {
//     // Thêm byte vào bộ đệm nếu đã tìm thấy header
//     crsfBuffer[crsfIndex++] = byte;

//     // Kiểm tra độ dài khung CRSF
//     if (crsfIndex >= CRSF_FRAME_LENGTH_MIN) {
//       uint8_t payloadLength = crsfBuffer[1];

//       if (crsfIndex == payloadLength + 2) {  // Kiểm tra đủ khung CRSF
//         // Đã nhận đủ khung CRSF, giải mã
//         decodeCRSF(crsfBuffer, crsfIndex);
//         crsfFrameStarted = false;  // Reset trạng thái
//       } else if (crsfIndex > CRSF_MAX_PAYLOAD_SIZE) {
//         // Dữ liệu vượt kích thước cho phép
//         crsfFrameStarted = false;
//         crsfIndex = 0;
//       }
//     }
//   }
// }

// // Hàm giải mã dữ liệu CRSF
// void decodeCRSF(uint8_t *buffer, uint8_t length) {
//   if (length < CRSF_FRAME_LENGTH_MIN || buffer[0] != CRSF_HEADER) {
//     return; // Gói không hợp lệ
//   }

//   if (buffer[2] == 0x16) {  // Kiểm tra ID của RC_CHANNELS_PACKED
//     for (int i = 0; i < 8; i++) {
//       int bitOffset = i * 11;
//       int byteIndex = bitOffset / 8 + 3;  // Bắt đầu từ byte thứ 3
//       int bitIndex = bitOffset % 8;

//       channels[i] = ((buffer[byteIndex] | buffer[byteIndex + 1] << 8 | buffer[byteIndex + 2] << 16) >> bitIndex) & 0x07FF;
//     }
//   }
// }

void processCRSF(uint8_t byte) {
  if (!crsfFrameStarted) {
    if (byte == CRSF_HEADER) {
      crsfIndex = 0;
      crsfBuffer[crsfIndex++] = byte;
      crsfFrameStarted = true;
    }
    return;
  }

  if (crsfIndex < CRSF_MAX_PAYLOAD_SIZE) {
    crsfBuffer[crsfIndex++] = byte;

    if (crsfIndex == 2) return;

    uint8_t payloadLength = crsfBuffer[1];
    uint8_t totalLength = payloadLength + 2;

    if (crsfIndex == totalLength) {
      decodeCRSF(crsfBuffer, totalLength);
      crsfFrameStarted = false;
    } else if (crsfIndex > totalLength) {
      crsfFrameStarted = false;
    }
  } else {
    crsfFrameStarted = false;
  }
}

void decodeCRSF(uint8_t* buffer, uint8_t length) {
  if (length < 6 || buffer[0] != CRSF_HEADER) return;

  if (buffer[2] == 0x16) {
    const uint8_t* payload = buffer + 3;

    for (uint8_t i = 0; i < 8; i++) {
      uint16_t bitOffset = i * 11;
      uint8_t byteIndex = bitOffset / 8;
      uint8_t bitIndex = bitOffset % 8;

      uint32_t data = *(uint32_t*)(payload + byteIndex);
      channels[i] = (data >> bitIndex) & 0x07FF;
    }
  }
}