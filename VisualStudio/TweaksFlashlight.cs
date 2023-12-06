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

        private static void Postfix(LightRandomIntensity __instance)                    // Need to revamp this method, change the color from the flashlight - not LightRandomIntensity.
        {
            if (__instance.gameObject.name == "LightIndoors" || __instance.gameObject.name == "LightOutdoors" || __instance.gameObject.name == "LightExtend")
            {
                Light lightComponent = __instance.gameObject.GetComponent<Light>();

                if (lightComponent != null)
                {
                    switch (Settings.Instance.LightColor)
                    {
                        case FlashlightColor.Custom:
                            lightComponent.color = new Color(Settings.Instance.RedValue / 255,
                                                             Settings.Instance.GreenValue / 255,
                                                             Settings.Instance.BlueValue / 255);
                            break;
                        case FlashlightColor.Default:
                            lightComponent.color = new Color(0.7215686f, 0.8117647f, 0.9176471f);
                            break;
                        case FlashlightColor.Red:
                            lightComponent.color = Color.red;
                            break;
                        case FlashlightColor.Green:
                            lightComponent.color = Color.green;
                            break;
                        case FlashlightColor.Blue:
                            lightComponent.color = Color.blue;
                            break;
                        case FlashlightColor.Yellow:
                            lightComponent.color = Color.yellow;
                            break;
                        case FlashlightColor.Purple:
                            lightComponent.color = new Color(0.5f, 0f, 0.5f);
                            break;
                        case FlashlightColor.Orange:
                            lightComponent.color = new Color(1f, 0.6470588f, 0f);
                            break;
                        case FlashlightColor.White:
                            lightComponent.color = Color.white;
                            break;
                    }
                }
            }
        }
    }
}