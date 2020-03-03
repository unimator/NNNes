#pragma once
#include "Cpu.h"
#include "Ram.h"
#include "INes.h"


class Nes
{
private:
	Cpu* cpu_;
	Ram* ram_;
	Bus* bus_;
	INes* i_nes_;
		
public:
	Nes();
	~Nes();

	void Clock() const;
	uint8_t* GetRam() const;
	auto GetCpu() const -> Cpu* { return cpu_; }
	auto SetINesHandle(INes* i_nes) -> void { i_nes_ = i_nes; }
	void Reset();
};

typedef Nes* NesHandle;