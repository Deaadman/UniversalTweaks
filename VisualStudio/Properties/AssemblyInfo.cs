using BuildInfo = UniversalTweaks.BuildInfo;

[assembly: AssemblyTitle(BuildInfo.Name)]
[assembly: AssemblyDescription(BuildInfo.Description)]
[assembly: AssemblyCompany(BuildInfo.Company)]
[assembly: AssemblyProduct(BuildInfo.Product)]
[assembly: AssemblyCopyright(BuildInfo.Copyright)]
[assembly: AssemblyTrademark(BuildInfo.Trademark)]
[assembly: AssemblyCulture(BuildInfo.Culture)]

[assembly: AssemblyInformationalVersion(BuildInfo.Version)]
[assembly: AssemblyFileVersion(BuildInfo.Version)]

[assembly: MelonInfo(typeof(UniversalTweaks.Main), BuildInfo.GUIName, BuildInfo.Version, BuildInfo.Author, BuildInfo.DownloadLink)]
[assembly: MelonGame("Hinterland", "TheLongDark")]

[assembly: VerifyLoaderVersion(BuildInfo.MelonLoaderVersion, true)]
[assembly: MelonPriority(BuildInfo.Priority)]
[assembly: MelonIncompatibleAssemblies(BuildInfo.IncompatibleMods)]