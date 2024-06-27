using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksNoisemaker
{
    [HarmonyPatch(typeof(GearItem), nameof(GearItem.Deserialize))]
    private static class AdjustNoisemakerValues
    {
        private static void Postfix(GearItem __instance)
        {
            if (__instance.gameObject.name == "GEAR_NoiseMaker")
            {
                __instance.m_NoiseMakerItem.m_BurnLifetimeMinutes = Settings.Instance.NoisemakerBurnLength;
                __instance.m_NoiseMakerItem.m_ThrowForce = Settings.Instance.NoisemakerThrowForce;
            }
        }
    }
}