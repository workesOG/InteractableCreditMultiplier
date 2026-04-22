using RoR2;
using UnityEngine;

namespace InteractableCreditMultiplier
{
    public class GeneralHooks
    {
        public static void InitHooks()
        {
            SceneDirector.onPrePopulateSceneServer += OnPrePopulateSceneServer;

            On.RoR2.DirectorCore.TrySpawnObject += OnTrySpawnObject;
        }

        private static void OnPrePopulateSceneServer(SceneDirector self)
        {
            float mult = ConfigHandler.InteractableCreditMultiplier.Value;

            int original = self.interactableCredit;
            int modified = (int)(original * mult);

            self.interactableCredit = modified;

            Main.Log.LogInfo($"[InteractableCreditMultiplier] Credits: {original} -> {modified}");
        }



        private static GameObject OnTrySpawnObject(On.RoR2.DirectorCore.orig_TrySpawnObject orig, RoR2.DirectorCore self, RoR2.DirectorSpawnRequest request)
        {
            var spawnCard = request.spawnCard as InteractableSpawnCard;
            if (spawnCard != null)
            {
                var prefab = spawnCard.prefab;
                var entry = PrefabHandler.GetPrefabEntry(prefab);

                bool isUnknown = entry.Prefab == PrefabType.Unknown;
                if (isUnknown && ConfigHandler.LogUncategorizedPrefabs.Value)
                {
                    Main.Log.LogInfo($"[Unrecognized Prefab] Name: {prefab?.name ?? "NULL"}, Card: {spawnCard?.name ?? "NULL"}");
                }
                else if (ConfigHandler.LogSpawnedPrefabs.Value)
                {
                    Main.Log.LogInfo($"{entry.Prefab}, {entry.Category}");
                }
            }
            return orig(self, request);
        }
    }
}