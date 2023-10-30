namespace UniversalTweaks;

internal class TweaksFlashlight
{
    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.Awake))]
    private static class FlashlightRandomCharge
    {
        private static void Prefix(FlashlightItem __instance)
        {
            __instance.m_CurrentBatteryCharge = UnityEngine.Random.Range(0f, 1f);
        }
    }

    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.GetNormalizedCharge))]
    private static class FlashlightKeepBatteryCharge
    {
        private static bool Prefix(FlashlightItem __instance, ref float __result)
        {
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

    [HarmonyPatch(typeof(LightRandomIntensity), nameof(LightRandomIntensity.Update))]
    private static class FlashlightFlicker
    {
        private static bool Prefix()
        {
            if (!GameManager.GetAuroraManager().AuroraIsActive())
            {
                return false;
            }

            return true;
        }
    }
}