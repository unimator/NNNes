#pragma once
#include "INes.h"
#include "Device.h"
#include "InstructionInfo.h"
#include <vector>

class Cpu;
class Ppu;
class Bus;
class Apu;
class CpuRam;

class Nes
{
private:
	Cpu* cpu_;
	Ppu* ppu_;
	Apu* apu_;
	CpuRam* cpu_ram_;
	Bus* bus_;
	INes* i_nes_ = nullptr;

	uint64_t counter_ = 0x0;
		
public:
	Nes();
	~Nes();

	uint8_t* GetCpuRam() const;
	auto GetCpu() const -> Cpu* { return cpu_; }

	void SetINesHandle(INes* i_nes);
	auto GetINesHandle() const -> const INes& { return *this->i_nes_; }
	
	void Clock();
	void NextInstruction() const;
	void Reset();

public:
	std::vector<InstructionInfo> Disassemble(const uint16_t start_address, const uint16_t end_address);
	std::vector<InstructionInfo> DisassembleByCount(const uint16_t start_address, size_t count);
};

typedef Nes* NesHandle;

#include "Cpu.h"
#include "Ppu.h"
#include "Ram.h"
#include "Bus.h"
#include "Apu.h"