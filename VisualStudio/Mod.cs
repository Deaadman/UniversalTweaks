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
            if (Settings.Instance.MRETextureVariant)
            {
                TextureSwapper.SwapGearItemMainTexture("GEAR_MRE", "Obj_FoodMRE_LOD0", "GEAR_FoodBrownMRE_Dif");
            }
        }
    }

    //[HarmonyPatch(typeof(Panel_ActionsRadial), nameof(Panel_ActionsRadial.GetShouldGreyOut))]
    //private static class Testing10
    //{
    //    private static bool Prefix(Panel_ActionsRadial.RadialType radialType, ref bool __result)
    //    {
    //        if (radialType == Panel_ActionsRadial.RadialType.RockCache)
    //        {
    //            if (GameManager.GetWeatherComponent().IsIndoorEnvironment())
    //            {
    //                __result = false;
    //            }
    //            else
    //            {
    //                __result = true;
    //            }

    //            return false;
    //        }

    //        return true;
    //    }
    //}

    //[HarmonyPatch(typeof(Panel_Actions), nameof(Panel_Actions.OnPlaceRockCache))]
    //private static class Testing
    //{
    //    private static bool Prefix()
    //    {
    //        //if (GameManager.GetWeatherComponent().IsIndoorEnvironment())
    //        //{
    //        //    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_CannotBuildRockCacheIndoors"), false, false);
    //        //    return false;
    //        //}
    //        return false;
    //    }
    //}

    //[HarmonyPatch(typeof(Panel_ActionsRadial), nameof(Panel_ActionsRadial.ShowNoRockCacheMessage))]
    //private static class Testing
    //{
    //    private static bool Prefix()
    //    {
    //        if (GameManager.GetWeatherComponent().IsIndoorEnvironment())
    //        {
    //            return false;
    //        }
    //        return true;
    //    }
    //}

    //[HarmonyPatch(typeof(RockCacheManager), nameof(RockCacheManager.CanAttemptToPlaceRockCache))]
    //public static class Testing2
    //{
    //    private static bool Prefix()
    //    {
    //        if (GameManager.GetWeatherComponent().IsIndoorEnvironment())
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            return true;
    //        }
    //    }
    //}
}