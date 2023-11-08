using UniversalTweaks.Utilities;
using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal sealed class MelonModImplementation : MelonMod
{
    public override void OnInitializeMelon()
    {
        Settings.OnLoad();
        LoadLocalizations();

        TextureSwapper.SwapMREMainTexture("GEAR_FoodMRE_Dif", "GEAR_FoodBrownMRE_Dif");
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        TweaksFood.RemoveHeadacheDebuff("GEAR_CookedPiePeach", "GEAR_CookedPieRoseHip");
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