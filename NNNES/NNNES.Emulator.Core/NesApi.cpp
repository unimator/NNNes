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
	
	__declspec(dllexport) const uint8_t* GetCpuRam(const NesHandle nes)
	{
		return nes->GetCpuRam();
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

	__declspec(dllexport) void Clock(const NesHandle nes)
	{
		nes->Clock();
	}
}
