#include "pch.h"
#include "Bus.h"

Bus::Bus(Cpu& cpu, Ram& ram)
: cpu(cpu), ram(ram) {

	cpu.SetBus(this);
}

Bus::~Bus()
{
}
