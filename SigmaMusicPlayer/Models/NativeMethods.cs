namespace SigmaMusicPlayer.Models;

#if Windows
public static class NativeMethods
{
    [DllImport("user32.dll")]
    public static extern bool RegisterHotKey(IntPtr hWnd, int id, 
        uint fsModifiers, uint vk);

    public const uint MOD_ALT = 0x0001;
    public const uint MOD_CONTROL = 0x0002;
}
#endif