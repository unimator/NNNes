#pragma once
#include "Cpu.h"
#include "Ram.h"

class Bus
{
public:
	Cpu& cpu;
	Ram& ram;

	Bus(Cpu& cpu, Ram& ram);
	~Bus();
};
