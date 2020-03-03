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

	__declspec(dllexport) void Run(NesHandle nes)
	{
		nes->Clock();
	}

	__declspec(dllexport) void ResetState(NesHandle nes)
	{
		nes->Reset();
	}
	
	__declspec(dllexport) const uint8_t* GetRam(const NesHandle nes)
	{
		return nes->GetRam();
	}
	
	__declspec(dllexport) void GetCpuRegisters(const NesHandle nes, CpuRegisters& registers)
	{
		registers = nes->GetCpu()->Registers();
		nes->GetCpu()->StackPointer() = 1;
	}

	__declspec(dllexport) void SetCartridge(NesHandle nes, const INesHandle iNes)
	{
		nes->SetINesHandle(iNes);
	}
}
