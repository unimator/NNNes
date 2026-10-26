#pragma once
#include "Device.h"
#include "InstructionInfo.h"
#include <vector>

class Cpu;
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

	void Clock();
	void NextInstruction() const;
	void Reset();
};