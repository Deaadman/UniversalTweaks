namespace UniversalTweaks
{
    internal class SnowShelterTweaks
    {
        [HarmonyPatch(typeof(SnowShelterManager), nameof(SnowShelterManager.InstantiateSnowShelter))]
        private class SnowShelterDecayRate
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
}