#include "pch.h"
#include "Nrom.h"

uint16_t Nrom::CpuMappedAddress(uint16_t address)
{
	if(address >= 0x8000 && address <= 0xFFFF)
	{
		return address & (prg_banks_ > 1 ? 0x7FFF : 0x3FFF);
	}

	return 0;
}

uint16_t Nrom::PpuMappedAddress(uint16_t address)
{
	if (address >= 0x0000 && address <= 0x1FFF)
	{
		return address;
	}

	return 0;
}
