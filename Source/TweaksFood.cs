using Il2CppTLD.Gear;
using Il2CppTLD.IntBackedUnit;
using UniversalTweaks.Properties;
using UniversalTweaks.Utilities;

namespace UniversalTweaks;

internal class TweaksFood
{
    // Possibly move this to the Awake() method and attach a GearItemExtension.cs MonoBehaviour to each GearItem prefab.
    // From there we can call a method that will set the values of the GearItem based on the settings without relying on Harmony Patches.
    // This will allow us to change the settings and have them apply immediately without needing to reload the game.
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
            
            if (__instance.gameObject.name is "GEAR_CookedStewMeat" or "GEAR_CookedStewVegetables")
            {
                __instance.gameObject.GetComponentInParent<FoodStatEffect>().m_Effect = Settings.Instance.ReduceStewFatigueLossAmount;
            }
            
            string[] insulatedFlasks = ["GEAR_InsulatedFlask_A", "GEAR_InsulatedFlask_B", "GEAR_InsulatedFlask_C", "GEAR_InsulatedFlask_D", "GEAR_InsulatedFlask_E", "GEAR_InsulatedFlask_F"];

            // When optimising this mod, consider using the GearItem.LoadPrefab blah blah blah - so we can make a separate 'RefreshGearItems' method that can be called when the settings are changed.
            if (insulatedFlasks.Contains(__instance.gameObject.name))
            {
                __instance.m_InsulatedFlask.m_PercentHeatLossPerMinuteIndoors = Settings.Instance.InsulatedFlaskHeatLossPerMinuteIndoors;
                __instance.m_InsulatedFlask.m_PercentHeatLossPerMinuteOutdoors = Settings.Instance.InsulatedFlaskHeatLossPerMinuteOutdoors;
            }

            if (Settings.Instance.ConsistantDressingWeight && __instance.gameObject.name == "GEAR_OldMansBeardDressing")
            {
                __instance.m_GearItemData.m_BaseWeight = ItemWeight.FromKilograms(0.03f);
            }
        }
    }
}