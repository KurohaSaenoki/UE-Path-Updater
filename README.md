# UE-Path-Updater

Built in C# with Visual Studio, Requires [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

Uses [UAssetAPI](https://github.com/atenfyr/UAssetAPI) to open every .uasset and modify any Name Map with the path provided with a new path.
[Newtonsoft.Json](https://www.nuget.org/packages/newtonsoft.json/) is just to remember the last used settings so if your going to re-use it for the same game, you don't have to constantly input the UE Version / Pathing.

## USAGE

- Place any Unreal Engine Assets you want to modify inside of the "Updater" folder
- Open the UE Path Updater.exe
- Follow the CMD Prompts to create a Settings.json that'll remember if you want Backups / UE Version / Path to Find
- Set the Path to replace With
- All modified assets and paths will be shown in the CMD
- Insert the modified assets back into a game using [UnrealPak (UE4)](https://unrealpak.com/) or [Retoc (UE5)](https://github.com/trumank/retoc)
