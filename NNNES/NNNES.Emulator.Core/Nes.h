#pragma once
#include "Cpu.h"
#include "Ram.h"

class Nes
{
private:
	Cpu* cpu_;
	Ram* ram_;
	Bus* bus_;
	
public:
	Nes();
	~Nes();

	void Run();
	uint8_t* GetRam() const;
	auto GetCpu() const -> const Cpu* { return cpu_; }
};

typedef Nes* NesHandle;