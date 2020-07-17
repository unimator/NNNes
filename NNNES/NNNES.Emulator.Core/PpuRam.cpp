#include "pch.h"
#include "PpuRam.h"

PpuRam::PpuRam()
{
	primaryNameTable = new uint8_t[TABLE_NAME_SIZE];
	secondaryNameTable = new uint8_t[TABLE_NAME_SIZE];
	paletteTable = new uint8_t[PALETTE_SIZE];
}

PpuRam::~PpuRam()
{
	if (primaryNameTable) delete [] primaryNameTable;
	if (secondaryNameTable) delete [] secondaryNameTable;
	if (paletteTable) delete [] paletteTable;
}

