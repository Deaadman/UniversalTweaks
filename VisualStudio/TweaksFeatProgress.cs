using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksFeatProgress
{
    [HarmonyPatch(typeof(Feat), nameof(Feat.ShouldBlockIncrement))]
    private static class FeatProgressInCustomMode
    {
        private static void Postfix(ref bool __result)
        {
            if (Settings.Instance.FeatProgressInCustomMode)
            {
                __result = false;
            }
        }
    }
}