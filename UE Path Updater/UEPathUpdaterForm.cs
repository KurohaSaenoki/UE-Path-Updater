using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAssetAPI;
using UAssetAPI.ExportTypes;
using UAssetAPI.UnrealTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UE_Path_Updater
{
    public partial class UEPathUpdaterForm : Form
    {
        public static string InputFolder = "";
        public static string OutputFolder = "";
        public static string CurrentInputFolder = "";
        public static EngineVersion UEVersion = EngineVersion.UNKNOWN;
        public static string[] AllFiles = [];
        public static List<string> FilesToDelete = new List<string>();
        public static string GameFolder = "";
        public static int GameFolderSize = 0;
        public static string EnteredString = "";
        public static Color[] Colors = [SystemColors.Control, SystemColors.ControlText];
        public static int DefaultFindWidth = 0;
        public UEPathUpdaterForm()
        {
            InitializeComponent();
        }
        private void UEPathUpdaterForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            DefaultFindWidth = FindTextBox.Width;
        }
        private void UEPathUpdaterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
        public void LoadSettings()
        {
            if (Properties.Settings.Default.InputPath != "")
            {
                InputFolder = Properties.Settings.Default.InputPath;
            }
            if (Properties.Settings.Default.OutputPath != "")
            {
                OutputFolder = Properties.Settings.Default.OutputPath;
            }
            if (!string.IsNullOrEmpty(InputFolder) && !string.IsNullOrEmpty(OutputFolder) && InputFolder != OutputFolder)
            {
                Output("Input Folder Path: " + InputFolder);
                Output("Output Folder Path: " + OutputFolder);
                UpdateCurrentInputFolder(InputFolder);
                CheckInputOutputFolders(true);
            }

            AutomateFilePathBtn.Checked = Properties.Settings.Default.AutoFilePaths;

            if (Properties.Settings.Default.GameFolder != "")
            {
                GameTextBox.Text = Properties.Settings.Default.GameFolder;
                Output("Game Folder: " + GameTextBox.Text);
            }

            if (Properties.Settings.Default.UEString != "")
            {
                UEVersionComboBox.Text = Properties.Settings.Default.UEString;
            }
            else
            {
                UEVersionComboBox.Text = "4.0";
            }

            if (Properties.Settings.Default.FindPath != "")
            {
                FindTextBox.Text = Properties.Settings.Default.FindPath;
                Output("Find Path String: " + FindTextBox.Text);
            }
            if (Properties.Settings.Default.ReplacePath != "")
            {
                ReplaceTextBox.Text = Properties.Settings.Default.ReplacePath;
                Output("Replace Path String: " + ReplaceTextBox.Text);
            }

            DarkModeCheckBox.Checked = Properties.Settings.Default.DarkMode;
        }
        public void SaveSettings()
        {
            Properties.Settings.Default.InputPath = InputFolder;
            Properties.Settings.Default.OutputPath = OutputFolder;
            Properties.Settings.Default.AutoFilePaths = AutomateFilePathBtn.Checked;
            Properties.Settings.Default.GameFolder = GameTextBox.Text;
            Properties.Settings.Default.UEString = UEVersionComboBox.Text;
            Properties.Settings.Default.FindPath = FindTextBox.Text;
            Properties.Settings.Default.ReplacePath = ReplaceTextBox.Text;
            Properties.Settings.Default.DarkMode = DarkModeCheckBox.Checked;
            Properties.Settings.Default.Save();
        }
        private void UEVersionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Output("Unreal Engine: " + UEVersionComboBox.Text);
            UpdateCurrentInputFolder(InputFolder);
        }
        private void AutomateFilePathBtn_CheckStateChanged(object sender, EventArgs e)
        {
            if (AutomateFilePathBtn.Checked)
            {
                Output("Automate File Paths: Enabled");
                GameTextBox.Enabled = true;
            }
            else
            {
                Output("Automate File Paths: Disabled");
                GameTextBox.Enabled = false;
            }
            UpdateCurrentInputFolder(InputFolder);
        }
        private void GameTextBox_Enter(object sender, EventArgs e)
        {
            EnteredString = GameTextBox.Text;
        }
        private void GameTextBox_Leave(object sender, EventArgs e)
        {
            if (EnteredString != GameTextBox.Text)
            {
                Output("Game Folder: " + GameTextBox.Text);
                UpdateCurrentInputFolder(InputFolder);
            }
        }
        private void FindTextBox_Enter(object sender, EventArgs e)
        {
            EnteredString = FindTextBox.Text;
        }
        private void FindTextBox_Leave(object sender, EventArgs e)
        {
            if (EnteredString != FindTextBox.Text)
            {
                Output("Find Path String: " + FindTextBox.Text);
            }
        }
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            SetUpdateBtn();
        }
        private void FindTextBox_EnabledChanged(object sender, EventArgs e)
        {
            SetUpdateBtn();
        }
        private void SetUpdateBtn()
        {
            if (FindTextBox.Text != "" && FindTextBox.Enabled)
            {
                UpdateBtn.Enabled = true;
            }
            else
            {
                UpdateBtn.Enabled = false;
            }
        }
        private void ReplaceTextBox_Enter(object sender, EventArgs e)
        {
            EnteredString = ReplaceTextBox.Text;
        }
        private void ReplaceTextBox_Leave(object sender, EventArgs e)
        {
            if (EnteredString != ReplaceTextBox.Text)
            {
                Output("Replace Path String: " + ReplaceTextBox.Text);
            }
        }
        private void SetInputBtn_Click(object sender, EventArgs e)
        {
            InputFolder = SetFolderLocation(InputFolder, "Set Folder of Assets to Open");
            UpdateCurrentInputFolder("");
            ReloadInputBtn.Enabled = false;

            if (string.IsNullOrEmpty(InputFolder))
            {
                Output("Input Folder Path is an Unacceptable Path as it's null");
                InputFolder = "";
            }
            else if (InputFolder == OutputFolder)
            {
                Output("Input Folder Path is an Unacceptable Path as it's the same as the Output Directory");
                InputFolder = "";
                CheckInputOutputFolders(false);
            }
            else
            {
                Output("Input Folder Path: " + InputFolder);
                if (OutputFolder != "")
                {
                    UpdateCurrentInputFolder(InputFolder);
                    CheckInputOutputFolders(true);
                }
                else
                {
                    UpdateCurrentInputFolder("");
                    CheckInputOutputFolders(false);
                }
            }
        }
        private void OutputBtn_Click(object sender, EventArgs e)
        {
            OutputFolder = SetFolderLocation(OutputFolder, "Set Where to Save Assets");
            if (string.IsNullOrEmpty(OutputFolder))
            {
                Output("Output Folder Path is an Unacceptable Path as it's null");
                OutputFolder = "";
                CheckInputOutputFolders(false);
            }
            else if (OutputFolder == InputFolder)
            {
                Output("Output Folder Path is an Unacceptable Path as it's the same as the Input Directory");
                OutputFolder = "";
                CheckInputOutputFolders(false);
            }
            else
            {
                Output("Output Folder Path: " + OutputFolder);
                if (InputFolder != "")
                {
                    UpdateCurrentInputFolder(InputFolder);
                    CheckInputOutputFolders(true);
                }
                else
                {
                    UpdateCurrentInputFolder("");
                    CheckInputOutputFolders(false);
                }
            }
        }
        private void ReloadInputBtn_Click(object sender, EventArgs e)
        {
            if (InputFolder != OutputFolder && InputFolder != null)
            {
                UpdateCurrentInputFolder(InputFolder);
                CheckInputOutputFolders(true);
            }
        }
        private void CheckInputOutputFolders(bool IsValid)
        {
            if (IsValid)
            {
                Output("Both Input and Output Folders are Unique");
                AllFiles = Directory.EnumerateFiles(CurrentInputFolder, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".uasset") || s.EndsWith(".umap")).ToArray();
                AllAssetCountLabel.Text = "Asset Count: " + AllFiles.Length;
                ReloadInputBtn.Enabled = true;
            }
            else
            {
                AllFiles = [];
                AllAssetCountLabel.Text = "Asset Count: 0";
            }
            if (AllFiles.Length == 0)
            {
                AutoDetectUEBtn.Enabled = false;
                Output("Input Folder has no Assets in it...");
                IsValid = false;
            }
            else
            {
                if (IsValid)
                {
                    AutoDetectUEBtn.Enabled = true;
                    ReloadInputBtn.Enabled = true;
                }
            }
            FindTextBox.Enabled = IsValid;
            ReplaceTextBox.Enabled = IsValid;
        }
        private void UpdateCurrentInputFolder(string NewFolder)
        {
            CurrentInputFolder = NewFolder;
            try
            {
                AllFiles = Directory.EnumerateFiles(CurrentInputFolder, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".uasset") || s.EndsWith(".umap")).ToArray();
            }
            catch
            {
                AllFiles = [];
            }

            if (AllFiles.Length > 0)
            {
                AutoDetectUEBtn.Enabled = true;
            }
            else
            {
                AutoDetectUEBtn.Enabled = false;
            }

            AllAssetCountLabel.Text = "Asset Count: " + AllFiles.Length;
        }
        public static string SetFolderLocation(string DefaultInput, string Description)
        {
            using (var FolderBrowser = new FolderBrowserDialog())
            {
                FolderBrowser.Description = Description;
                FolderBrowser.UseDescriptionForTitle = true;
                if (DefaultInput == "")
                {
                    FolderBrowser.SelectedPath = Path.Combine(Directory.GetCurrentDirectory());
                }
                else
                {
                    FolderBrowser.SelectedPath = DefaultInput;
                }
                DialogResult result = FolderBrowser.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(FolderBrowser.SelectedPath))
                {
                    return FolderBrowser.SelectedPath;
                }
                else
                {
                    return "";
                }
            }
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            OutputTextBox.Text = "";
        }
        private async void UpdateBtn_Click(object sender, EventArgs e)
        {
            //Delete Output Folder on First UpdateBtn use
            if (CurrentInputFolder == InputFolder)
            {
                if (Directory.Exists(OutputFolder))
                {
                    foreach (string file in Directory.GetFiles(OutputFolder))
                    {
                        File.Delete(file);
                    }
                    foreach (string dir in Directory.GetDirectories(OutputFolder))
                    {
                        Directory.Delete(dir, true);
                    }
                }
                else
                {
                    Directory.CreateDirectory(OutputFolder);
                }
            }

            if (UEVersionComboBox.Text == "4 (Oldest)")
            {
                UEVersion = EngineVersion.VER_UE4_OLDEST_LOADABLE_PACKAGE;
            }
            else if (UEVersionComboBox.Text == "5.0 (Early Access)")
            {
                UEVersion = EngineVersion.VER_UE5_0EA;
            }
            else
            {
                string UEVersionText = "VER_UE" + UEVersionComboBox.Text.Replace(".", "_");
                if (Enum.TryParse<EngineVersion>(UEVersionText, out EngineVersion result))
                {
                    UEVersion = result;
                }
                else
                {
                    Output("Invalid UE Version?");
                    return;
                }
            }

            UpdateBtn.Enabled = false;
            if (AllFiles.Length == 0)
            {
                return;
            }
            ProgressBar.Value = 0;
            ProgressBar.Maximum = AllFiles.Length;
            ProgressBar.Visible = true;
            ProgressLabel.Visible = true;

            var progress = new Progress<int>(reportedValue =>
            {
                //Needs to be Set to Maximum before updating the value accurately, for some reason this makes the animation accurate.
                ProgressBar.Value = ProgressBar.Maximum;
                ProgressBar.Value = reportedValue;
                ProgressLabel.Text = ($"{ProgressBar.Value}/{AllFiles.Length}");
            });

            await Task.Run(() => ProcessFilesData(progress));

            DeleteUnnecessaryAssets();
            UpdateBtn.Enabled = true;

            //Set CurrentInputFolder to Output Folder so if modifying again, will update the ones already in the Output Folder.
            if (Directory.EnumerateFileSystemEntries(OutputFolder).Any())
            {
                UpdateCurrentInputFolder(OutputFolder);
            }
            ProgressBar.Visible = false;
            ProgressLabel.Visible = false;
        }
        private void ProcessFilesData(IProgress<int> progress)
        {
            Output("");
            Output("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", 1);

            if (AutomateFilePathBtn.Checked)
            {
                if (GameTextBox.Text == "")
                {
                    AutomateFilePathBtn.Checked = false;
                    Output("Game TextBox is Empty, Disabling Automatic File Pathing");
                }
                else
                {
                    //Set Game Folder and its Size
                    GameFolderSize = GameTextBox.Text.Length;
                    GameFolder = "/" + GameTextBox.Text + "/Content/";
                }
            }

            for (int i = 0; i < AllFiles.Length; i++)
            {

                // --- Perform your file logic here (e.g., parsing, uploading, copying) ---
                ModifyAssets(AllFiles[i]);

                // Report the current item index back to the UI thread (1-based index)
                progress?.Report(i + 1);
            }
        }
        private void ModifyAssets(string CurrentFile)
        {
            string CurrentString;
            string UpdatedString;

            if (File.Exists(CurrentFile))
            {
                bool ModifyFilePath = false;
                string NewFileName = "";
                string NewFilePath = "";
                string CurrentFileExportName = "";
                string AnotherNameMapWithExportName = "";
                string CurrentExtension = Path.GetExtension(CurrentFile);

                Output($"Loading Asset: {Path.GetFileNameWithoutExtension(CurrentFile)}", 1);

                UAsset CurrentAsset;
                try
                {
                    CurrentAsset = new UAsset(CurrentFile, UEVersion);
                }
                catch
                {
                    Output("Failed to Load Asset... Ensure the Unreal Engine Version is correct.");
                    return;
                }

                if (!CurrentAsset.VerifyBinaryEquality())
                {
                    Output("Invalid Binary Equality... Ensure the Unreal Engine Version is correct.");
                    return;
                }

                if (CurrentAsset != null)
                {
                    if (AutomateFilePathBtn.Checked)
                    {
                        try
                        {
                            //Get Filename of Asset
                            for (int i = 0; i < CurrentAsset.Exports.Count; i++)
                            {
                                if (CurrentAsset.Exports[i].OuterIndex.ToString() == "0" && (!CurrentAsset.Exports[i].ObjectName.ToString().StartsWith("Default__")))
                                {
                                    if (CurrentAsset.Exports[i].ObjectName.ToString().EndsWith("_C"))
                                    {
                                        CurrentFileExportName = CurrentAsset.Exports[i].ObjectName.ToString()[..^2];
                                    }
                                    else
                                    {
                                        CurrentFileExportName = CurrentAsset.Exports[i].ObjectName.ToString();
                                    }
                                    break;
                                }
                            }
                        }
                        catch
                        {
                            Output("Failed to Look Through Exports... Ensure the Unreal Engine Version is correct.");
                            return;
                        }
                        try
                        {
                            //Check for if linked to another Asset that uses the same name...
                            foreach (var import in CurrentAsset.Imports)
                            {
                                try
                                {
                                    if (import?.ClassName?.Value != null && import?.ObjectName?.Value != null && CurrentFileExportName != null)
                                    {
                                        string className = import.ClassName.Value.ToString();
                                        string objectName = import.ObjectName.Value.ToString();

                                        if (className == "Package" && objectName.StartsWith("/Game/") && objectName.EndsWith(CurrentFileExportName))
                                        {
                                            AnotherNameMapWithExportName = objectName;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Output("Failed to Look Through Imports... Ensure the Unreal Engine Version is correct.");
                                        return;
                                    }
                                }
                                catch
                                {
                                    Output("Failed to Look Through Imports... Ensure the Unreal Engine Version is correct.");
                                    return;
                                }
                            }
                        }
                        catch
                        {
                            Output("Failed to Look Through Imports... Ensure the Unreal Engine Version is correct.");
                            return;
                        }
                    }

                    try
                    {
                        //Update Name Map Entries
                        for (int i = 0; i < CurrentAsset.GetNameMapIndexList().Count; i++)
                        {
                            CurrentString = CurrentAsset.GetNameReference(i).ToString();
                            UpdatedString = CurrentString.Replace(FindTextBox.Text, ReplaceTextBox.Text);
                            if (UpdatedString != CurrentString)
                            {
                                CurrentAsset.SetNameReference(i, (FString)UpdatedString);
                                Output($"Updated NameMap Index {i}: {UpdatedString}");
                            }
                            if (AutomateFilePathBtn.Checked)
                            {
                                //Update File Path Based on Name Map Entry
                                string NameMapFile = Path.GetFileNameWithoutExtension(CurrentString);
                                if (CurrentFileExportName != "" && NameMapFile.EndsWith(CurrentFileExportName) && CurrentString.StartsWith("/Game/") && CurrentString != AnotherNameMapWithExportName)
                                {
                                    NewFileName = Path.GetFileNameWithoutExtension(UpdatedString);
                                    NewFilePath = Path.GetDirectoryName(GameFolder + UpdatedString.Substring(6)) ?? "";
                                    NewFilePath = NewFilePath.Replace('\\', '/');
                                    if (!NewFilePath.EndsWith("/"))
                                    {
                                        NewFilePath += "/";
                                    }
                                    if (NewFilePath.StartsWith("//"))
                                    {
                                        NewFilePath = NewFilePath.Substring(1);
                                    }
                                    NewFilePath = NewFilePath + NewFileName;
                                    ModifyFilePath = true;
                                }
                            }
                        }
                    }
                    catch
                    {
                        Output("Failed to Look Through Name Maps... Ensure the Unreal Engine Version is correct.");
                        return;
                    }
                    try
                    {
                        //Update Folder Name if it's not empty, not every game needs it
                        if (CurrentAsset.FolderName.ToString() != "None")
                        {
                            if (ModifyFilePath)
                            {
                                CurrentAsset.FolderName = (FString)("/Game/" + NewFilePath.Substring(10 + GameFolderSize));
                            }
                            else
                            {
                                CurrentString = CurrentAsset.FolderName.ToString();
                                UpdatedString = CurrentString.Replace(FindTextBox.Text, ReplaceTextBox.Text);

                                if (UpdatedString != CurrentString)
                                {
                                    Output($"New Folder Name: {UpdatedString}", 1);
                                    CurrentAsset.FolderName = (FString)UpdatedString;
                                }
                            }
                        }
                    }
                    catch
                    {
                        Output("Failed to Find Folder Name... Ensure the Unreal Engine Version is correct.");
                        return;
                    }
                    try
                    {
                        //Save Asset
                        string NewFile = "";
                        string NewPath = "";
                        string ubulkPath = CurrentFile.Replace(CurrentExtension, ".ubulk");
                        if (ModifyFilePath)
                        {
                            NewFile = NewFilePath.Replace('/', Path.DirectorySeparatorChar);
                            NewFile = OutputFolder + NewFile + CurrentExtension;
                            NewPath = Path.GetDirectoryName(NewFile) ?? "";

                            if (CurrentFile.StartsWith(OutputFolder) && NewFile != CurrentFile)
                            {
                                FilesToDelete.Add(CurrentFile);
                                FilesToDelete.Add(CurrentFile.Replace(CurrentExtension, ".uexp"));
                                if (File.Exists(ubulkPath))
                                {
                                    FilesToDelete.Add(ubulkPath);
                                }
                            }
                            if (File.Exists(ubulkPath))
                            {
                                if (!Path.Exists(NewPath))
                                {
                                    Directory.CreateDirectory(NewPath);
                                }

                                if (ubulkPath != NewFile.Replace(CurrentExtension, ".ubulk"))
                                {
                                    File.Copy(ubulkPath, NewFile.Replace(CurrentExtension, ".ubulk"), true);
                                }
                            }
                        }
                        else
                        {
                            NewFile = CurrentFile.Replace(InputFolder, OutputFolder);
                            NewPath = Path.GetDirectoryName(NewFile) ?? "";
                        }

                        Output("");
                        Output($"Saving Asset {Path.GetFileNameWithoutExtension(NewFile)}", 1);
                        Output("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", 1);

                        if (!string.IsNullOrEmpty(NewPath))
                        {
                            Directory.CreateDirectory(NewPath);
                            CurrentAsset.Write(NewFile);
                        }
                    }
                    catch
                    {
                        Output("Failed to Save Asset... Ensure the Unreal Engine Version is correct.");
                        return;
                    }
                }
            }
            else
            {
                Output("Somehow File Doesn't Exist: " + CurrentFile);
            }
        }
        private void DeleteUnnecessaryAssets()
        {
            foreach (var CurrentFile in FilesToDelete)
            {
                if (CurrentFile.StartsWith(OutputFolder) && File.Exists(CurrentFile))
                {
                    File.Delete(CurrentFile);
                }
            }
            DeleteEmptyFolders(OutputFolder);
            FilesToDelete.Clear();
        }
        private void Output(string Str, int LineBreakCount = 0)
        {
            // Check if we need to marshal the call to the UI thread
            if (OutputTextBox.InvokeRequired)
            {
                OutputTextBox.Invoke(new Action(() => Output(Str, LineBreakCount)));
                return;
            }

            OutputTextBox.AppendText(Str + Environment.NewLine);

            for (int i = 0; i < LineBreakCount; i++)
            {
                OutputTextBox.AppendText(Environment.NewLine);
            }
        }
        private static void DeleteEmptyFolders(string startLocation)
        {
            foreach (var directory in Directory.GetDirectories(startLocation))
            {
                DeleteEmptyFolders(directory);
                if (Directory.GetFileSystemEntries(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }
        private void AutoDetectUEBtn_Click(object sender, EventArgs e)
        {
            string LikelyUEVer = "";

            if (AllFiles.Length > 0)
            {
                UAsset CurrentAsset;
                for (int i = 0; i < UEVersionComboBox.Items.Count; i++)
                {
                    string CurrentItem = UEVersionComboBox.Items[i]?.ToString() ?? "";

                    if (CurrentItem == "4 (Oldest)")
                    {
                        UEVersion = EngineVersion.VER_UE4_OLDEST_LOADABLE_PACKAGE;
                    }
                    else if (CurrentItem == "5.0 (Early Access)")
                    {
                        UEVersion = EngineVersion.VER_UE5_0EA;
                    }
                    else
                    {
                        string UEVersionText = "VER_UE" + CurrentItem.Replace(".", "_");
                        if (Enum.TryParse<EngineVersion>(UEVersionText, out EngineVersion result))
                        {
                            UEVersion = result;
                        }
                        else
                        {
                            Output("Invalid UE Version?");
                            return;
                        }
                    }

                    try
                    {
                        CurrentAsset = new UAsset(AllFiles[0], UEVersion);
                        if (CurrentAsset.VerifyBinaryEquality())
                        {

                            if (CurrentItem.StartsWith("4"))
                            {
                                if (CurrentAsset.ObjectVersion.ToString() != "UNKNOWN")
                                {
                                    Output("Possible UE4 Version: " + CurrentItem);
                                    LikelyUEVer = CurrentItem;
                                }
                            }
                            else
                            {
                                if (CurrentAsset.ObjectVersionUE5.ToString() != "UNKNOWN")
                                {
                                    Output("Possible UE5 Version: " + CurrentItem);
                                    LikelyUEVer = CurrentItem;
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                UEVersionComboBox.Text = LikelyUEVer;
                Output("Auto-Detection has updated your Unreal Engine version based on the first asset found and picked the most up-to-date Engine that is validated correctly. This has a high chance of not being the exact Engine Version, but may still work.");
            }
        }
        private void SetDarkColors(bool IsDark)
        {
            int Result = IsDark ? 1 : 0;
            int OppResult = !IsDark ? 1 : 0;

            BackColor = Colors[Result];
            ForeColor = Colors[OppResult];
            toolStrip1.BackColor = Colors[Result];
            UpdateBtn.BackColor = Colors[0];
            UpdateBtn.ForeColor = Colors[1];
            ClearBtn.BackColor = Colors[0];
            ClearBtn.ForeColor = Colors[1];
        }
        private void DarkModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetDarkColors(DarkModeCheckBox.Checked);
        }
        private void UEPathUpdaterForm_Resize(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                FindTextBox.Width = ((ActiveForm.Size.Width - ActiveForm.MinimumSize.Width) / 2) + DefaultFindWidth;
                ReplaceTextBox.Size = FindTextBox.Size;
                ReplaceTextBox.Location = new Point(FindTextBox.Location.X + FindTextBox.Size.Width + 43, ReplaceTextBox.Location.Y);
                ReplaceLabel.Location = new Point(ReplaceTextBox.Location.X, ReplaceLabel.Location.Y);
            }
        }
    }
}