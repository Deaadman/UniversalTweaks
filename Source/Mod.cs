using LocalizationUtilities;

using UniversalTweaks.Properties;
using UniversalTweaks.Utilities;

namespace UniversalTweaks;

internal sealed class Mod : MelonMod
{
	public override void OnInitializeMelon()
	{
		LoadLocalizations();
		Settings.OnLoad();
	}

	private static void LoadLocalizations()
	{
		const string jsonFile = "UniversalTweaks.Resources.Localization.json";

		try
		{
#pragma warning disable CS8600, CS8604
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(jsonFile))
			{
				using StreamReader reader = new(stream);
				string results = reader.ReadToEnd();
				LocalizationManager.LoadJsonLocalization(results);
			}
#pragma warning restore CS8600,CS8604 
		}
		catch (Exception ex)
		{
			Logging.LogError(ex.Message);
		}
	}
}