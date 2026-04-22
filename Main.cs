using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using RoR2;

namespace InteractableCreditMultiplier
{
    [BepInPlugin("com.workes.interactablecreditmultiplier", "Interactable Credit Multiplier", "1.2.0")]
    public class Main : BaseUnityPlugin
    {
        public static ManualLogSource Log { get; private set; }
        public static SceneSpawnTracker CurrentSpawnTracker { get; set; }

        public void Awake()
        {
            Log = Logger;
            ConfigHandler.InitConfig(Config);
            PrefabHandler.InitPrefabHandler();

            GeneralHooks.InitHooks();
            DebugUtils.InitDebugHooks();

            Log.LogInfo("[InteractableCreditMultiplier] Mod loaded");
        }
    }
}