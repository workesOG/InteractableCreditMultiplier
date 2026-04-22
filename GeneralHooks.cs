using RoR2;
using UnityEngine;

namespace InteractableCreditMultiplier
{
    public class GeneralHooks
    {
        // Scene-specific tracker

        public static void InitHooks()
        {
            SceneDirector.onPrePopulateSceneServer += OnPrePopulateSceneServer;
            SceneDirector.onPostPopulateSceneServer += OnPostPopulateSceneServer;
            On.RoR2.DirectorCore.TrySpawnObject += OnTrySpawnObject;
        }

        private static void OnPrePopulateSceneServer(SceneDirector self)
        {
            Main.CurrentSpawnTracker = new SceneSpawnTracker(); // Start tracker for this scene
            float mult = ConfigHandler.InteractableCreditMultiplier.Value;

            int original = self.interactableCredit;
            int modified = (int)(original * mult);

            self.interactableCredit = modified;

            Main.Log.LogInfo($"[InteractableCreditMultiplier] Credits: {original} -> {modified}");
        }

        private static GameObject OnTrySpawnObject(On.RoR2.DirectorCore.orig_TrySpawnObject orig, DirectorCore self, DirectorSpawnRequest request)
        {
            var spawnCard = request.spawnCard as InteractableSpawnCard;

            if (spawnCard != null)
            {
                var prefab = spawnCard.prefab;
                var entry = PrefabHandler.GetPrefabEntry(prefab);

                bool allowed = PrefabHandler.IsSpawnAllowed(entry);

                var obj = orig(self, request); // always call

                if (!allowed)
                {
                    if (obj != null)
                    {
                        Object.Destroy(obj);
                    }

                    if (ConfigHandler.LogPreventedSpawns.Value)
                        Main.Log.LogInfo($"Prevented spawn of {entry.Prefab} ({entry.Category})");

                    return obj; // IMPORTANT: non-null → no retry
                }

                Main.CurrentSpawnTracker?.RegisterSpawn(prefab, entry.Prefab, entry.Category);

                return obj;
            }

            return orig(self, request);
        }

        private static void OnPostPopulateSceneServer(SceneDirector self)
        {
            if (Main.CurrentSpawnTracker != null && ConfigHandler.DebugSpawnTracker.Value)
                Main.CurrentSpawnTracker.LogTrackerResults();
            Main.CurrentSpawnTracker = null;
        }
    }
}