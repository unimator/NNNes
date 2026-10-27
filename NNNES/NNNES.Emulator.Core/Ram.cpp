#include "pch.h"
#include "Ram.h"

Ram::Ram()
: AddressableDevice(0, 0x2000), physical_size_(0x800)
{
	memory_ = new uint8_t[physical_size_];
	Clear();
}

Ram::~Ram()
{
	if(memory_)
	{
		delete[] memory_;
	}
}

void Ram::Clear() const
{
	for(size_t i = 0x00; i < physical_size_; ++i)
	{
		memory_[i] = 0x00;
	}
}

void Ram::Write(uint16_t address, uint8_t data)
{
	if(address >= 0 && address < virtual_size_)
	{
		memory_[address & physical_size_ - 1] = data;
	}
}

uint8_t Ram::Read(uint16_t address)
{
	if (address >= 0 && address < virtual_size_)
	{
		return memory_[address & physical_size_ - 1];
	}
}

uint8_t* Ram::GetMemory() const
{
	return memory_;
}
