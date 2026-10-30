#pragma once
#include "Mapper.h"

class Nrom : public Mapper
{
public:
	explicit Nrom(const uint8_t prg_banks, const uint8_t chr_banks)
		: Mapper(0, prg_banks, chr_banks)
	{
	}

	uint16_t CpuMappedAddress(uint16_t address) override;
	uint16_t PpuMappedReadAddress(uint16_t address) override;
	uint16_t PpuMappedWriteAddress(uint16_t address) override;
};

