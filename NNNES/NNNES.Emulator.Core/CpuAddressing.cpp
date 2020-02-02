#include "pch.h"
#include "Cpu.h"

uint8_t Cpu::ZeroPageX()
{
	const uint16_t arg = Read(ProgramCounter()++);
	absolute_address_ = arg + X() & 0xFF;
	return 0;
}

uint8_t Cpu::ZeroPageY()
{
	const auto arg = Read(ProgramCounter()++);
	absolute_address_ = arg + Y() & 0xFF;
	return 0;
}

uint8_t Cpu::AbsoluteX()
{
	const uint16_t lower = Read(ProgramCounter()++);
	const uint16_t higher = Read(ProgramCounter()++);

	absolute_address_ = (higher << 8 | lower) + X();

	if ((absolute_address_ & 0xFF00) != higher << 8)
	{
		return 1;
	}
	else
	{
		return 0;
	}
}

uint8_t Cpu::AbsoluteY()
{
	const uint16_t lower = Read(ProgramCounter()++);
	const uint16_t higher = Read(ProgramCounter()++);

	absolute_address_ = (higher << 8 | lower) + Y();

	if ((absolute_address_ & 0xFF00) != higher << 8)
	{
		return 1;
	}
	else
	{
		return 0;
	}
}

uint8_t Cpu::IndirectX()
{
	const uint16_t arg = Read(ProgramCounter()++);
	const uint16_t lower = Read((arg + X()) & 0xFF);
	const uint16_t higher = Read((arg + X() + 1) & 0xFF);

	absolute_address_ = higher << 8 | lower;

	return 0;
}

uint8_t Cpu::IndirectY()
{
	const uint16_t arg = Read(ProgramCounter()++);
	const uint16_t lower = Read(arg);
	const uint16_t higher = Read(arg + 1 & 0xFF);

	absolute_address_ = (higher << 8 | lower) + Y();

	if ((absolute_address_ & 0xFF00) != (higher << 8))
	{
		return 1;
	}
	else
	{
		return 0;
	}
}

uint8_t Cpu::Implicit()
{
	return 0;
}

uint8_t Cpu::Immediate()
{
	absolute_address_ = ProgramCounter()++;
	return 0;
}

uint8_t Cpu::ZeroPage()
{
	const auto arg = Read(ProgramCounter()++);
	absolute_address_ = arg & 0xFF;
	return 0;
}

uint8_t Cpu::Absolute()
{
	const uint16_t lower = Read(ProgramCounter()++);
	const uint16_t higher = Read(ProgramCounter()++);
	absolute_address_ = higher << 8 | lower;
	return 0;
}


uint8_t Cpu::Relative()
{
	offset_ = Read(ProgramCounter()++);
	if (offset_ & 0x80)
	{
		offset_ |= 0xFF00;
	}
	return 0;
}


uint8_t Cpu::Indirect()
{
	uint16_t lower = Read(ProgramCounter()++);
	uint16_t higher = Read(ProgramCounter()++);

	const uint16_t target_address = higher << 8 | lower;
	higher = Read(target_address);
	lower = Read(target_address + 1);

	absolute_address_ = higher << 8 | lower;
	
	return 0;
}


