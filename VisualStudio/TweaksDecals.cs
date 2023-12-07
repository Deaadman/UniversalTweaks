using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksDecals 
{
    [HarmonyPatch(typeof(DynamicDecalsManager), nameof(DynamicDecalsManager.RenderDynamicDecal))]
    private static class DynamicDecalsManager_RenderDynamicDecal_Patch
    {
        private static bool Prefix(DynamicDecalsManager __instance)
        {
            if (Settings.Instance.GlowingDecals && __instance.m_GlowMaterial != null)
            {
                __instance.m_GlowMaterial.SetColor("_GlowColor", new Color(1f, 0.4489248f, 0f, 0f));
                __instance.m_GlowMaterial.SetFloat("_GlowMult", Settings.Instance.GlowingDecalMultiplier);

                __instance.m_AnimatedRevealMaterial = __instance.m_GlowMaterial;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(Panel_SprayPaint), nameof(Panel_SprayPaint.Enable), new Type[] { typeof(bool) })]
    private static class DecalRestrictions
    {
        private static void Postfix()
        {
            DynamicDecalsManager dynamicDecalsManager = GameManager.GetDynamicDecalsManager();
            dynamicDecalsManager.m_DecalOverlapLeniencyPercent = Settings.Instance.DecalOverlapLeniency;
        }
    }
}