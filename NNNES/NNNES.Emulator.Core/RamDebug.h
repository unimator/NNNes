#pragma once
#include "AddressableDevice.h"

class RamDebug : public AddressableDevice
{
private:
	uint8_t* memory_;
	uint16_t physical_size_;

public:
	RamDebug();
	virtual ~RamDebug();

	void Clear() const;

	void Write(uint16_t address, uint8_t data) override;
	uint8_t Read(uint16_t address) override;
};