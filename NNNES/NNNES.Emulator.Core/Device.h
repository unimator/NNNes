#pragma once
#include <cstdint>

class Bus;

class Device
{
private:
	bool non_maskable_interrupt_ = false;

protected:
	Bus* bus_ = nullptr;

	Device() = default;
	
public:
	virtual ~Device() = default;

	auto SetNonMaskableInterrupt() -> auto { non_maskable_interrupt_ = true; }
	auto ClearNonMaskableInterrupt() -> auto { non_maskable_interrupt_ = false; }
	auto NonMaskableInterrupt() -> auto { return non_maskable_interrupt_; }

	void SetBus(Bus* bus);
};
