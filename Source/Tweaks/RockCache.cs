using UniversalTweaks.Properties;

namespace UniversalTweaks.Tweaks;

internal static class RockCache
{
    [HarmonyPatch(typeof(RockCacheManager), nameof(RockCacheManager.CanAttemptToPlaceRockCache))]
    public static class RockCacheRadialMenuIndoors
    {
        private static bool Prefix(ref bool __result)
        {
            if (!Settings.Instance.AllowedIndoorsRockCaches)
            {
                return true;
            }

            __result = true;
            return false;
        }

        private static void Postfix(RockCacheManager __instance)
        {
            __instance.m_MaxRockCachesPerRegion = Settings.Instance.MaximumPerRegionRockCaches;
            __instance.m_MinDistanceBetweenRockCaches = Settings.Instance.MinimumDistanceBetweenRockCaches;
        }
    }

    [HarmonyPatch(typeof(Panel_Actions), nameof(Panel_Actions.OnPlaceRockCache))]
    public static class RockCachePlacementIndoors
    {
        private static bool Prefix()
        {
            if (!Settings.Instance.AllowedIndoorsRockCaches)
            {
                return true;
            }

            if (!GameManager.GetRockCacheManager().CanAttemptToPlaceRockCache())
            {
                GameAudioManager.PlayGUIError();
                return false;
            }

            var missingMaterialsString = GameManager.GetRockCacheManager().GetMissingMaterialsString();
            if (missingMaterialsString != null)
            {
                HUDMessage.AddMessage(missingMaterialsString, false, false);
                return false;
            }

            GameAudioManager.PlayGUIButtonClick();
            var gameObject =
                UnityEngine.Object.Instantiate(GameManager.GetRockCacheManager().m_RockCachePrefab.gameObject);
            if (gameObject == null)
            {
                return false;
            }

            gameObject.name = GameManager.GetRockCacheManager().m_RockCachePrefab.name;
            gameObject.SetActive(false);
            GameManager.GetPlayerManagerComponent().StartPlaceMesh(gameObject,
                GameManager.GetRockCacheManager().m_BuildRangeMax, PlaceMeshFlags.UseMeshVariant);

            return false;
        }
    }
}