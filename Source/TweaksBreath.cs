using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksBreath
{
    [HarmonyPatch(typeof(Breath), nameof(Breath.PlayBreathEffect))]
    private static class BreathVisibility
    {
        private static void Postfix(Breath __instance)
        {
            __instance.m_SuppressEffects = !Settings.Instance.BreathVisibility;
        }
    }
}