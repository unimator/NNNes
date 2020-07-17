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
		Accumulator() = result & 0x00FF;
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
	absolute_address_ = ProgramCounter() + offset_;

	if ((absolute_address_ & 0xFF00) != (ProgramCounter() & 0xFF00))
	{
		cycles_++;
	}

	ProgramCounter() = absolute_address_;
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
	X() = Accumulator();
	SetFlag(Z, X() == 0x00);
	SetFlag(N, X() & 0x80);
	return 0;
}

uint8_t Cpu::TAY()
{
	Y() = Accumulator();
	SetFlag(Z, Y() == 0x00);
	SetFlag(N, Y() & 0x80);
	return 0;
}

uint8_t Cpu::TSX()
{
	X() = StackPointer();
	SetFlag(Z, X() == 0x00);
	SetFlag(N, X() & 0x80);
	return 0;
}


uint8_t Cpu::TXA()
{
	Accumulator() = X();
	SetFlag(Z, Accumulator() == 0x00);
	SetFlag(N, Accumulator() & 0x80);
	return 0;
}

uint8_t Cpu::TXS()
{
	Accumulator() = StackPointer();
	return 0;
}

uint8_t Cpu::TYA()
{
	Accumulator() = Y();
	SetFlag(Z, Accumulator() == 0x00);
	SetFlag(N, Accumulator() & 0x80);
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

	const auto temp = static_cast<uint16_t>(Accumulator()) + static_cast<uint16_t>(argument) + static_cast<uint16_t>(GetFlag(C));
	SetFlag(C, temp > 255);
	SetFlag(Z, (temp & 0x00FF) == 0);
	SetFlag(V, (~(static_cast<uint16_t>(Accumulator()) ^ static_cast<uint16_t>(argument))& (static_cast<uint16_t>(argument) ^ static_cast<uint16_t>(temp))) & 0x0080);
	SetFlag(N, temp & 0x80);
	Accumulator() = temp & 0x00FF;
	return 1;
}


uint8_t Cpu::SBC()
{
	const auto argument = Fetch();

	const uint16_t value = static_cast<uint16_t>(argument) ^ 0x00FF;
	const auto temp = static_cast<uint16_t>(Accumulator()) + value + static_cast<uint16_t>(GetFlag(C));
	SetFlag(C, temp & 0xFF00);
	SetFlag(Z, ((temp & 0x00FF) == 0));
	SetFlag(V, (temp ^ static_cast<uint16_t>(Accumulator()))& (temp ^ value) & 0x0080);
	SetFlag(N, temp & 0x0080);
	Accumulator() = temp & 0x00FF;
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
	X()++;
	SetFlag(Z, X() == 0x00);
	SetFlag(N, X() & 0x80);
	return 0;
}

uint8_t Cpu::INY()
{
	Y()++;
	SetFlag(Z, Y() == 0x00);
	SetFlag(N, Y() & 0x80);
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
	X()--;
	SetFlag(Z, X() == 0x00);
	SetFlag(N, X() & 0x80);
	return 0;
}

uint8_t Cpu::DEY()
{
	Y()--;
	SetFlag(Z, Y() == 0x00);
	SetFlag(N, Y() & 0x80);
	return 0;
}
#pragma endregion

#pragma region Logic
uint8_t Cpu::AND()
{
	Accumulator() = Accumulator() & Fetch();
	SetFlag(Z, Accumulator() == 0x00);
	SetFlag(Z, Accumulator() & 0x80);
	return 1;
}

uint8_t Cpu::BIT()
{
	const auto argument = Fetch();
	const auto temp = Accumulator() & argument;
	SetFlag(Z, (temp & 0x00FF) == 0x00);
	SetFlag(N, argument & (1 << 7));
	SetFlag(V, argument & (1 << 6));
	return 0;
}

uint8_t Cpu::EOR()
{
	const auto argument = Fetch();
	Accumulator() = Accumulator() ^ argument;
	SetFlag(Z, Accumulator() == 0x00);
	SetFlag(N, Accumulator() & 0x80);
	return 1;
}

uint8_t Cpu::ORA()
{
	const auto argument = Fetch();
	Accumulator() = Accumulator() | argument;
	SetFlag(Z, Accumulator() == 0x00);
	SetFlag(N, Accumulator() & 0x80);
	return 1;
}
#pragma endregion

#pragma region Comparison
uint8_t Cpu::CMP()
{
	const auto argument = Fetch();
	const auto temp = static_cast<uint16_t>(Accumulator()) - static_cast<uint16_t>(argument);
	SetFlag(C, Accumulator() >= temp);
	SetFlag(Z, (temp & 0x00FF) == 0x0000);
	SetFlag(N, temp & 0x0080);
	return 1;
}

uint8_t Cpu::CPX()
{
	const auto argument = Fetch();
	const auto temp = static_cast<uint16_t>(X()) - static_cast<uint16_t>(argument);
	SetFlag(C, X() >= argument);
	SetFlag(Z, (temp & 0x00FF) == 0x0000);
	SetFlag(N, temp & 0x0080);
	return 0;
}

uint8_t Cpu::CPY()
{
	const auto argument = Fetch();
	const auto temp = static_cast<uint16_t>(Y()) - static_cast<uint16_t>(argument);
	SetFlag(C, Y() >= argument);
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
	ProgramCounter()++;

	SetFlag(I, true);
	Write(0x0100 + StackPointer(), (ProgramCounter() >> 8) & 0x00FF);
	StackPointer()--;
	Write(0x0100 + StackPointer(), ProgramCounter() & 0x00FF);
	StackPointer()--;

	SetFlag(B, 1);
	Write(0x0100 + StackPointer(), Status());
	StackPointer()--;
	SetFlag(B, 0);

	ProgramCounter() = static_cast<uint16_t>(Read(0xFFFE)) | static_cast<uint16_t>(Read(0xFFFF)) << 8;
	return 0;
}

uint8_t Cpu::JMP()
{
	ProgramCounter() = absolute_address_;
	return 0;
}

uint8_t Cpu::JSR()
{
	ProgramCounter()--;

	const auto higher = (ProgramCounter() >> 8) & 0x00FF;
	const auto lower = ProgramCounter() & 0x00FF;
	Push(higher);
	Push(lower);

	ProgramCounter() = absolute_address_;
	return 0;
}


uint8_t Cpu::RTI()
{
	Status() = Pop();
	Status() &= ~B;
	Status() &= ~U;

	ProgramCounter() = Pop();
	ProgramCounter() |= Pop() << 8;
	return 0;
}

uint8_t Cpu::RTS()
{
	ProgramCounter() = Pop();
	ProgramCounter() |= Pop() << 8;

	ProgramCounter()++;
	return 0;
}

#pragma endregion

#pragma region Store&Load
uint8_t Cpu::LDA()
{
	const auto argument = Fetch();
	Accumulator() = argument;
	SetFlag(Z, Accumulator() == 0x00);
	SetFlag(N, Accumulator() & 0x80);
	return 1;
}

uint8_t Cpu::LDX()
{
	const auto argument = Fetch();
	X() = argument;
	SetFlag(Z, X() == 0x00);
	SetFlag(N, X() & 0x80);
	return 1;
}


uint8_t Cpu::LDY()
{
	const auto argument = Fetch();
	Y() = argument;
	SetFlag(Z, Y() == 0x00);
	SetFlag(N, Y() & 0x80);
	return 1;
}

uint8_t Cpu::STA()
{
	Write(absolute_address_, Accumulator());
	return 0;
}

uint8_t Cpu::STX()
{
	Write(absolute_address_, X());
	return 0;
}

uint8_t Cpu::STY()
{
	Write(absolute_address_, Y());
	return 0;
}

uint8_t Cpu::PHA()
{
	Push(Accumulator());
	return 0;
}

uint8_t Cpu::PHP()
{
	Push(Status() | B | U);
	SetFlag(B, 0);
	SetFlag(U, 0);
	return 0;
}

uint8_t Cpu::PLA()
{
	Accumulator() = Pop();
	SetFlag(Z, Accumulator() == 0x00);
	SetFlag(N, Accumulator() & 0x80);
	return 0;
}

uint8_t Cpu::PLP()
{
	Status() = Pop();
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

uint8_t Cpu::XXX()
{
	return 0;
}