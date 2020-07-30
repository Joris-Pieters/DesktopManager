using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;

namespace DesktopManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //try
            //{
                bool tray = false;

                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].Contains("-t"))
                    {
                        tray = true;
                    }
                }

                if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    MessageBox.Show("Application already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmGhost(tray));
                }
            /*}
            catch (Exception ex)
            {
                using (var frm = new frmError(ex))
                {
                    frm.ShowDialog();
                }
            }*/
        }
    }
}
