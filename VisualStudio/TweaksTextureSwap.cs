using UniversalTweaks.Properties;
using UniversalTweaks.Utilities;

namespace UniversalTweaks;

internal class TweaksTextureSwap
{
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

    internal static string GetTextureNameForGearItem(GearItem gi)
    {
        var textureMapping = new Dictionary<string, string>
            {
                { "GEAR_MRE", "ico_GearItem__BrownMRE" },
            };

        if (gi.name == "GEAR_MRE" && !Settings.Instance.MRETextureVariant)
        {
            return string.Empty;
        }

        if (textureMapping.TryGetValue(gi.name, out var textureName))
        {
            return textureName;
        }

        return string.Empty;
    }
}