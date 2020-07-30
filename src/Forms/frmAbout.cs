using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace DesktopManager
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            labelDesktopManager.Text = "Desktop Manager v" + Application.ProductVersion.Split('.')[0] + "." + Application.ProductVersion.Split('.')[1];
        }

        private void labelDesktopManager_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("www.expi.be/desktopmanager.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open webpage: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
