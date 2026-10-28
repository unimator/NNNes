#include "pch.h"
#include "Nes.h"
#include "INes.h"

extern "C" {
	__declspec(dllexport) NesHandle CreateInstance()
	{
		return new Nes();
	}

	__declspec(dllexport) void DestroyInstance(const NesHandle nes)
	{
		if (nes)
		{
			delete nes;
		}
	}

	__declspec(dllexport) void ResetState(NesHandle nes)
	{
		nes->Reset();
	}
		
	//__declspec(dllexport) const uint8_t* GetRam(const NesHandle nes)
	//{
	//	return nes->GetRam();
	//}

	__declspec(dllexport) void SetCpuRegisters(const NesHandle nes, const CpuRegisters& registers)
	{
		nes->GetCpu()->Registers() = registers;
	}
	
	__declspec(dllexport) void GetCpuRegisters(const NesHandle nes, CpuRegisters& registers)
	{
		registers = nes->GetCpu()->Registers();
	}

	__declspec(dllexport) void SetCartridge(NesHandle nes, const INesHandle iNes)
	{
		nes->SetINesHandle(iNes);
	}

	__declspec(dllexport) void Clock(const NesHandle nes)
	{
		nes->Clock();
	}

	__declspec(dllexport) void NextInstruction(const NesHandle nes)
	{
		nes->NextInstruction();
	}

	__declspec(dllexport) uint8_t* GetRamAddress(const NesHandle nes)
	{
		const auto ram = nes->GetRam();
		return ram;
	}
	
	__declspec(dllexport) const InstructionInfo* Disassemble(const NesHandle nes, const uint16_t address_start, const uint16_t address_end, size_t& instructions_length)
	{
		const auto disassembled = nes->Disassemble(address_start, address_end);
		instructions_length = disassembled.size();
		const auto x = static_cast<int>(sizeof(InstructionInfo));
		const auto data = malloc(instructions_length * sizeof(InstructionInfo));
		if(data != nullptr)
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

	__declspec(dllexport) const uint32_t* GetFrameHandle(const NesHandle nes)
	{
		return nes->Frame()->pixels;
	}

	__declspec(dllexport) bool IsFrameReady(const NesHandle nes)
	{
		return nes->Frame()->frame_ready;
	}
}
