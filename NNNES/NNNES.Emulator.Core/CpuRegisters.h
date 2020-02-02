#pragma once
#include <cstdint>

struct CpuRegisters
{
	uint8_t accumulator;
	uint8_t x, y;
	uint16_t program_counter;
	uint8_t status;
	uint8_t stack_pointer;
};
