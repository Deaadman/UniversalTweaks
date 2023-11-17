namespace UniversalTweaks.Properties;

internal class Settings : JsonModSettings
{
    internal static Settings Instance { get; } = new();

    #region General Tweaks
    [Section("General Tweaks")]

    [Name("Revolver Handling")]
    [Description("Enhances revolver usability by allowing movement while aiming.")]
    public bool EnableRevolverTweaks = false;

    [Name("Headache Debuff")]
    [Description("Removes the headache debuff on Peach and Rosehip Pies.")]
    public bool RemoveHeadacheDebuffFromPies = false;

    [Name("Breath Effect")]
    [Description("Enable or disable the visual breath effect.")]
    public bool DisableBreathEffect = true;

    [Name("Decal Overlap Leniency")]
    [Description("Adjust the leniency for decal overlap between 0 (strict) and 1 (lenient).")]
    [Slider(0f, 1f, 11)]
    public float DecalOverlapLeniencyPerfect = 0.2f;

    [Name("Snow Shelter Decay Rate")]
    [Description("Adjust the snow shelter's decay rate between 50 (slower decay) and 100 (normal decay).")]
    [Slider(50, 100)]
    public int SnowShelterDailyDecayRate = 100;

    [Name("Toilet Water Quality")]
    [Description("Determines whether water from toilets is potable or non-potable.")]
    [Choice("Potable", "Non-Potable")]
    public int ToiletWaterQuality = 0;

    [Name("Always Show Crosshair")]
    [Description("When enabled, the crosshair will always be visible.")]
    public bool AlwaysShowCrosshair = false;

    [Name("Main Menu Items")]
    [Description("When enabled, the WINTERMUTE and Expansion menu items will be removed if those DLCs aren't installed.")]
    public bool RemoveMenuItems = false;
    #endregion

    #region Flashlight Tweaks
    [Section("Flashlight Tweaks")]

    [Name("Extended Flashlight Functionality")]
    [Description("Allows the flashlight to be used outside of an aurora and anytime.")]
    public bool EnableFlashlightWithoutAurora = false;

    [Name("Randomize Flashlight Charge")]
    [Description("Determines if the flashlight starts with a random battery charge.")]
    public bool RandomizeFlashlightCharge = false;
    #endregion

    #region Experimental Tweaks
    [Section("Experimental - Use At Your Own Risk")]

    [Name("MRE Texture Swap")]
    [Description("Changes the MRE texture to a brown variant. DISCLAIMER: Requires a game restart.")]
    public bool SwapMRETexture = false;

    [Name("First Person Handedness")]
    [Description("Switches the handedness of first-person animations. DISCLAIMER: Tracking points break if used.")]
    [Choice("Right-Handed", "Left-Handed")]
    public int FirstPersonHandednessView = 0;
    #endregion

    internal static void OnLoad()
    {
        Instance.AddToModSettings(BuildInfo.GUIName);
        Instance.RefreshGUI();
    }
}