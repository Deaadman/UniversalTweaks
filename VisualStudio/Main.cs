namespace UniversalTweaks;

public class Main : MelonMod
{
    internal static AssetBundle? BrownMREAssetBundle { get; } = Miscellaneous.AssetBundleLoader.LoadBundle("UniversalTweaks.AssetBundles.UniversalTweaksAssetBundle");

    // New fields to store the loaded textures
    // public static Texture2D? IconTexture { get; private set; }
    public static Texture2D? MRETexture { get; private set; }

    public override void OnInitializeMelon()
    {
        // IconTexture = BrownMREAssetBundle.LoadAsset<Texture2D>("Assets/BrownMRE/ico_GearItem__MRE.png");
        MRETexture = BrownMREAssetBundle.LoadAsset<Texture2D>("Assets/UniversalTweaks/BrownMRE/GEAR_FoodBrownMRE_Dif.png");

        LoadLocalizations();
    }

    public override void OnSceneWasInitialized(int buildIndex, string sceneName)
    {
        if (!Tweaks.FoodTweaks.debuffDestroyed)
        {
            Tweaks.FoodTweaks.PieItems();
        }
    }

    private static void LoadLocalizations()
    {
        const string JSONfile = "UniversalTweaks.Data.Localization.json";

        try
        {
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(JSONfile) ?? throw new InvalidOperationException($"Failed to load resource: {JSONfile}");
            using StreamReader reader = new(stream);

            string results = reader.ReadToEnd();

            LocalizationManager.LoadJsonLocalization(results);
        }
        catch (Exception ex)
        {
            Logging.LogError(ex.Message);
        }
    }
}