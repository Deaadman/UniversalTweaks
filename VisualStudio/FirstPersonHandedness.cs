using UniversalTweaks.Properties;

namespace UniversalTweaks;
[RegisterTypeInIl2Cpp(false)]
internal class FirstPersonHandedness : MonoBehaviour
{
    public FirstPersonHandedness(IntPtr ptr) : base(ptr) { }

    private GameObject? MirrorThis;

    internal enum FirstPersonHandednessView
    {
        LeftHanded,
        RightHanded
    }

    private void LateUpdate()
    {
        if (MirrorThis)
        {
            switch (Settings.Instance.FirstPersonHandednessView)
            {
                case FirstPersonHandednessView.LeftHanded:
                    MirrorThis.transform.localScale = new Vector3(-1, 1, 1);
                    break;
                case FirstPersonHandednessView.RightHanded:
                    MirrorThis.transform.localScale = new Vector3(1, 1, 1);
                    break;
            }
        }
    }

    [HarmonyPatch(typeof(PlayerCameraAnim), nameof(PlayerCameraAnim.Start))]
    private static class InvertXScale
    {
        private static void Postfix(PlayerCameraAnim __instance)
        {
            if (__instance.gameObject && __instance.gameObject.name == "NEW_FPHand_Rig")
            {
                FirstPersonHandedness helperGameObject = __instance.gameObject.GetComponent<FirstPersonHandedness>();
                if (helperGameObject == null)
                {
                    helperGameObject = __instance.gameObject.AddComponent<FirstPersonHandedness>();
                    helperGameObject.MirrorThis = __instance.gameObject;
                }
            }
        }
    }
}