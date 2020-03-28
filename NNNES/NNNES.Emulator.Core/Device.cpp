#include "pch.h"
#include <cstdint>
#include "Device.h"

Device::Device(uint16_t base_address, uint16_t virtual_size)
	: base_address_(base_address), virtual_size_(virtual_size)
{
}
