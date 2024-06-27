// namespace UniversalTweaks;
//
// internal class TweaksFreeLook
// {
//
//     [HarmonyPatch(typeof(TimelinePlayback), nameof(TimelinePlayback.LateUpdate))]
//     private static class EnableAndDisableFreelook
//     {
//         private static void Postfix(TimelinePlayback __instance)
//         {
//             if (KeyboardUtilities.InputManager.GetKey(KeyCode.LeftAlt))
//             {
//                 __instance.EnablePlayerFreeCameraMovement();
//             }
//             else
//             {
//                 __instance.DisablePlayerFreeCameraMovement();
//             }
//         }
//     }
// }