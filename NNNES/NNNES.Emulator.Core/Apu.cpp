#include "pch.h";
#include "Nes.h"

Apu::Apu(): Device(0x4000, 0x8 + 0x18)
{
}

void Apu::CpuWrite(uint16_t address, uint8_t data)
{
}

uint8_t Apu::CpuRead(uint16_t address)
{
	return 0x00;
}
