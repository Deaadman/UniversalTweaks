namespace UniversalTweaks
{
    internal class UITweaks
    {
        [HarmonyPatch(typeof(Panel_FeedFire), nameof(Panel_FeedFire.Initialize))]
        private class FireSpriteFix
        {
            private static void Postfix(Panel_FeedFire __instance)
            {
                if (__instance.m_Sprite_FireFill != null)
                {
                    __instance.m_Sprite_FireFill.gameObject.transform.localPosition = new Vector3(159.1f, -31.6f, 0);
                    __instance.m_Sprite_FireFill.gameObject.transform.localScale = new Vector3(1.7f, 1.7f, 1);
                }
            }
        }
    }
}