namespace UniversalTweaks;

public class Main : MelonMod
{
    //public static AssetBundle? BrownMREAssetBundle { get; } = Miscellaneous.AssetBundleLoader.LoadBundle("UniversalTweaks.AssetBundles.BrownMRE");

    public override void OnInitializeMelon()
    {
        //if (BrownMREAssetBundle != null)
        //{
        //    string[] assetNames = BrownMREAssetBundle.GetAllAssetNames();
        //    foreach (string name in assetNames)
        //    {
        //        Logging.Log($"Found asset: {name}");
        //    }
        //}
        //else
        //{
        //    Logging.LogError("AssetBundle is null.");
        //}

        //BrownMREAssetBundle.LoadAsset<Texture2D>("Assets/BrownMRE/ico_GearItem__MRE.png");
        //BrownMREAssetBundle.LoadAsset<Texture2D>("Assets/BrownMRE/GEAR_FoodMRE_Dif.png");

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