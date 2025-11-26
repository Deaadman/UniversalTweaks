using LocalizationUtilities;

using UniversalTweaks.Properties;
using UniversalTweaks.Utilities;

namespace UniversalTweaks;

internal sealed class Mod : MelonMod
{
    public override void OnInitializeMelon()
    {
        LoadLocalizations();
        Settings.OnLoad();
    }

    private static void LoadLocalizations()
    {
        const string jsonFile = "UniversalTweaks.Resources.Localization.json";

        try
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(jsonFile) ??
                               throw new InvalidOperationException($"Failed to load resource: {jsonFile}");
            using StreamReader reader = new(stream);

            var results = reader.ReadToEnd();

            LocalizationManager.LoadJsonLocalization(results);
        }
        catch (Exception ex)
        {
            Logging.LogError(ex.Message);
        }
    }
}