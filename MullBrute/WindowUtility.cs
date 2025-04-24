using System;
using System.Runtime.InteropServices;

namespace MullBrute
{
    internal class WindowUtility
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

        const int MONITOR_DEFAULTTOPRIMARY = 1;

        [DllImport("user32.dll")]
        static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

        [StructLayout(LayoutKind.Sequential)]
        struct MONITORINFO
        {
            public uint cbSize;
            public RECT rcMonitor;
            public RECT rcWork;
            public uint dwFlags;

            public static MONITORINFO Default
            {
                get
                {
                    var inst = new MONITORINFO();
                    
                    inst.cbSize = (uint)Marshal.SizeOf(inst);
                    
                    return inst;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public int x, y;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

        const uint SW_RESTORE = 9;

        [StructLayout(LayoutKind.Sequential)]
        struct WINDOWPLACEMENT
        {
            public uint Length;
            public uint Flags;
            public uint ShowCmd;
            public POINT MinPosition;
            public POINT MaxPosition;
            public RECT NormalPosition;

            public static WINDOWPLACEMENT Default
            {
                get
                {
                    var instance = new WINDOWPLACEMENT();

                    instance.Length = (uint)Marshal.SizeOf(instance);

                    return instance;
                }
            }
        }

        internal enum AnchorWindow
        {
            None = 0x0,
            Top = 0x1,
            Bottom = 0x2,
            Left = 0x4,
            Right = 0x8,
            Center = 0x10,
            Fill = 0x20
        }

        internal static void SetConsoleWindowPosition(AnchorWindow position)
        {
            IntPtr hWnd = GetConsoleWindow();
            var monitorInfo = MONITORINFO.Default;

            GetMonitorInfo(MonitorFromWindow(hWnd, MONITOR_DEFAULTTOPRIMARY), ref monitorInfo);

            var windowPlacement = WINDOWPLACEMENT.Default;

            GetWindowPlacement(hWnd, ref windowPlacement);

            int fudgeOffset = 7;
            int _left = 0;
            int _top = 0;

            switch (position)
            {
                case AnchorWindow.Left | AnchorWindow.Top:

                    windowPlacement.NormalPosition = new RECT()
                    {
                        Left = -fudgeOffset,
                        Top = monitorInfo.rcWork.Top,
                        Right = (windowPlacement.NormalPosition.Right - windowPlacement.NormalPosition.Left) - fudgeOffset,
                        Bottom = (windowPlacement.NormalPosition.Bottom - windowPlacement.NormalPosition.Top)
                    };

                    break;

                case AnchorWindow.Right | AnchorWindow.Top:

                    windowPlacement.NormalPosition = new RECT()
                    {
                        Left = monitorInfo.rcWork.Right - windowPlacement.NormalPosition.Right + windowPlacement.NormalPosition.Left + fudgeOffset,
                        Top = monitorInfo.rcWork.Top,
                        Right = monitorInfo.rcWork.Right + fudgeOffset,
                        Bottom = (windowPlacement.NormalPosition.Bottom - windowPlacement.NormalPosition.Top)
                    };

                    break;

                case AnchorWindow.Left | AnchorWindow.Bottom:

                    windowPlacement.NormalPosition = new RECT()
                    {
                        Left = -fudgeOffset,
                        Top = monitorInfo.rcWork.Bottom - (windowPlacement.NormalPosition.Bottom - windowPlacement.NormalPosition.Top),
                        Right = (windowPlacement.NormalPosition.Right - windowPlacement.NormalPosition.Left) - fudgeOffset,
                        Bottom = fudgeOffset + monitorInfo.rcWork.Bottom
                    };

                    break;

                case AnchorWindow.Right | AnchorWindow.Bottom:

                    windowPlacement.NormalPosition = new RECT()
                    {
                        Left = monitorInfo.rcWork.Right - windowPlacement.NormalPosition.Right + windowPlacement.NormalPosition.Left + fudgeOffset,
                        Top = monitorInfo.rcWork.Bottom - (windowPlacement.NormalPosition.Bottom - windowPlacement.NormalPosition.Top),
                        Right = monitorInfo.rcWork.Right + fudgeOffset,
                        Bottom = fudgeOffset + monitorInfo.rcWork.Bottom
                    };

                    break;

                case AnchorWindow.Center | AnchorWindow.Top:

                    _left = monitorInfo.rcWork.Right / 2 - (windowPlacement.NormalPosition.Right - windowPlacement.NormalPosition.Left) / 2;

                    windowPlacement.NormalPosition = new RECT()
                    {
                        Left = _left,
                        Top = monitorInfo.rcWork.Top,
                        Right = monitorInfo.rcWork.Right + fudgeOffset - _left,
                        Bottom = (windowPlacement.NormalPosition.Bottom - windowPlacement.NormalPosition.Top)
                    };

                    break;

                case AnchorWindow.Center | AnchorWindow.Bottom:

                    _left = monitorInfo.rcWork.Right / 2 - (windowPlacement.NormalPosition.Right - windowPlacement.NormalPosition.Left) / 2;

                    windowPlacement.NormalPosition = new RECT()
                    {
                        Left = _left,
                        Top = monitorInfo.rcWork.Bottom - (windowPlacement.NormalPosition.Bottom - windowPlacement.NormalPosition.Top),
                        Right = monitorInfo.rcWork.Right + fudgeOffset - _left,
                        Bottom = fudgeOffset + monitorInfo.rcWork.Bottom
                    };

                    break;

                case AnchorWindow.Center:

                    _left = monitorInfo.rcWork.Right / 2 - (windowPlacement.NormalPosition.Right - windowPlacement.NormalPosition.Left) / 2;
                    _top = monitorInfo.rcWork.Bottom / 2 - (windowPlacement.NormalPosition.Bottom - windowPlacement.NormalPosition.Top) / 2;

                    windowPlacement.NormalPosition = new RECT()
                    {
                        Left = _left,
                        Top = _top,
                        Right = monitorInfo.rcWork.Right + fudgeOffset - _left,
                        Bottom = monitorInfo.rcWork.Bottom + fudgeOffset - _top
                    };

                    break;

                case AnchorWindow.Fill:

                    windowPlacement.NormalPosition = new RECT()
                    {
                        Left = -fudgeOffset,
                        Top = monitorInfo.rcWork.Top,
                        Right = monitorInfo.rcWork.Right + fudgeOffset,
                        Bottom = monitorInfo.rcWork.Bottom + fudgeOffset
                    };

                    break;

                default:

                    return;
            }

            SetWindowPlacement(hWnd, ref windowPlacement);
        }
    }
}