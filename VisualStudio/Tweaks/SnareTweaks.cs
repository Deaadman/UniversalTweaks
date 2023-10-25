namespace UniversalTweaks;

internal class SnareTweaks
{
    private static SnareItem? snareItem;

    [HarmonyPatch(typeof(PlayerManager), nameof(PlayerManager.InitLabelsForGear))]
    private static class SnareItemInspectEquipPrompt
    {
        private static void Postfix(PlayerManager __instance)
        {
            if (snareItem = __instance.m_Gear.m_SnareItem)
            {
                if (snareItem != null && snareItem.m_State == SnareState.WithRabbit)
                {
                    InterfaceManager.TryGetPanel<Panel_HUD>(out var hudPanel);
                    hudPanel.m_InspectMode_Equip.gameObject.SetActive(true);
                    hudPanel.m_InspectMode_Equip.text = Localization.Get("GAMEPLAY_SetSnare");
                }
                else
                {
                    InterfaceManager.TryGetPanel<Panel_HUD>(out var hudPanel);
                    hudPanel.m_InspectMode_Equip.gameObject.SetActive(false);
                }
            }
        }
    }

    [HarmonyPatch(typeof(PlayerManager), nameof(PlayerManager.UpdateInspectGear))]
    private static class SnareItemInspectEquipFunctionality
    {
        private static void Postfix(PlayerManager __instance)
        {
            if (snareItem != null && snareItem.m_State == SnareState.WithRabbit)
            {
                if (InputManager.GetEquipPressed(__instance))
                {
                    __instance.ExitInspectGearMode(false);

                    snareItem.SetState(SnareState.Set);
                }
            }
        }
    }
}