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
            if (__instance.IsOn())
            {
                __result = true;
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.Update))]
    internal class FlashlightBatteryDrain
    {
        internal static void Postfix(FlashlightItem __instance)
        {
            if (!GameManager.GetAuroraManager().AuroraIsActive())
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
            __instance.EnableLights(__instance.m_State);
            __instance.UpdateAudio();
        }
    }

    // Updates the ID, but doesn't currently play any sound.
    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.UpdateAudio))]
    internal class FlashlightIntenseAudio
    {
        internal static bool Prefix(FlashlightItem __instance)
        {
            if (!GameManager.GetAuroraManager().AuroraIsActive() && __instance.m_State == FlashlightItem.State.High && __instance.m_IntensityAudioID == 0)
            {
                __instance.m_IntensityAudioID = GameAudioManager.PlaySound(__instance.m_IntensityAudioEvent, __instance.gameObject);
                return false;
            }
            else if (__instance.m_IntensityAudioID != 0)
            {
                uint intensityAudioIDRef = __instance.m_IntensityAudioID;
                GameAudioManager.StopPlayingID(ref intensityAudioIDRef);
                __instance.m_IntensityAudioID = 0u;
                return false;
            }

            return true;
        }
    }
}