#include "pch.h";
#include "Apu.h"

Apu::Apu() : AddressableDevice(0x4000, 0x8 + 0x18)
{
}

void Apu::Write(uint16_t address, uint8_t data)
{
}

uint8_t Apu::Read(uint16_t address)
{
	return 0x00;
}
