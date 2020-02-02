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

	__declspec(dllexport) const uint8_t* GetRam(const NesHandle nes)
	{
		return nes->GetRam();
	}

	struct CpuRegisters
	{
		char accumulator;
		char x, y;
		short program_counter;
		char status;
		char stack;
	};
	
	__declspec(dllexport) CpuRegisters* GetCpuRegisters(const NesHandle nes)
	{
		const auto cpu = nes->GetCpu();
		/*return CpuRegisters{
			cpu->Accumulator(),
			cpu->X(), cpu->Y(),
			cpu->ProgramCounter(),
			cpu->Status(),
			cpu->StackPointer()
		};*/

		return new CpuRegisters{
			1,2,3,4,5,6
		};
	}
}
