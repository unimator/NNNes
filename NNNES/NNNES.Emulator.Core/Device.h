#pragma once
#include <cstdint>

class Bus;

class Device
{
protected:
	Bus* bus_ = nullptr;

	Device() = default;
	
public:
	virtual ~Device() = default;

	void SetBus(Bus* bus);
};
