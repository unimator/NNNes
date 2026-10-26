#include "pch.h"
#include "Nes.h"
#include "Cpu.h"
#include "Ram.h"
#include "Bus.h"

Nes::Nes()
{
	cpu_ = new Cpu();
	ram_ = new Ram();
	ppu_ = new Ppu();
	apu_ = new Apu();
	bus_ = new Bus();

	bus_->AddDevice(cpu_);
	bus_->AddDevice(ram_);
	bus_->AddDevice(ppu_);
	bus_->AddDevice(apu_);

}

Nes::~Nes()
{
	delete bus_;
	delete ram_;
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
	return ram_->GetMemory();
}

void Nes::SetINesHandle(INes* i_nes)
{
	if (this->i_nes_ != nullptr)
	{
		this->bus_->RemoveDevice(this->i_nes_);
	}
	this->i_nes_ = i_nes;
	this->bus_->AddDevice(this->i_nes_);
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

