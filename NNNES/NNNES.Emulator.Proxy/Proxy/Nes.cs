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

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "NextFrame")]
        private static extern void NextFrame(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "ResetState")]
        private static extern void ResetState(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "SetCpuRegisters")]
        private static extern void SetCpuRegisters(IntPtr nesInstance, ref CpuRegisters registers);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetCpuRegisters")]
        private static extern void GetRegisters(IntPtr nesInstance, ref CpuRegisters registers);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetRamAddress")]
        private static extern IntPtr GetRamAddress(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "SetCartridge")]
        private static extern void SetCartridge(IntPtr nesInstance, IntPtr nesCartridge);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "DisassembleByCount")]
        private static extern IntPtr DisassembleByCount(IntPtr nesInstance, ushort addressStart, uint count,
            out uint instructionsLength);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetFrameHandle")]
        private static extern IntPtr GetFrameHandle(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "IsFrameReady")]
        private static extern bool IsFrameReady(IntPtr nesInstance);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetChrRom")]
        private static extern void GetChrRom(IntPtr nesInstance, out IntPtr byteArray, out int size);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetPalletes")]
        private static extern void GetPalletes(IntPtr nesInstance, out IntPtr byteArray, out int size);
        private readonly IntPtr _instance;

        private byte[] _chrRom;

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
            _chrRom = null;
        }

        public void Reset()
        {
            ResetState(_instance);
            _chrRom = null;
        }

        public void Clock()
        {
            Clock(_instance);
        }

        public void NextInstruction()
        {
            NextInstruction(_instance);
        }

        public void NextFrame()
        {
            NextFrame(_instance);
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

        public byte[] GetRam(ushort addressStart, uint size)
        {
            var ramAddress = GetRamAddress(_instance);
            var data = new byte[size];
            Marshal.Copy(new IntPtr((IntPtr.Size == 4 ? ramAddress.ToInt32() : ramAddress.ToInt64()) + addressStart), data, 0, (int)size);
            return data;
        }

        public IntPtr GetFramePtr()
        {
            var frameHandle = GetFrameHandle(_instance);
            return frameHandle;
        }

        public bool IsFrameReady()
        {
            return IsFrameReady(_instance);
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

        public byte[]? GetChrRom()
        {
            if (_chrRom != null)
            {
                return _chrRom;
            }
            GetChrRom(_instance, out var byteArray, out var size);
            if (size == 0)
            {
                return null;
            }
            var data = new byte[size];
            Marshal.Copy(byteArray, data, 0, size);
            _chrRom = data;
            return data;
        }

        public byte[]? GetPalletes()
        {
            GetPalletes(_instance, out var byteArray, out var size);
            if (size == 0)
            {
                return null;
            }
            var data = new byte[size];
            Marshal.Copy(byteArray, data, 0, size);
            return data;
        }
    }
}