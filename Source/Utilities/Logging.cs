namespace UniversalTweaks.Utilities;

public static class Logging
{
    public static void LogStarter() => Melon<Mod>.Logger.Msg($"Mod Loaded, Currently on Version v{Properties.BuildInfo.Version}");
    public static void Log(string message, params object[] parameters) => Melon<Mod>.Logger.Msg($"{message}", parameters);
    public static void LogWarning(string message, params object[] parameters) => Melon<Mod>.Logger.Warning($"{message}", parameters);
    public static void LogError(string message, params object[] parameters) => Melon<Mod>.Logger.Error($"{message}", parameters);
    public static void LogSeparator(params object[] parameters) => Melon<Mod>.Logger.Msg("==============================================================================", parameters);
    public static void LogIntraSeparator(string message, params object[] parameters) => Melon<Mod>.Logger.Msg($"=========================   {message}   =========================", parameters);
}