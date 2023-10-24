namespace UniversalTweaks;

internal class GunTweaks
{
    [HarmonyPatch(typeof(vp_FPSPlayer), nameof(vp_FPSPlayer.Update))]
    private class RevolverMovementUnblocked
    {
        private static void Postfix(vp_FPSPlayer __instance)
        {
            PlayerControlMode controlMode = GameManager.GetPlayerManagerComponent().GetControlMode();
            if (controlMode == PlayerControlMode.AimRevolver && GameManager.IsMoveInputUnblocked())
            {
                __instance.InputWalk();
            }
        }
    }

    [HarmonyPatch(typeof(Panel_HUD), nameof(Panel_HUD.Update))]
    private class RevolverLimitedMobilityUIDisable
    {
        private static void Postfix(Panel_HUD __instance)
        {
            if (GameManager.GetPlayerManagerComponent().GetControlMode() == PlayerControlMode.AimRevolver)
            {
                __instance.m_AimingLimitedMobility.gameObject.SetActive(false);
            }
        }
    }
}