namespace UniversalTweaks;

internal class TweaksSnowShelter
{
    [HarmonyPatch(typeof(SnowShelterManager), nameof(SnowShelterManager.InstantiateSnowShelter))]
    private static class SnowShelterDecayRate
    {
        private static void Postfix(ref SnowShelter __result)
        {
            if (__result != null)
            {
                __result.m_DailyDecayHP = 50f;
            }
        }
    }
}