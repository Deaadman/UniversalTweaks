using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksFlashlight
{
    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.Awake))]
    private static class FlashlightRandomCharge
    {
        private static void Prefix(FlashlightItem __instance)
        {
            if (Settings.Instance.RandomizeFlashlightCharge)
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
            if (!Settings.Instance.EnableFlashlightWithoutAurora)
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
                else if (__instance.m_State == FlashlightItem.State.High)
                {
                    __instance.m_CurrentBatteryCharge -= tODHours / __instance.m_HighBeamDuration;
                }
                if (__instance.m_CurrentBatteryCharge <= 0f)
                {
                    __instance.m_CurrentBatteryCharge = 0f;
                    __instance.m_State = FlashlightItem.State.Off;
                }
            }
        }
    }

    [HarmonyPatch(typeof(LightRandomIntensity), nameof(LightRandomIntensity.Update))]
    private static class FlashlightFlicker
    {
        private static bool Prefix(LightRandomIntensity __instance)
        {
            if (__instance.gameObject.name == "LightIndoors" || __instance.gameObject.name == "LightOutdoors" || __instance.gameObject.name == "LightExtend")
            {
                if (!GameManager.GetAuroraManager().AuroraIsActive() && Settings.Instance.EnableFlashlightWithoutAurora)
                {
                    return false;
                }
            }
            return true;
        }
    }
}