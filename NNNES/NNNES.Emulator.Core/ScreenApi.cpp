#include "pch.h"
#include "ScreenPalette.h"

extern "C" {
	__declspec(dllexport) void GetScreenPalette(uint32_t** screen_colors, size_t* size)
	{
		*screen_colors = screen_palette;
		*size = 0x40;
	}
}