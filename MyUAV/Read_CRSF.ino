// Hàm xử lý từng byte CRSF
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