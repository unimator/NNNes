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
	apu_ = new Apu();
	bus_ = new Bus(*cpu_, *ppu_, *apu_, *cpu_ram_);

	cpu_->SetBus(bus_);
}

Nes::~Nes()
{
	delete bus_;
	delete cpu_ram_;
	delete cpu_;
	delete ppu_;
}

void Nes::Clock()
{
	if(counter_ % 3 == 0)
	{
		cpu_->Clock();
	}
	ppu_->Clock();
	++counter_;
}

void Nes::NextInstruction() const
{
	cpu_->NextInstruction();
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
	counter_ = 0;
	cpu_->Reset();
}

std::vector<InstructionInfo> Nes::Disassemble(const uint16_t start_address, const uint16_t end_address)
{
	auto address = start_address;
	std::vector<InstructionInfo> result;

	while (address >= start_address && address <= end_address)
	{
		result.push_back(cpu_->DisassembleInstruction(address));
	}

	return result;
}

std::vector<InstructionInfo> Nes::DisassembleByCount(const uint16_t start_address, size_t count)
{
	auto address = start_address;
	std::vector<InstructionInfo> result;

	while (address <= 0xFFFF && count > 0 && address >= start_address)
	{
		result.push_back(cpu_->DisassembleInstruction(address));
		--count;
	}

	return result;
}

