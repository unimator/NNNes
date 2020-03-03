#include "pch.h"
#include "Nes.h"
#include "Cpu.h"
#include "Ram.h"
#include "Bus.h"

Nes::Nes()
{
	cpu_ = new Cpu();
	ram_ = new Ram();
	bus_ = new Bus(*cpu_, *ram_);

	cpu_->SetBus(bus_);
}

Nes::~Nes()
{
	delete bus_;
	delete ram_;
	delete cpu_;
}

void Nes::Clock() const
{
	cpu_->Clock();
}


uint8_t* Nes::GetRam() const
{
	return ram_->GetRam();
}

void Nes::Reset()
{
	cpu_->Reset();
}

