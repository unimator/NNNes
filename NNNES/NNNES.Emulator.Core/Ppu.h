#pragma once
#include "Nes.h"
#include "Frame.h"

class INes;

class Ppu : public AddressableDevice
{
private:

	uint8_t oam_address_, oam_data_, scroll_, data_, oam_dma_;

	union LoopyRegister
	{
		struct
		{
			uint16_t coarse_x : 5;
			uint16_t coarse_y : 5;
			uint16_t nametable_x : 1;
			uint16_t nametable_y : 1;
			uint16_t fine_y : 3;
			uint16_t unused : 1;
		};

		uint16_t value;
	};

	LoopyRegister vram_address_, tram_address_;
	uint8_t fine_x_;

	union PpuCtrl
	{
		struct
		{
			uint8_t nametable_x : 1;
			uint8_t nametable_y : 1;
			uint8_t incrementMode : 1;
			uint8_t spriteSelectMode : 1;
			uint8_t backgroundPatternTable : 1;
			uint8_t spriteSize : 1;
			uint8_t masterSlave : 1;
			uint8_t generateNMI : 1;	
		};
		uint8_t value;
	} ctrl_;

	union PpuMask
	{
		struct
		{
			uint8_t greyscale : 1;
			uint8_t backgroundLeft : 1;
			uint8_t spriteLeft : 1;
			uint8_t showBackground : 1;
			uint8_t showSprites : 1;
			uint8_t emphasizeR : 1;
			uint8_t emphasizeG : 1;
			uint8_t emphasizeB : 1;
		};
		uint8_t value;
	} mask_;

	union PpuStatus
	{
		struct
		{
			uint8_t prevLsb : 5;
			uint8_t spriteOverflow : 1;
			uint8_t spriteZeroHit : 1;
			uint8_t verticalBlank : 1;
		};
		uint8_t value;
	} status_;

	uint32_t cycle_count_ = 0;
	int32_t scanline_count_ = 0;

	Frame* frame_;

	uint8_t address_latch_;

	uint8_t palletes[32];
	uint8_t nametables_[2][1024];
	uint8_t pattern_tables_[2][4096];

	uint8_t bg_next_tile_ = 0, bg_next_tile_attribute_ = 0, bg_next_tile_lsb_ = 0, bg_next_tile_msb_ = 0;

	uint16_t bg_shifter_pattern_lo_ = 0x0000,
		bg_shifter_pattern_hi_ = 0x0000, 
		bg_shifter_attribute_lo_ = 0x0000, 
		bg_shifter_attribute_hi_ = 0x0000;

public:
	Ppu(Frame* frame_);
	virtual ~Ppu();

	void Reset();
	void Clock();
	
	void SetBus(Bus* bus)
	{
		bus_ = bus;
	}

	void Write(uint16_t address, uint8_t data) override;
	uint8_t Read(uint16_t address) override;

	void PpuWrite(uint16_t address, uint8_t data);
	uint8_t PpuRead(uint16_t address);

	auto Palletes() const -> const uint8_t* { return palletes; }
};
