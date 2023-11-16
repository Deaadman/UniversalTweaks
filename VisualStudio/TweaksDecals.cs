using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksDecals
{
    [HarmonyPatch(typeof(Panel_SprayPaint), nameof(Panel_SprayPaint.Enable), new Type[] { typeof(bool) })]
    private static class DecalRestrictions
    {
        private static void Postfix()
        {
            DynamicDecalsManager dynamicDecalsManager = GameManager.GetDynamicDecalsManager();
            dynamicDecalsManager.m_DecalOverlapLeniencyPercent = Settings.Instance.DecalOverlapLeniencyPerfect;
        }
    }
}