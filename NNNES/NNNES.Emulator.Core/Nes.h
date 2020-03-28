#pragma once
#include "INes.h"
#include "Device.h"

class Cpu;
class Ppu;
class Bus;
class CpuRam;

class Nes
{
private:
	Cpu* cpu_;
	Ppu* ppu_;
	CpuRam* cpu_ram_;
	Bus* bus_;
	INes* i_nes_;
		
public:
	Nes();
	~Nes();

	void Clock() const;
	uint8_t* GetCpuRam() const;
	auto GetCpu() const -> Cpu* { return cpu_; }
	void SetINesHandle(INes* i_nes);
	void Reset();
};

typedef Nes* NesHandle;

#include "Cpu.h"
#include "Ppu.h"
#include "Ram.h"
#include "Bus.h"