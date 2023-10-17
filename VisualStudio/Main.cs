namespace UniversalTweaks
{
    public class Main : MelonMod
    {
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (!FoodTweaks.debuffDestroyed)
            {
                FoodTweaks.PieItems();
            }
        }
    }
}