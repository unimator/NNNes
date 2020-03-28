#include "pch.h"
#include "Ppu.h"

Ppu::Ppu() : Device(0x2000, 0x2000){}

void Ppu::Write(uint16_t address, uint8_t data) const
{
}

uint8_t Ppu::Read(uint16_t address)
{
	return 0x00;
}
