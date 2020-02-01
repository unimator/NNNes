#include "pch.h"
#include "INes.h"

extern "C" {
	__declspec(dllexport) INesHandle LoadINes(uint8_t* bytes, const uint32_t length)
	{
		return new INes(bytes, length);
	}

	__declspec(dllexport) void DestroyINes(const INesHandle i_nes)
	{
		if (i_nes)
		{
			delete i_nes;
		}
	}

	__declspec(dllexport) void GetPrgRom(const INesHandle i_nes, uint8_t** out_data, uint32_t* out_size)
	{
		auto t = i_nes->PrgRomSize();
		*out_data = i_nes->PrgRom();
		*out_size = i_nes->PrgRomSize();
	}

	/*__declspec(dllexport) uint8_t GetPrgRomSize(const INesHandle i_nes)
	{
		return i_nes->PrgRomSize();
	}*/

	__declspec(dllexport) void GetChrRom(const INesHandle i_nes, uint8_t** out_data, uint32_t* out_size)
	{
		*out_data = i_nes->ChrRom();
		*out_size = i_nes->ChrRomSize();
	}

	/*__declspec(dllexport) uint8_t GetChrRomSize(const INesHandle i_nes)
	{
		return i_nes->ChrRomSize();
	}*/
}
