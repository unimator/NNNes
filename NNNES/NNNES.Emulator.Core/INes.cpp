#include "pch.h"
#include "INes.h"
#include "Nrom.h"

INes::INes(const uint8_t* bytes, const uint32_t length) : Device(0x4020, 0xBFE0)
{
	if (memcmp(bytes, "NES\x001a", 4) != 0)
	{
		throw "Invalid iNES header";
	}

	if ((bytes[7] & 0x0C) == 0x08)
	{
		is_nes20_ = true;
		LoadNes20Format(bytes, length);
	}
	else
	{
		LoadNesFormat(bytes, length);
	}
}

INes::~INes()
{
	auto try_delete = [](auto ptr)
	{
		if (ptr)
		{
			delete[] ptr;
		}
	};

	try_delete(trainer_);
	try_delete(prg_rom_);
	try_delete(chr_rom_);
	try_delete(prom_);

	if(mapper_)
	{
		delete mapper_;
	}
}

void INes::LoadNesFormat(const uint8_t* bytes, const uint32_t length)
{
	prg_rom_size_ = bytes[4];
	chr_rom_size_ = bytes[5];

	flags6_ = bytes[6];
	flags7_ = bytes[7];
	flags8_ = bytes[8];
	flags9_ = bytes[9];
	flags10_ = bytes[10];

	auto offset = 0x10;

	if (flags6_ & Trainer) {
		offset += 0x200;
		trainer_ = new uint8_t[0x200];
		memcpy(trainer_, (bytes + 16), 0x200);
	}

	prg_rom_ = new uint8_t[PRG_ROM_BANK_SIZE * prg_rom_size_];
	memcpy(prg_rom_, (bytes + offset), PRG_ROM_BANK_SIZE * prg_rom_size_);
	offset += PRG_ROM_BANK_SIZE * prg_rom_size_;

	if(chr_rom_size_)
	{
		chr_rom_ = new uint8_t[CHR_ROM_BANK_SIZE * chr_rom_size_];
		memcpy(chr_rom_, (bytes + offset), CHR_ROM_BANK_SIZE * chr_rom_size_);
		offset += CHR_ROM_BANK_SIZE * chr_rom_size_;
	}
	

	if(flags7_ & PlayChoice10)
	{
		inst_rom_ = new uint8_t[0x2000];
		memcpy(inst_rom_, (bytes + offset), 0x2000);
		offset += 0x2000;
		prom_ = new uint8_t[0x10 * 2];
		memcpy(prom_, (bytes + offset), 0x10 * 2);
		offset += 0x10 * 2;
	}

	if(offset < length)
	{
		title_ = std::string(reinterpret_cast<const char*>(bytes + offset), length - offset);
	}

	switch(MapperNumber())
	{
	case 0:
		mapper_ = new Nrom(prg_rom_size_, chr_rom_size_);
	}
}

void INes::LoadNes20Format(const uint8_t* bytes, const uint32_t length)
{
}

void INes::CpuWrite(uint16_t address, uint8_t data)
{
	const auto real_address = mapper_->CpuWriteAddress(address);
	prg_rom_[real_address] = data;
}

uint8_t INes::CpuRead(uint16_t address)
{
	const auto real_address = mapper_->CpuReadAddress(address);
	return prg_rom_[real_address];
}

void INes::PpuWrite(uint16_t address, uint8_t data) const
{
	const auto real_address = mapper_->PpuWriteAddress(address);
	chr_rom_[real_address] = data;
}

uint8_t INes::PpuRead(uint16_t address) const
{
	const auto real_address = mapper_->PpuReadAddress(address);
	return chr_rom_[real_address];
}
