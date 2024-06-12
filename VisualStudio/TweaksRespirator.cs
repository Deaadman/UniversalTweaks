using Il2CppTLD.Gear;
using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksRespirator
{
    [HarmonyPatch(typeof(Respirator), nameof(Respirator.AttachCanister))]
    private static class ModifyCanisterDuration
    {
        private static void Postfix(Respirator __instance, RespiratorCanister canister)
        {
            canister.m_ProtectionDurationRTSeconds = Settings.Instance.RespiratorCanisterDuration;
        }
    }
}