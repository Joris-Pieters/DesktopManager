namespace DesktopManager
{
    partial class frmOneZone
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboKey = new System.Windows.Forms.ComboBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.modAlt = new System.Windows.Forms.CheckBox();
            this.modCtrl = new System.Windows.Forms.CheckBox();
            this.modShift = new System.Windows.Forms.CheckBox();
            this.modWinKey = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonOk.Location = new System.Drawing.Point(6, 167);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(87, 27);
            this.buttonOk.TabIndex = 10;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCancel.Location = new System.Drawing.Point(195, 167);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 27);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // numWidth
            // 
            this.numWidth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numWidth.Location = new System.Drawing.Point(182, 100);
            this.numWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(65, 23);
            this.numWidth.TabIndex = 7;
            this.numWidth.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
            // 
            // numX
            // 
            this.numX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numX.Location = new System.Drawing.Point(54, 100);
            this.numX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(65, 23);
            this.numX.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(29, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(136, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Width:";
            // 
            // numHeight
            // 
            this.numHeight.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numHeight.Location = new System.Drawing.Point(182, 136);
            this.numHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(65, 23);
            this.numHeight.TabIndex = 9;
            this.numHeight.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            // 
            // numY
            // 
            this.numY.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numY.Location = new System.Drawing.Point(54, 136);
            this.numY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(65, 23);
            this.numY.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(29, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(133, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Height:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(38, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Name: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(51, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Key:";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxName.Location = new System.Drawing.Point(85, 7);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(165, 23);
            this.textBoxName.TabIndex = 0;
            // 
            // comboKey
            // 
            this.comboKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboKey.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboKey.FormattingEnabled = true;
            this.comboKey.Location = new System.Drawing.Point(85, 66);
            this.comboKey.Name = "comboKey";
            this.comboKey.Size = new System.Drawing.Size(165, 23);
            this.comboKey.TabIndex = 5;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonRemove.Location = new System.Drawing.Point(100, 167);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(87, 27);
            this.buttonRemove.TabIndex = 11;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // modAlt
            // 
            this.modAlt.AutoSize = true;
            this.modAlt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.modAlt.Location = new System.Drawing.Point(6, 37);
            this.modAlt.Name = "modAlt";
            this.modAlt.Size = new System.Drawing.Size(41, 19);
            this.modAlt.TabIndex = 1;
            this.modAlt.Text = "Alt";
            this.modAlt.UseVisualStyleBackColor = true;
            // 
            // modCtrl
            // 
            this.modCtrl.AutoSize = true;
            this.modCtrl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.modCtrl.Location = new System.Drawing.Point(69, 37);
            this.modCtrl.Name = "modCtrl";
            this.modCtrl.Size = new System.Drawing.Size(45, 19);
            this.modCtrl.TabIndex = 2;
            this.modCtrl.Text = "Ctrl";
            this.modCtrl.UseVisualStyleBackColor = true;
            // 
            // modShift
            // 
            this.modShift.AutoSize = true;
            this.modShift.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.modShift.Location = new System.Drawing.Point(135, 37);
            this.modShift.Name = "modShift";
            this.modShift.Size = new System.Drawing.Size(50, 19);
            this.modShift.TabIndex = 3;
            this.modShift.Text = "Shift";
            this.modShift.UseVisualStyleBackColor = true;
            // 
            // modWinKey
            // 
            this.modWinKey.AutoSize = true;
            this.modWinKey.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.modWinKey.Location = new System.Drawing.Point(209, 37);
            this.modWinKey.Name = "modWinKey";
            this.modWinKey.Size = new System.Drawing.Size(75, 19);
            this.modWinKey.TabIndex = 4;
            this.modWinKey.Text = "Windows";
            this.modWinKey.UseVisualStyleBackColor = true;
            // 
            // frmOneZone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 203);
            this.Controls.Add(this.modWinKey);
            this.Controls.Add(this.modShift);
            this.Controls.Add(this.modCtrl);
            this.Controls.Add(this.modAlt);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.comboKey);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.numY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.numX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOneZone";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "One zone";
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboKey;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.CheckBox modAlt;
        private System.Windows.Forms.CheckBox modCtrl;
        private System.Windows.Forms.CheckBox modShift;
        private System.Windows.Forms.CheckBox modWinKey;
    }
}