namespace UniversalTweaks.Tweaks;

internal class DecalTweaks
{
    [HarmonyPatch(typeof(DynamicDecalsManager), nameof(DynamicDecalsManager.Start))]
    private static class RemoveSprayPaintRestrictions
    {
        private static void Postfix(DynamicDecalsManager __instance)
        {
            __instance.m_DecalOverlapLeniencyPercent = 1;
        }
    }
}