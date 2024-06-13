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

            string[] InsulatedFlasks = ["GEAR_InsulatedFlask_A", "GEAR_InsulatedFlask_B", "GEAR_InsulatedFlask_C", "GEAR_InsulatedFlask_D", "GEAR_InsulatedFlask_E", "GEAR_InsulatedFlask_F"];

            // When optimising this mod, consider using the GearItem.LoadPrefab blah blah blah - so we can make a separate 'RefreshGearItems' method that can be called when the settings are changed.
            if (InsulatedFlasks.Contains(__instance.gameObject.name))
            {
                __instance.m_InsulatedFlask.m_PercentHeatLossPerMinuteIndoors = Settings.Instance.InsulatedFlaskHeatLossPerMinuteIndoors;
                __instance.m_InsulatedFlask.m_PercentHeatLossPerMinuteOutdoors = Settings.Instance.InsulatedFlaskHeatLossPerMinuteOutdoors;
            }
        }
    }
}