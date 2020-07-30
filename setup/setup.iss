; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{A9BAE31C-01FA-409F-9E2B-177E8DCC333D}
AppName=Desktop Manager
AppVersion=1.0
;AppVerName=Desktop Manager 1.0
DefaultDirName={pf}\Desktop Manager
DefaultGroupName=Desktop Manager
AllowNoIcons=yes
OutputBaseFilename=Desktop Manager Setup
Compression=lzma
SolidCompression=yes
OutputDir="D:\Documenten\Development\DesktopManager\setup"

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "D:\Documenten\Development\DesktopManager\src\bin\Release\Desktop Manager.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Documenten\Development\DesktopManager\src\bin\Release\PdfSharp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Documenten\Development\DesktopManager\src\bin\Release\RichPictureBox.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\Desktop Manager"; Filename: "{app}\Desktop Manager.exe"
Name: "{group}\{cm:UninstallProgram,Desktop Manager}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\Desktop Manager"; Filename: "{app}\Desktop Manager.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\Desktop Manager"; Filename: "{app}\Desktop Manager.exe"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\Desktop Manager.exe"; Description: "{cm:LaunchProgram,Desktop Manager}"; Flags: nowait postinstall skipifsilent

