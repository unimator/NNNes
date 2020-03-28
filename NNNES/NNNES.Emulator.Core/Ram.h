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

public:

	void Clear() const;
	
	void Write(uint16_t address, uint8_t data) const override;
	uint8_t Read(uint16_t address) override;

	uint8_t* GetMemory() const;
};

