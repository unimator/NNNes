#pragma once
#include <cstdint>

class Device
{
protected:
	uint16_t base_address_;
	uint16_t virtual_size_;

	Device(uint16_t base_address, uint16_t virtual_size);
	
public:
	virtual ~Device() = default;

	virtual void CpuWrite(uint16_t address, uint8_t data) = 0;
	virtual uint8_t CpuRead(uint16_t address) = 0;

};



