using UniversalTweaks.Properties;
using UniversalTweaks.Utilities;

namespace UniversalTweaks;

internal static class TextureSwapper
{
    private static readonly AssetBundle? universalTweaksAssetBundle = AssetBundleLoader.LoadBundle("UniversalTweaks.Resources.UniversalTweaksAssetBundle");
    private static readonly Dictionary<string, Texture2D> textures = LoadTexturesFromAssetBundle();

    private static Dictionary<string, Texture2D> LoadTexturesFromAssetBundle()
    {
        var loadedTextures = new Dictionary<string, Texture2D>();
        if (universalTweaksAssetBundle == null) return loadedTextures;

        foreach (var texture in universalTweaksAssetBundle.LoadAllAssets<Texture2D>())
        {
            loadedTextures[texture.name] = texture;
        }

        return loadedTextures;
    }

    internal static void SwapMREMainTexture(string originalTextureName, string newTextureName)
    {
        if (!textures.TryGetValue(newTextureName, out var newTexture)) return;

        var gearItem = GearItem.LoadGearItemPrefab("GEAR_MRE");
        if (gearItem == null) return;

        foreach (var renderer in gearItem.GetComponentsInChildren<Renderer>(true))
        {
            if (renderer.gameObject.name == "Obj_FoodMRE_LOD0" || renderer.gameObject.name == "Obj_FoodMRE_LOD1")
            {
                foreach (var material in renderer.materials)
                {
                    if (material.mainTexture.name == originalTextureName)
                    {
                        material.mainTexture = newTexture;
                        break;
                    }
                }
            }
        }
    }

    [HarmonyPatch(typeof(Utils), nameof(Utils.GetInventoryIconTexture), new Type[] { typeof(GearItem) })]
    private static class SwapMREIconTexture
    {
        private static bool Prefix(GearItem gi, ref Texture2D __result)
        {
            if (gi == null)
            {
                return true;
            }
            if (Settings.Instance.MRETextureVariant && gi.name == "GEAR_MRE")
            {
                var textures = LoadTexturesFromAssetBundle();
                if (textures.Count == 0)
                {
                    return true;
                }

                if (textures.TryGetValue("ico_GearItem__BrownMRE", out Texture2D? newTexture))
                {
                    __result = newTexture;
                    return false;
                }
            }

            return true;
        }
    }
}