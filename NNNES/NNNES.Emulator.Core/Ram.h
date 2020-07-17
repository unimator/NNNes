#pragma once
#include <array>
#include "Device.h"

class Ram : public Device
{
private:
	uint8_t* memory_;
	uint16_t physical_size_;
	
protected:
	Ram(uint16_t virtual_size, uint16_t physical_size);
	virtual ~Ram();
	
public:

	void Clear() const;
	
	void CpuWrite(uint16_t address, uint8_t data) override;
	uint8_t CpuRead(uint16_t address) override;

	uint8_t* GetMemory() const;
};

