using System;
using System.Runtime.InteropServices;

namespace NNNES.Emulator.Forms.Proxy
{
    public class Nes
    {
        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "CreateInstance")]
        private static extern IntPtr CreateInstance();

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "DestroyInstance")]
        private static extern void DestroyInstance(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "Run")]
        private static extern int Run(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetCpuRegisters")]
        private static extern IntPtr GetRegisters(IntPtr nesInstance);

        private readonly IntPtr _instance;

        [StructLayout(LayoutKind.Sequential)]
        public struct CpuRegisters
        {
            public byte Accumulator { get; set; }
            public byte X { get; set; }
            public byte Y { get; set; }
            public short ProgramCounter { get; set; }
            public byte Status { get; set; }
            public byte Stack { get; set; }
        }

        private CpuRegisters? _registers;

        public CpuRegisters Registers
        {
            get
            {
                if (_registers.HasValue)
                {
                    return _registers.Value;
                }

                var cpuRegistersHandle = GetRegisters(_instance);
                _registers = Marshal.PtrToStructure<CpuRegisters>(cpuRegistersHandle);
                //Marshal.FreeHGlobal(cpuRegistersHandle);
                return _registers.Value;
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
    }
}