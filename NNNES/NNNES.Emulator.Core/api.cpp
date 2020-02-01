#include "pch.h"
#include <cstdio>
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
		nes->Run();
	}

	__declspec(dllexport) const uint8_t* GetMemoryHandle(const NesHandle nes)
	{
		return nes->GetMemoryHandle();
	}
}