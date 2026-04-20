using BepInEx;
using BepInEx.Configuration;
using RoR2;

namespace InteractableCreditMultiplier
{
    [BepInPlugin("com.workes.interactablecreditmultiplier", "Interactable Credit Multiplier", "1.2.0")]
    public class Main : BaseUnityPlugin
    {
        public void Awake()
        {
            ConfigHandler.InitConfig(Config);

            SceneDirector.onPrePopulateSceneServer += OnPrePopulationSceneServer;

            DebugUtils.InitDebugHooks();

            Logger.LogInfo("[InteractableCreditMultiplier] Mod loaded");
        }

        private void OnPrePopulationSceneServer(SceneDirector self)
        {
            float mult = ConfigHandler.InteractableCreditMultiplier.Value;

            int original = self.interactableCredit;
            int modified = (int)(original * mult);

            self.interactableCredit = modified;

            Logger.LogInfo($"[InteractableCreditMultiplier] Credits: {original} -> {modified}");
        }
    }
}