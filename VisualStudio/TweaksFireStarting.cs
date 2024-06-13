namespace UniversalTweaks;

// Need to fix this error, can replicate by having no research books in your inventory - then adding something to the fire.
// When there is nothing left in the players inventory this error shows up, showing in the UI 'None' indicating no fuel items are left.
// But before it wasn't displaying that without throwing the error. Something funky is going on with the fuel sources list.

//System.NullReferenceException: Object reference not set to an instance of an object.
//   at UniversalTweaks.TweaksFireStarting.RemoveUnresearchedBooksFromFeedingFires.Postfix(Panel_FeedFire __instance)
//   at DMD<Il2Cpp.Panel_FeedFire::RefreshFuelSources>(Panel_FeedFire this)
//   at(il2cpp -> managed) RefreshFuelSources(IntPtr , Il2CppMethodInfo* )
internal class TweaksFireStarting
{
    [HarmonyPatch(typeof(Panel_FeedFire), nameof(Panel_FeedFire.RefreshFuelSources))]
    private static class RemoveUnresearchedBooksFromFeedingFires
    {
        private static void Postfix(Panel_FeedFire __instance)
        {
            for (int i = 0; i < __instance.m_FuelSourcesList.Count; i++)
            {
                if (__instance.m_FuelSourcesList[i].m_ResearchItem != null && !__instance.m_FuelSourcesList[i].m_ResearchItem.IsResearchComplete())
                {
                    __instance.m_FuelSourcesList.RemoveAt(i);
                }
            }

            __instance.m_FuelScrollList.CleanUp();
            __instance.m_FuelScrollList.CreateList(__instance.m_FuelSourcesList.Count);
        }
    }

    [HarmonyPatch(typeof(Panel_FireStart), nameof(Panel_FireStart.RefreshList))]
    private static class RemoveUnresearchedBooksFromFireStarting
    {
        private static void Postfix(Panel_FireStart __instance)
        {
            for (int i = 0; i < __instance.m_FuelList.Count; i++)
            {
                if (__instance.m_FuelList[i].m_ResearchItem != null && !__instance.m_FuelList[i].m_ResearchItem.IsResearchComplete())
                {
                    __instance.m_FuelList.RemoveAt(i);
                }
            }
        }
    }
}