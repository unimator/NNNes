#include "pch.h"
#include "NesDebug.h"
#include "Cpu.h"
#include "RamDebug.h"
#include "Bus.h"

NesDebug::NesDebug()
{
	cpu_ = new Cpu();
	ram_debug_ = new RamDebug();
	bus_ = new Bus();

	bus_->AddDevice(cpu_);
	bus_->AddDevice(ram_debug_);
}

NesDebug::~NesDebug()
{
	delete bus_;
	delete ram_debug_;
	delete cpu_;
}

void NesDebug::Clock()
{
	if (counter_ % 3 == 0)
	{
		cpu_->Clock();
	}
	++counter_;
}

void NesDebug::NextInstruction() const
{
	cpu_->NextInstruction();
}

void NesDebug::Reset() 
{
	counter_ = 0;
	cpu_->Reset();
}
