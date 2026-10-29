#pragma once
#include "Nes.h"
#include "Frame.h"

class INes;

class Ppu : public AddressableDevice
{
private:

	uint8_t oam_address, oam_data, ppu_scroll, ppu_data, oam_dma;
	uint16_t ppu_address;

	union PpuCtrl
	{
		struct
		{
			uint8_t nameTable : 2;
			uint8_t incrementMode : 1;
			uint8_t spriteSelectMode : 1;
			uint8_t backgroundPatternTable : 1;
			uint8_t spriteSize : 1;
			uint8_t masterSlave : 1;
			uint8_t generateNMI : 1;	
		};
		uint8_t value;
	} ppu_ctrl;

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
	} ppu_mask;

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
	} ppu_status;

	uint32_t clock_count_ = 0;
	uint32_t scanline_count_ = 0;

	Frame* frame_;

	uint8_t address_latch_;

	uint8_t palletes[4 * 2 * 4];

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
