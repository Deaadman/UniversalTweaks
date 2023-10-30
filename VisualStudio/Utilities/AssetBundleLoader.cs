namespace UniversalTweaks.Utilities;
internal class AssetBundleLoader
{
    internal static AssetBundle? LoadBundle(string path)
    {
        AssetBundle? temp;
        MemoryStream? memory;
        Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);

        if (stream == null)
        {
            Logging.LogError("Stream is null. Unable to load asset bundle.");
            return null;
        }

        memory = new MemoryStream((int)stream.Length);
        stream.CopyTo(memory);

        temp = AssetBundle.LoadFromMemory(memory.ToArray());

        memory.Dispose();
        stream.Dispose();

        return temp;
    }
}