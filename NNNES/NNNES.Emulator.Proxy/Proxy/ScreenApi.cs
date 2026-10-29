using System.Runtime.InteropServices;

namespace NNNES.Emulator.Proxy.Proxy;

public static class ScreenApi
{

    [DllImport("NNNES.Emulator.Core.dll", EntryPoint = "GetScreenPalette")]
    private static extern void GetScreenPalette(out IntPtr screenColors, out int size);

    private static int[] _screenPalette;

    public static int[] GetScreenPalette()
    {
        if(_screenPalette != null)
        {
            return _screenPalette;
        }

        GetScreenPalette(out var screenColors, out var size);
        _screenPalette = new int[size];
        Marshal.Copy(screenColors, (Int32[])(object)_screenPalette, 0, size);
        return _screenPalette;
    }
}
