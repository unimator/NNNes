﻿using System;

namespace NNNES.Emulator.Forms
{
    [Flags]
    public enum CpuFlags
    {
		C = (1 << 0),
        Z = (1 << 1),
        I = (1 << 2),
        D = (1 << 3),
        B = (1 << 4),
        U = (1 << 5),
        V = (1 << 6),
        N = (1 << 7)
	}
}