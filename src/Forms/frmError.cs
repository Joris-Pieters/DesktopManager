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
    public partial class frmError : Form
    {
        public frmError(Exception ex)
        {
            InitializeComponent();
            label.Text =
                "Something went wrong. This is not your fault, but probably the result \r\n" +
                "of one of our programmers not doing a good job. We will make the \r\n" +
                "responsible person pay for this, but we can only do that if you raise \r\n" +
                "our awareness. \r\n" +
                "To do this, copy the message in the textbox hereunder, and paste it \r\n" +
                "on the contact form on our website. We thank you for your help \r\n" +
                "improving the product.";
            textBox.Text =
                "Desktop Manager v" + Application.ProductVersion.Split('.')[0] + "." + Application.ProductVersion.Split('.')[1] + "\r\n" +
                ex.Message + "\r\n" + ex.Data + "\r\n" + ex.InnerException + "\r\n" + ex.Source + "\r\n" + ex.StackTrace + "\r\n" + ex.TargetSite;
            Clipboard.SetText(textBox.Text);
        }

        private void labelContact_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("www.expi.be/contact.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open webpage: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox.Text);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       


    }
}
