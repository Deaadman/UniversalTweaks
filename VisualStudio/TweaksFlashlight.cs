using UniversalTweaks.Properties;
using UniversalTweaks.Utilities;

namespace UniversalTweaks;

internal class TweaksFlashlight
{
    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.Awake))]
    private static class FlashlightCustomization
    {
        private static void Prefix(FlashlightItem __instance)
        {
            if (Settings.Instance.BatteryRandomization)
            {
                __instance.m_CurrentBatteryCharge = UnityEngine.Random.Range(0f, 1f);
            }
        }
    }

    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.GetNormalizedCharge))]
    private static class FlashlightKeepBatteryCharge
    {
        private static bool Prefix(FlashlightItem __instance, ref float __result)
        {
            if (!Settings.Instance.ExtendedFunctionality)
            {
                return true;
            }

            __result = __instance.m_CurrentBatteryCharge;
            return false;
        }
    }

    //

    //[HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.EnableLights))]
    //private static class Testing10000000000000
    //{
    //    private static bool Prefix()
    //    {
    //        return false;
    //    }
    //}

    //

    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.IsLit))]
    private static class FlashlightFunctionality
    {
        private static bool Prefix(FlashlightItem __instance, ref bool __result)
        {
            if (Settings.Instance.HighBeamRestrictions && __instance.m_State == FlashlightItem.State.High && !GameManager.GetAuroraManager().AuroraIsActive())
            {
                GameAudioManager.PlayGUIError();
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_StateHighFail"), false, false);
                __result = __instance.IsOn();
                return true;
            }

            __result = __instance.IsOn();
            return false;
        }
    }

    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.Update))]
    private static class FlashlightBatteryDrain
    {
        private static void Postfix(FlashlightItem __instance)
        {
            float tODHours = GameManager.GetTimeOfDayComponent().GetTODHours(Time.deltaTime);

            if (!GameManager.GetAuroraManager().AuroraIsActive())
            {
                if (__instance.m_State == FlashlightItem.State.Low)
                {
                    __instance.m_CurrentBatteryCharge -= tODHours / __instance.m_LowBeamDuration;
                }
                else if (!Settings.Instance.HighBeamRestrictions && __instance.m_State == FlashlightItem.State.High)
                {
                    __instance.m_CurrentBatteryCharge -= tODHours / __instance.m_HighBeamDuration;
                }
                if (__instance.m_CurrentBatteryCharge <= 0f)
                {
                    __instance.m_CurrentBatteryCharge = 0f;
                    __instance.m_State = FlashlightItem.State.Off;
                }
            }

            if (Settings.Instance.InfiniteBattery)
            {
                __instance.m_CurrentBatteryCharge = 1f;
            }

            bool isMinersFlashlight = __instance.m_GearItem != null && __instance.m_GearItem.name == "GEAR_Flashlight_LongLasting";
            __instance.m_LowBeamDuration = Settings.Instance.CheatingTweaks ? (isMinersFlashlight ? Settings.Instance.MinersFlashlightLowBeamDuration : Settings.Instance.FlashlightLowBeamDuration) : (isMinersFlashlight ? 1.5f : 1f);
            __instance.m_HighBeamDuration = Settings.Instance.CheatingTweaks ? (isMinersFlashlight ? Settings.Instance.MinersFlashlightHighBeamDuration : Settings.Instance.FlashlightHighBeamDuration) : (isMinersFlashlight ? 0.08333334f : 0.08333334f);
            __instance.m_RechargeTime = Settings.Instance.CheatingTweaks ? (isMinersFlashlight ? Settings.Instance.MinersFlashlightRechargeTime : Settings.Instance.FlashlightRechargeTime) : (isMinersFlashlight ? 1.75f : 2f);

            UpdateFlashlightBeamColor(__instance, null, __instance.m_FxObjectHigh);
        }
    }

    [HarmonyPatch(typeof(FirstPersonFlashlight), nameof(FirstPersonFlashlight.Update))]
    private static class ModifyFlashFlashlightBeamColor
    {
        private static void Postfix(FirstPersonFlashlight __instance)
        {
            GearItem itemInHands = GameManager.GetPlayerManagerComponent().m_ItemInHands;
            FlashlightItem flashlightItem = itemInHands.m_FlashlightItem;

            UpdateFlashlightBeamColor(flashlightItem, __instance, __instance.m_HighFxGameObject);
        }
    }

    [HarmonyPatch(typeof(LightRandomIntensity), nameof(LightRandomIntensity.Update))]
    private static class FlashlightFlicker
    {
        private static bool Prefix(LightRandomIntensity __instance)
        {
            if (Settings.Instance.AuroraFlickering == true)
            {
                if ((__instance.gameObject.name == "LightIndoors" || __instance.gameObject.name == "LightOutdoors" || __instance.gameObject.name == "LightExtend") && !GameManager.GetAuroraManager().AuroraIsActive() && Settings.Instance.ExtendedFunctionality)
                {
                    return false;
                }
            }

            return true;
        }
    }

    //

    private static Color GetColorFromFlashlight(FlashlightItem flashlightItem)
    {
        bool isMinersFlashlight = flashlightItem.m_GearItem != null && flashlightItem.m_GearItem.name == "GEAR_Flashlight_LongLasting";
        return GetColorFromSettings(isMinersFlashlight ? Settings.Instance.MinersFlashlightBeamColor : Settings.Instance.FlashlightBeamColor, isMinersFlashlight);
    }

    private static Color GetColorFromSettings(FlashlightBeamColor beamColor, bool isMinersFlashlight)
    {
        return beamColor switch
        {
            FlashlightBeamColor.Custom => new Color(
                (isMinersFlashlight ? Settings.Instance.MinersFlashlightRedValue : Settings.Instance.FlashlightRedValue) / 255f,
                (isMinersFlashlight ? Settings.Instance.MinersFlashlightGreenValue : Settings.Instance.FlashlightGreenValue) / 255f,
                (isMinersFlashlight ? Settings.Instance.MinersFlashlightBlueValue : Settings.Instance.FlashlightBlueValue) / 255f),
            FlashlightBeamColor.Default => new Color(0.7215686f, 0.8117647f, 0.9176471f),
            FlashlightBeamColor.Red => Color.red,
            FlashlightBeamColor.Green => Color.green,
            FlashlightBeamColor.Blue => Color.blue,
            FlashlightBeamColor.Yellow => Color.yellow,
            FlashlightBeamColor.Purple => new Color(0.5f, 0f, 0.5f),
            FlashlightBeamColor.Orange => new Color(1f, 0.6470588f, 0f),
            FlashlightBeamColor.White => Color.white,
            _ => new Color(0.7215686f, 0.8117647f, 0.9176471f),
        };
    }

    private static void UpdateFlashlightBeamColor(FlashlightItem flashlightItem, FirstPersonFlashlight? firstPersonFlashlight, GameObject highFxGameObject)
    {
        if (flashlightItem == null)
        {
            return;
        }

        Color newColor = GetColorFromFlashlight(flashlightItem);

        if (flashlightItem.m_LightIndoor != null)
        {
            flashlightItem.m_LightIndoor.color = newColor;
        }
        if (flashlightItem.m_LightOutdoor != null)
        {
            flashlightItem.m_LightOutdoor.color = newColor;
        }

        if (firstPersonFlashlight != null)
        {
            if (firstPersonFlashlight.m_LightIndoorsLow != null)
            {
                firstPersonFlashlight.m_LightIndoorsLow.color = newColor;
            }
            if (firstPersonFlashlight.m_LightOutdoorsLow != null)
            {
                firstPersonFlashlight.m_LightOutdoorsLow.color = newColor;
            }
        }

        if (highFxGameObject != null)
        {
            Transform lightExtendTransform = highFxGameObject.transform.Find("LightExtend");
            if (lightExtendTransform != null)
            {
                Light lightExtend = lightExtendTransform.GetComponent<Light>();
                if (lightExtend != null)
                {
                    lightExtend.color = newColor;
                }
            }
        }
    }
}