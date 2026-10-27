using System.Runtime.InteropServices;

namespace NNNES.Emulator.Proxy.Proxy;

[StructLayout(LayoutKind.Sequential)]
public struct InstructionInfo
{
    [MarshalAs(UnmanagedType.U2)]
    public ushort Address;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    private char[] MnemonicInternal;

    [MarshalAs(UnmanagedType.U4)]
    private uint AddressingModeInternal;

    [MarshalAs(UnmanagedType.U1)]
    public byte ArgumentsNumber;

    [MarshalAs(UnmanagedType.U1)]
    public byte Argument1;

    [MarshalAs(UnmanagedType.U1)]
    public byte Argument2;

    public string Mnemonic => new string(MnemonicInternal.Take(MnemonicInternal.Length - 1).ToArray());

    public string AddressingMode
    {
        get
        {
            switch (AddressingModeInternal)
            {
                case 0:
                    return "IMM";
                case 1:
                    return "IMP";
                case 2:
                    return "REL";
                case 3:
                    return "ZP ";
                case 4:
                    return "ZPX";
                case 5:
                    return "ZPY";
                case 6:
                    return "ABS";
                case 7:
                    return "ABX";
                case 8:
                    return "ABY";
                case 9:
                    return "IND";
                case 10:
                    return "INX";
                case 11:
                    return "INY";
            }
            throw new ArgumentOutOfRangeException(nameof(AddressingModeInternal));
        }
    }
}