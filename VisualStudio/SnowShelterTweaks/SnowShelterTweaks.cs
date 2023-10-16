namespace UniversalTweaks
{
    internal class SnowShelterTweaks
    {
        [HarmonyPatch(typeof(SnowShelterManager), nameof(SnowShelterManager.InstantiateSnowShelter))]
        internal class SnowShelterDecayRate
        {
            static void Postfix(ref SnowShelter __result)
            {
                if (__result != null)
                {
                    __result.m_DailyDecayHP = 50f;
                }
            }
        }
    }
}