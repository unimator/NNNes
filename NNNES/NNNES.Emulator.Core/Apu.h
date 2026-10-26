#pragma once
#include "AddressableDevice.h"

class Apu : public AddressableDevice
{	
public:
	Apu();

	void SetBus(Bus* bus)
	{
		bus_ = bus;
	}
	
	void Write(uint16_t address, uint8_t data) override;
	uint8_t Read(uint16_t address) override;
};
