namespace UniversalTweaks.Properties;

internal class Settings : JsonModSettings
{
    internal static Settings Instance { get; } = new();

    #region General Tweaks
    [Section("General Tweaks")]

    [Name("Breath Visibility")]
    [Description("Toggle the visual breath effect on or off.")]
    public bool DisableBreathEffect = true;

    [Name("Decal Placement Flexibility")]
    [Description("Set the leniency for placing decals. Range: 0 (strict) to 1 (lenient).")]
    [Slider(0f, 1f, 11)]
    public float DecalOverlapLeniencyPerfect = 0.2f;

    [Name("Main Menu Customization")]
    [Description("Removes WINTERMUTE and Expansion menu items if not installed.")]
    public bool RemoveMenuItems = false;

    [Name("Permanent Crosshair")]
    [Description("Keep the crosshair visible at all times.")]
    public bool AlwaysShowCrosshair = false;

    [Name("Remove Headache from Pies")]
    [Description("Eliminates the headache debuff from Peach and Rosehip Pies.")]
    public bool RemoveHeadacheDebuffFromPies = false;

    [Name("Revolver Handling Improvements")]
    [Description("Allows movement while aiming the revolver for enhanced usability.")]
    public bool EnableRevolverTweaks = false;

    [Name("Snow Shelter Durability")]
    [Description("Adjust the decay rate of snow shelters. Range: 50 (slower) to 100 (normal).")]
    [Slider(50, 100)]
    public int SnowShelterDailyDecayRate = 100;

    [Name("Toilet Water Potability")]
    [Description("Sets whether water obtained from toilets is potable or non-potable.")]
    [Choice("Potable", "Non-Potable")]
    public int ToiletWaterQuality = 0;
    #endregion

    #region Flashlight Tweaks
    [Section("Flashlight Tweaks")]

    [Name("Aurora-Independent Flashlight Use")]
    [Description("Allows the flashlight to function anytime, not just during auroras.")]
    public bool EnableFlashlightWithoutAurora = false;

    [Name("Aurora-Only High Beam")]
    [Description("Restricts high beam functionality to aurora events only.")]
    public bool HighBeamOnlyDuringAurora = false;

    [Name("Flashlight Battery Randomization")]
    [Description("Sets the flashlight to start with a random battery charge level.")]
    public bool RandomizeFlashlightCharge = false;
    #endregion

    #region Experimental Tweaks
    [Section("Experimental Tweaks")]

    [Name("First-Person Handedness")]
    [Description("Alters the handedness of first-person animations. May cause tracking issues.")]
    [Choice("Right-Handed", "Left-Handed")]
    public int FirstPersonHandednessView = 0;

    [Name("MRE Texture Variation")]
    [Description("Switches the MRE texture to a brown variant. Requires game restart.")]
    public bool SwapMRETexture = false;
    #endregion

    internal static void OnLoad()
    {
        Instance.AddToModSettings(BuildInfo.GUIName);
        Instance.RefreshGUI();
    }
}