#include "pch.h"
#include "Ram.h"

Ram::Ram(uint16_t virtual_size, uint16_t physical_size)
: Device(0, virtual_size), physical_size_(physical_size)
{
	memory_ = new uint8_t[physical_size];
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
	for(uint16_t i = 0x00; i < physical_size_; ++i)
	{
		memory_[i] = 0x00;
	}
}

void Ram::CpuWrite(uint16_t address, uint8_t data)
{
	if(address >= 0 && address < virtual_size_)
	{
		memory_[address & physical_size_ - 1] = data;
	}
}

uint8_t Ram::CpuRead(uint16_t address)
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
