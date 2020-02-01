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

        private readonly IntPtr _instance;

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