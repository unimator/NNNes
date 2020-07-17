#pragma once
#include "Ram.h"

#define TABLE_NAME_SIZE 1024
#define PALETTE_SIZE 32

class PpuRam
{
private:
	uint8_t* primaryNameTable;;
	uint8_t* secondaryNameTable;
	uint8_t* paletteTable;
	
public:
	PpuRam();
	virtual ~PpuRam();
};
