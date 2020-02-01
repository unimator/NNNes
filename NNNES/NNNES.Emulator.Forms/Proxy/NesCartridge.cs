using System;
using System.Runtime.InteropServices;

namespace NNNES.Emulator.Forms.Proxy
{
    public class NesCartridge
    {
        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "LoadINes")]
        private static extern IntPtr LoadINes(byte[] bytes, int length);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "DestroyINes")]
        private static extern void DestroyINes(IntPtr iNesHandle);

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetPrgRom")]
        private static extern void GetPrgRom(IntPtr iNesHandle, out IntPtr byteArray, out int size);

        /*[DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetPrgRomSize")]
        private static extern uint GetPrgRomSize(IntPtr iNesHandle);*/

        [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetChrRom")]
        private static extern void GetChrRom(IntPtr iNesHandle, out IntPtr byteArray, out int size);

        /*[DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetChrRomSize")]
        private static extern uint GetChrRomSize(IntPtr iNesHandle);*/


        private readonly IntPtr _iNesHandle;
        private byte[] _prgRom;
        private byte[] _chrRom;
        
        public NesCartridge(byte[] bytes)
        {
            _iNesHandle = LoadINes(bytes, bytes.Length);
        }

        ~NesCartridge()
        {
            DestroyINes(_iNesHandle);
        }

        public byte[] GetPrgRom()
        {
            if (_prgRom != null)
            {
                return _prgRom;
            }
            GetPrgRom(_iNesHandle, out var byteArray, out var size);
            var data = new byte[size];
            Marshal.Copy(byteArray, data, 0, size);
            _prgRom = data;
            return data;
        }

        public byte[] GetChrRom()
        {
            if (_chrRom != null)
            {
                return _chrRom;
            }
            GetChrRom(_iNesHandle, out var byteArray, out var size);
            if (size == 0)
            {
                return null;
            }
            var data = new byte[size];
            Marshal.Copy(byteArray, data, 0, size);
            _chrRom = data;
            return data;
        }

    }
}