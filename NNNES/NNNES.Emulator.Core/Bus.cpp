#include "pch.h"
#include "Nes.h"


Bus::Bus(Cpu& cpu, Ppu& ppu, Apu& apu, CpuRam& cpu_ram)
	: cpu_(cpu), ppu_(ppu), apu_(apu), cpu_ram_(cpu_ram)
{
	cpu.SetBus(this);
	apu.SetBus(this);
	ppu.SetBus(this);
}

Bus::~Bus()
{
}

void Bus::SetINesHandle(INes* i_nes)
{
	this->i_nes_ = i_nes;
}

INes* Bus::GetINesHandle() const
{
	return this->i_nes_;
}

void Bus::Write(uint16_t address, uint8_t data) const
{
	auto& device = GetDevice(address);
	device.CpuWrite(address, data);
}

uint8_t Bus::Read(uint16_t address) const
{
	auto& device = GetDevice(address);
	return device.CpuRead(address);
}

void Bus::Clock()
{
	this->cpu_.Clock();
	++clock_counter_;
}

void Bus::Reset()
{
	this->cpu_.Reset();
	clock_counter_ = 0;
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
	else if(address >= 0x4000 && address <= 0x4020)
	{
		return this->apu_;
	}
	else if (address >= 0x4020 && address <= 0xFFFF)
	{
		return static_cast<Device&>(*this->i_nes_);
	}

	throw "Address out of range";
}
