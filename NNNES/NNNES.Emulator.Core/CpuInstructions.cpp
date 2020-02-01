#include "pch.h"
#include "Cpu.h"

uint8_t Cpu::Fetch()
{
	if (instructions_set_[current_opcode_].address_mode == &Cpu::Implicit)
	{
		return Accumulator();
	}
	else
	{
		return Read(absolute_address_);
	}
}

void Cpu::SaveResult(uint8_t result)
{
	if (instructions_set_[current_opcode_].address_mode == &Cpu::Implicit)
	{
		accumulator_ = result & 0x00FF;
	}
	else
	{
		Write(absolute_address_, result & 0x00FF);
	}
}

#pragma region Branching
void Cpu::DoBranch()
{
	cycles_++;
	absolute_address_ = program_counter_ + offset_;

	if ((absolute_address_ & 0xFF00) != (program_counter_ & 0xFF00))
	{
		cycles_++;
	}

	program_counter_ = absolute_address_;
}

uint8_t Cpu::BCC()
{
	if (GetFlag(C) == 0)
	{
		DoBranch();
	}
	return 0;
}

uint8_t Cpu::BCS()
{
	if (GetFlag(C) == 1)
	{
		DoBranch();
	}
	return 0;
}

uint8_t Cpu::BNE()
{
	if (GetFlag(Z) == 0)
	{
		DoBranch();
	}
	return 0;
}

uint8_t Cpu::BEQ()
{
	if (GetFlag(Z) == 1)
	{
		DoBranch();
	}
	return 0;
}

uint8_t Cpu::BPL()
{
	if (GetFlag(N) == 0)
	{
		DoBranch();
	}
	return 0;
}

uint8_t Cpu::BMI()
{
	if (GetFlag(N) == 1)
	{
		DoBranch();
	}
	return 0;
}

uint8_t Cpu::BVC()
{
	if (GetFlag(V) == 0)
	{
		DoBranch();
	}
	return 0;
}

uint8_t Cpu::BVS()
{
	if (GetFlag(V) == 1)
	{
		DoBranch();
	}
	return 0;
}
#pragma endregion 

#pragma region Transfer

uint8_t Cpu::TAX()
{
	x_ = accumulator_;
	SetFlag(Z, x_ == 0x00);
	SetFlag(N, x_ & 0x80);
	return 0;
}

uint8_t Cpu::TAY()
{
	y_ = accumulator_;
	SetFlag(Z, y_ == 0x00);
	SetFlag(N, y_ & 0x80);
	return 0;
}

uint8_t Cpu::TSX()
{
	x_ = stack_pointer_;
	SetFlag(Z, x_ == 0x00);
	SetFlag(N, x_ & 0x80);
	return 0;
}


uint8_t Cpu::TXA()
{
	accumulator_ = x_;
	SetFlag(Z, accumulator_ == 0x00);
	SetFlag(N, accumulator_ & 0x80);
	return 0;
}

uint8_t Cpu::TXS()
{
	accumulator_ = stack_pointer_;
	return 0;
}

uint8_t Cpu::TYA()
{
	accumulator_ = y_;
	SetFlag(Z, accumulator_ == 0x00);
	SetFlag(N, accumulator_ & 0x80);
	return 0;
}
#pragma endregion

#pragma region Flags
uint8_t Cpu::CLC()
{
	SetFlag(C, false);
	return 0;
}

uint8_t Cpu::CLD()
{
	SetFlag(D, false);
	return 0;
}


uint8_t Cpu::CLI()
{
	SetFlag(I, false);
	return 0;
}

uint8_t Cpu::CLV()
{
	SetFlag(V, false);
	return 0;
}

uint8_t Cpu::SEC()
{
	SetFlag(C, true);
	return 0;
}

uint8_t Cpu::SED()
{
	SetFlag(D, true);
	return 0;
}

uint8_t Cpu::SEI()
{
	SetFlag(I, true);
	return 0;
}
#pragma endregion

#pragma region Arithemetic
uint8_t Cpu::ADC()
{
	const auto argument = Fetch();

	const auto temp = static_cast<uint16_t>(accumulator_) + static_cast<uint16_t>(argument) + static_cast<uint16_t>(GetFlag(C));
	SetFlag(C, temp > 255);
	SetFlag(Z, (temp & 0x00FF) == 0);
	SetFlag(V, (~(static_cast<uint16_t>(accumulator_) ^ static_cast<uint16_t>(argument))& (static_cast<uint16_t>(argument) ^ static_cast<uint16_t>(temp))) & 0x0080);
	SetFlag(N, temp & 0x80);
	accumulator_ = temp & 0x00FF;
	return 1;
}


uint8_t Cpu::SBC()
{
	const auto argument = Fetch();

	const uint16_t value = static_cast<uint16_t>(argument) ^ 0x00FF;
	const auto temp = static_cast<uint16_t>(accumulator_) + value + static_cast<uint16_t>(GetFlag(C));
	SetFlag(C, temp & 0xFF00);
	SetFlag(Z, ((temp & 0x00FF) == 0));
	SetFlag(V, (temp ^ static_cast<uint16_t>(accumulator_))& (temp ^ value) & 0x0080);
	SetFlag(N, temp & 0x0080);
	accumulator_ = temp & 0x00FF;
	return 1;
}

uint8_t Cpu::INC()
{
	const auto argument = Fetch();
	const auto temp = argument + 1;
	Write(absolute_address_, temp & 0x00FF);
	SetFlag(Z, (temp & 0x00FF) == 0x0000);
	SetFlag(N, temp & 0x0080);
	return 0;
}


uint8_t Cpu::INX()
{
	x_++;
	SetFlag(Z, x_ == 0x00);
	SetFlag(N, x_ & 0x80);
	return 0;
}

uint8_t Cpu::INY()
{
	y_++;
	SetFlag(Z, y_ == 0x00);
	SetFlag(N, y_ & 0x80);
	return 0;
}

uint8_t Cpu::DEC()
{
	const auto argument = Fetch();
	const auto temp = argument - 1;
	Write(absolute_address_, temp & 0x00FF);
	SetFlag(Z, (temp & 0x00FF) == 0x0000);
	SetFlag(N, temp & 0x0080);
	return 0;
}

uint8_t Cpu::DEX()
{
	x_--;
	SetFlag(Z, x_ == 0x00);
	SetFlag(N, x_ & 0x80);
	return 0;
}

uint8_t Cpu::DEY()
{
	y_--;
	SetFlag(Z, y_ == 0x00);
	SetFlag(N, y_ & 0x80);
	return 0;
}
#pragma endregion

#pragma region Logic
uint8_t Cpu::AND()
{
	accumulator_ = accumulator_ & Fetch();
	SetFlag(Z, accumulator_ == 0x00);
	SetFlag(Z, accumulator_ & 0x80);
	return 1;
}

uint8_t Cpu::BIT()
{
	const auto argument = Fetch();
	const auto temp = accumulator_ & argument;
	SetFlag(Z, (temp & 0x00FF) == 0x00);
	SetFlag(N, argument & (1 << 7));
	SetFlag(V, argument & (1 << 6));
	return 0;
}

uint8_t Cpu::EOR()
{
	const auto argument = Fetch();
	accumulator_ = accumulator_ ^ argument;
	SetFlag(Z, accumulator_ == 0x00);
	SetFlag(N, accumulator_ & 0x80);
	return 1;
}

uint8_t Cpu::ORA()
{
	const auto argument = Fetch();
	accumulator_ = accumulator_ | argument;
	SetFlag(Z, accumulator_ == 0x00);
	SetFlag(N, accumulator_ & 0x80);
	return 1;
}
#pragma endregion

#pragma region Comparison
uint8_t Cpu::CMP()
{
	const auto argument = Fetch();
	const auto temp = static_cast<uint16_t>(accumulator_) - static_cast<uint16_t>(argument);
	SetFlag(C, accumulator_ >= temp);
	SetFlag(Z, (temp & 0x00FF) == 0x0000);
	SetFlag(N, temp & 0x0080);
	return 1;
}

uint8_t Cpu::CPX()
{
	const auto argument = Fetch();
	const auto temp = static_cast<uint16_t>(x_) - static_cast<uint16_t>(argument);
	SetFlag(C, x_ >= argument);
	SetFlag(Z, (temp & 0x00FF) == 0x0000);
	SetFlag(N, temp & 0x0080);
	return 0;
}

uint8_t Cpu::CPY()
{
	const auto argument = Fetch();
	const auto temp = static_cast<uint16_t>(y_) - static_cast<uint16_t>(argument);
	SetFlag(C, y_ >= argument);
	SetFlag(Z, (temp & 0x00FF) == 0x0000);
	SetFlag(N, temp & 0x0080);
	return 0;
}

#pragma endregion 

#pragma region Bitshifting
uint8_t Cpu::ASL()
{
	const auto argument = Fetch();
	const auto temp = static_cast<uint16_t>(argument) << 1;
	SetFlag(C, (temp & 0xFF00) > 0);
	SetFlag(Z, (temp & 0x00FF) == 0x00);
	SetFlag(N, temp & 0x80);
	SaveResult(temp);
	return 0;
}

uint8_t Cpu::LSR()
{
	const auto argument = Fetch();
	SetFlag(C, argument & 0x0001);
	const auto temp = argument >> 1;
	SetFlag(Z, (temp & 0x00FF) == 0x0000);
	SetFlag(N, temp & 0x0080);
	SaveResult(temp);
	return 0;
}

uint8_t Cpu::ROL()
{
	const auto argument = Fetch();
	const auto temp = static_cast<uint16_t>(argument << 1) | static_cast<uint16_t>(GetFlag(C));
	SetFlag(C, temp & 0xFF00);
	SetFlag(Z, (temp & 0x00FF) == 0x0000);
	SetFlag(N, temp & 0x0080);
	SaveResult(temp);
	return 0;
}

uint8_t Cpu::ROR()
{
	const auto argument = Fetch();
	const auto temp = static_cast<uint16_t>(GetFlag(C) << 7) | (argument >> 1);
	SetFlag(C, argument & 0x01);
	SetFlag(Z, (temp & 0x00FF) == 0x00);
	SetFlag(N, temp & 0x0080);
	SaveResult(temp);
	return 0;
}
#pragma endregion

#pragma region Interruptions&Subroutines
uint8_t Cpu::BRK()
{
	program_counter_++;

	SetFlag(I, true);
	Write(0x0100 + stack_pointer_, (program_counter_ >> 8) & 0x00FF);
	stack_pointer_--;
	Write(0x0100 + stack_pointer_, program_counter_ & 0x00FF);
	stack_pointer_--;

	SetFlag(B, 1);
	Write(0x0100 + stack_pointer_, status_);
	stack_pointer_--;
	SetFlag(B, 0);

	program_counter_ = static_cast<uint16_t>(Read(0xFFFE)) | static_cast<uint16_t>(Read(0xFFFF)) << 8;
	return 0;
}

uint8_t Cpu::JMP()
{
	program_counter_ = absolute_address_;
	return 0;
}

uint8_t Cpu::JSR()
{
	program_counter_--;

	const auto higher = (program_counter_ >> 8) & 0x00FF;
	const auto lower = program_counter_ & 0x00FF;
	Push(higher);
	Push(lower);

	program_counter_ = absolute_address_;
	return 0;
}


uint8_t Cpu::RTI()
{
	status_ = Pop();
	status_ &= ~B;
	status_ &= ~U;

	program_counter_ = Pop();
	program_counter_ |= Pop() << 8;
	return 0;
}

uint8_t Cpu::RTS()
{
	program_counter_ = Pop();
	program_counter_ |= Pop() << 8;

	program_counter_++;
	return 0;
}

#pragma endregion

#pragma region Store&Load
uint8_t Cpu::LDA()
{
	const auto argument = Fetch();
	accumulator_ = argument;
	SetFlag(Z, accumulator_ == 0x00);
	SetFlag(N, accumulator_ & 0x80);
	return 1;
}

uint8_t Cpu::LDX()
{
	const auto argument = Fetch();
	x_ = argument;
	SetFlag(Z, x_ == 0x00);
	SetFlag(N, x_ & 0x80);
	return 1;
}


uint8_t Cpu::LDY()
{
	const auto argument = Fetch();
	y_ = argument;
	SetFlag(Z, y_ == 0x00);
	SetFlag(N, y_ & 0x80);
	return 1;
}

uint8_t Cpu::STA()
{
	Write(absolute_address_, accumulator_);
	return 0;
}

uint8_t Cpu::STX()
{
	Write(absolute_address_, x_);
	return 0;
}

uint8_t Cpu::STY()
{
	Write(absolute_address_, y_);
	return 0;
}

uint8_t Cpu::PHA()
{
	Push(accumulator_);
	return 0;
}

uint8_t Cpu::PHP()
{
	Push(status_ | B | U);
	SetFlag(B, 0);
	SetFlag(U, 0);
	return 0;
}

uint8_t Cpu::PLA()
{
	accumulator_ = Pop();
	SetFlag(Z, accumulator_ == 0x00);
	SetFlag(N, accumulator_ & 0x80);
	return 0;
}

uint8_t Cpu::PLP()
{
	status_ = Pop();
	SetFlag(U, true);
	return 0;
}
#pragma endregion 

uint8_t Cpu::NOP()
{
	switch (current_opcode_)
	{
	case 0x1C:
	case 0x3C:
	case 0x5C:
	case 0x7C:
	case 0xDC:
	case 0xFC:
		return 1;
	}
	return 0;
}



