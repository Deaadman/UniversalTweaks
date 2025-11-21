using UniversalTweaks.Properties;

namespace UniversalTweaks.Tweaks;

internal static class Breath
{
    [HarmonyPatch(typeof(Il2Cpp.Breath), nameof(Il2Cpp.Breath.PlayBreathEffect))]
    private static class BreathVisibility
    {
        private static void Postfix(Il2Cpp.Breath __instance)
        {
            __instance.m_SuppressEffects = !Settings.Instance.BreathVisibility;
        }
    }
}