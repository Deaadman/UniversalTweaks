using Il2CppTLD.BigCarry;
using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksTravois
{
    [HarmonyPatch(typeof(TravoisBigCarryItem), nameof(TravoisBigCarryItem.OnCarried))]
    private static class AllTravoisTweaks
    {
        private static void Postfix(TravoisBigCarryItem __instance)
        {
            __instance.m_TravoisMovement.m_TurnSpeed = Settings.Instance.TurnSpeed;
            __instance.m_TravoisMovement.m_MaxSlopeClimbAngle = Settings.Instance.MaxSlopeAngle;
            __instance.m_TravoisMovement.m_MaxSlopeDownhillAngle = Settings.Instance.MaxSlopeAngle;

            __instance.m_BlizzardDecayPerHour = Settings.Instance.CheatingTweaks ? Settings.Instance.DecayBlizzardTravois : 3;
            __instance.m_DecayHPPerHour = Settings.Instance.CheatingTweaks ? Settings.Instance.DecayHPPerHourTravois / 1000f : 0.01f;
            __instance.m_MovementDecayPerUnit = Settings.Instance.CheatingTweaks ? Settings.Instance.DecayMovementPerUnitTravois / 100f : 0.05f;
        }
    }
}