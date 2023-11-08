using Il2CppTLD.Gear;

namespace UniversalTweaks;

internal class TweaksFood
{
    internal static void RemoveHeadacheDebuff(params string[] itemNames)
    {
        foreach (var itemName in itemNames)
        {
            GearItem item = GearItem.LoadGearItemPrefab(itemName);
            if (item != null)
            {
                CausesHeadacheDebuff debuffScript = item.gameObject.GetComponent<CausesHeadacheDebuff>();
                if (debuffScript != null)
                {
                    UnityEngine.Object.Destroy(debuffScript);
                }
            }
        }
    }
}