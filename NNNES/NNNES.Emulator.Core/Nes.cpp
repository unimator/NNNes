#include "pch.h"
#include "Nes.h"
#include "Cpu.h"
#include "Ram.h"
#include "Bus.h"

Nes::Nes()
{
	cpu_ = new Cpu();
	cpu_ram_ = new CpuRam();
	ppu_ = new Ppu();
	bus_ = new Bus(*cpu_, *ppu_, *cpu_ram_);

	cpu_->SetBus(bus_);
}

Nes::~Nes()
{
	delete bus_;
	delete cpu_ram_;
	delete cpu_;
}

void Nes::Clock() const
{
	cpu_->Clock();
}


uint8_t* Nes::GetCpuRam() const
{
	return cpu_ram_->GetMemory();
}

void Nes::SetINesHandle(INes* i_nes)
{
	this->i_nes_ = i_nes;
	this->bus_->SetINesHandle(i_nes);
}

void Nes::Reset()
{
	cpu_->Reset();
}

