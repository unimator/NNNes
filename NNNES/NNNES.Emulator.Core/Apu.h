#pragma once
#include "Device.h"

class Apu : public Device
{
private:
	Bus* bus_ = nullptr;
	
public:
	Apu();

	void SetBus(Bus* bus)
	{
		bus_ = bus;
	}
	
	void CpuWrite(uint16_t address, uint8_t data) override;
	uint8_t CpuRead(uint16_t address) override;
};
