using UnityEngine;
using System.Collections.Generic;

namespace InteractableCreditMultiplier
{
    public class SceneSpawnTracker
    {
        // Example tracked values (can expand later)
        public Dictionary<PrefabType, int> prefabCounts = new Dictionary<PrefabType, int>();
        public Dictionary<PrefabCategory, int> categoryCounts = new Dictionary<PrefabCategory, int>();

        public void RegisterSpawn(GameObject prefab, PrefabType type, PrefabCategory category)
        {
            // Placeholder minimal logic for pipeline skeleton
            if (!prefabCounts.ContainsKey(type)) prefabCounts[type] = 0;
            prefabCounts[type]++;
            if (!categoryCounts.ContainsKey(category)) categoryCounts[category] = 0;
            categoryCounts[category]++;
        }

        public void Clear()
        {
            prefabCounts.Clear();
            categoryCounts.Clear();
        }

        public void LogTrackerResults()
        {
            Main.Log.LogInfo("=== SceneSpawnTracker: Results After Populate ===");
            foreach (var pair in prefabCounts)
                Main.Log.LogInfo($"PrefabType {pair.Key}: {pair.Value}");
            foreach (var pair in categoryCounts)
                Main.Log.LogInfo($"PrefabCategory {pair.Key}: {pair.Value}");
        }
    }
}
