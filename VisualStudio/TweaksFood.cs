using Il2CppTLD.Gear;

namespace UniversalTweaks;

internal class TweaksFood
{
    private struct HeadacheDebuffInfo
    {
        public HeadacheData HeadacheSettings;
        public float CausesHeadacheThreshold;
    }

    private static readonly Dictionary<string, HeadacheDebuffInfo> storedDebuffs = [];

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
                    storedDebuffs[itemName] = new HeadacheDebuffInfo
                    {
                        HeadacheSettings = debuffScript.m_HeadacheSettings,
                        CausesHeadacheThreshold = debuffScript.m_CausesHeadacheThreshold
                    };

                    UnityEngine.Object.Destroy(debuffScript);
                }
            }
        }
    }

    internal static void AddHeadacheDebuff(params string[] itemNames)
    {
        foreach (var itemName in itemNames)
        {
            if (storedDebuffs.TryGetValue(itemName, out HeadacheDebuffInfo debuffInfo))
            {
                GearItem item = GearItem.LoadGearItemPrefab(itemName);
                if (item != null && item.gameObject.GetComponent<CausesHeadacheDebuff>() == null)
                {
                    CausesHeadacheDebuff debuffScript = item.gameObject.AddComponent<CausesHeadacheDebuff>();
                    debuffScript.m_HeadacheSettings = debuffInfo.HeadacheSettings;
                    debuffScript.m_CausesHeadacheThreshold = debuffInfo.CausesHeadacheThreshold;
                }
            }
        }
    }
}