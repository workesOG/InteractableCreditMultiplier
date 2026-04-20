using BepInEx;
using BepInEx.Configuration;
using RoR2;

namespace InteractableCreditMultiplier
{
    [BepInPlugin("com.workes.interactablecreditmultiplier", "Interactable Credit Multiplier", "1.1.0")]
    public class Main : BaseUnityPlugin
    {
        public static ConfigEntry<float> InteractableCreditMultiplier { get; private set; }

        public void Awake()
        {
            InteractableCreditMultiplier = Config.Bind(
                "General",
                "InteractableCreditMultiplier",
                1.5f,
                "A fixed multiplier for your interactable credits"
            );

            SceneDirector.onPrePopulateSceneServer += OnPrePopulationSceneServer;

            Logger.LogInfo("[InteractableCreditMultiplier] Mod loaded");
        }

        private void OnPrePopulationSceneServer(SceneDirector self)
        {
            float mult = InteractableCreditMultiplier.Value;

            int original = self.interactableCredit;
            int modified = (int)(original * mult);

            self.interactableCredit = modified;

            Logger.LogInfo($"[InteractableCreditMultiplier] Credits: {original} -> {modified}");
        }
    }
}