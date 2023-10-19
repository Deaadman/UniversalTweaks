namespace UniversalTweaks
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoadLocalizations();
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (!FoodTweaks.debuffDestroyed)
            {
                FoodTweaks.PieItems();
            }
        }

        private static void LoadLocalizations()
        {
            const string JSONfile = "UniversalTweaks.Data.Localization.json";

            try
            {
                using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(JSONfile) ?? throw new InvalidOperationException($"Failed to load resource: {JSONfile}");
                using StreamReader reader = new(stream);

                string results = reader.ReadToEnd();

                LocalizationManager.LoadJsonLocalization(results);
            }
            catch (Exception ex)
            {
                Logging.LogError(ex.Message);
            }
        }
    }
}