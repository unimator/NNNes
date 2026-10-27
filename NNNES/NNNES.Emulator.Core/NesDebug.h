#pragma once
#include "Device.h"
#include "InstructionInfo.h"
#include "Cpu.h"
#include <vector>

class RamDebug;
class Bus;

class NesDebug
{
private:
	Cpu* cpu_;
	RamDebug* ram_debug_;
	Bus* bus_;

	uint64_t counter_ = 0x0;

public:
	NesDebug();
	~NesDebug();

	auto GetCpu() const -> Cpu* { return cpu_; }

	void Clock();
	void NextInstruction() const;
	void Reset();
};

typedef NesDebug* NesDebugHandle;