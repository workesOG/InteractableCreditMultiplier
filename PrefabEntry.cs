namespace InteractableCreditMultiplier
{
    public class PrefabEntry
    {
        public PrefabType Prefab { get; }
        public PrefabCategory Category { get; }
        public PrefabEntry(PrefabType prefab, PrefabCategory category)
        {
            Prefab = prefab;
            Category = category;
        }
    }
}