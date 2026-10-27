#pragma once
#include "Device.h"

class AddressableDevice : public Device
{
protected:
	uint16_t base_address_;
	size_t virtual_size_;

	AddressableDevice(uint16_t base_address, size_t virtual_size);

public:
	virtual ~AddressableDevice() = default;

	auto BaseAddress() const -> const uint16_t& { return base_address_; }
	auto VirtualSize() const -> const size_t& { return virtual_size_; }

	virtual void Write(uint16_t address, uint8_t data) = 0;
	virtual uint8_t Read(uint16_t address) = 0;
};