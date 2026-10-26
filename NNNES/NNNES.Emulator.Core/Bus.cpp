#include "pch.h"
#include "Nes.h"


Bus::Bus()
{
}

Bus::~Bus()
{

}

void Bus::SetINesHandle(INes* i_nes)
{
	this->i_nes_ = i_nes;
}

INes* Bus::GetINesHandle() const
{
	return this->i_nes_;
}

void Bus::Write(uint16_t address, uint8_t data) const
{
	auto device = GetAddressableDevice(address);
	device->Write(address, data);
}

uint8_t Bus::Read(uint16_t address) const
{
	auto device = GetAddressableDevice(address);
	return device->Read(address);
}

void Bus::AddDevice(Device* device)
{
	devices_.push_back(device);
	device->SetBus(this);
}

void Bus::RemoveDevice(Device* device)
{
	auto it = std::find(devices_.begin(), devices_.end(), device);
	if (it != devices_.end())
	{
		devices_.erase(it);
	}
}

AddressableDevice* Bus::GetAddressableDevice(uint16_t address) const
{
	for (size_t i = 0; i < devices_.size(); ++i)
	{
		AddressableDevice* addressable_device = dynamic_cast<AddressableDevice*>(devices_[i]);
		
		if(addressable_device == nullptr)
		{
			continue;
		}

		if (address >= addressable_device->BaseAddress() && address < addressable_device->BaseAddress() + addressable_device->VirtualSize())
		{
			return addressable_device;
		}
	}

	throw "Address out of range";
}
