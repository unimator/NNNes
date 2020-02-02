#pragma once
#include <array>

#define RAM_SIZE (2 * 1024)

class Ram
{
private:
	uint8_t* ram_;
	
public:

	Ram();
	~Ram();

	void Write(uint16_t address, uint8_t data);
	uint8_t Read(uint16_t address);

	void Clear() const;

	uint8_t* GetRam() const;
};

