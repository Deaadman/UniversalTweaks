using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksDecals
{
    [HarmonyPatch(typeof(DynamicDecalsManager), nameof(DynamicDecalsManager.RenderDynamicDecal))]           // Need to figure out why decal texture is weird when switching back to the original material. Also need to get the colour from the DecalColour.
    private static class DynamicDecalsManager_RenderDynamicDecal_Patch
    {
        private static bool Prefix(DynamicDecalsManager __instance, ref Material __state)
        {
            __state = __instance.m_StandardMaterial;

            if (Settings.Instance.EnableGlowDecal && __instance.m_GlowMaterial != null)
            {
                __instance.m_StandardMaterial = __instance.m_GlowMaterial;
                __instance.m_AnimatedRevealMaterial = __instance.m_GlowMaterial;

                __instance.m_GlowMaterial.SetColor("_GlowColor", new Color(1f, 0.4489248f, 0f, 0f));
                __instance.m_GlowMaterial.SetFloat("_GlowMult", Settings.Instance.GlowDecalMultiplier);
            }

            return true;
        }

        private static void Postfix(DynamicDecalsManager __instance, ref Material __state)
        {
            __instance.m_StandardMaterial = __state;
            __instance.m_AnimatedRevealMaterial = __state;
        }
    }

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