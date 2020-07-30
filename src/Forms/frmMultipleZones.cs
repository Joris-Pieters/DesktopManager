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
    public partial class frmMultipleZones : Form
    {
    
        private Profile profile;
        private List<ZoneTemplate> zoneTemplateList;

        public frmMultipleZones(List<Display> displays, Profile profile, List<ZoneTemplate> zoneTemplateList, int onDisplay = 0)
        {
            InitializeComponent();
            this.profile = profile;
            this.zoneTemplateList = zoneTemplateList;
            foreach (Display display in displays)
            {
                comboDisplays.Items.Add(display.Name);
            }
            comboDisplays.SelectedIndex = onDisplay;

            for (int i = 0; i < 2; i++)
            {
                dataGridViewTemplates.Columns.Add(new DataGridViewImageColumn());
                dataGridViewTemplates.Columns[i].Width = 105;
            }

            int row = 0;
            int col = 0;
            for(int i = 0; i < zoneTemplateList.Count; i++)
            {
                if (col == 0)
                {
                    dataGridViewTemplates.Rows.Add();
                    dataGridViewTemplates.Rows[row].Height = 63;
                }
                dataGridViewTemplates[col, row].Value = zoneTemplateList[i].Image;
                col++;
                if (col == 2)
                {
                    col = 0;
                    row++;
                }
            }
            
            dataGridViewTemplates[0, 0].Selected = true;
            dataGridViewTemplates.ClearSelection();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {            
            if (comboDisplays.SelectedItem == null)
            {
                MessageBox.Show("You need to select a screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (radioButtonEqual.Checked)
                {
                    profile.AddMultipleZones((string)comboDisplays.SelectedItem, (int)numHorizontal.Value, (int)numericVertical.Value);
                    DialogResult = DialogResult.OK;
                }
                else if (radioButtonTemplate.Checked)
                {
                    if (dataGridViewTemplates.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("You need to select a template.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        profile.AddMultipleZones((string)comboDisplays.SelectedItem, 
                            TemplateFrom(dataGridViewTemplates.SelectedCells[0].RowIndex, dataGridViewTemplates.SelectedCells[0].ColumnIndex));
                        DialogResult = DialogResult.OK;
                    }
                }                
            }
        }

        private ZoneTemplate TemplateFrom(int row, int column)
        {
            return zoneTemplateList[(2 * row) + column];
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dataGridViewTemplates_Click(object sender, EventArgs e)
        {
            radioButtonTemplate.Checked = true;
        }


        
    }
}
