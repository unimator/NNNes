#include "pch.h"
#include <cstdint>
#include "Device.h"
#include "Bus.h"

void Device::SetBus(Bus* bus)
{
	this->bus_ = bus;
}