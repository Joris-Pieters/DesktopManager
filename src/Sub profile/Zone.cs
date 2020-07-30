using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Windows.Forms;

namespace DesktopManager
{
    public class Zone : IDisposable
    {        
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        
        [DllImport("user32.dll")]
        private static extern  bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        public string Name;
        public Area Area;
        public Hotkey Hotkey;

        public Zone()
        {
            Area = new Area();
            Hotkey = new Hotkey();
        }

        public Zone(string name)
        {
            Name = name;
            Area = new Area();
            Hotkey = new Hotkey();
        }

        public Zone(string name, Area area)
        {
            Name = name;
            Area = area;
            Hotkey = new Hotkey();
        }

        public Zone(string name, Hotkey hotkey)
        {
            Name = name;
            Hotkey = hotkey;
            Area = new Area();
        }

        public Zone(string name, Area area, Hotkey hotkey)
        {
            Name = name;
            Area = area;
            Hotkey = hotkey;           
        }

        public void Dispose()
        {
            Unregister();
        }

        public override string ToString()
        {
            return Name + " " + Area + " " + Hotkey;
        }

        public void Register(Control windowControl)
        {
            Register(Hotkey.Alt, Hotkey.Control, Hotkey.Shift, Hotkey.Windows, Hotkey.KeyCode, windowControl);
        }

        public bool Register(bool alt, bool ctrl, bool shift, bool winkey, Keys key, Control windowControl)
        {
            Unregister();
            Hotkey = new Hotkey(key, alt, ctrl, shift, winkey);
            if (Hotkey.GetCanRegister(windowControl))
            {
                Hotkey.Pressed += delegate { MoveHere(); };
                Hotkey.Register(windowControl);
                return true;
            }
            else
            {
                MessageBox.Show("Something went wrong registering this hotkey. Try another combination.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void Unregister()
        {
            try
            {
                if (Hotkey.Registered)
                {
                    Hotkey.Unregister();
                }                
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void MoveHere()
        {
            MoveHere((IntPtr)GetForegroundWindow());
        }

        public void MoveHere(IntPtr hWnd)
        {
            if (hWnd != IntPtr.Zero)
            {
                SetWindowPos(hWnd, Settings.MainHandle, Area.X, Area.Y, Area.Width, Area.Height, 0);
                ForceForegroundWindow(hWnd);
            }
        }

        private void ForceForegroundWindow(IntPtr hWnd)
        {
            uint foreThread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
            uint appThread = GetCurrentThreadId();
            const uint SW_SHOW = 5;
            if (foreThread != appThread)
            {
                AttachThreadInput(foreThread, appThread, true);
                BringWindowToTop(hWnd);
                ShowWindow(hWnd, SW_SHOW);
                AttachThreadInput(foreThread, appThread, false);
            }
            else
            {
                BringWindowToTop(hWnd);
                ShowWindow(hWnd, SW_SHOW);
            }
        }

        private string WindowName(IntPtr hWnd)
        {
            StringBuilder ClassName = new StringBuilder(100);
            int nRet = GetClassName(hWnd, ClassName, ClassName.Capacity);
            return ClassName.ToString();
        }

    }

}
