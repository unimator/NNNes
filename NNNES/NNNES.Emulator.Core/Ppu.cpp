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
	
}

void Ppu::Clock()
{
	if (scanline_count_ < FRAME_HEIGHT && clock_count_ < FRAME_WIDTH)
	{
		auto shade = (rand() & 0xFF);
		auto color = (shade << 16) | (shade << 8) | shade;
		frame_->pixels[scanline_count_ * FRAME_WIDTH + clock_count_] = color;
	}

	if (scanline_count_ == -1 && clock_count_ == 1)
	{
		ppu_status.verticalBlank = 0;
	}

	if (scanline_count_ == 241 && clock_count_ == 1)
	{
		ppu_status.verticalBlank = 1;

		if (ppu_ctrl.generateNMI)
		{
			SetNonMaskableInterrupt();
		}
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
			if (address_latch_ == 0)
			{
				ppu_address = (ppu_address & 0x00FF) | (data << 8);
				address_latch_ = 1;
			}
			else
			{
				ppu_address = (ppu_address & 0xFF00) | data;
				address_latch_ = 0;
			}
			break;
		case 7:
			PpuWrite(ppu_address, data);
			ppu_address += ppu_ctrl.incrementMode ? 32 : 1;
			break;
		default:
			break;
		}
	}
}

uint8_t Ppu::Read(uint16_t address)
{
	uint8_t data = 0x00;
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
			data = (ppu_status.value & 0xE0) | (ppu_data & 0x1F);
			ppu_status.verticalBlank = 0;
			address_latch_ = 0;
			return data;
		case 3:
			return oam_address;
		case 4:
			return oam_data;
		case 5:
			return ppu_scroll;
		case 6:
			break;
		case 7:
			data = ppu_data;
			ppu_data = PpuRead(ppu_address);

			if (ppu_address > 0x3F00) {
				data = ppu_data;
			}
			ppu_address += ppu_ctrl.incrementMode ? 32 : 1;
			return data;
		default:
			return 0x00;
		}
	}

	return data;
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
	else if (address >= 0x3F00 && address <= 0x3FFF) 
	{
		palletes[address & 0x1F] = data;
	}
}

uint8_t Ppu::PpuRead(uint16_t address)
{
	if (address >= 0 && address <= 0x1FFF)
	{
		return bus_->GetINesHandle()->PpuRead(address);
	}
	else if (address >= 0x2000 && address <= 0x2FFF)
	{
		return 0x00;
	}
	else if (address >= 0x3F00 && address <= 0x3FFF)
	{
		return palletes[address & 0x1F];
	}
}
