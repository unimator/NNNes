#include "pch.h"
#include "Ppu.h"

Ppu::Ppu() : Device(0x2000, 0x2000)
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
}

void Ppu::CpuWrite(uint16_t address, uint8_t data)
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

uint8_t Ppu::CpuRead(uint16_t address)
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
