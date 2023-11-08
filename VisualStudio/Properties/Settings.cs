namespace UniversalTweaks.Properties;

internal class Settings : JsonModSettings
{
    internal static Settings Instance { get; } = new();

    [Name("Disable Breath Effect")]
    [Description("When enabled, the breath effect will be disabled.")]
    public bool DisableBreathEffect = false;

    #region Experimental
    [Section("Experimental - Use At Your Own Risk")]

    [Name("First Person Handedness")]
    [Description("Select whether the player's animations are right-handed or left-handed.")]
    public FirstPersonHandedness.FirstPersonHandednessView FirstPersonHandednessView = FirstPersonHandedness.FirstPersonHandednessView.RightHanded;
    #endregion

    internal static void OnLoad()
    {
        Instance.AddToModSettings(BuildInfo.GUIName);
        Instance.RefreshGUI();
    }
}