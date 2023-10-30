namespace UniversalTweaks;
internal class TweaksWater
{
    [HarmonyPatch(typeof(WaterSource), nameof(WaterSource.Deserialize))]
    private static class NonPotableToiletWater
    {
        private static void Postfix(WaterSource __instance)
        {
            __instance.m_CurrentLiquidQuality = LiquidQuality.NonPotable;
        }
    }
}