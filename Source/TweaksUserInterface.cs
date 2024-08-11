using Il2CppTLD.OptionalContent;
using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksUserInterface
{
    [HarmonyPatch(typeof(HUDManager), nameof(HUDManager.UpdateCrosshair))]
    private static class PermanentCrosshair
    {
        private static bool Prefix(HUDManager __instance)
        {
            if (Settings.Instance.PermanentCrosshair)
            {
                __instance.m_CrosshairAlpha = 1f;
            }

            return true;
        }
    }

    /*[HarmonyPatch(typeof(Panel_Actions), nameof(Panel_Actions.UpdateLifeAfterDeath))]
    private static class DisableCampfireLifeElements
    {
        private static void Postfix(Panel_Actions __instance)
        {
            if (Settings.Instance.DisableCampfireHUDElements == false) return;
            __instance.m_CampfireGrid.GetComponentInParent<UIWidget>().alpha = 0f;
        }
    }*/
    
    /* --- */
    
    // [HarmonyPatch(typeof(Panel_HUD), nameof(Panel_HUD.Enable))]
    // private static class Testing
    // {
    //     private static void Postfix(Panel_HUD __instance)
    //     {
    //         __instance.m_SprintBar.alpha = 1;
    //         __instance.m_SprintBar.gameObject.SetActive(true);
    //         __instance.m_ScentIndicator.m_ScentIndicatorRoot.alpha = 1;
    //         __instance.m_ScentIndicator.SetActive(true);
    //     }
    // }
    
    // [HarmonyPatch(typeof(Panel_HUD), nameof(Panel_HUD.Update))]
    // private static class Testing1
    // {
    //     private static void Postfix(Panel_HUD __instance)
    //     {
    //         __instance.m_SprintBar.alpha = 1;
    //         __instance.m_SprintBar.gameObject.SetActive(true);
    //         __instance.m_ScentIndicator.m_ScentIndicatorRoot.alpha = 1;
    //         __instance.m_ScentIndicator.SetActive(true);
    //     }
    // }
    
    // Semi-Working permanent HUD, it stays active when you enable it - but it doesn't show up when you load a save or when you open and close a new panel.
    // Need to convert this to use a settings instance as well, instead of the HudDisplayMode enum.
    // [HarmonyPatch(typeof(Panel_Actions), nameof(Panel_Actions.Update))]
    // private static class Testing3
    // {
    //     private static void Postfix(Panel_Actions __instance)
    //     {
    //         __instance.m_DoFadeOut = false;
    //     }
    // }
    
    /* --- */
    
    [HarmonyPatch(typeof(Panel_ActionsRadial), nameof(Panel_ActionsRadial.GetShouldGreyOut))]
    private static class GreyOutSprayPaintRadial
    {
        private static bool Prefix(Panel_ActionsRadial.RadialType radialType, ref bool __result)
        {
            if (radialType == Panel_ActionsRadial.RadialType.SprayPaint)
            {
                if (GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_SprayPaintCan") != null)
                {
                    __result = false;
                }
                else
                {
                    __result = true;
                }

                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(Panel_FeedFire), nameof(Panel_FeedFire.Initialize))]
    private static class FireSpriteFix
    {
        private static void Postfix(Panel_FeedFire __instance)
        {
            if (__instance.m_Sprite_FireFill != null)
            {
                __instance.m_Sprite_FireFill.gameObject.transform.localPosition = new Vector3(159.1f, -31.6f, 0);
                __instance.m_Sprite_FireFill.gameObject.transform.localScale = new Vector3(1.7f, 1.7f, 1);
            }
        }
    }
    
    // The Cougar was removed in v2.30 so this throws an error
    // [HarmonyPatch(typeof(Panel_HUD), nameof(Panel_HUD.MaybeUpdateCougarState))]
    // private static class DisableCougarHUDElements
    // {
    //     private static void Postfix(Panel_HUD __instance)
    //     {
    //         if (Settings.Instance.DisableCougarHUDElements == false) return;
    //         __instance.m_CougarWidget.alpha = 0f;
    //     }
    // }
    
    [HarmonyPatch(typeof(Panel_MainMenu), nameof(Panel_MainMenu.Initialize))]
    private class RemoveOptionalContentMenus
    {
        private static void Postfix(Panel_MainMenu __instance)
        {
            OptionalContentManager contentManager = OptionalContentManager.Instance;
            bool hasWintermute = contentManager.IsContentOwned(__instance.m_WintermuteConfig);

            if (Settings.Instance.RemoveMainMenuItems == true)
            {
                RemoveMainMenuItem(Panel_MainMenu.MainMenuItem.MainMenuItemType.TFTFTUpsell, __instance);
                if (!hasWintermute)
                {
                    RemoveMainMenuItem(Panel_MainMenu.MainMenuItem.MainMenuItemType.Story, __instance);
                }
            }
        }

        private static void RemoveMainMenuItem(Panel_MainMenu.MainMenuItem.MainMenuItemType removeType, Panel_MainMenu __instance)
        {
            for (var i = __instance.m_MenuItems.Count - 1; i >= 0; i--)
            {
                if (__instance.m_MenuItems[i].m_Type == removeType)
                {
                    __instance.m_MenuItems.RemoveAt(i);
                }
            }
        }
    }
}