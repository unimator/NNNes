#include "pch.h"
#include "NesDebug.h"
#include "CpuRegisters.h"

extern "C" {
	__declspec(dllexport) NesDebugHandle CreateDebugInstance()
	{
		return new NesDebug();
	}

	__declspec(dllexport) void DestroyDebugInstance(const NesDebugHandle nes_debug)
	{
		if (nes_debug)
		{
			delete nes_debug;
		}
	}

	__declspec(dllexport) void ResetStateDebug(NesDebugHandle nes_debug)
	{
		nes_debug->Reset();
	}

	__declspec(dllexport) void SetCpuRegistersDebug(const NesDebugHandle nes_debug, const CpuRegisters& registers)
	{
		nes_debug->GetCpu()->Registers() = registers;
	}

	__declspec(dllexport) void GetCpuRegistersDebug(const NesDebugHandle nes_debug, CpuRegisters& registers)
	{
		registers = nes_debug->GetCpu()->Registers();
		nes_debug->GetCpu()->StackPointer() = 1;
	}

	__declspec(dllexport) void ClockDebug(const NesDebugHandle nes_debug)
	{
		nes_debug->Clock();
	}

	__declspec(dllexport) void NextInstructionDebug(const NesDebugHandle nes_debug)
	{
		nes_debug->NextInstruction();
	}

	__declspec(dllexport) void DirectBusWriteDebug(const NesDebugHandle nes_debug, const uint16_t address, const uint8_t data)
	{
		nes_debug->GetCpu()->Write(address, data);
	}

	__declspec(dllexport) uint8_t DirectBusReadDebug(const NesDebugHandle nes_debug, const uint16_t address)
	{
		return nes_debug->GetCpu()->Read(address);
	}
}