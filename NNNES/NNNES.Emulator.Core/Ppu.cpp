#include "pch.h"
#include "Ppu.h"
#include <cstdlib>

Ppu::Ppu(Frame* frame_) : AddressableDevice(0x2000, 0x2000), frame_(frame_)
{
}

Ppu::~Ppu()
{
}

void Ppu::Reset()
{
	ppu_ctrl.value = 0x00;
	ppu_mask.value = 0x00;
	ppu_scroll = 0x0000;
	ppu_data = 0x00;
	
}

void Ppu::Clock()
{
	if (scanline_count_ < FRAME_HEIGHT && clock_count_ < FRAME_WIDTH)
	{
		auto color = rand() % 0xFF;
		frame_->pixels[scanline_count_ * FRAME_WIDTH + clock_count_] = color;
	}
	
	clock_count_++;
	frame_->frame_ready = false;

	if(clock_count_ == 341)
	{
		clock_count_ = 0;
		scanline_count_++;

		if (scanline_count_ == 261)
		{
			scanline_count_ = -1;
			frame_->frame_ready = true;
		}
	}
}

void Ppu::Write(uint16_t address, uint8_t data)
{
	if (address >= 0x2000 && address < 0x4000)
	{
		const auto id = address & 7;
		switch (id)
		{
		case 0:
			ppu_ctrl.value = data;
			break;
		case 1:
			ppu_mask.value = data;
			break;
		case 2:
			ppu_status.value = data;
			break;
		case 3:
			oam_address = data;
			break;
		case 4:
			oam_data = data;
			break;
		case 5:
			ppu_scroll = data;
			break;
		case 6:
			ppu_address = data;
			break;
		case 7:
			ppu_data = data;
			break;
		default:
			break;
		}
	}
}

uint8_t Ppu::Read(uint16_t address)
{
	if (address >= 0x2000 && address < 0x4000)
	{
		const auto id = address & 7;
		switch (id)
		{
		case 0:
			return ppu_ctrl.value;
		case 1:
			return ppu_mask.value;
		case 2:
			return ppu_status.value;
		case 3:
			return oam_address;
		case 4:
			return oam_data;
		case 5:
			return ppu_scroll;
		case 6:
			return ppu_address;
		case 7:
			return ppu_data;
		default:
			return 0x00;
		}
	}

	return 0x00;
}

void Ppu::PpuWrite(uint16_t address, uint8_t data)
{
	if(address >= 0 && address <=0x1FFF)
	{
		bus_->GetINesHandle()->PpuWrite(address, data);
	}
	else if (address >= 0x2000 && address <= 0x2FFF)
	{
			
	}
}

uint8_t Ppu::PpuRead(uint16_t address, uint8_t data)
{
	if (address >= 0 && address <= 0x1FFF)
	{
		return bus_->GetINesHandle()->PpuRead(address);
	}
	else if (address >= 0x2000 && address <= 0x2FFF)
	{

	}
}
