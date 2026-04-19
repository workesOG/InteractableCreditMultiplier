using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace InteractableCreditMultiplier
{
    [BepInPlugin("com.workes.interactablecreditmultiplier", "Interactable Credit Multiplier", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        public static ConfigEntry<float> InteractableCreditMultiplier { get; private set; }

        public void Awake()
        {
            var harmony = new Harmony("com.workes.interactablecreditmultiplier");
            harmony.PatchAll();

            InteractableCreditMultiplier = Config.Bind(
                "General",
                "InteractableCreditMultiplier",
                1.5f,
                "A fixed multiplier for your interactable credits"
            );
            Logger.LogInfo("[InteractableCreditMultiplier] Mod loaded");
        }
    }
}