namespace DesktopManager
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.profilePictureBox = new RichPictureBox.RichPictureBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.zoneListBox = new System.Windows.Forms.ListBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveKeyboardMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeScreensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createOneZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createMultipleZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showScreenNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showZoneNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runWhenWindowsStartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonMaximize = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.toolTipPictureBox = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // profilePictureBox
            // 
            this.profilePictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.profilePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilePictureBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.profilePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("profilePictureBox.Image")));
            this.profilePictureBox.Location = new System.Drawing.Point(0, 0);
            this.profilePictureBox.MaxZoom = 100D;
            this.profilePictureBox.MinZoom = 10D;
            this.profilePictureBox.Name = "profilePictureBox";
            this.profilePictureBox.ShowToolTip = false;
            this.profilePictureBox.Size = new System.Drawing.Size(600, 525);
            this.profilePictureBox.StepZoom = 10D;
            this.profilePictureBox.TabIndex = 3;
            this.profilePictureBox.Zoom = 30D;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Desktop Manager";
            this.notifyIcon.Visible = true;
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinimize.Location = new System.Drawing.Point(296, 0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(23, 23);
            this.buttonMinimize.TabIndex = 21;
            this.buttonMinimize.Text = "-";
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(354, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(23, 23);
            this.buttonExit.TabIndex = 22;
            this.buttonExit.Text = "X";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // zoneListBox
            // 
            this.zoneListBox.BackColor = System.Drawing.SystemColors.Control;
            this.zoneListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zoneListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoneListBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoneListBox.FormattingEnabled = true;
            this.zoneListBox.HorizontalScrollbar = true;
            this.zoneListBox.ItemHeight = 15;
            this.zoneListBox.Location = new System.Drawing.Point(0, 0);
            this.zoneListBox.Name = "zoneListBox";
            this.zoneListBox.Size = new System.Drawing.Size(180, 525);
            this.zoneListBox.TabIndex = 24;
            this.zoneListBox.Click += new System.EventHandler(this.zoneListBox_Click);
            this.zoneListBox.DoubleClick += new System.EventHandler(this.zoneListBox_DoubleClick);
            this.zoneListBox.Leave += new System.EventHandler(this.zoneListBox_Leave);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 25;
            this.menuStrip.Text = "menuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveKeyboardMapToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // saveKeyboardMapToolStripMenuItem
            // 
            this.saveKeyboardMapToolStripMenuItem.Name = "saveKeyboardMapToolStripMenuItem";
            this.saveKeyboardMapToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveKeyboardMapToolStripMenuItem.Text = "Save keyboard map";
            this.saveKeyboardMapToolStripMenuItem.Click += new System.EventHandler(this.saveKeyboardMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeScreensToolStripMenuItem,
            this.createOneZoneToolStripMenuItem,
            this.createMultipleZonesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // changeScreensToolStripMenuItem
            // 
            this.changeScreensToolStripMenuItem.Name = "changeScreensToolStripMenuItem";
            this.changeScreensToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.changeScreensToolStripMenuItem.Text = "Change screens";
            this.changeScreensToolStripMenuItem.Click += new System.EventHandler(this.changeScreensToolStripMenuItem_Click);
            // 
            // createOneZoneToolStripMenuItem
            // 
            this.createOneZoneToolStripMenuItem.Name = "createOneZoneToolStripMenuItem";
            this.createOneZoneToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.createOneZoneToolStripMenuItem.Text = "Create one zone";
            this.createOneZoneToolStripMenuItem.Click += new System.EventHandler(this.createOneZoneToolStripMenuItem_Click);
            // 
            // createMultipleZonesToolStripMenuItem
            // 
            this.createMultipleZonesToolStripMenuItem.Name = "createMultipleZonesToolStripMenuItem";
            this.createMultipleZonesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.createMultipleZonesToolStripMenuItem.Text = "Create multiple zones";
            this.createMultipleZonesToolStripMenuItem.Click += new System.EventHandler(this.createMultipleZonesToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showScreenNamesToolStripMenuItem,
            this.showZoneNamesToolStripMenuItem,
            this.runWhenWindowsStartsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // showScreenNamesToolStripMenuItem
            // 
            this.showScreenNamesToolStripMenuItem.Checked = true;
            this.showScreenNamesToolStripMenuItem.CheckOnClick = true;
            this.showScreenNamesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showScreenNamesToolStripMenuItem.Name = "showScreenNamesToolStripMenuItem";
            this.showScreenNamesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.showScreenNamesToolStripMenuItem.Text = "Show screen names";
            this.showScreenNamesToolStripMenuItem.Click += new System.EventHandler(this.viewScreenNamesToolStripMenuItem_Click);
            // 
            // showZoneNamesToolStripMenuItem
            // 
            this.showZoneNamesToolStripMenuItem.Checked = true;
            this.showZoneNamesToolStripMenuItem.CheckOnClick = true;
            this.showZoneNamesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showZoneNamesToolStripMenuItem.Name = "showZoneNamesToolStripMenuItem";
            this.showZoneNamesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.showZoneNamesToolStripMenuItem.Text = "Show zone names";
            this.showZoneNamesToolStripMenuItem.Click += new System.EventHandler(this.viewZoneNamesToolStripMenuItem_Click);
            // 
            // runWhenWindowsStartsToolStripMenuItem
            // 
            this.runWhenWindowsStartsToolStripMenuItem.Checked = true;
            this.runWhenWindowsStartsToolStripMenuItem.CheckOnClick = true;
            this.runWhenWindowsStartsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runWhenWindowsStartsToolStripMenuItem.Name = "runWhenWindowsStartsToolStripMenuItem";
            this.runWhenWindowsStartsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.runWhenWindowsStartsToolStripMenuItem.Text = "Run when Windows starts";
            this.runWhenWindowsStartsToolStripMenuItem.Click += new System.EventHandler(this.runWhenWindowsStartsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpOnlineToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHelpOnlineToolStripMenuItem
            // 
            this.viewHelpOnlineToolStripMenuItem.Name = "viewHelpOnlineToolStripMenuItem";
            this.viewHelpOnlineToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.viewHelpOnlineToolStripMenuItem.Text = "View help online";
            this.viewHelpOnlineToolStripMenuItem.Click += new System.EventHandler(this.viewManualToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // buttonMaximize
            // 
            this.buttonMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaximize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMaximize.Location = new System.Drawing.Point(325, 0);
            this.buttonMaximize.Name = "buttonMaximize";
            this.buttonMaximize.Size = new System.Drawing.Size(23, 23);
            this.buttonMaximize.TabIndex = 26;
            this.buttonMaximize.Text = "+";
            this.buttonMaximize.UseVisualStyleBackColor = true;
            this.buttonMaximize.Click += new System.EventHandler(this.buttonMaximize_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.Controls.Add(this.profilePictureBox);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.Controls.Add(this.zoneListBox);
            this.splitContainer.Panel2MinSize = 100;
            this.splitContainer.Size = new System.Drawing.Size(784, 525);
            this.splitContainer.SplitterDistance = 600;
            this.splitContainer.TabIndex = 27;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 549);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.buttonMaximize);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonMinimize);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desktop Manager";
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.Click += new System.EventHandler(this.frmMain_Click);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichPictureBox.RichPictureBox profilePictureBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ListBox zoneListBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button buttonMaximize;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveKeyboardMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeScreensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createOneZoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createMultipleZonesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showScreenNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showZoneNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runWhenWindowsStartsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolTip toolTipPictureBox;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpOnlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}