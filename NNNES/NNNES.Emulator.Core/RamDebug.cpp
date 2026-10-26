#include "pch.h"
#include "RamDebug.h"

RamDebug::RamDebug()
	: AddressableDevice(0, 0xFFFF), physical_size_(0xFFFF)
{
	memory_ = new uint8_t[physical_size_];
	Clear();
}

void RamDebug::Clear() const
{
	for (uint16_t i = 0x00; i < physical_size_; ++i)
	{
		memory_[i] = 0x00;
	}
}

void RamDebug::Write(uint16_t address, uint8_t data)
{
	if (address >= 0 && address < virtual_size_)
	{
		memory_[address & physical_size_ - 1] = data;
	}
}

uint8_t RamDebug::Read(uint16_t address)
{
	if (address >= 0 && address < virtual_size_)
	{
		return memory_[address & physical_size_ - 1];
	}
}
