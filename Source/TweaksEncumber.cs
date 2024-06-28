using Il2CppTLD.IntBackedUnit;
using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksEncumber
{
    [HarmonyPatch(typeof(Encumber), nameof(Encumber.Start))]
    internal class StartEncumberTweaks
    {
        private static void Postfix(Encumber __instance)
        {
            EncumberUpdate(__instance);
        }
    }
    
    [HarmonyPatch(typeof(PlayerManager), nameof(PlayerManager.CalculateModifiedCalorieBurnRate), [typeof(float)])]
    internal class CalorieBurnRateFix
    {
        private static void Postfix(PlayerManager __instance, float baseBurnRate, ref float __result)
        {
            float rate = baseBurnRate;

            if (__instance.PlayerIsSprinting() || __instance.PlayerIsWalking() || __instance.PlayerIsClimbing())
            {
                rate += (GameManager.GetEncumberComponent().GetHourlyCalorieBurnFromWeight() * (30f / GameManager.GetEncumberComponent().m_MaxCarryCapacity.m_Units));
            }
            if (GameManager.GetFreezingComponent().IsFreezing())
            {
                rate *= GameManager.GetFreezingComponent().m_CalorieBurnMultiplier;
            }
            if (__instance.PlayerIsSprinting() || __instance.PlayerIsWalking())
            {
                float y = GameManager.GetVpFPSPlayer().Controller.Velocity.normalized.y;
                if (y > 0.1f)
                {
                    float speed = (y - 0.1f) / 0.5f;
                    speed = Mathf.Clamp(speed, 0f, 1f);
                    float speedMod = Mathf.Lerp(1f, 1.5f, speed);
                    rate *= speedMod;
                }
            }
            rate *= GameManager.GetExperienceModeManagerComponent().GetCalorieBurnScale();
            float moddedBurn = rate * GameManager.GetFeatEfficientMachine().ReduceCaloriesScale();

            __result = moddedBurn;
        }
    }
    
    internal static void EncumberUpdate(Encumber encumber)
    {
        if (Settings.Instance.AdditionalEncumbermentWeight > 0 || Settings.Instance.InfiniteEncumberWeight)
        {
            var additionalWeight = Settings.Instance.AdditionalEncumbermentWeight;
            if (Settings.Instance.InfiniteEncumberWeight) additionalWeight = 9970;

            encumber.m_MaxCarryCapacity = ItemWeight.FromKilograms(30f + additionalWeight);
            encumber.m_MaxCarryCapacityWhenExhausted = ItemWeight.FromKilograms(15f + additionalWeight);
            encumber.m_NoSprintCarryCapacity = ItemWeight.FromKilograms(40f + additionalWeight);
            encumber.m_NoWalkCarryCapacity = ItemWeight.FromKilograms(60f + additionalWeight);
            encumber.m_EncumberLowThreshold = ItemWeight.FromKilograms(31f + additionalWeight);
            encumber.m_EncumberMedThreshold = ItemWeight.FromKilograms(40f + additionalWeight);
            encumber.m_EncumberHighThreshold = ItemWeight.FromKilograms(60f + additionalWeight);
        }
        else
        {
            encumber.m_MaxCarryCapacity = ItemWeight.FromKilograms(30f);
            encumber.m_MaxCarryCapacityWhenExhausted = ItemWeight.FromKilograms(15f);
            encumber.m_NoSprintCarryCapacity = ItemWeight.FromKilograms(40f);
            encumber.m_NoWalkCarryCapacity = ItemWeight.FromKilograms(60f);
            encumber.m_EncumberLowThreshold = ItemWeight.FromKilograms(31f);
            encumber.m_EncumberMedThreshold = ItemWeight.FromKilograms(40f);
            encumber.m_EncumberHighThreshold = ItemWeight.FromKilograms(60f);
        }
    }
}