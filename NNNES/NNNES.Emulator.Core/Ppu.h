#pragma once
#include "Nes.h"

class INes;

class Ppu : public Device
{
private:
	Bus* bus_ = nullptr;

	uint8_t oam_address, oam_data, ppu_scroll, ppu_address, ppu_data, oam_dma;

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
	
public:
	Ppu();
	virtual ~Ppu();

	void Reset();
	void Clock();
	
	void SetBus(Bus* bus)
	{
		bus_ = bus;
	}

	void CpuWrite(uint16_t address, uint8_t data) override;
	uint8_t CpuRead(uint16_t address) override;

	void PpuWrite(uint16_t address, uint8_t data);
	uint8_t PpuRead(uint16_t address, uint8_t data);

};
