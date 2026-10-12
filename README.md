Built in C# with Visual Studio, Requires .NET 8.0.

Uses UAssetAPI to open every .uasset and modify any Name Map with the path provided with a new path.
Newtonsoft.Json is just to remember the last used settings so if your going to re-use it for the same game, you don't have to constantly input the UE Version / Pathing.


Examples would be to rename a path of a mesh to a new location in multiple materials/textures, or cloning material instances that the mesh currently uses.
