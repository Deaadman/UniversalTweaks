using UniversalTweaks.Properties;

namespace UniversalTweaks;

[RegisterTypeInIl2Cpp(false)]
internal class FirstPersonHandedness : MonoBehaviour
{
    public FirstPersonHandedness(IntPtr ptr) : base(ptr) { }

    private GameObject? MirrorThis;

    private void LateUpdate()
    {
        if (MirrorThis != null)
        {
            Vector3 targetScale = Settings.Instance.FirstPersonHandednessView == 0 ? Vector3.one : new Vector3(-1, 1, 1);
            MirrorThis.transform.localScale = targetScale;
        }
    }

    [HarmonyPatch(typeof(PlayerCameraAnim), nameof(PlayerCameraAnim.Start))]
    private static class InvertXScale
    {
        private static void Postfix(PlayerCameraAnim __instance)
        {
            if (__instance.gameObject?.name == "NEW_FPHand_Rig")
            {
                var helperGameObject = __instance.gameObject.GetComponent<FirstPersonHandedness>()
                                       ?? __instance.gameObject.AddComponent<FirstPersonHandedness>();
                helperGameObject.MirrorThis ??= __instance.gameObject;
            }
        }
    }
}