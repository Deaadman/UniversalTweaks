using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksRockCache
{
    [HarmonyPatch(typeof(RockCacheManager), nameof(RockCacheManager.CanAttemptToPlaceRockCache))]
    public static class RockCacheManager_CanAttemptToPlaceRockCache_Patch
    {
        private static bool Prefix(ref bool __result)
        {
            if (Settings.Instance.AllowedIndoorsRockCaches)
            {
                __result = true;
                return false;
            }

            return true;
        }

        private static void Postfix(RockCacheManager __instance)
        {
            __instance.m_MaxRockCachesPerRegion = Settings.Instance.MaximumPerRegionRockCaches;
            __instance.m_MinDistanceBetweenRockCaches = Settings.Instance.MinimumDistanceBetweenRockCaches;
        }
    }

    [HarmonyPatch(typeof(Panel_Actions), nameof(Panel_Actions.OnPlaceRockCache))]
    public static class Panel_Actions_OnPlaceRockCache_Patch
    {
        private static bool Prefix()
        {
            if (Settings.Instance.AllowedIndoorsRockCaches)
            {
                if (!GameManager.GetRockCacheManager().CanAttemptToPlaceRockCache())
                {
                    GameAudioManager.PlayGUIError();
                    return false;
                }

                string missingMaterialsString = GameManager.GetRockCacheManager().GetMissingMaterialsString();
                if (missingMaterialsString != null)
                {
                    HUDMessage.AddMessage(missingMaterialsString, false, false);
                    return false;
                }

                GameAudioManager.PlayGUIButtonClick();
                GameObject gameObject = UnityEngine.Object.Instantiate(GameManager.GetRockCacheManager().m_RockCachePrefab.gameObject);
                if (gameObject != null)
                {
                    gameObject.name = GameManager.GetRockCacheManager().m_RockCachePrefab.name;
                    gameObject.SetActive(false);
                    GameManager.GetPlayerManagerComponent().StartPlaceMesh(gameObject, GameManager.GetRockCacheManager().m_BuildRangeMax, PlaceMeshFlags.UseMeshVariant);
                }

                return false;
            }

            return true;
        }
    }
}