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
    public partial class frmOneZone : Form
    {
        Form handleForm;
        Profile profile;
        int zoneId;

        /// <summary>
        /// Completely new zone
        /// </summary>
        /// <param name="displays"></param>
        /// <param name="profile"></param>
        public frmOneZone(List<Display> displays, Profile profile, Form handle)
        {
            InitializeComponent();
            zoneId = -1;
            buttonRemove.Enabled = false;                        
            this.profile = profile;
            handleForm = handle;
            textBoxName.Text = profile.FreeZoneName();
            comboKey.DataSource = Enum.GetValues(typeof(Keys));
        }

        /// <summary>
        /// Editing an existing zone
        /// </summary>
        /// <param name="displays"></param>
        /// <param name="profile"></param>
        /// <param name="zoneId"></param>
        public frmOneZone(List<Display> displays, Profile profile, int zoneId, Form handle)
        {
            InitializeComponent();
            this.zoneId = zoneId;
            buttonRemove.Enabled = true;            
            this.profile = profile;
            handleForm = handle;
            textBoxName.Text = profile.Zones[zoneId].Name;
            
            comboKey.DataSource = Enum.GetValues(typeof(Keys));
            comboKey.SelectedItem = profile.Zones[zoneId].Hotkey.KeyCode;

            if (profile.Zones[zoneId].Hotkey.Alt)
            {
                modAlt.Checked = true;
            }
            if (profile.Zones[zoneId].Hotkey.Control)
            {
                modCtrl.Checked = true;
            }
            if (profile.Zones[zoneId].Hotkey.Shift)
            {
                modShift.Checked = true;
            }
            if (profile.Zones[zoneId].Hotkey.Windows)
            {
                modWinKey.Checked = true;
            }

            numX.Value = profile.Zones[zoneId].Area.X;
            numY.Value = profile.Zones[zoneId].Area.Y;
            numWidth.Value = profile.Zones[zoneId].Area.Width;
            numHeight.Value = profile.Zones[zoneId].Area.Height;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            bool validKey = true;

            if (!modAlt.Checked && !modCtrl.Checked && !modShift.Checked && !modWinKey.Checked)
            {
                validKey = false;
                //MessageBox.Show("You need to select at least one modifier (Alt, Ctrl, Shift or WinKey).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboKey.SelectedIndex == 0)
            {
                validKey = false;
                //MessageBox.Show("You need to select a key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var createdZone = new Zone(textBoxName.Text, new Area((int)numX.Value, (int)numY.Value, (int)numWidth.Value, (int)numHeight.Value));            
            if (validKey)
            {
                if (zoneId != -1) // Edit zone
                {
                    profile.Zones[zoneId].Unregister();
                }
                if (createdZone.Register(modAlt.Checked, modCtrl.Checked, modShift.Checked, modWinKey.Checked, (Keys)comboKey.SelectedItem, handleForm))
                {
                    if (zoneId == -1) // New zone
                    {
                        profile.AddZone(createdZone);
                    }
                    else // Edit zone
                    {                        
                        profile.Zones[zoneId] = createdZone;
                    }
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (zoneId == -1) // New zone
                {
                    profile.AddZone(createdZone);
                }
                else // Edit zone
                {
                    profile.Zones[zoneId] = createdZone;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {            
            if (MessageBox.Show("Are you sure you want to remove this zone?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                profile.Zones[zoneId].Unregister();
                profile.Zones.RemoveAt(zoneId);
            }
            DialogResult = DialogResult.Cancel;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
