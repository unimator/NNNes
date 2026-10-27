using NNNES.Emulator.Proxy.Proxy;
using System.Runtime.InteropServices;

namespace NNNES.Emulator.Core.Tests.Proxy
{
    public class NesDebug
    {

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "CreateDebugInstance")]
        private static extern IntPtr CreateDebugInstance();

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "DestroyDebugInstance")]
        private static extern void DestroyDebugInstance(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "ClockDebug")]
        private static extern void ClockDebug(IntPtr nesInstance);
        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "NextInstructionDebug")]
        private static extern void NextInstructionDebug(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "ResetStateDebug")]
        private static extern void ResetStateDebug(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "SetCpuRegistersDebug")]
        private static extern void SetCpuRegistersDebug(IntPtr nesInstance, ref CpuRegisters registers);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetCpuRegistersDebug")]
        private static extern void GetRegistersDebug(IntPtr nesInstance, ref CpuRegisters registers);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "DirectBusWriteDebug")]
        private static extern void DirectBusWriteDebug(IntPtr nesInstance, ushort address, byte data);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "DirectBusReadDebug")]
        private static extern byte DirectBusReadDebug(IntPtr nesInstance, ushort address);

        private readonly IntPtr _instance;

        public void WriteToBus(ushort address, byte data)
        {
            DirectBusWriteDebug(_instance, address, data);
        }

        public byte ReadFromBus(ushort address)
        {
            return DirectBusReadDebug(_instance, address);
        }

        public NesDebug()
        {
            _instance = CreateDebugInstance();
        }

        ~NesDebug()
        {
            DestroyDebugInstance(_instance);
        }

        public void Reset()
        {
            ResetStateDebug(_instance);
        }

        public void Clock()
        {
            ClockDebug(_instance);
        }

        public void NextInstruction()
        {
            NextInstructionDebug(_instance);
        }

        public void SetRegisters(CpuRegisters registers)
        {
            SetCpuRegistersDebug(_instance, ref registers);
        }

        public CpuRegisters GetRegisters()
        {
            var cpuRegisters = new CpuRegisters();
            GetRegistersDebug(_instance, ref cpuRegisters);
            return cpuRegisters;
        }
    }
}
