namespace UniversalTweaks.Properties;

internal class Settings : JsonModSettings
{
    internal static Settings Instance { get; } = new();

    [Name("Disable Breath Effect")]
    [Description("When enabled, the breath effect will be disabled.")]
    public bool DisableBreathEffect = false;

    internal static void OnLoad()
    {
        Instance.AddToModSettings(BuildInfo.GUIName);
        Instance.RefreshGUI();
    }
}