#include "pch.h"
#include "Nes.h"


Bus::Bus(Cpu& cpu, Ppu& ppu, CpuRam& cpu_ram)
	: cpu_(cpu), ppu_(ppu), cpu_ram_(cpu_ram)
{
	cpu.SetBus(this);
	ppu.SetBus(this);
}

Bus::~Bus()
{
}

void Bus::SetINesHandle(INes* i_nes)
{
	this->i_nes_ = i_nes;
}

void Bus::Write(uint16_t address, uint8_t data) const
{
	auto& device = GetDevice(address);
	device.Write(address, data);
}

uint8_t Bus::Read(uint16_t address) const
{
	auto& device = GetDevice(address);
	return device.Read(address);
}


Device& Bus::GetDevice(uint16_t address) const
{
	if (address <= 0x1fff)
	{
		return this->cpu_ram_;
	}
	else if (address >= 0x2000 && address <= 0x3fff)
	{
		return this->ppu_;
	}

	throw "Address out of range";
}
