#pragma once

#include <cstdint>

#define FRAME_WIDTH 256
#define FRAME_HEIGHT 240

class Frame
{
public:
	uint32_t pixels[FRAME_WIDTH * FRAME_HEIGHT];
	bool frame_ready = false;
};