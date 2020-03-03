using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NNNES.Emulator.Forms.Proxy
{
    public class Nes
    {
        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "CreateInstance")]
        private static extern IntPtr CreateInstance();

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "DestroyInstance")]
        private static extern void DestroyInstance(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "Clock")]
        private static extern int Clock(IntPtr nesInstance);
        
        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "ResetState")]
        private static extern void ResetState(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetCpuRegisters")]
        private static extern void GetRegisters(IntPtr nesInstance, ref CpuRegisters registers);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "SetCartridge")]
        private static extern void SetCartridge(IntPtr nesInstance, IntPtr nesCartridge);
        
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

        private CpuRegisters? _registers;

        public CpuRegisters Registers
        {
            get
            {
                if (_registers.HasValue)
                {
                    return _registers.Value;
                }
                
                var cpuRegisters = new CpuRegisters();
                GetRegisters(_instance, ref cpuRegisters);
                _registers = cpuRegisters;
                
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

        public void SetCartridge(NesCartridge cartridge)
        {
            SetCartridge(_instance, cartridge.INesHandle);
        }
    }
}