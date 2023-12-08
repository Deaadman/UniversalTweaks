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

    //

    [HarmonyPatch(typeof(GearItem), nameof(GearItem.Deserialize))]
    private static class GearItemSettings
    {
        private static void Postfix()
        {
            if (Settings.Instance.RemoveHeadacheDebuffFromPies)
            {
                TweaksFood.RemoveHeadacheDebuff("GEAR_CookedPiePeach", "GEAR_CookedPieRoseHip");
            }
            else
            {
                TweaksFood.AddHeadacheDebuff("GEAR_CookedPiePeach", "GEAR_CookedPieRoseHip");
            }

            if (Settings.Instance.MRETextureVariant)
            {
                TextureSwapper.SwapGearItemTexture("GEAR_MRE", "Obj_FoodMRE_LOD0", "GEAR_FoodBrownMRE_Dif");
            }
        }
    }
}