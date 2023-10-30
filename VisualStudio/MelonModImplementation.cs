using UniversalTweaks.Utilities;
using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal sealed class MelonModImplementation : MelonMod
{
    internal static AssetBundle? UniversalTweaksAssetBundle { get; } = AssetBundleLoader.LoadBundle("UniversalTweaks.Resources.UniversalTweaksAssetBundle");

    // public static Texture2D? IconTexture { get; private set; }
    internal static Texture2D? MRETexture { get; private set; }

    public override void OnInitializeMelon()
    {
        // IconTexture = BrownMREAssetBundle.LoadAsset<Texture2D>("Assets/BrownMRE/ico_GearItem__MRE.png");
        MRETexture = UniversalTweaksAssetBundle.LoadAsset<Texture2D>("Assets/UniversalTweaks/BrownMRE/GEAR_FoodBrownMRE_Dif.png");

        Settings.OnLoad();
        LoadLocalizations();
    }

    public override void OnSceneWasInitialized(int buildIndex, string sceneName)
    {
        if (!TweaksFood.debuffDestroyed)
        {
            TweaksFood.PieItems();
        }
    }

    private static void LoadLocalizations()
    {
        const string JSONfile = "UniversalTweaks.Resources.Localization.json";

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