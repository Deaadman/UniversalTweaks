namespace UniversalTweaks.Utilities;

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

    internal static void SwapGearItemTexture(string gearItemName, string gameObjectName, string newTextureName)
    {
        if (!textures.TryGetValue(newTextureName, out var newTexture)) return;

        var gearItemPrefab = GearItem.LoadGearItemPrefab(gearItemName);
        if (gearItemPrefab == null) return;

        foreach (var renderer in gearItemPrefab.GetComponentsInChildren<Renderer>(true))
        {
            if (renderer.gameObject.name == gameObjectName)
            {
                foreach (var material in renderer.materials)
                {
                    material.mainTexture = newTexture;
                }
            }
        }
    }

    [HarmonyPatch(typeof(Utils), nameof(Utils.GetInventoryIconTexture), new Type[] { typeof(GearItem) })]
    private static class GenericIconTextureSwap
    {
        private static bool Prefix(GearItem gi, ref Texture2D __result)
        {
            if (gi == null)
            {
                return true;
            }

            string textureName = TweaksTextureSwap.GetTextureNameForGearItem(gi);
            if (string.IsNullOrEmpty(textureName))
            {
                return true;
            }

            var textures = LoadTexturesFromAssetBundle();
            if (textures.Count == 0)
            {
                return true;
            }

            if (textures.TryGetValue(textureName, out Texture2D? newTexture))
            {
                __result = newTexture;
                return false;
            }

            return true;
        }
    }
}