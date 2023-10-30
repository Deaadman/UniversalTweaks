namespace UniversalTweaks.Miscellaneous;

internal static class TextureSwapper
{
    public class ObjectTextureData
    {
        public int matID = 0;
        public Dictionary<string, Texture2D> textures;
    }

    public static void ApplyTexture(GearItem gi, ObjectTextureData objTextures)
    {
        MeshRenderer[] rends = gi.gameObject.GetComponentsInChildren<MeshRenderer>();
        Logging.Log($"Applying texture to GearItem: {gi.gameObject.name}");

        foreach (KeyValuePair<string, Texture2D> texData in objTextures.textures)
        {
            foreach (MeshRenderer rend in rends)
            {
                foreach (Material mat in rend.materials)
                {
                    if (mat.HasProperty(texData.Key))
                    {
                        mat.SetTexture(texData.Key, texData.Value);
                        Logging.Log($"Texture applied to: {gi.gameObject.name} on material: {mat.name}");
                    }
                    else
                    {
                        Logging.LogWarning($"Material {mat.name} does not have property: {texData.Key}");
                    }
                }
            }
        }
    }
}

[HarmonyPatch(typeof(GearItem), nameof(GearItem.LoadGearItemPrefab))]
public static class GearItem_LoadGearItemPrefab
{
    public static void Postfix(GearItem __result, string name)
    {
        if (__result == null || __result.gameObject == null)
        {
            Logging.LogWarning("GearItem or its GameObject is null!");
            return;
        }

        string objName = name.ToLower();
        Logging.Log($"Loaded GearItem prefab with name: {objName}");

        if (objName == "gear_mre") // Check against the specific prefab name
        {
            var objTextures = new TextureSwapper.ObjectTextureData
            {
                matID = 0,
                textures = new Dictionary<string, Texture2D>
                {
                    { "_MainTex", Main.MRETexture }
                }
            };

            TextureSwapper.ApplyTexture(__result, objTextures);
            Logging.Log($"Applied custom texture for GearItem: {objName}");
        }
        else
        {
            Logging.LogWarning($"Not applying custom texture for GearItem: {objName}");
        }
    }
}