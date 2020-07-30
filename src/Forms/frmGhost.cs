using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopManager
{
    public partial class frmGhost : Form
    {
        public frmGhost(bool tray = false)
        {
            InitializeComponent();
            Settings.MainHandle = this.Handle;
            this.Hide();
            Application.Run(new frmMain(tray));
        }
    }
}
