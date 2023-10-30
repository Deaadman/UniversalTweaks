namespace UniversalTweaks.Tweaks;
internal class TolietTweaks
{
    [HarmonyPatch(typeof(WaterSource), nameof(WaterSource.Update))] // Has to be update for some reason? Awake or Start don't set all (only a few) toilets to the quality NonPotable.
    private static class ToiletNonPotableWater
    {
        private static void Postfix(WaterSource __instance)
        {
            __instance.m_CurrentLiquidQuality = LiquidQuality.NonPotable;
        }
    }
}