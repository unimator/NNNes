#pragma once
#include "Nes.h"

class Ppu : public Device
{
private:
	Bus* bus_ = nullptr;
	
public:
	Ppu();
	
	void SetBus(Bus* bus)
	{
		bus_ = bus;
	}

	void Write(uint16_t address, uint8_t data) const override;
	uint8_t Read(uint16_t address) override;
};
