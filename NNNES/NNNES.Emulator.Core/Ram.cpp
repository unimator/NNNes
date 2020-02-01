#include "pch.h"
#include "Ram.h"
#include <vector>

Ram::Ram()
{
	ram_ = new uint8_t[RAM_SIZE];
	Clear();
}

Ram::~Ram()
{
	delete [] ram_;
}

void Ram::Write(const uint16_t address, const uint8_t data)
{
	if(address >= 0x0000 && address <= 0x1FFF)
	{
		ram_[address & 0x07FF] = data;
	}
}

uint8_t Ram::Read(const uint16_t address)
{
	if(address >= 0x0000 && address <= 0x1FFF)
	{
		return ram_[address & 0x07FF];
	}

	return 0x00;
}

void Ram::Clear() const
{
	for(uint16_t i = 0x00; i < RAM_SIZE; ++i)
	{
		ram_[i] = 0x00;
	}
}

uint8_t* Ram::GetRamAddress() const
{
	return ram_;
}

