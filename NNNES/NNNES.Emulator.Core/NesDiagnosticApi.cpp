#include "pch.h"
#include "Nes.h"

extern "C" {
	__declspec(dllexport) const uint32_t* GetFrameHandle(const NesHandle nes)
	{
		return nes->Frame()->pixels;
	}

	__declspec(dllexport) bool IsFrameReady(const NesHandle nes)
	{
		return nes->Frame()->frame_ready;
	}

	__declspec(dllexport) void NextFrame(const NesHandle nes)
	{
		do
			nes->Clock();
		while (!nes->Frame()->frame_ready);
	}

	__declspec(dllexport) const InstructionInfo* Disassemble(const NesHandle nes, const uint16_t address_start, const uint16_t address_end, size_t& instructions_length)
	{
		const auto disassembled = nes->Disassemble(address_start, address_end);
		instructions_length = disassembled.size();
		const auto x = static_cast<int>(sizeof(InstructionInfo));
		const auto data = malloc(instructions_length * sizeof(InstructionInfo));
		if (data != nullptr)
		{
			memcpy(data, disassembled.data(), instructions_length * sizeof(InstructionInfo));
		}
		return static_cast<const InstructionInfo*>(data);
	}

	__declspec(dllexport) const InstructionInfo* DisassembleByCount(const NesHandle nes, const uint16_t address_start, const size_t count, size_t& instructions_length)
	{
		const auto disassembled = nes->DisassembleByCount(address_start, count);
		instructions_length = disassembled.size();
		const auto x = static_cast<int>(sizeof(InstructionInfo));
		const auto data = malloc(instructions_length * sizeof(InstructionInfo));
		if (data != nullptr)
		{
			memcpy(data, disassembled.data(), instructions_length * sizeof(InstructionInfo));
		}
		return static_cast<const InstructionInfo*>(data);
	}

	__declspec(dllexport) void GetChrRom(const NesHandle nes, const uint8_t** out_data, uint32_t* out_size)
	{
		*out_data = nes->ChrRom();
		*out_size = nes->ChrRomSize();
	}

	__declspec(dllexport) void GetPalletes(const NesHandle nes, const uint8_t** out_palletes, size_t* out_size)
	{
		*out_palletes = nes->GetPpu()->Palletes();
		*out_size = 4 * 2 * 4;
	}
}