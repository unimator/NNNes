#include "pch.h"
#include "Ppu.h"
#include <cstdlib>

extern uint32_t screen_palette[0x40];

Ppu::Ppu(Frame* frame_) : AddressableDevice(0x2000, 0x2000), frame_(frame_)
{
}

Ppu::~Ppu()
{
}

void Ppu::Reset()
{
	ctrl_.value = 0x00;
	mask_.value = 0x00;
	scroll_ = 0x0000;
	
	fine_x_ = 0x00;
	
	cycle_count_ = 0;
	scanline_count_ = 0;
	
	bg_next_tile_ = 0; 
	bg_next_tile_attribute_ = 0; 
	bg_next_tile_lsb_ = 0;
	bg_next_tile_msb_ = 0;

	bg_shifter_pattern_lo_ = 0x0000;
	bg_shifter_pattern_hi_ = 0x0000;
	bg_shifter_attribute_lo_ = 0x0000;
	bg_shifter_attribute_hi_ = 0x0000;
	
	vram_address_.value = 0;
	tram_address_.value = 0;
}

void Ppu::Clock()
{
	auto increment_scroll_x = [&]()
	{
		if (mask_.showBackground || mask_.showSprites)
		{
			if (vram_address_.coarse_x == 31)
			{
				vram_address_.coarse_x = 0;
				vram_address_.nametable = (vram_address_.nametable & 0b10) | ~(vram_address_.nametable & 0b01);
			}
			else
			{
				vram_address_.coarse_x++;
			}
		}
	};

	auto increment_scroll_y = [&]()
	{
		if (mask_.showBackground || mask_.showSprites)
		{
			if (vram_address_.fine_y < 7)
			{
				vram_address_.fine_y++;
			}
			else
			{
				vram_address_.fine_y = 0;

				if (vram_address_.coarse_y == 29)
				{
					vram_address_.coarse_y = 0;
					vram_address_.nametable = ~(vram_address_.nametable & 0b10) | (vram_address_.nametable & 0b01);
				}
				else if (vram_address_.coarse_y == 31)
				{
					vram_address_.coarse_y = 0;
				}
				else
				{
					vram_address_.coarse_y++;
				}
			}
		}
	};

	auto apply_x = [&]()
	{
		if (mask_.showBackground || mask_.showSprites)
		{
			vram_address_.nametable = (vram_address_.nametable & 0b10) & (tram_address_.nametable & 0b01);
			vram_address_.coarse_x = tram_address_.coarse_x;
		}
	};

	auto apply_y = [&]()
	{
		if (mask_.showBackground || mask_.showSprites)
		{
			vram_address_.fine_y = tram_address_.fine_y;
			vram_address_.nametable = (tram_address_.nametable & 0b10) & (vram_address_.nametable & 0b01);
			vram_address_.coarse_y = tram_address_.coarse_y;
		}
	};

	auto load_background_shifters = [&]()
	{
		bg_shifter_pattern_lo_ = (bg_shifter_pattern_lo_ & 0xFF00) | bg_next_tile_lsb_;
		bg_shifter_pattern_hi_ = (bg_shifter_pattern_hi_ & 0xFF00) | bg_next_tile_msb_;

		bg_shifter_attribute_lo_ = (bg_shifter_attribute_lo_ & 0xFF00) | ((bg_next_tile_attribute_ & 0b01) ? 0xFF : 0x00);
		bg_shifter_attribute_hi_ = (bg_shifter_attribute_hi_ & 0xFF00) | ((bg_next_tile_attribute_ & 0b10) ? 0xFF : 0x00);
	};

	auto update_shifters = [&]()
	{
		if (mask_.showBackground)
		{
			bg_shifter_pattern_lo_ <<= 1;
			bg_shifter_pattern_hi_ <<= 1;
			bg_shifter_attribute_lo_ <<= 1;
			bg_shifter_attribute_hi_ <<= 1;
		}
	};

	if (scanline_count_ >= -1 && scanline_count_ < 240)
	{
		if (scanline_count_ == 0 && cycle_count_ == 0)
		{
			cycle_count_ = 1;
		}

		if (scanline_count_ == -1 && cycle_count_ == 1)
		{
			status_.verticalBlank = 0;
		}

		if ((cycle_count_ >= 2 && cycle_count_ < 256) || (cycle_count_ >= 321 && cycle_count_ < 338))
		{
			update_shifters();

			switch ((cycle_count_ - 1) % 8)
			{
			case 0:
				load_background_shifters();
				bg_next_tile_ = PpuRead(0x2000 | (vram_address_.value & 0x0FFF));
				break;
			case 1:
				break;
			case 2:
				bg_next_tile_attribute_ = PpuRead(
					0x23C0 | ((vram_address_.nametable & 0b10) << 11)
					| ((vram_address_.nametable & 0b01) << 10)
					| ((vram_address_.coarse_y >> 2) << 3)
					| (vram_address_.coarse_x >> 2)
				);
				if (vram_address_.coarse_y & 0x02) bg_next_tile_attribute_ >>= 4;
				if (vram_address_.coarse_x & 0x02) bg_next_tile_attribute_ >>= 2;
				bg_next_tile_attribute_ &= 0x03;
				break;
			case 3:
				break;
			case 4:
				bg_next_tile_lsb_ = PpuRead((ctrl_.backgroundPatternTable << 12)
					+ ((uint16_t) bg_next_tile_ << 4)
					+ vram_address_.fine_y + 0
				);
				break;
			case 5:
				break;
			case 6:
				bg_next_tile_msb_ = PpuRead((ctrl_.backgroundPatternTable << 12)
					+ ((uint16_t)bg_next_tile_ << 4)
					+ vram_address_.fine_y + 8
				);
				break;
			case 7:
				increment_scroll_x();
				break;
			}
		}

		if (cycle_count_ == 256)
		{
			increment_scroll_y();
		}

		if (cycle_count_ == 257)
		{
			load_background_shifters();
			apply_x();
		}

		if (cycle_count_ == 338 || cycle_count_ == 340)
		{
			bg_next_tile_ = PpuRead(0x2000 | vram_address_.value & 0x0FFF);
		}

		if (scanline_count_ == -1 && cycle_count_ >= 280 && cycle_count_ < 305)
		{
			apply_y();
		}
	}


	if (scanline_count_ >= 241 && scanline_count_ < 261)
	{
		if (scanline_count_ == 241 && cycle_count_ == 1)
		{
			status_.verticalBlank = 1;

			if (ctrl_.generateNMI)
			{
				SetNonMaskableInterrupt();
			}
		}
	}


	uint8_t pixel = 0x00;
	uint8_t palette = 0x00;

	if (mask_.showBackground)
	{
		uint16_t bit_mux = 0x8000 >> fine_x_;

		uint8_t p0_pixel = (bg_shifter_pattern_lo_ & bit_mux) > 0;
		uint8_t p1_pixel = (bg_shifter_pattern_hi_ & bit_mux) > 0;
		pixel = (p1_pixel << 1) | p0_pixel;

		uint8_t bg_pal0 = (bg_shifter_attribute_lo_ & bit_mux) > 0;
		uint8_t bg_pal1 = (bg_shifter_attribute_hi_ & bit_mux) > 0;
		palette = (bg_pal1 << 1) | bg_pal0;
	}

	auto color = PpuRead(0x3F00 + (palette << 2) + pixel) & 0x3F;
		
	if (
		scanline_count_ >= 0 && scanline_count_ < FRAME_HEIGHT
		&& cycle_count_ >= 0 && cycle_count_ < FRAME_WIDTH
		)
	{
		frame_->pixels[scanline_count_ * FRAME_WIDTH + cycle_count_] = screen_palette[color];
	}
	
	
	cycle_count_++;
	frame_->frame_ready = false;

	if(cycle_count_ == 341)
	{
		cycle_count_ = 0;
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
			ctrl_.value = data;
			tram_address_.nametable = ctrl_.nametable;
;			break;
		case 1:
			mask_.value = data;
			break;
		case 2:
			break;
		case 3:
			oam_address_ = data;
			break;
		case 4:
			oam_data_ = data;
			break;
		case 5:
			if (address_latch_ == 0)
			{
				fine_x_ = data & 0x07;
				tram_address_.coarse_x = data >> 3;
				address_latch_ = 1;
			}
			else
			{
				tram_address_.fine_y = data & 0x07;
				tram_address_.coarse_y = data >> 3;
				address_latch_ = 0;
			}
			break;
		case 6:
			if (address_latch_ == 0)
			{
				tram_address_.value = (uint16_t)((tram_address_.value & 0x00FF) | (data & 0x3F << 8));
				address_latch_ = 1;
			}
			else
			{
				tram_address_.value = (tram_address_.value & 0xFF00) | data;
				vram_address_ = tram_address_;
				address_latch_ = 0;
			}
			break;
		case 7:
			PpuWrite(vram_address_.value, data);
			vram_address_.value += ctrl_.incrementMode ? 32 : 1;
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
			return ctrl_.value;
		case 1:
			return mask_.value;
		case 2:
			data = (status_.value & 0xE0) | (data_ & 0x1F);
			status_.verticalBlank = 0;
			address_latch_ = 0;
			return data;
		case 3:
			return oam_address_;
		case 4:
			return oam_data_;
		case 5:
			return scroll_;
		case 6:
			break;
		case 7:
			data = data_;
			data_ = PpuRead(vram_address_.value);

			if (vram_address_.value > 0x3F00) {
				data = data_;
			}
			vram_address_.value += ctrl_.incrementMode ? 32 : 1;
			break;
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
	else if (address >= 0x2000 && address <= 0x3EFF)
	{
		auto mirroring = bus_->GetINesHandle()->Mirroring();

		if (mirroring == Mirroring::Vertical)
		{
			if (address >= 0x0000 && address <= 0x03FF)
			{
				nametables_[0][address & 0x03FF] = data;
			}

			if (address >= 0x0400 && address <= 0x07FF)
			{
				nametables_[1][address & 0x03FF + 0x03C0] = data;
			}

			if (address >= 0x0800 && address <= 0x0BFF)
			{
				nametables_[0][address & 0x03FF] = data;
			}

			if (address >= 0x0C00 && address <= 0x0FFF)
			{
				nametables_[1][address & 0x03FF + 0x03C0] = data;
			}
		}
		else if (mirroring == Mirroring::Horizontal)
		{
			if (address >= 0x0000 && address <= 0x03FF)
			{
				nametables_[0][address & 0x03FF] = data;
			}

			if (address >= 0x0400 && address <= 0x07FF)
			{
				nametables_[0][address & 0x03FF] = data;
			}

			if (address >= 0x0800 && address <= 0x0BFF)
			{
				nametables_[1][address & 0x03FF + 0x03C0] = data;
			}

			if (address >= 0x0C00 && address <= 0x0FFF)
			{
				nametables_[1][address & 0x03FF + 0x03C0] = data;
			}
		}
	}
	else if (address >= 0x3F00 && address <= 0x3FFF) 
	{
		address &= 0x001F;
		if (address == 0x0010) address = 0x0000;
		if (address == 0x0014) address = 0x0004;
		if (address == 0x0018) address = 0x0008;
		if (address == 0x001C) address = 0x000C;
		palletes[address] = data;
	}
}

uint8_t Ppu::PpuRead(uint16_t address)
{
	if (address >= 0 && address <= 0x1FFF)
	{
		return bus_->GetINesHandle()->PpuRead(address);
	}
	else if (address >= 0x2000 && address <= 0x3EFF)
	{
		auto mirroring = bus_->GetINesHandle()->Mirroring();

		if (mirroring == Mirroring::Vertical)
		{
			if (address >= 0x0000 && address <= 0x03FF)
			{
				return nametables_[0][address & 0x03FF];
			}

			if (address >= 0x0400 && address <= 0x07FF)
			{
				return nametables_[1][address & 0x03FF];
			}

			if (address >= 0x0800 && address <= 0x0BFF)
			{
				return nametables_[0][address & 0x03FF];
			}

			if (address >= 0x0C00 && address <= 0x0FFF)
			{
				return nametables_[1][address & 0x03FF];
			}
		}
		else if (mirroring == Mirroring::Horizontal)
		{
			if (address >= 0x0000 && address <= 0x03FF)
			{
				return nametables_[0][address & 0x03FF];
			}

			if (address >= 0x0400 && address <= 0x07FF)
			{
				return nametables_[0][address & 0x03FF];
			}

			if (address >= 0x0800 && address <= 0x0BFF)
			{
				return nametables_[1][address & 0x03FF];
			}

			if (address >= 0x0C00 && address <= 0x0FFF)
			{
				return nametables_[1][address & 0x03FF];
			}
		}

		return 0x00;
	}
	else if (address >= 0x3F00 && address <= 0x3FFF)
	{
		address &= 0x001F;
		if (address == 0x0010) address = 0x0000;
		if (address == 0x0014) address = 0x0004;
		if (address == 0x0018) address = 0x0008;
		if (address == 0x001C) address = 0x000C;
		return palletes[address] & (mask_.greyscale ? 0x30 : 0x3F);
	}
}
