using Il2CppTLD.Gear;
using UniversalTweaks.Properties;
using UniversalTweaks.Utilities;

namespace UniversalTweaks;

internal class TweaksFood
{
    [HarmonyPatch(typeof(GearItem), nameof(GearItem.Deserialize))]
    private static class RemoveHeadacheComponents
    {
        private static void Postfix(GearItem __instance)
        {
            if (Settings.Instance.RemoveHeadacheDebuffFromFoods)
            {
                ComponentUtilities.RemoveComponent<CausesHeadacheDebuff>("GEAR_CookedPiePeach", "GEAR_CookedPieRoseHip", "GEAR_CookedPorridgeFruit");
            }
            else
            {
                ComponentUtilities.RestoreComponent<CausesHeadacheDebuff>("GEAR_CookedPiePeach", "GEAR_CookedPieRoseHip", "GEAR_CookedPorridgeFruit");
            }

            if (__instance.gameObject.name == "GEAR_CookedStewMeat" || __instance.gameObject.name == "GEAR_CookedStewVegetables")
            {
                __instance.m_FoodItem.gameObject.GetComponentInParent<FoodStatEffect>().m_Effect = Settings.Instance.ReduceStewFatigueLossAmount;
            }
        }
    }
}