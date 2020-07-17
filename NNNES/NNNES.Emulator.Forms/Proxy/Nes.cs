using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace NNNES.Emulator.Forms.Proxy
{
    public class Nes
    {
        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "CreateInstance")]
        private static extern IntPtr CreateInstance();

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "DestroyInstance")]
        private static extern void DestroyInstance(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "Clock")]
        private static extern void Clock(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "NextInstruction")]
        private static extern void NextInstruction(IntPtr nesInstance);
        
        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "ResetState")]
        private static extern void ResetState(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetCpuRegisters")]
        private static extern void GetRegisters(IntPtr nesInstance, ref CpuRegisters registers);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "SetCartridge")]
        private static extern void SetCartridge(IntPtr nesInstance, IntPtr nesCartridge);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "DisassembleByCount")]
        private static extern IntPtr DisassembleByCount(IntPtr nesInstance, ushort addressStart, uint count,
            out uint instructionsLength);

        private readonly IntPtr _instance;

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

        [StructLayout(LayoutKind.Sequential)]
        public struct InstructionInfo
        {
            [MarshalAs(UnmanagedType.U2)]
            public ushort Address;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            private char [] MnemonicInternal;

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
;                   }
                    throw new ArgumentOutOfRangeException(nameof(AddressingModeInternal));
                }
            }
        }

        public Nes()
        {
            _instance = CreateInstance();
        }

        ~Nes()
        {
            DestroyInstance(_instance);
        }

        public void SetCartridge(NesCartridge cartridge)
        {
            SetCartridge(_instance, cartridge.INesHandle);
        }

        public void Reset()
        {
            ResetState(_instance);
        }

        public void Clock()
        {
            Clock(_instance);
        }

        public void NextInstruction()
        {
            NextInstruction(_instance);
        }

        public CpuRegisters GetRegisters()
        {
            var cpuRegisters = new CpuRegisters();
            GetRegisters(_instance, ref cpuRegisters);
            return cpuRegisters;
        }

        public IEnumerable<InstructionInfo> DisassembleByCount(ushort addressStart, uint count)
        {
            var rawData = DisassembleByCount(_instance, addressStart, count, out var length);
            var instructionInfoSize = Marshal.SizeOf<InstructionInfo>();
            var result = new InstructionInfo[length];

            for (var i = 0; i < length; ++i)
            {
                var ptr = new IntPtr((IntPtr.Size == 4 ? rawData.ToInt32() : rawData.ToInt64()) + i * instructionInfoSize);
                result[i] = Marshal.PtrToStructure<InstructionInfo>(ptr);
            }

            return result;
        }
    }
}