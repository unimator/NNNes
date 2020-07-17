#pragma once
#include "Mapper.h"

class Nrom : public Mapper
{
public:
	explicit Nrom(const uint8_t prg_banks, const uint8_t chr_banks)
		: Mapper(0, prg_banks, chr_banks)
	{
	}

	uint16_t CpuReadAddress(uint16_t address) override;
	uint16_t CpuWriteAddress(uint16_t address) override;
	uint16_t PpuReadAddress(uint16_t address) override;
	uint16_t PpuWriteAddress(uint16_t address) override;

	Mirroring GetMirroring() override;
};

