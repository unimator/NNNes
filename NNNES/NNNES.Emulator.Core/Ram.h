#pragma once
#include "AddressableDevice.h"

class Ram : public AddressableDevice
{
private:
	uint8_t* memory_;
	size_t physical_size_;
		
public:
	Ram();
	virtual ~Ram();

	void Clear() const;
	
	void Write(uint16_t address, uint8_t data) override;
	uint8_t Read(uint16_t address) override;

	uint8_t* GetMemory() const;
};

