using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(Info.Description)]
[assembly: AssemblyDescription(Info.Description)]
[assembly: AssemblyCompany(Info.Company)]
[assembly: AssemblyProduct(Info.Name)]
[assembly: AssemblyCopyright(Info.Author)]
[assembly: AssemblyTrademark(Info.Company)]
[assembly: AssemblyVersion(Info.Version)]
[assembly: AssemblyFileVersion(Info.Version)]
[assembly: MelonInfo(typeof(neeko.Main),Info.Name, Info.Version, Info.Author,Info.DownloadLink)]

[assembly: MelonGame("VRChat")]

public static class Info
{
    public const string Name = "NeekoClient";
    public const string Description = "";
    public const string Author = "Neeko#9879";
    public const string Company = "";
    public const string Version = "0.1";
    public const string DownloadLink = "";
}