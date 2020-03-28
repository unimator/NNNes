#pragma once
#include <cstdint>

class Device
{
protected:
	uint16_t base_address_;
	uint16_t virtual_size_;

	Device(uint16_t base_address, uint16_t virtual_size);
	
public:

	virtual void Write(uint16_t address, uint8_t data) const = 0;
	virtual uint8_t Read(uint16_t address) = 0;

};



