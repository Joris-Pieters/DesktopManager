namespace DesktopManager
{
    partial class frmMultipleZones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numHorizontal = new System.Windows.Forms.NumericUpDown();
            this.numericVertical = new System.Windows.Forms.NumericUpDown();
            this.comboDisplays = new System.Windows.Forms.ComboBox();
            this.radioButtonEqual = new System.Windows.Forms.RadioButton();
            this.radioButtonTemplate = new System.Windows.Forms.RadioButton();
            this.dataGridViewTemplates = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplates)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCancel.Location = new System.Drawing.Point(162, 345);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 27);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonOk.Location = new System.Drawing.Point(68, 345);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(87, 27);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(28, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Screen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(178, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Vertical:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(28, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Horizontal:";
            // 
            // numHorizontal
            // 
            this.numHorizontal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numHorizontal.Location = new System.Drawing.Point(96, 80);
            this.numHorizontal.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numHorizontal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHorizontal.Name = "numHorizontal";
            this.numHorizontal.Size = new System.Drawing.Size(65, 23);
            this.numHorizontal.TabIndex = 3;
            this.numHorizontal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericVertical
            // 
            this.numericVertical.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numericVertical.Location = new System.Drawing.Point(234, 81);
            this.numericVertical.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericVertical.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericVertical.Name = "numericVertical";
            this.numericVertical.Size = new System.Drawing.Size(65, 23);
            this.numericVertical.TabIndex = 4;
            this.numericVertical.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboDisplays
            // 
            this.comboDisplays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDisplays.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboDisplays.FormattingEnabled = true;
            this.comboDisplays.Location = new System.Drawing.Point(82, 10);
            this.comboDisplays.Name = "comboDisplays";
            this.comboDisplays.Size = new System.Drawing.Size(203, 23);
            this.comboDisplays.TabIndex = 1;
            // 
            // radioButtonEqual
            // 
            this.radioButtonEqual.AutoSize = true;
            this.radioButtonEqual.Checked = true;
            this.radioButtonEqual.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radioButtonEqual.Location = new System.Drawing.Point(14, 53);
            this.radioButtonEqual.Name = "radioButtonEqual";
            this.radioButtonEqual.Size = new System.Drawing.Size(183, 19);
            this.radioButtonEqual.TabIndex = 2;
            this.radioButtonEqual.TabStop = true;
            this.radioButtonEqual.Text = "Divide screen into equal parts:";
            this.radioButtonEqual.UseVisualStyleBackColor = true;
            // 
            // radioButtonTemplate
            // 
            this.radioButtonTemplate.AutoSize = true;
            this.radioButtonTemplate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radioButtonTemplate.Location = new System.Drawing.Point(14, 120);
            this.radioButtonTemplate.Name = "radioButtonTemplate";
            this.radioButtonTemplate.Size = new System.Drawing.Size(156, 19);
            this.radioButtonTemplate.TabIndex = 5;
            this.radioButtonTemplate.Text = "Choose from a template:";
            this.radioButtonTemplate.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTemplates
            // 
            this.dataGridViewTemplates.AllowUserToAddRows = false;
            this.dataGridViewTemplates.AllowUserToDeleteRows = false;
            this.dataGridViewTemplates.AllowUserToOrderColumns = true;
            this.dataGridViewTemplates.AllowUserToResizeColumns = false;
            this.dataGridViewTemplates.AllowUserToResizeRows = false;
            this.dataGridViewTemplates.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTemplates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewTemplates.ColumnHeadersVisible = false;
            this.dataGridViewTemplates.GridColor = System.Drawing.Color.White;
            this.dataGridViewTemplates.Location = new System.Drawing.Point(31, 147);
            this.dataGridViewTemplates.MultiSelect = false;
            this.dataGridViewTemplates.Name = "dataGridViewTemplates";
            this.dataGridViewTemplates.RowHeadersVisible = false;
            this.dataGridViewTemplates.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewTemplates.Size = new System.Drawing.Size(230, 192);
            this.dataGridViewTemplates.TabIndex = 6;
            this.dataGridViewTemplates.Click += new System.EventHandler(this.dataGridViewTemplates_Click);
            // 
            // frmMultipleZones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 376);
            this.Controls.Add(this.dataGridViewTemplates);
            this.Controls.Add(this.radioButtonTemplate);
            this.Controls.Add(this.radioButtonEqual);
            this.Controls.Add(this.comboDisplays);
            this.Controls.Add(this.numericVertical);
            this.Controls.Add(this.numHorizontal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMultipleZones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Multiple zones";
            ((System.ComponentModel.ISupportInitialize)(this.numHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numHorizontal;
        private System.Windows.Forms.NumericUpDown numericVertical;
        private System.Windows.Forms.ComboBox comboDisplays;
        private System.Windows.Forms.RadioButton radioButtonEqual;
        private System.Windows.Forms.RadioButton radioButtonTemplate;
        private System.Windows.Forms.DataGridView dataGridViewTemplates;
    }
}