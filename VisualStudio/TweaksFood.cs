using Il2CppTLD.Gear;

namespace UniversalTweaks;

internal class TweaksFood
{
    internal static bool debuffDestroyed = false;

    internal static void PieItems()
    {
        RemoveHeadacheDebuffFromItems("GEAR_CookedPiePeach");
        RemoveHeadacheDebuffFromItems("GEAR_CookedPieRoseHip");
        RemoveHeadacheDebuffFromItems("GEAR_MRE");
    }

    private static void RemoveHeadacheDebuffFromItems(string itemName)
    {
        GearItem item = GearItem.LoadGearItemPrefab(itemName);
        if (item != null)
        {
            CausesHeadacheDebuff debuffScript = item.gameObject.GetComponent<CausesHeadacheDebuff>();
            if (debuffScript != null)
            {
                UnityEngine.Object.Destroy(debuffScript);
                debuffDestroyed = true;
            }
        }
    }
}