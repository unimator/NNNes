#pragma once
#include <cstdint>
#include <string>
#include <map>
#include "Bus.h"
#include "CpuRegisters.h"

class Cpu
{
private:
	CpuRegisters registers_;

public:
	auto Accumulator() -> uint8_t& { return registers_.accumulator; }
	auto Accumulator() const -> const uint8_t& { return registers_.accumulator; }

	auto X() -> uint8_t& { return registers_.x; }
	auto X() const -> const uint8_t& { return registers_.x; }

	auto Y() -> uint8_t& { return registers_.y; }
	auto Y() const -> const uint8_t& { return registers_.y; }

	auto StackPointer() -> uint8_t& { return registers_.stack_pointer; }
	auto StackPointer() const -> const uint8_t& { return registers_.stack_pointer; }

	auto ProgramCounter() -> uint16_t& { return registers_.program_counter; }
	auto ProgramCounter() const -> const uint16_t& { return registers_.program_counter; }

	auto Status() -> uint8_t& { return registers_.status; }
	auto Status() const -> const uint8_t& { return registers_.status; }

	auto Registers() -> CpuRegisters& { return registers_; }
	auto Registers() const -> const CpuRegisters& { return registers_; }

private:
	// Addressing

	// Indexed
	uint8_t ZeroPageX();
	uint8_t ZeroPageY();
	uint8_t AbsoluteX();
	uint8_t AbsoluteY();
	uint8_t IndirectX();
	uint8_t IndirectY();
	
	// Non-Indexed
	uint8_t Implicit();
	uint8_t Immediate();
	uint8_t Absolute();
	uint8_t Indirect();
	uint8_t Relative();
	uint8_t ZeroPage();


private:
	uint32_t clock_count_ = 0;

	uint8_t cycles_ = 0x00;
	uint8_t current_opcode_ = 0x00;

	uint16_t absolute_address_ = 0x00;
	uint16_t offset_ = 0x00;
	
	void Push(uint8_t arg);
	uint8_t Pop();

	void SaveResult(uint8_t result);
public:
	Cpu();
	~Cpu();

private:
	Bus* bus_ = nullptr;

public:
	void SetBus(Bus* bus)
	{
		bus_ = bus;
	}
	
	void Write(uint16_t address, uint8_t data) const;
	uint8_t Read(uint16_t address);
	
	void Clock();
	void NextInstruction();

	void Reset();
	void Interrupt(uint16_t address);
	void InterruptRequest();
	void NonMaskedInterruptRequest();
			
	enum Flags
	{
		C = (1 << 0),
		Z = (1 << 1),
		I = (1 << 2),
		D = (1 << 3),
		B = (1 << 4),
		U = (1 << 5),
		V = (1 << 6),
		N = (1 << 7)
	};

	void SetFlag(Flags flag, bool value);
	bool GetFlag(Flags flag);

private:
	struct Instruction
	{
		std::string name;
		uint8_t (Cpu::*operate)(void) = nullptr;
		uint8_t (Cpu::*address_mode)(void) = nullptr;
		uint8_t cycles = 0;
	};

	std::map<uint16_t, Instruction> instructions_set_;
	   
	// Instructions
	uint8_t ADC();
	uint8_t AND();
	uint8_t ASL();

	// Branching
	uint8_t BCC();
	uint8_t BCS();
	uint8_t BEQ();
	uint8_t BIT();
	uint8_t BMI();
	uint8_t BNE();
	uint8_t BPL();
	void DoBranch();
	
	uint8_t BRK();
	uint8_t BVC();
	uint8_t BVS();
	uint8_t CLC();
	uint8_t CLD();
	uint8_t CLI();
	uint8_t CLV();
	uint8_t CMP();
	uint8_t CPX();
	uint8_t CPY();
	uint8_t DEC();
	uint8_t DEX();
	uint8_t DEY();
	uint8_t EOR();
	uint8_t INC();
	uint8_t INX();
	uint8_t INY();
	uint8_t JMP();
	uint8_t JSR();
	uint8_t LDA();
	uint8_t LDX();
	uint8_t LDY();
	uint8_t LSR();
	uint8_t NOP();
	uint8_t ORA();
	uint8_t PHA();
	uint8_t PHP();
	uint8_t PLA();
	uint8_t PLP();
	uint8_t ROL();
	uint8_t ROR();
	uint8_t RTI();
	uint8_t RTS();
	uint8_t SBC();
	uint8_t SEC();
	uint8_t SED();
	uint8_t SEI();
	uint8_t STA();
	uint8_t STX();
	uint8_t STY();
	uint8_t TAX();
	uint8_t TAY();
	uint8_t TSX();
	uint8_t TXA();
	uint8_t TXS();
	uint8_t TYA();
	uint8_t XXX();

	uint8_t Fetch();

public:
	InstructionInfo DisassembleInstruction(uint16_t& address);
};
