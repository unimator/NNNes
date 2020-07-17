#pragma once
#include <cstdint>
#include <string>
#include "Device.h"
#include "Mapper.h"

#define PRG_ROM_BANK_SIZE 0x4000
#define CHR_ROM_BANK_SIZE 0x2000

class INes : public Device
{
private:
	bool is_nes20_;

	uint8_t* trainer_;

	uint8_t prg_rom_size_;
	uint8_t* prg_rom_;

	uint8_t chr_rom_size_;
	uint8_t* chr_rom_;

	uint8_t* inst_rom_;
	uint8_t* prom_;

	uint8_t flags6_, flags7_, flags8_, flags9_, flags10_;

	Mapper* mapper_;
	
	std::string title_;
	
public:
	INes(const uint8_t* bytes, const uint32_t length);
	~INes();

	auto PrgRom() ->  uint8_t*& { return prg_rom_; }
	auto PrgRomSize() const -> const uint32_t& { return static_cast<uint32_t>(prg_rom_size_) * PRG_ROM_BANK_SIZE; }
	
	auto ChrRom() -> uint8_t*& { return chr_rom_; }
	auto ChrRomSize() const -> const uint32_t& { return static_cast<uint32_t>(chr_rom_size_) * CHR_ROM_BANK_SIZE; }

	auto MapperNumber() const -> uint8_t
	{
		return flags7_ & 0xff00 | flags6_ >> 4;
	}
	
	enum Flags6
	{
		Trainer = 1 << 2
	};

	enum Flags7
	{
		PlayChoice10 = 1 << 1
	};

private:
	void LoadNesFormat(const uint8_t* bytes, const uint32_t length);
	void LoadNes20Format(const uint8_t* bytes, const uint32_t length);
public:
	void CpuWrite(uint16_t address, uint8_t data) override;
	uint8_t CpuRead(uint16_t address) override;

	void PpuWrite(uint16_t address, uint8_t data) const;
	uint8_t PpuRead(uint16_t address) const;
};

typedef INes* INesHandle;