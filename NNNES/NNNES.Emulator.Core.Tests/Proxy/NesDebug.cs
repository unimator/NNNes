using NNNES.Emulator.Proxy;
using System.Runtime.InteropServices;

namespace NNNES.Emulator.Core.Tests.Proxy
{
    public class NesDebug : Nes
    {
        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "DirectBusWrite")]
        private static extern void DirectBusWrite(IntPtr nesInstance, ushort address, byte data);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "DirectBusRead")]
        private static extern byte DirectBusRead(IntPtr nesInstance, ushort address);


        public void WriteToBus(ushort address, byte data)
        {
            DirectBusWrite(_instance, address, data);
        }

        public byte ReadFromBus(ushort address)
        {
            return DirectBusRead(_instance, address);
        }
    }
}
