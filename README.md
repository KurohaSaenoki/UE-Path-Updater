# UE-Path-Updater

Built in C# with Visual Studio 2026, Requires [.NET 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0).

Uses [UAssetAPI](https://github.com/atenfyr/UAssetAPI) to open every .uasset and modify any Name Map with the path provided with a new path.
[Newtonsoft.Json](https://www.nuget.org/packages/newtonsoft.json/) is just to remember the last used settings so if your going to re-use it for the same game, you don't have to constantly input the UE Version / Pathing.

## USAGE

- Open the UE Path Updater.exe
- On the Top Left, Set Input Folder and Set Output Folder
- On the Top Right, Ensure your Unreal Engine version is correct
  - Optionally, you can enable "Automate File Paths" to set all the assets in a proper folder to quickly have the assets ready for packaging.
  - If "Automate File Paths" is enabled, the {Game} textbox will be enabled. This textbox should be your game project folder
- Set a "Find" Path
- Set a "Replace" Path
- Click Update Assets to modify every asset in the Input Folder, and saves them in the Output Folder
- Insert the modified assets back into a game using [UnrealPak (UE4)](https://unrealpak.com/) or [Retoc (UE5)](https://github.com/trumank/retoc)
