namespace UniversalTweaks
{
    internal class DecalTweaks
    {
        /* [HarmonyPatch(typeof(DynamicDecalsManager), nameof(DynamicDecalsManager.Start))]
        private class RemoveSprayPaintRestrictions
        {
            private static void Postfix(DynamicDecalsManager __instance)
            {
                __instance.m_DecalOverlapLeniencyPercent = 0.2f;
            }
        } */
    }
}