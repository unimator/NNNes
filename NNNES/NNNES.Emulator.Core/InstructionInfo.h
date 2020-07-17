#pragma once
#include <cstdint>

enum AddressingMode;

struct InstructionInfo
{
	uint16_t address;
	char mnemonic[4];
	AddressingMode addressing_mode;
	uint8_t args_num;
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