namespace UniversalTweaks.Utilities;

internal static class AssetBundleLoader
{
    internal static AssetBundle LoadBundle(string path)
    {
        using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            MemoryStream? memory = new((int)stream.Length);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            stream!.CopyTo(memory);

            Il2CppSystem.IO.MemoryStream memoryStream = new(memory.ToArray()); // workaround to deal with span unstripping not working properly as of 2.51
            AssetBundle bundle = AssetBundle.LoadFromStream(memoryStream);

            return bundle;
        }
        ;
    }
}