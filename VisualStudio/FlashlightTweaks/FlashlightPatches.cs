namespace UniversalTweaks
{
    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.GetNormalizedCharge))]
    internal class FlashlightKeepBatteryCharge
    {
        internal static bool Prefix(FlashlightItem __instance, ref float __result)
        {
            __result = __instance.m_CurrentBatteryCharge;
            return false;
        }
    }

    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.IsLit))]
    internal class FlashlightFunctionality
    {
        internal static bool Prefix(FlashlightItem __instance, ref bool __result)
        {
            __result = __instance.IsOn();
            return false;
        }
    }

    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.Update))]
    internal class FlashlightBatteryDrain
    {
        internal static void Postfix(FlashlightItem __instance)
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
}