using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksDecals
{
    [HarmonyPatch(typeof(DynamicDecalsManager), nameof(DynamicDecalsManager.Start))]
    private static class DecalRestrictions
    {
        private static void Postfix(DynamicDecalsManager __instance)
        {
            __instance.m_DecalOverlapLeniencyPercent = Settings.Instance.DecalOverlapLeniencyPerfect;
        }
    }
}