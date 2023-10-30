namespace UniversalTweaks.Tweaks;
internal class BreathTweaks
{
    [HarmonyPatch(typeof(Breath), nameof(Breath.Start))]
    private static class DisableBreathEffect
    {
        private static void Postfix(Breath __instance)
        {
            __instance.m_ColdBreathTempThreshold = -float.MaxValue;
            __instance.m_VeryColdBreathTempThreshold = -float.MaxValue;
            __instance.m_FreezingBreathTempThreshold = -float.MaxValue;
            __instance.StopBreathEffectImmediate();
        }
    }
}