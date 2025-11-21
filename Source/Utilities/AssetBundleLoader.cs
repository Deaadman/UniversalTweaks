namespace UniversalTweaks.Utilities;

internal static class AssetBundleLoader
{
    internal static AssetBundle? LoadBundle(string path)
    {
        var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);

        if (stream == null)
        {
            Logging.LogError("Stream is null. Unable to load asset bundle.");
            return null;
        }

        var memory = new MemoryStream((int)stream.Length);
        stream.CopyTo(memory);

        var temp = AssetBundle.LoadFromMemory(memory.ToArray());

        memory.Dispose();
        stream.Dispose();

        return temp;
    }
}