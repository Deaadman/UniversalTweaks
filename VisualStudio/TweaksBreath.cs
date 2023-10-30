using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksBreath
{
    [HarmonyPatch(typeof(Breath), nameof(Breath.PlayBreathEffect))]
    private static class DisableBreathEffect
    {
        private static float originalColdBreathTempThreshold;
        private static float originalVeryColdBreathTempThreshold;
        private static float originalFreezingBreathTempThreshold;
        private static bool hasStoredOriginalValues = false;

        private static void Postfix(Breath __instance)
        {
            if (!hasStoredOriginalValues)
            {
                originalColdBreathTempThreshold = __instance.m_ColdBreathTempThreshold;
                originalVeryColdBreathTempThreshold = __instance.m_VeryColdBreathTempThreshold;
                originalFreezingBreathTempThreshold = __instance.m_FreezingBreathTempThreshold;
                hasStoredOriginalValues = true;
            }

            if (Settings.Instance.DisableBreathEffect)
            {
                __instance.m_ColdBreathTempThreshold = -float.MaxValue;
                __instance.m_VeryColdBreathTempThreshold = -float.MaxValue;
                __instance.m_FreezingBreathTempThreshold = -float.MaxValue;
                __instance.StopBreathEffectImmediate();
            }
            else
            {
                __instance.m_ColdBreathTempThreshold = originalColdBreathTempThreshold;
                __instance.m_VeryColdBreathTempThreshold = originalVeryColdBreathTempThreshold;
                __instance.m_FreezingBreathTempThreshold = originalFreezingBreathTempThreshold;
            }
        }
    }
}