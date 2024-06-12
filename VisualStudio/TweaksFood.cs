using Il2CppTLD.Gear;
using UniversalTweaks.Properties;
using UniversalTweaks.Utilities;

namespace UniversalTweaks;

internal class TweaksFood
{
    [HarmonyPatch(typeof(GearItem), nameof(GearItem.Deserialize))]
    private static class RemoveHeadacheComponents
    {
        private static void Postfix()
        {
            if (Settings.Instance.RemoveHeadacheDebuffFromFoods)
            {
                ComponentUtilities.RemoveComponent<CausesHeadacheDebuff>("GEAR_CookedPiePeach", "GEAR_CookedPieRoseHip", "GEAR_CookedPorridgeFruit");
            }
            else
            {
                ComponentUtilities.RestoreComponent<CausesHeadacheDebuff>("GEAR_CookedPiePeach", "GEAR_CookedPieRoseHip", "GEAR_CookedPorridgeFruit");
            }
        }
    }
}