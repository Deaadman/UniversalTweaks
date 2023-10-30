namespace UniversalTweaks.Utilities;

public class Logging
{
    public static void LogStarter() => Melon<MelonModImplementation>.Logger.Msg($"Mod Loaded, Currently on Version v{Properties.BuildInfo.Version}");
    public static void Log(string message, params object[] parameters) => Melon<MelonModImplementation>.Logger.Msg($"{message}", parameters);
    public static void LogWarning(string message, params object[] parameters) => Melon<MelonModImplementation>.Logger.Warning($"{message}", parameters);
    public static void LogError(string message, params object[] parameters) => Melon<MelonModImplementation>.Logger.Error($"{message}", parameters);
    public static void LogSeperator(params object[] parameters) => Melon<MelonModImplementation>.Logger.Msg("==============================================================================", parameters);
    public static void LogIntraSeparator(string message, params object[] parameters) => Melon<MelonModImplementation>.Logger.Msg($"=========================   {message}   =========================", parameters);
}