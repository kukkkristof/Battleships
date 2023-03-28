using System;
using System.Runtime.InteropServices;

class BackgroundColorChanger
{
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool GetConsoleScreenBufferInfo_EX(IntPtr hConsoleOutput, out CONSOLE_SCREEN_BUFFER_INFO_EX lpConsoleScreenBufferInfo);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool SetConsoleScreenBufferInfo_EX(IntPtr hConsoleOutput, ref CONSOLE_SCREEN_BUFFER_INFO_EX lpConsoleScreenBufferInfo);

    [StructLayout(LayoutKind.Sequential)]
    struct COORD
    {
        public short X;
        public short Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct SMALL_RECT
    {
        public short Left;
        public short Top;
        public short Right;
        public short Bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct COLORREF
    {
        public byte R;
        public byte G;
        public byte B;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct CONSOLE_SCREEN_BUFFER_INFO
    {
        public COORD dwSize;
        public COORD dwCursorPosition;
        public ushort wAttributes;
        public SMALL_RECT srWindow;
        public COORD dwMaximumWindowSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct CONSOLE_SCREEN_BUFFER_INFO_EX
    {
        public uint cbSize;
        public COORD dwSize;
        public COORD dwCursorPosition;
        public ushort wAttributes;
        public SMALL_RECT srWindow;
        public COORD dwMaximumWindowSize;
        public ushort wPopupAttributes;
        public bool bFullscreenSupported;
        public COLORREF black;
        public COLORREF darkBlue;
        public COLORREF darkGreen;
        public COLORREF darkCyan;
        public COLORREF darkRed;
        public COLORREF darkMagenta;
        public COLORREF darkYellow;
        public COLORREF gray;
        public COLORREF darkGray;
        public COLORREF blue;
        public COLORREF green;
        public COLORREF cyan;
        public COLORREF red;
        public COLORREF magenta;
        public COLORREF yellow;
    }

    public static void ChangeBackGround(byte r, byte g, byte b)
    {
        var handle = GetStdHandle(-11); // STD_OUTPUT_HANDLE
        var csbi = new CONSOLE_SCREEN_BUFFER_INFO_EX();
        if (!GetConsoleScreenBufferInfo_EX(handle, out csbi))
            throw new Exception("GetConsoleScreenBufferInfo failed: " + Marshal.GetLastWin32Error());
        var csbe = new CONSOLE_SCREEN_BUFFER_INFO_EX();
        csbe.cbSize = (uint)Marshal.SizeOf<CONSOLE_SCREEN_BUFFER_INFO_EX>();
        csbe.dwSize = csbi.dwSize;
        csbe.srWindow = csbi.srWindow;
        csbe.dwMaximumWindowSize = csbi.dwMaximumWindowSize;
        csbe.blue = new COLORREF { R = r, G = g, B = b }; // Set background to blue
        if (!SetConsoleScreenBufferInfo_EX(handle, ref csbe))
            throw new Exception("SetConsoleScreenBufferInfo failed: " + Marshal.GetLastWin32Error());
        Console.WriteLine("Hello, world!");
    }
}