namespace UniversalTweaks
{
    internal class FlashlightTweaks
    {
        [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.GetNormalizedCharge))]
        private class FlashlightKeepBatteryCharge
        {
            private static bool Prefix(FlashlightItem __instance, ref float __result)
            {
                __result = __instance.m_CurrentBatteryCharge;
                return false;
            }
        }

        [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.IsLit))]
        private class FlashlightFunctionality
        {
            private static bool Prefix(FlashlightItem __instance, ref bool __result)
            {
                __result = __instance.IsOn();
                return false;
            }
        }

        [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.Update))]
        private class FlashlightBatteryDrain
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

        #region Revisit Later
        /* [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.Awake))]
        internal static class Test2
        {
            private static void Postfix(FlashlightItem __instance)
            {
                if (!GameManager.GetAuroraManager().AuroraIsActive())
                {
                    DisableLightRandomIntensity(__instance.m_LightIndoor);
                    DisableLightRandomIntensity(__instance.m_LightOutdoor);
                    DisableLightRandomIntensity(__instance.m_LightIndoorHigh);
                    DisableLightRandomIntensity(__instance.m_LightOutdoorHigh);
                }
                else
                {
                    EnableLightRandomIntensity(__instance.m_LightIndoor);
                    EnableLightRandomIntensity(__instance.m_LightOutdoor);
                    EnableLightRandomIntensityHigh(__instance.m_LightIndoorHigh);
                    EnableLightRandomIntensityHigh(__instance.m_LightOutdoorHigh);
                }
            }
        }

        private static void DisableLightRandomIntensity(Light lightComponent)
        {
            if (lightComponent != null)
            {
                LightRandomIntensity intensityComponent = lightComponent.gameObject.GetComponent<LightRandomIntensity>();
                if (intensityComponent != null)
                {
                    intensityComponent.m_IntervalSeconds = 0;
                    intensityComponent.m_Min = 0;
                    intensityComponent.m_Max = 0;
                }
            }
        }

        private static void EnableLightRandomIntensity(Light lightComponent)
        {
            if (lightComponent != null)
            {
                LightRandomIntensity intensityComponent = lightComponent.gameObject.GetComponent<LightRandomIntensity>();
                if (intensityComponent != null)
                {
                    intensityComponent.m_IntervalSeconds = 0.15f;
                    intensityComponent.m_Min = 2;
                    intensityComponent.m_Max = 4;
                }
            }
        }

        private static void EnableLightRandomIntensityHigh(Light lightComponent)
        {
            if (lightComponent != null)
            {
                LightRandomIntensity intensityComponent = lightComponent.gameObject.GetComponent<LightRandomIntensity>();
                if (intensityComponent != null)
                {
                    intensityComponent.m_IntervalSeconds = 0.15f;
                    intensityComponent.m_Min = 10;
                    intensityComponent.m_Max = 20;
                }
            }
        } */
        #endregion
    }
}