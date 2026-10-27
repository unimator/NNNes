#include "pch.h"
#include "AddressableDevice.h"

AddressableDevice::AddressableDevice(uint16_t base_address, size_t virtual_size)
	: base_address_(base_address), virtual_size_(virtual_size)
{}