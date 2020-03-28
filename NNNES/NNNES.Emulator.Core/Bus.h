#pragma once
#include "Cpu.h"
#include "Ppu.h"
#include "INes.h"
#include "CpuRam.h"
#include "PpuRam.h"

class Bus
{
private:
	Cpu& cpu_;
	Ppu& ppu_;
	CpuRam& cpu_ram_;
	//PpuRam& ppu_ram_;
	INes* i_nes_;

	Device& GetDevice(uint16_t address) const;


public:

	Bus(Cpu& cpu, Ppu& ppu, CpuRam& cpu_ram/*, PpuRam& ppu_ram*/);
	~Bus();

	void SetINesHandle(INes* i_nes);

	void Write(uint16_t address, uint8_t data) const;
	uint8_t Read(uint16_t address) const;
		
};
