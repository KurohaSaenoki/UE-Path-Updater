using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UAssetAPI;
using UAssetAPI.UnrealTypes;

namespace UE_Path_Updater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string UpdaterFolder = Path.Combine(Directory.GetCurrentDirectory(), "Updater");
            string SettingsFilePath = Directory.GetCurrentDirectory() + "\\Settings.json";
            JObject SettingsFile;
            string JsonBak = "";
            string JsonUEString = "";
            string JsonFindPath = "";
            bool CreateBaks;

            //Create Settings.json if doesn't exist
            if (!File.Exists(SettingsFilePath))
            {
                File.WriteAllText(SettingsFilePath, "{}");
            }

            //Set Text to {} if Settings.json is empty, otherwise just load file.
            try
            {
                SettingsFile = JObject.Parse(File.ReadAllText(SettingsFilePath));
            }
            catch
            {
                File.WriteAllText(SettingsFilePath, "{}");
                SettingsFile = JObject.Parse(File.ReadAllText(SettingsFilePath));
            }

            //AutoFill Bak
            if (SettingsFile.SelectToken("BackupFiles") != null)
            {
                JsonBak = (string)SettingsFile.SelectToken("BackupFiles");
            }
            //AutoFill UE Version
            if (SettingsFile.SelectToken("UEVersion") != null)
            {
                JsonUEString = (string)SettingsFile.SelectToken("UEVersion");
            }
            //AutoFill FindPath
            if (SettingsFile.SelectToken("FindPath") != null)
            {
                JsonFindPath = (string)SettingsFile.SelectToken("FindPath");
            }

            //Get All UAssets
            string[] AllFiles;

            if (!Directory.Exists(UpdaterFolder))
            {
                Console.WriteLine("Updater Folder does not exist, program will now create that folder.\nSince it will be empty, the program will simply close after creating the directory.");
                Console.ReadLine();

                Directory.CreateDirectory(UpdaterFolder);
                return;
            }
            else
            {
                AllFiles = Directory.GetFiles(UpdaterFolder, "*.uasset", SearchOption.AllDirectories);

                if (AllFiles.Length == 0)
                {
                    Console.WriteLine("You have no .uasset files anywhere in the Updater folder. There's nothing for the program to do.");
                    Console.ReadLine();
                    return;
                }
            }

            //Create Backups
            Console.WriteLine("Create Backups? [Y/N]");
            if (!string.IsNullOrEmpty(JsonBak))
            {
                Console.WriteLine("\tDefault Value = " + JsonBak);
            }
            string Bak = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrEmpty(Bak))
            {
                if (!string.IsNullOrEmpty(JsonBak))
                {
                    Bak = JsonBak;
                }
            }

            if (Bak == "Y" || Bak == "y")
            {
                CreateBaks = true;
            }
            else if (Bak == "N" || Bak == "n")
            {
                CreateBaks = false;
            }
            else
            {
                Bak = "Y";
                CreateBaks = true;
                Console.WriteLine("Invalid Input, will default to true.");
            }

            if ((string?)SettingsFile.SelectToken("BackupFiles") != Bak)
            {
                if (SettingsFile.ContainsKey("BackupFiles"))
                {
                    SettingsFile.Remove("BackupFiles");
                }
                SettingsFile.Add("BackupFiles", Bak);
                File.WriteAllText(SettingsFilePath, SettingsFile.ToString(Formatting.Indented));
            }

            //Get Current UE Version
            Console.WriteLine("Enter Unreal Engine Version (#_##): ");
            if (!string.IsNullOrEmpty(JsonUEString))
            {
                Console.WriteLine("\tDefault Value = " + JsonUEString);
            }

            string UEString = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrEmpty(UEString))
            {
                UEString = JsonUEString;
                if (string.IsNullOrEmpty(UEString))
                {
                    Console.WriteLine("Unknown which UE Version you're using, setting it to Automatic which may not work correctly.");
                    Console.ReadLine();
                    UEString = "4_AUTOMATIC_VERSION";
                }
            }
            
            if ((string?)SettingsFile.SelectToken("UEVersion") != UEString)
            {
                if (SettingsFile.ContainsKey("UEVersion"))
                {
                    SettingsFile.Remove("UEVersion");
                }
                SettingsFile.Add("UEVersion", UEString);
                File.WriteAllText(SettingsFilePath, SettingsFile.ToString(Formatting.Indented));
            }
            UEString = "VER_UE" + UEString;
            EngineVersion UEVersion;
            if (Enum.TryParse<EngineVersion>(UEString, out EngineVersion result))
            {
                UEVersion = result;
            }
            else
            {
                Console.WriteLine("Invalid UE Version.");
                Console.ReadLine();
                return;
            }


            //Find Path
            Console.WriteLine("Enter Path to Find:");
            if (!string.IsNullOrEmpty(JsonFindPath))
            {
                Console.WriteLine("\tDefault Value = " + JsonFindPath);
            }
            string FindPath = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrEmpty(FindPath))
            {
                FindPath = JsonFindPath;
                if (string.IsNullOrEmpty(FindPath))
                {
                    Console.WriteLine("You must put a Path to Find.");
                    Console.ReadLine();
                    return;
                }
            }
            if ((string?)SettingsFile.SelectToken("FindPath") != FindPath)
            {
                if (SettingsFile.ContainsKey("FindPath"))
                {
                    SettingsFile.Remove("FindPath");
                }
                SettingsFile.Add("FindPath", FindPath);
                File.WriteAllText(SettingsFilePath, SettingsFile.ToString(Formatting.Indented));
            }

            //Replace Path
            Console.WriteLine("Enter Path to Replace with:");
            string ReplacePath = Console.ReadLine();
            Console.WriteLine();

            string CurrentString;
            string UpdatedString;
            bool SaveFile;

            foreach (var CurrentFile in AllFiles)
            {
                Console.WriteLine();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine();

                string CurrentFileSmallPath = CurrentFile.Replace(Path.Combine(Directory.GetCurrentDirectory(), "Updater"), "");
                Console.WriteLine(CurrentFileSmallPath);
                Console.WriteLine();

                UAsset CurrentAsset = new UAsset(CurrentFile, UEVersion);
                SaveFile = false;

                for (int i = 0; i < CurrentAsset.GetNameMapIndexList().Count; i++)
                {
                    string BakUAssetFile = CurrentFile.Replace(".uasset", ".uasset.bak");

                    string UExpFile = CurrentFile.Replace(".uasset", ".uexp");
                    string BakUExpFile = UExpFile.Replace(".uexp", ".uexp.bak");

                    CurrentString = CurrentAsset.GetNameReference(i).ToString();
                    UpdatedString = CurrentString.Replace(FindPath, ReplacePath);

                    if (UpdatedString != CurrentString)
                    {
                        SaveFile = true;

                        if (CreateBaks)
                        {
                            Console.WriteLine("Creating Backups");
                            Console.WriteLine();
                            File.Copy(CurrentFile, BakUAssetFile, true);
                            File.Copy(UExpFile, BakUExpFile, true);
                        }
                        CurrentAsset.SetNameReference(i, (FString)UpdatedString);
                        Console.WriteLine("Updated NameMap Index " + i + ": " + UpdatedString);
                    }
                }

                if (SaveFile)
                {
                    Console.WriteLine();
                    Console.WriteLine("Saving Asset");
                    CurrentAsset.Write(CurrentFile);
                }
            }

            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine("UE Path Updater was created by Kuroha Saenoki");
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadLine();
        }
    }
}