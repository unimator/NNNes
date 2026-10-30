#pragma once
#include <cstdint>

enum Mirroring
{
	Vertical = 0,
	Horizontal = 1
};

class Mapper
{
protected:
	uint8_t mapper_number_;

	uint8_t prg_banks_, chr_banks_;

	Mapper(const uint8_t mapper_number, const uint8_t prg_banks, const uint8_t chr_banks);

public:
	auto MapperNumber() const -> uint8_t { return mapper_number_; }
	
	virtual uint16_t CpuMappedAddress(uint16_t address) = 0;
	virtual uint16_t PpuMappedReadAddress(uint16_t address) = 0;
	virtual uint16_t PpuMappedWriteAddress(uint16_t address) = 0;
};
