using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksSnowShelter
{
    [HarmonyPatch(typeof(SnowShelterManager), nameof(SnowShelterManager.InstantiateSnowShelter))]
    private static class SnowShelterDecayRate
    {
        private static void Postfix(ref SnowShelter __result)
        {
            __result.m_DailyDecayHP = Settings.Instance.SnowShelterDailyDecayRate;
        }
    }
}