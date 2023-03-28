using System.Diagnostics;
using Pastel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace Battleships;
public static class UtilityCommands
{
    [DllImport("user32.dll")]
    public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

    public static void Maximize()
    {
        Process p = Process.GetCurrentProcess();
        ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
    }
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool SetCurrentConsoleFontEx(
    IntPtr consoleOutput,
    bool maximumWindow,
    ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);
    private const int LF_FACESIZE = 32;
    [StructLayout(LayoutKind.Sequential)]
    internal struct COORD
    {
        internal short X;
        internal short Y;
        internal COORD(short x, short y)
        {
            X = x;
            Y = y;
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    
    internal unsafe struct CONSOLE_FONT_INFO_EX
    {
    internal uint cbSize;
    internal uint nFont;
    internal COORD dwFontSize;
    internal int FontFamily;
    internal int FontWeight;
    internal fixed char FaceName[LF_FACESIZE];
    }
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(int nStdHandle);
    private const int STD_OUTPUT_HANDLE = -11;
    private const int TMPF_TRUETYPE = 4;
    private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool SetCurrentConsoleFontEx(
    IntPtr consoleOutput,
    bool maximumWindow,
    CONSOLE_FONT_INFO_EX consoleCurrentFontEx);
    public static void SetConsoleFont(string fontName = "Lucida Console") 
      {
          unsafe
          {
            IntPtr hnd = GetStdHandle(STD_OUTPUT_HANDLE);
            if (hnd != INVALID_HANDLE_VALUE)
            {
                CONSOLE_FONT_INFO_EX info = new CONSOLE_FONT_INFO_EX();
                info.cbSize = (uint)Marshal.SizeOf(info);

                // Set console font to Lucida Console.
                CONSOLE_FONT_INFO_EX newInfo = new CONSOLE_FONT_INFO_EX();
                newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
                newInfo.FontFamily = TMPF_TRUETYPE;
                IntPtr ptr = new IntPtr(newInfo.FaceName);
                Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

                // Get some settings from current font.
                newInfo.dwFontSize = new COORD(info.dwFontSize.X, info.dwFontSize.Y);
                newInfo.FontWeight = info.FontWeight;
                SetCurrentConsoleFontEx(hnd, false, newInfo);
            }
          }
      }
}
