using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using PdfSharp.Pdf.IO;

namespace DesktopManager
{
    public partial class frmMain : Form
    {
        Screen[] screens;
        Profile currentProfile;
        UserSettings currentUserSettings;
        List<ZoneTemplate> zoneTemplateList;
        string openProfileName = "";
        Rectangle lastRect;
        bool maximized = false;
        bool startInTray = false;

        public frmMain(bool tray = false)
        {
            if (tray)
            {
                startInTray = true;
            }

            InitializeComponent();

            menuStrip.Renderer = new ToolStripRender();
            this.profilePictureBox.PictureBox.MouseClick += PictureBox_MouseClick;

            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
            SystemEvents.UserPreferenceChanging += new UserPreferenceChangingEventHandler(SystemEvents_UserPreferenceChanging);

            this.notifyIcon.MouseClick += new MouseEventHandler(notifyIcon_MouseClick);

            if (!Directory.Exists(Settings.DefaultDirectory))
            {
                Directory.CreateDirectory(Settings.DefaultDirectory);
            }
            if (!Directory.Exists(Settings.DefaultDirectory + "\\Profiles"))
            {
                Directory.CreateDirectory(Settings.DefaultDirectory + "\\Profiles");
            }

            OpenUserSettings();

            screens = Screen.AllScreens;
            currentProfile = new Profile();

            if (currentUserSettings.LastOpenFile != "")
            {
                Open(currentUserSettings.LastOpenFile);
            }
            currentProfile.UpdateDisplays(screens);

            zoneTemplateList = ZoneTemplate.CreateZoneTemplates();

            RefreshProfiles();
            SetSize();

            buttonMinimize.FlatAppearance.BorderSize = 0;
            buttonMaximize.FlatAppearance.BorderSize = 0;
            buttonExit.FlatAppearance.BorderSize = 0;

            buttonMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 153, 255);
            buttonMaximize.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 153, 255);
            buttonExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 153, 255);

            this.Text = "Desktop Manager v" + Application.ProductVersion.Split('.')[0] + "." + Application.ProductVersion.Split('.')[1];
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!startInTray)
            {
                base.SetVisibleCore(value);
            }
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            SetSize();
        }

        private void SetSize()
        {
            GraphicsPath p = new GraphicsPath();
            p.AddRectangle(new Rectangle(0, 0, Width, Height));
            this.Region = new Region(p);
            buttonExit.Left = this.ClientSize.Width - buttonExit.Width;
            buttonMaximize.Left = buttonExit.Left - buttonMaximize.Width - 6;
            buttonMinimize.Left = buttonMaximize.Left - buttonMinimize.Width - 6;
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            screens = Screen.AllScreens;
            currentProfile.UpdateDisplays(screens);
            UpdateForm();
        }

        private void SystemEvents_UserPreferenceChanging(object sender, EventArgs e)
        {
            screens = Screen.AllScreens;
            currentProfile.UpdateDisplays(screens);
            UpdateForm();
        }

        private void UpdateStartUp()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    if (runWhenWindowsStartsToolStripMenuItem.Checked)
                    {
                        string str = Application.ExecutablePath.ToString();
                        str = str.Replace('/', '\\');
                        key.SetValue("DesktopManager", str + " -t");
                    }
                    else
                    {
                        key.DeleteValue("DesktopManager");
                    }
                }
            }
            catch (Exception ex)
            {
                // Do not change into a messagebox
                Debug.WriteLine("Error updating registry: " + ex.Message);
            }
        }

        private void ShowForm()
        {
            if (this.Visible == false)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
            else
            {
                this.Hide();
                SaveUserSettings();
            }
        }

        private void UpdateForm(bool highLight = false)
        {
            profilePictureBox.Image = currentProfile.ProfileImage(showScreenNamesToolStripMenuItem.Checked, showZoneNamesToolStripMenuItem.Checked, highLight);
            if (!highLight)
            {
                zoneListBox.Items.Clear();
                foreach (var it in currentProfile.Zones)
                {
                    zoneListBox.Items.Add(it.ToString());
                }
                zoneListBox.Sorted = true;
            }
        }

        private void Exit()
        {
            if (MessageBox.Show("Are you sure you want to exit? Unsaved changes will be lost.",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                currentProfile.Dispose();
                UpdateStartUp();
                SaveUserSettings();
                Application.Exit();
            }
        }

        #region form

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            UpdateForm();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to start an empty profile? Unsaved changes will be lost.",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                screens = Screen.AllScreens;
                if (currentProfile != null)
                {
                    currentProfile.Dispose();
                }
                currentProfile = new Profile();
                currentProfile.UpdateDisplays(screens);
                this.Text = "Desktop Manager v" + Application.ProductVersion.Split('.')[0] + "." + Application.ProductVersion.Split('.')[1];
                openProfileName = "";
                UpdateForm();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to open another profile? Unsaved changes will be lost.",
               "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var openDlg = new OpenFileDialog())
                {
                    openDlg.InitialDirectory = Settings.DefaultDirectory + "\\Profiles";
                    openDlg.DefaultExt = "profile";
                    openDlg.Filter = "Profile files (*.profile)|*.profile";

                    if (openDlg.ShowDialog() == DialogResult.OK)
                    {
                        if (openDlg.FileName != "")
                        {
                            Open(openDlg.FileName);
                        }
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openProfileName == "")
            {
                SaveAs();
            }
            else
            {
                SaveAs(openProfileName);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void saveKeyboardMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var saveDlg = new SaveFileDialog())
            {
                saveDlg.InitialDirectory = Settings.DefaultDirectory;
                saveDlg.DefaultExt = "pdf";
                saveDlg.Filter = "Pdf files (*.pdf)|*.pdf|Image (*.bmp)|*.bmp|Image (*.jpg)|*.jpg|Image (*.png)|*.png";
                saveDlg.CheckPathExists = true;

                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    if (saveDlg.FileName != "")
                    {
                        bool error = false;
                        try
                        {
                            string ext = saveDlg.FileName.Split('.')[1];
                            if (ext == "pdf")
                            {
                                Pdf.Create(currentProfile).Save(saveDlg.FileName);
                            }
                            else if (ext == "bmp")
                            {
                                currentProfile.ProfileImage(showScreenNamesToolStripMenuItem.Checked, showZoneNamesToolStripMenuItem.Checked).Save(saveDlg.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            }
                            else if (ext == "jpg")
                            {
                                currentProfile.ProfileImage(showScreenNamesToolStripMenuItem.Checked, showZoneNamesToolStripMenuItem.Checked).Save(saveDlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                            else if (ext == "png")
                            {
                                currentProfile.ProfileImage(showScreenNamesToolStripMenuItem.Checked, showZoneNamesToolStripMenuItem.Checked).Save(saveDlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            }
                        }
                        catch (Exception ex)
                        {
                            error = true;
                            MessageBox.Show("Could not save " + saveDlg.FileName + ". " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (!error)
                        {
                            try
                            {
                                Process.Start(saveDlg.FileName);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Could not show " + saveDlg.FileName + ". " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void changeScreensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("desk.cpl");
        }

        private void createOneZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmOneZone(currentProfile.Displays, currentProfile, this))
            {
                frm.ShowDialog();
            }
            UpdateForm();
        }

        private void createMultipleZonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmMultipleZones(currentProfile.Displays, currentProfile, zoneTemplateList))
            {
                frm.ShowDialog();
            }
            UpdateForm();
        }

        private void viewScreenNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateForm();
            SaveUserSettings();
        }

        private void viewZoneNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateForm();
            SaveUserSettings();
        }

        private void runWhenWindowsStartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStartUp();
            SaveUserSettings();
        }

        private void viewManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("www.expi.be/desktopmanager/help.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open webpage: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAbout())
            {
                frm.ShowDialog();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if (maximized)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                Zone z = new Zone("tmp", new Area(lastRect));
                z.MoveHere(this.Handle);
                maximized = false;
            }
            else
            {
                var p = this.PointToScreen(new Point(0, 0));
                lastRect = new Rectangle(p.X, p.Y, this.Width, this.Height);
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                Screen scr = Screen.FromRectangle(lastRect);
                Zone z = new Zone("tmp", new Area(scr.WorkingArea));
                z.MoveHere(this.Handle);
                maximized = true;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        private void zoneListBox_Click(object sender, EventArgs e)
        {
            if (zoneListBox.SelectedIndex != -1)
            {
                currentProfile.SetLast(zoneListBox.Items[zoneListBox.SelectedIndex].ToString());
                UpdateForm(true);
            }
            else
            {
                UpdateForm();
            }
        }

        private void zoneListBox_DoubleClick(object sender, EventArgs e)
        {
            if (zoneListBox.SelectedIndex != -1)
            {
                using (var frm = new frmOneZone(currentProfile.Displays, currentProfile, currentProfile.Zones.Count - 1, this))
                {
                    frm.ShowDialog();
                }
            }

            UpdateForm();
        }

        private void zoneListBox_Leave(object sender, EventArgs e)
        {
            UpdateForm();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmMain_Click(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            var locationClicked = new Point(
                (int)((e.X / profilePictureBox.Zoom * 100) + currentProfile.TotalArea.X),
                (int)((e.Y / profilePictureBox.Zoom * 100) + currentProfile.TotalArea.Y));
            bool containsZone = false;

            // Check if there is a zone at that location, and if so: LEFT -> edit, RIGHT -> remove
            // Reversed because last item in list lies on top
            for (int i = currentProfile.Zones.Count - 1; i >= 0; i--)
            {
                if (currentProfile.Zones[i].Area.Contains(locationClicked))
                {
                    currentProfile.SetLast(i);
                    UpdateForm(true);
                    if (e.Button == MouseButtons.Left)
                    {
                        using (var frm = new frmOneZone(currentProfile.Displays, currentProfile, currentProfile.Zones.Count - 1, this))
                        {
                            frm.ShowDialog();
                        }
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        if (MessageBox.Show("Are you sure you want to remove this zone?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            currentProfile.Zones[currentProfile.Zones.Count - 1].Unregister();
                            currentProfile.Zones.RemoveAt(currentProfile.Zones.Count - 1);
                        }
                    }
                    UpdateForm();
                    containsZone = true;
                    break;
                }
            }

            // If there is no zone, but there is a display, then give the option to add zones: LEFT -> one, RIGHT -> multiple
            if (!containsZone)
            {
                for (int i = 0; i < currentProfile.Displays.Count; i++)
                {
                    if (currentProfile.Displays[i].WorkingArea.Contains(locationClicked))
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            using (var frm = new frmOneZone(currentProfile.Displays, currentProfile, this))
                            {
                                frm.ShowDialog();
                            }
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            using (var frm = new frmMultipleZones(currentProfile.Displays, currentProfile, zoneTemplateList, i))
                            {
                                frm.ShowDialog();
                            }
                        }
                        UpdateForm();
                        break;
                    }
                }
            }
        }

        #endregion 

        #region notify

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(notifyIcon, null);
            }
        }

        private void RefreshProfiles()
        {
            var menu = new ContextMenuStrip();

            var menuItemShow = new ToolStripMenuItem("Show Desktop Manager");
            menuItemShow.Click += new EventHandler(notifyMenuItemShow_Click);
            menu.Items.Add(menuItemShow);

            var menuItemClose = new ToolStripMenuItem("Close");
            menuItemClose.Click += new EventHandler(notifyMenuItemClose_Click);
            menu.Items.Add(menuItemClose);

            var menuProfiles = new ToolStripMenuItem("Switch profile");
            menu.Items.Add(menuProfiles);

            string[] filePaths = Directory.GetFiles(Settings.DefaultDirectory + "\\Profiles");
            for (int i = 0; i < filePaths.Count(); i++)
            {
                var file = filePaths[i].Split('\\', '.');
                if (file[file.Count() - 1] == "profile")
                {
                    menuProfiles.DropDownItems.Add(file[file.Count() - 2]);
                    menuProfiles.DropDownItems[menuProfiles.DropDownItems.Count - 1].Click += new EventHandler(notifyMenuProfiles_Click);
                }
            }
            notifyIcon.ContextMenuStrip = menu;

            UpdateForm();
        }

        private void notifyMenuItemShow_Click(object sender, EventArgs e)
        {
            if (startInTray)
            {
                startInTray = false;
                SetVisibleCore(true);
                ShowForm();
            }
            ShowForm();
        }

        private void notifyMenuItemClose_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void notifyMenuProfiles_Click(object sender, EventArgs e)
        {
            var menu = (ToolStripItem)sender;
            Open(menu.Text);
        }

        #endregion

        #region io

        private void Open(string fileName)
        {
            if (!fileName.Contains("\\"))
            {
                fileName = Settings.DefaultDirectory + "\\Profiles\\" + fileName;
            }
            var file = fileName.Split('\\', '.');
            if (file[file.Count() - 1] != "profile")
            {
                fileName += ".profile";
            }
            try
            {
                if (currentProfile != null)
                {
                    currentProfile.Dispose();
                }
                using (var reader = new StreamReader(fileName))
                {
                    currentProfile = XmlProfile.Read(reader);
                    currentProfile.UpdateDisplays(screens);
                    foreach (Zone z in currentProfile.Zones)
                    {
                        z.Register(this);
                    }
                    UpdateForm();
                }
                file = fileName.Split('\\', '.');
                this.Text = "Desktop Manager v" + Application.ProductVersion.Split('.')[0] + "." + Application.ProductVersion.Split('.')[1] + " - " + file[file.Count() - 2] + ".profile";
                openProfileName = fileName;
            }
            catch
            {
                MessageBox.Show(fileName + " is not a valid profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAs()
        {
            using (var saveDlg = new SaveFileDialog())
            {
                saveDlg.InitialDirectory = Settings.DefaultDirectory + "\\Profiles";
                saveDlg.DefaultExt = "profile";
                saveDlg.Filter = "Profile files (*.profile)|*.profile";
                saveDlg.CheckPathExists = true;

                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    if (saveDlg.FileName != "")
                    {
                        SaveAs(saveDlg.FileName);
                    }
                }
            }
        }

        private void SaveAs(string fileName)
        {
            try
            {
                using (var writer = new StreamWriter(fileName))
                {
                    XmlProfile.Save(writer, currentProfile);
                }
                var file = fileName.Split('\\', '.');
                this.Text = "Desktop Manager v" + Application.ProductVersion.Split('.')[0] + "." + Application.ProductVersion.Split('.')[1] + " - " + file[file.Count() - 2] + ".profile";
                openProfileName = fileName;
                RefreshProfiles();
            }
            catch
            {
                MessageBox.Show("Could not save " + fileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenUserSettings()
        {
            if (File.Exists(Settings.DefaultDirectory + "\\settings.xml"))
            {
                try
                {
                    using (var reader = new StreamReader(Settings.DefaultDirectory + "\\settings.xml"))
                    {
                        currentUserSettings = XmlUserSettings.Read(reader);
                    }
                    showScreenNamesToolStripMenuItem.Checked = currentUserSettings.ShowScreenNames;
                    showZoneNamesToolStripMenuItem.Checked = currentUserSettings.ShowZoneNames;
                    runWhenWindowsStartsToolStripMenuItem.Checked = currentUserSettings.StartWithWindows;
                    openProfileName = currentUserSettings.LastOpenFile;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading user settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (currentUserSettings == null)
                {
                    currentUserSettings = new UserSettings();
                }
            }
            else
            {
                currentUserSettings = new UserSettings();
            }
        }        

        private void SaveUserSettings()
        {
            if (currentUserSettings == null)
            {
                currentUserSettings = new UserSettings();
            }
            currentUserSettings.ShowScreenNames = showScreenNamesToolStripMenuItem.Checked;
            currentUserSettings.ShowZoneNames = showZoneNamesToolStripMenuItem.Checked;
            currentUserSettings.StartWithWindows = runWhenWindowsStartsToolStripMenuItem.Checked;
            currentUserSettings.LastOpenFile = openProfileName;

            try
            {
                using (var writer = new StreamWriter(Settings.DefaultDirectory + "\\settings.xml"))
                {
                    XmlUserSettings.Save(writer, currentUserSettings);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}