using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksMiscellaneous
{
    [HarmonyPatch(typeof(GearItem), nameof(GearItem.Drop))]
    public class RandomizedItemRotation
    {
        private static void Postfix(GearItem __instance)
        {
            if (__instance != null && Settings.Instance.RandomizedItemRotationDrops)
            {
                Transform itemTransform = __instance.transform;
                float randomRotationY = UnityEngine.Random.Range(0f, 360f);

                if (__instance.name.Contains("GEAR_Rifle"))
                {
                    itemTransform.eulerAngles = new Vector3(itemTransform.eulerAngles.x, randomRotationY, 90);
                }
                else
                {
                    itemTransform.eulerAngles = new Vector3(0, randomRotationY, 0);
                }
            }
        }
    }
}