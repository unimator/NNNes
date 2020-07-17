#include "pch.h"
#include "Nes.h"
#include <vector>

Cpu::Cpu()
	: registers_(CpuRegisters {0x00, 0x00, 0x00, 0x0000, 0x00, 0x00})
{
	instructions_set_ =
	{
		{0x00, {"BRK", &Cpu::BRK, &Cpu::Implicit, 7}},
		{0x01, {"ORA", &Cpu::ORA, &Cpu::IndirectX, 6}},
		{0x05, {"ORA", &Cpu::ORA, &Cpu::ZeroPage, 3}},
		{0x06, {"ASL", &Cpu::ASL, &Cpu::ZeroPage, 5}},
		{0x08, {"PHP", &Cpu::PHP, &Cpu::Implicit, 3}},
		{0x09, {"ORA", &Cpu::ORA, &Cpu::Immediate, 2}},
		{0x0a, {"ASL", &Cpu::ASL, &Cpu::Implicit, 2}},
		{0x0d, {"ORA", &Cpu::ORA, &Cpu::Absolute, 4}},
		{0x0e, {"ASL", &Cpu::ASL, &Cpu::Absolute, 6}},

		{0x10, {"BPL", &Cpu::BRK, &Cpu::Relative, 2}},
		{0x11, {"ORA", &Cpu::ORA, &Cpu::IndirectY, 5}},
		{0x15, {"ORA", &Cpu::ORA, &Cpu::ZeroPageX, 4}},
		{0x16, {"ASL", &Cpu::ASL, &Cpu::ZeroPageX, 6}},
		{0x18, {"CLC", &Cpu::CLC, &Cpu::Implicit, 2}},
		{0x19, {"ORA", &Cpu::ORA, &Cpu::AbsoluteY, 4}},
		{0x1d, {"ORA", &Cpu::ORA, &Cpu::AbsoluteX, 4}},
		{0x1e, {"ASL", &Cpu::ASL, &Cpu::AbsoluteX, 7}},

		{0x20, {"JSR", &Cpu::JSR, &Cpu::Relative, 2}},
		{0x21, {"AND", &Cpu::AND, &Cpu::IndirectX, 6}},
		{0x22, {"BIT", &Cpu::BIT, &Cpu::ZeroPage, 3}},
		{0x25, {"AND", &Cpu::AND, &Cpu::ZeroPage, 3}},
		{0x26, {"ROL", &Cpu::ROL, &Cpu::ZeroPage, 5}},
		{0x28, {"PLP", &Cpu::PLP, &Cpu::Implicit, 4}},
		{0x29, {"AND", &Cpu::AND, &Cpu::Immediate, 2}},
		{0x2a, {"ROL", &Cpu::ROL, &Cpu::Implicit, 2}},
		{0x2c, {"BIT", &Cpu::BIT, &Cpu::Absolute, 4}},
		{0x2d, {"AND", &Cpu::AND, &Cpu::Absolute, 4}},
		{0x2e, {"ROL", &Cpu::ROL, &Cpu::Absolute, 6}},

		{0x30, {"BMI", &Cpu::BMI, &Cpu::Relative, 2}},
		{0x31, {"AND", &Cpu::AND, &Cpu::IndirectY, 5}},
		{0x35, {"AND", &Cpu::AND, &Cpu::ZeroPageX, 4}},
		{0x36, {"ROL", &Cpu::ROL, &Cpu::ZeroPageX, 6}},
		{0x38, {"SEC", &Cpu::SEC, &Cpu::Implicit, 2}},
		{0x39, {"AND", &Cpu::AND, &Cpu::AbsoluteY, 4}},
		{0x3d, {"AND", &Cpu::AND, &Cpu::AbsoluteX, 4}},
		{0x3e, {"ROL", &Cpu::ROL, &Cpu::AbsoluteX, 7}},

		{0x40, {"RTI", &Cpu::RTI, &Cpu::Implicit, 6}},
		{0x41, {"EOR", &Cpu::EOR, &Cpu::IndirectX, 6}},
		{0x45, {"EOR", &Cpu::EOR, &Cpu::ZeroPage, 3}},
		{0x46, {"LSR", &Cpu::LSR, &Cpu::ZeroPage, 5}},
		{0x48, {"PHA", &Cpu::PHA, &Cpu::Implicit, 3}},
		{0x49, {"EOR", &Cpu::EOR, &Cpu::Immediate, 2}},
		{0x4a, {"LSR", &Cpu::LSR, &Cpu::Implicit, 2}},
		{0x4c, {"JMP", &Cpu::JMP, &Cpu::Absolute, 3}},
		{0x4d, {"EOR", &Cpu::EOR, &Cpu::Absolute, 4}},
		{0x4e, {"LSR", &Cpu::LSR, &Cpu::Absolute, 6}},

		{0x50, {"BVC", &Cpu::BVC, &Cpu::Relative, 2}},
		{0x51, {"EOR", &Cpu::EOR, &Cpu::IndirectY, 5}},
		{0x55, {"EOR", &Cpu::EOR, &Cpu::ZeroPageX, 4}},
		{0x56, {"LSR", &Cpu::LSR, &Cpu::ZeroPageX, 6}},
		{0x58, {"CLI", &Cpu::CLI, &Cpu::Implicit, 2}},
		{0x59, {"EOR", &Cpu::EOR, &Cpu::AbsoluteY, 4}},
		{0x5d, {"EOR", &Cpu::EOR, &Cpu::AbsoluteX, 4}},
		{0x5e, {"LSR", &Cpu::LSR, &Cpu::AbsoluteX, 7}},

		{0x60, {"RTS", &Cpu::RTS, &Cpu::Implicit, 6}},
		{0x61, {"ADC", &Cpu::ADC, &Cpu::IndirectX, 6}},
		{0x65, {"ADC", &Cpu::ADC, &Cpu::ZeroPage, 3}},
		{0x66, {"ROR", &Cpu::ROR, &Cpu::ZeroPage, 5}},
		{0x68, {"PLA", &Cpu::PLA, &Cpu::Implicit, 4}},
		{0x69, {"ADC", &Cpu::ADC, &Cpu::Immediate, 2}},
		{0x6a, {"ROR", &Cpu::ROR, &Cpu::Implicit, 2}},
		{0x6c, {"JMP", &Cpu::JMP, &Cpu::Indirect, 3}},
		{0x6d, {"ADC", &Cpu::ADC, &Cpu::Absolute, 4}},
		{0x6e, {"ROR", &Cpu::ROR, &Cpu::Absolute, 6}},

		{0x70, {"BVS", &Cpu::BVS, &Cpu::Relative, 2}},
		{0x71, {"ADC", &Cpu::ADC, &Cpu::IndirectY, 5}},
		{0x75, {"ADC", &Cpu::ADC, &Cpu::ZeroPageX, 4}},
		{0x76, {"ROR", &Cpu::ROR, &Cpu::ZeroPageX, 6}},
		{0x78, {"SEI", &Cpu::SEI, &Cpu::Implicit, 2}},
		{0x79, {"ADC", &Cpu::ADC, &Cpu::AbsoluteY, 4}},
		{0x7d, {"ADC", &Cpu::ADC, &Cpu::AbsoluteX, 4}},
		{0x7e, {"ROR", &Cpu::ROR, &Cpu::AbsoluteX, 7}},

		{0x81, {"STA", &Cpu::STA, &Cpu::IndirectX, 6}},
		{0x84, {"STY", &Cpu::STY, &Cpu::ZeroPage, 3}},
		{0x85, {"STA", &Cpu::STA, &Cpu::ZeroPage, 3}},
		{0x86, {"STX", &Cpu::STX, &Cpu::ZeroPage, 3}},
		{0x88, {"DEY", &Cpu::DEY, &Cpu::Implicit, 2}},
		{0x8a, {"TXA", &Cpu::TXA, &Cpu::Implicit, 2}},
		{0x8c, {"STY", &Cpu::STY, &Cpu::Absolute, 4}},
		{0x8d, {"STA", &Cpu::STA, &Cpu::Absolute, 4}},
		{0x8e, {"STX", &Cpu::STX, &Cpu::Absolute, 4}},

		{0x90, {"BCC", &Cpu::BCC, &Cpu::Relative, 2}},
		{0x91, {"STA", &Cpu::STA, &Cpu::IndirectY, 6}},
		{0x94, {"STY", &Cpu::STY, &Cpu::ZeroPageX, 4}},
		{0x95, {"STA", &Cpu::STA, &Cpu::ZeroPageX, 4}},
		{0x96, {"STX", &Cpu::STX, &Cpu::ZeroPageX, 4}},
		{0x98, {"TYA", &Cpu::TYA, &Cpu::Implicit, 2}},
		{0x99, {"STA", &Cpu::STA, &Cpu::AbsoluteY, 5}},
		{0x9a, {"TXS", &Cpu::TXS, &Cpu::Implicit, 2}},
		{0x9d, {"STA", &Cpu::STA, &Cpu::AbsoluteX, 5}},

		{0xa0, {"LDY", &Cpu::LDY, &Cpu::Immediate, 2}},
		{0xa1, {"LDA", &Cpu::LDA, &Cpu::IndirectX, 6}},
		{0xa2, {"LDX", &Cpu::LDX, &Cpu::Immediate, 2}},
		{0xa4, {"LDY", &Cpu::LDY, &Cpu::ZeroPage, 3}},
		{0xa5, {"LDA", &Cpu::LDA, &Cpu::ZeroPage, 3}},
		{0xa6, {"LDX", &Cpu::LDX, &Cpu::ZeroPage, 3}},
		{0xa8, {"TAY", &Cpu::TAY, &Cpu::Implicit, 2}},
		{0xa9, {"LDA", &Cpu::LDA, &Cpu::Immediate, 2}},
		{0xaa, {"TAX", &Cpu::TAX, &Cpu::Implicit, 2}},
		{0xac, {"LDY", &Cpu::LDY, &Cpu::Absolute, 4}},
		{0xad, {"LDA", &Cpu::LDA, &Cpu::Absolute, 4}},
		{0xae, {"LDX", &Cpu::LDX, &Cpu::Absolute, 4}},

		{0xb0, {"BCS", &Cpu::BCS, &Cpu::Relative, 2}},
		{0xb1, {"LDA", &Cpu::LDA, &Cpu::IndirectY, 5}},
		{0xb4, {"LDY", &Cpu::LDY, &Cpu::ZeroPageX, 4}},
		{0xb5, {"LDA", &Cpu::LDA, &Cpu::ZeroPageX, 4}},
		{0xb6, {"LDX", &Cpu::LDX, &Cpu::ZeroPageY, 4}},
		{0xb8, {"CLV", &Cpu::CLV, &Cpu::Implicit, 2}},
		{0xb9, {"LDA", &Cpu::LDA, &Cpu::ZeroPageY, 4}},
		{0xba, {"TSX", &Cpu::TSX, &Cpu::Implicit, 2}},
		{0xbc, {"LDY", &Cpu::LDY, &Cpu::AbsoluteX, 4}},
		{0xbd, {"LDA", &Cpu::LDA, &Cpu::AbsoluteX, 4}},
		{0xbe, {"LDX", &Cpu::LDX, &Cpu::AbsoluteX, 4}},

		{0xc0, {"CPY", &Cpu::CPY, &Cpu::Immediate, 2}},
		{0xc1, {"CMP", &Cpu::CMP, &Cpu::IndirectX, 6}},
		{0xc4, {"CPY", &Cpu::CPY, &Cpu::ZeroPage, 3}},
		{0xc5, {"CMP", &Cpu::CMP, &Cpu::ZeroPage, 3}},
		{0xc6, {"DEC", &Cpu::DEC, &Cpu::ZeroPage, 5}},
		{0xc8, {"INY", &Cpu::INY, &Cpu::Implicit, 2}},
		{0xc9, {"CMP", &Cpu::CMP, &Cpu::Immediate, 2}},
		{0xca, {"DEX", &Cpu::DEX, &Cpu::Implicit, 2}},
		{0xcc, {"CPY", &Cpu::CPY, &Cpu::Absolute, 4}},
		{0xcd, {"CMP", &Cpu::CMP, &Cpu::Absolute, 4}},
		{0xce, {"DEC", &Cpu::DEC, &Cpu::Absolute, 6}},

		{0xd0, {"BNE", &Cpu::BNE, &Cpu::Relative, 2}},
		{0xd1, {"CMP", &Cpu::CMP, &Cpu::IndirectY, 5}},
		{0xd5, {"CMP", &Cpu::CMP, &Cpu::ZeroPageX, 4}},
		{0xd6, {"DEC", &Cpu::DEC, &Cpu::ZeroPageX, 6}},
		{0xd8, {"CLD", &Cpu::CLD, &Cpu::Implicit, 2}},
		{0xd9, {"CMP", &Cpu::CMP, &Cpu::AbsoluteY, 4}},
		{0xdd, {"CMP", &Cpu::CMP, &Cpu::AbsoluteX, 4}},
		{0xde, {"DEC", &Cpu::DEC, &Cpu::AbsoluteX, 7}},

		{0xe0, {"CPX", &Cpu::CPX, &Cpu::Immediate, 2}},
		{0xe1, {"SBC", &Cpu::SBC, &Cpu::IndirectX, 6}},
		{0xe4, {"CPX", &Cpu::CPX, &Cpu::ZeroPage, 3}},
		{0xe5, {"SBC", &Cpu::SBC, &Cpu::ZeroPage, 3}},
		{0xe6, {"INC", &Cpu::INC, &Cpu::ZeroPage, 5}},
		{0xe8, {"INX", &Cpu::INX, &Cpu::Implicit, 2}},
		{0xe9, {"SBC", &Cpu::SBC, &Cpu::Immediate, 2}},
		{0xea, {"NOP", &Cpu::NOP, &Cpu::Implicit, 2}},
		{0xec, {"CPX", &Cpu::CPX, &Cpu::Absolute, 4}},
		{0xed, {"SBC", &Cpu::SBC, &Cpu::Absolute, 4}},
		{0xee, {"INC", &Cpu::INC, &Cpu::Absolute, 6}},

		{0xf0, {"BEQ", &Cpu::BEQ, &Cpu::Relative, 2}},
		{0xf1, {"SBC", &Cpu::SBC, &Cpu::IndirectY, 5}},
		{0xf5, {"SBC", &Cpu::SBC, &Cpu::ZeroPageX, 4}},
		{0xf6, {"INC", &Cpu::INC, &Cpu::ZeroPageX, 6}},
		{0xf8, {"SED", &Cpu::SED, &Cpu::Implicit, 2}},
		{0xf9, {"SBC", &Cpu::SBC, &Cpu::AbsoluteY, 4}},
		{0xfd, {"SBC", &Cpu::SBC, &Cpu::AbsoluteX, 4}},
		{0xfe, {"INC", &Cpu::INC, &Cpu::AbsoluteX, 7}}
	};

	for(auto i = 0x00; i <= 0xFF; ++i)
	{
		if(instructions_set_.count(i) == 0)
		{
			auto instruction = Instruction{ "XXX", &Cpu::XXX, &Cpu::Implicit, 0 };
			instructions_set_.insert({ i, instruction });
		}
	}
}

Cpu::~Cpu()
{
	
}

void Cpu::Write(const uint16_t address, const uint8_t data) const
{
	bus_->Write(address, data);
}

uint8_t Cpu::Read(const uint16_t address)
{
	return bus_->Read(address);
}

void Cpu::Clock()
{
	if (cycles_ == 0)
	{
		current_opcode_ = Read(ProgramCounter());
		ProgramCounter()++;

		cycles_ = instructions_set_[current_opcode_].cycles;

		const auto extra_cycle_address = (this->*instructions_set_[current_opcode_].address_mode)();
		const auto extra_cycle_operate = (this->*instructions_set_[current_opcode_].operate)();

		cycles_ += (extra_cycle_address & extra_cycle_operate);
	}

	cycles_--;
}

void Cpu::NextInstruction()
{
	do
	{
		Clock();
	} while (cycles_ > 0);
}

void Cpu::SetFlag(const Flags flag, const bool value)
{
	if (value)
	{
		Status() |= flag;
	}
	else
	{
		Status() &= ~flag;
	}
}

bool Cpu::GetFlag(const Flags flag)
{
	return Status() & flag;
}

void Cpu::Push(uint8_t arg)
{
	Write(0x100 + StackPointer()--, arg);
}

uint8_t Cpu::Pop()
{
	return Read(0x100 + ++StackPointer());
}

void Cpu::Reset()
{
	Accumulator() = 0x00;
	X() = 0x00;
	Y() = 0x00;
	StackPointer() = 0xFD;
	Status() = 0x00 | U;

	const auto start_address = 0xFFFC;
	ProgramCounter() = (Read(start_address + 1) << 8) | Read(start_address);

	absolute_address_ = 0x00;
	offset_ = 0x00;

	cycles_ = 8;
}

void Cpu::Interrupt(uint16_t address)
{
	Push((ProgramCounter() >> 8) & 0x00FF);
	Push(ProgramCounter() & 0x00FF);

	SetFlag(B, false);
	SetFlag(U, true);
	SetFlag(I, true);

	Push(Status());

	const auto interrupt_handler = address;
	ProgramCounter() = Read(interrupt_handler << 8) | Read(interrupt_handler);

	cycles_ = 7;
}


void Cpu::InterruptRequest()
{
	if(GetFlag(I) == 0)
	{
		const auto interrupt_handler = 0xFFFE;
		Interrupt(interrupt_handler);
	}
}

void Cpu::NonMaskedInterruptRequest()
{
	const auto interrupt_handler = 0xFFFA;
	Interrupt(interrupt_handler);
}


InstructionInfo Cpu::DisassembleInstruction(uint16_t& address)
{
	const auto opcode = Read(address);

	auto get_addressing_mode = [](auto address_mode)
	{
		if (address_mode == &Cpu::Implicit)
		{
			return AddressingMode::Implicit;
		}
		else if (address_mode == &Cpu::Immediate)
		{
			return AddressingMode::Immediate;
		}
		else if (address_mode == &Cpu::Absolute)
		{
			return AddressingMode::Absolute;
		}
		else if (address_mode == &Cpu::AbsoluteX)
		{
			return AddressingMode::AbsoluteX;
		}
		else if (address_mode == &Cpu::AbsoluteY)
		{
			return AddressingMode::AbsoluteY;
		}
		else if (address_mode == &Cpu::Indirect)
		{
			return AddressingMode::Indirect;
		}
		else if (address_mode == &Cpu::IndirectX)
		{
			return AddressingMode::IndirectX;
		}
		else if (address_mode == &Cpu::IndirectY)
		{
			return AddressingMode::IndirectY;
		}
		else if (address_mode == &Cpu::ZeroPage)
		{
			return AddressingMode::ZeroPage;
		}
		else if (address_mode == &Cpu::ZeroPageX)
		{
			return AddressingMode::ZeroPageX;
		}
		else if (address_mode == &Cpu::ZeroPageY)
		{
			return AddressingMode::ZeroPageY;
		}
		else if (address_mode == &Cpu::Relative)
		{
			return AddressingMode::Relative;
		}
	};

	if (instructions_set_.count(opcode) == 0)
	{
		const auto empty_instruction = InstructionInfo
		{
			address,
			"---",
			AddressingMode::Implicit,
			0,0, 0
		};
		++address;
		return empty_instruction;
	}

	auto instruction_info = InstructionInfo();
	const auto instruction = instructions_set_[opcode];
	instruction_info.address = address;
	memcpy(instruction_info.mnemonic, instruction.name.c_str(), 4);
	const auto address_mode = instruction.address_mode;

	if (address_mode == &Cpu::Implicit)
	{
		instruction_info.args_num = 0;
	}
	else if (address_mode == &Cpu::Immediate
		|| address_mode == &Cpu::ZeroPage
		|| address_mode == &Cpu::ZeroPageX
		|| address_mode == &Cpu::ZeroPageY
		|| address_mode == &Cpu::Relative)
	{
		if(static_cast<uint32_t>(address + 1) > 0xFFFF)
		{
			return instruction_info;
		}
		instruction_info.args_num = 1;
		instruction_info.arg1 = Read(++address);
	}
	else if (address_mode == &Cpu::Absolute
		|| address_mode == &Cpu::AbsoluteX
		|| address_mode == &Cpu::AbsoluteY
		|| address_mode == &Cpu::Indirect
		|| address_mode == &Cpu::IndirectX
		|| address_mode == &Cpu::IndirectY)
	{
		if(static_cast<uint32_t>(address + 2) > 0xFFFF)
		{
			return instruction_info;
		}
		instruction_info.args_num = 2;
		instruction_info.arg1 = Read(++address);
		instruction_info.arg2 = Read(++address);
	}

	instruction_info.addressing_mode = get_addressing_mode(address_mode);

	++address;
	return instruction_info;
}
