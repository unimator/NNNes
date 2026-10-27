using System.Runtime.InteropServices;

namespace NNNES.Emulator.Proxy.Proxy;

[StructLayout(LayoutKind.Sequential)]
public struct CpuRegisters
{
    [MarshalAs(UnmanagedType.U1)]
    public byte Accumulator;

    [MarshalAs(UnmanagedType.U1)]
    public byte X;

    [MarshalAs(UnmanagedType.U1)]
    public byte Y;

    [MarshalAs(UnmanagedType.U2)]
    public ushort ProgramCounter;

    [MarshalAs(UnmanagedType.U1)]
    public byte Status;

    [MarshalAs(UnmanagedType.U1)]
    public byte Stack;
}