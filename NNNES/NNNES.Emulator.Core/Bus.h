#pragma once
#include <vector>
#include "INes.h"

class Device;
class AddressableDevice;

class Bus
{
private:
	INes* i_nes_;

	AddressableDevice* GetAddressableDevice(uint16_t address) const;

	uint8_t clock_counter_;

	std::vector<Device*> devices_;

public:

	Bus();
	~Bus();

	void SetINesHandle(INes* i_nes);
	INes* GetINesHandle() const;

	void AddDevice(Device* device);
	void RemoveDevice(Device* device);
	
	auto GetDevices() const -> const std::vector<Device*>& { return devices_; }
	
	void Write(uint16_t address, uint8_t data) const;
	uint8_t Read(uint16_t address) const;
};
