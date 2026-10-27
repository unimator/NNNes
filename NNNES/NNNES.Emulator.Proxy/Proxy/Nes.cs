using NNNES.Emulator.Proxy.Proxy;
using System.Runtime.InteropServices;

namespace NNNES.Emulator.Proxy
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

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "SetCpuRegisters")]
        private static extern void SetCpuRegisters(IntPtr nesInstance, ref CpuRegisters registers);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetCpuRegisters")]
        private static extern void GetRegisters(IntPtr nesInstance, ref CpuRegisters registers);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "SetCartridge")]
        private static extern void SetCartridge(IntPtr nesInstance, IntPtr nesCartridge);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "DisassembleByCount")]
        private static extern IntPtr DisassembleByCount(IntPtr nesInstance, ushort addressStart, uint count,
            out uint instructionsLength);

        private readonly IntPtr _instance;


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

        public void SetRegisters(CpuRegisters registers)
        {
            SetCpuRegisters(_instance, ref registers);
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