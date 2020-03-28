#pragma once
#include <cstdint>
#include <string>

enum AddressingMode;

struct Instruction
{
	uint16_t address;
	std::string mnemonic;
	AddressingMode addressing_mode;
	uint8_t arg1, arg2;
};

enum AddressingMode
{
	Immediate = 0,
	Implicit = 1,
	Relative = 2,
	ZeroPage = 3,
	ZeroPageX = 4,
	ZeroPageY = 5,
	Absolute = 6,
	AbsoluteX = 7,
	AbsoluteY = 8,
	Indirect = 9,
	IndirectX = 10,
	IndirectY = 11
};