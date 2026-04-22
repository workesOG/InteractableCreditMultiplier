using System;
using System.Collections.Generic;
using BepInEx.Configuration;
using UnityEngine;

public enum PrefabCategory
{
    None,
    TieredChest,
    CategorizedChest,
    MultiShop,
    Drone,
    Printer,
}

public enum PrefabType
{
    Unknown,
    ChestT1,
    ChestT2,
    ChestT3,
    ChestCatDamage,
    ChestCatHealing,
    ChestCatUtility,
    ChestAdaptive,
    ChestCloaked,
    ChestLunar,
    BarrelMoney,
    BarrelMoneyVoid,
    BarrelEquipment,
    MultiShopSmall,
    MultiShopLarge,
    MultiShopEquipment,
    ShrineBlood,
    ShrineMountain,
    ShrineCombat,
    ShrineHealing,
    ShrineChance,
    ShrineOrder,
    ShrineShaping,
    ShrineCleanse,
    PrinterT1,
    PrinterT2,
    PrinterRedBoss,
    Scrapper,
    DroneGunner,
    DroneHealing,
    DroneTurret,
    DroneMissile,
    DroneIncinerator,
    DroneEmergency,
    DroneEquipment,
    DroneTC280,
    VoidSeed,
    VoidCradle,
    VoidTriple,
}

namespace InteractableCreditMultiplier
{
    public static class PrefabHandler
    {
        private static Dictionary<string, PrefabEntry> prefabMap;
        private static Dictionary<PrefabType, ConfigEntry<int>> individualPrefabLimiters;

        public static void InitPrefabHandler()
        {
            PrefabCategory cloakedChestCategory = ConfigHandler.IgnoreCloakedChests.Value ? PrefabCategory.None : PrefabCategory.TieredChest;
            PrefabCategory redAndBossDuplicatorCategory = ConfigHandler.IgnoreRedAndBossPrinters.Value ? PrefabCategory.None : PrefabCategory.Printer;
            PrefabCategory tier3ChestCategory = ConfigHandler.IgnoreTier3Chests.Value ? PrefabCategory.None : PrefabCategory.TieredChest;
            PrefabCategory equipmentShopCategory = ConfigHandler.IgnoreEquipmentMultishops.Value ? PrefabCategory.None : PrefabCategory.MultiShop;

            prefabMap = new Dictionary<string, PrefabEntry>
            {
                // Tiered Chests
                { "Chest1", new PrefabEntry(PrefabType.ChestT1, PrefabCategory.TieredChest) },
                { "Chest2", new PrefabEntry(PrefabType.ChestT2, PrefabCategory.TieredChest) },
                { "GoldChest", new PrefabEntry(PrefabType.ChestT3, tier3ChestCategory) },

                // Category Chests
                { "CategoryChestDamage", new PrefabEntry(PrefabType.ChestCatDamage, PrefabCategory.CategorizedChest) },
                { "CategoryChest2Damage Variant", new PrefabEntry(PrefabType.ChestCatDamage, PrefabCategory.CategorizedChest) },
                { "CategoryChestHealing", new PrefabEntry(PrefabType.ChestCatHealing, PrefabCategory.CategorizedChest) },
                { "CategoryChest2Healing Variant", new PrefabEntry(PrefabType.ChestCatHealing, PrefabCategory.CategorizedChest) },
                { "CategoryChestUtility", new PrefabEntry(PrefabType.ChestCatUtility, PrefabCategory.CategorizedChest) },
                { "CategoryChest2Utility Variant", new PrefabEntry(PrefabType.ChestCatUtility, PrefabCategory.CategorizedChest) },

                // Misc
                { "Chest1StealthedVariant", new PrefabEntry(PrefabType.ChestCloaked, cloakedChestCategory) },
                { "Chest2StealthedVariant", new PrefabEntry(PrefabType.ChestCloaked, cloakedChestCategory) },
                { "CasinoChest", new PrefabEntry(PrefabType.ChestAdaptive, PrefabCategory.None) },
                { "LunarChest", new PrefabEntry(PrefabType.ChestLunar, PrefabCategory.None) },
                { "Barrel1", new PrefabEntry(PrefabType.BarrelMoney, PrefabCategory.None) },
                { "VoidCoinBarrel", new PrefabEntry(PrefabType.BarrelMoneyVoid, PrefabCategory.None) },
                { "EquipmentBarrel", new PrefabEntry(PrefabType.BarrelEquipment, PrefabCategory.None) },
                { "TripleShop", new PrefabEntry(PrefabType.MultiShopSmall, PrefabCategory.MultiShop) },
                { "TripleShopLarge", new PrefabEntry(PrefabType.MultiShopLarge, PrefabCategory.MultiShop) },
                { "TripleShopEquipment", new PrefabEntry(PrefabType.MultiShopEquipment, equipmentShopCategory) },

                // Void & Lunar
                { "VoidCamp", new PrefabEntry(PrefabType.VoidSeed, PrefabCategory.None) },
                { "VoidChest", new PrefabEntry(PrefabType.VoidCradle, PrefabCategory.None) },
                { "VoidTriple", new PrefabEntry(PrefabType.VoidTriple, PrefabCategory.None) },

                // Printers & Scrappers
                { "Duplicator", new PrefabEntry(PrefabType.PrinterT1, PrefabCategory.Printer) },
                { "DuplicatorLarge", new PrefabEntry(PrefabType.PrinterT2, PrefabCategory.Printer) },
                { "DuplicatorMilitary", new PrefabEntry(PrefabType.PrinterRedBoss, redAndBossDuplicatorCategory) },
                { "DuplicatorWild", new PrefabEntry(PrefabType.PrinterRedBoss, redAndBossDuplicatorCategory) },
                { "Scrapper", new PrefabEntry(PrefabType.Scrapper, PrefabCategory.None) },

                // Shrines
                { "ShrineBlood", new PrefabEntry(PrefabType.ShrineBlood, PrefabCategory.None) },
                { "ShrineBloodSandy Variant", new PrefabEntry(PrefabType.ShrineBlood, PrefabCategory.None) },
                { "ShrineBloodSnowy Variant", new PrefabEntry(PrefabType.ShrineBlood, PrefabCategory.None) },
                { "ShrineCombat", new PrefabEntry(PrefabType.ShrineCombat, PrefabCategory.None) },
                { "ShrineCombatSandy Variant", new PrefabEntry(PrefabType.ShrineCombat, PrefabCategory.None) },
                { "ShrineCombatSnowy Variant", new PrefabEntry(PrefabType.ShrineCombat, PrefabCategory.None) },
                { "ShrineBoss", new PrefabEntry(PrefabType.ShrineMountain, PrefabCategory.None) },
                { "ShrineBossSandy Variant", new PrefabEntry(PrefabType.ShrineMountain, PrefabCategory.None) },
                { "ShrineBossSnowy Variant", new PrefabEntry(PrefabType.ShrineMountain, PrefabCategory.None) },
                { "ShrineHealing", new PrefabEntry(PrefabType.ShrineHealing, PrefabCategory.None) },
                { "ShrineRestack", new PrefabEntry(PrefabType.ShrineOrder, PrefabCategory.None) },
                { "ShrineRestackSandy Variant", new PrefabEntry(PrefabType.ShrineOrder, PrefabCategory.None) },
                { "ShrineRestackSnowy Variant", new PrefabEntry(PrefabType.ShrineOrder, PrefabCategory.None) },
                { "ShrineColossusAccess", new PrefabEntry(PrefabType.ShrineShaping, PrefabCategory.None) },
                { "ShrineChance", new PrefabEntry(PrefabType.ShrineChance, PrefabCategory.None) },
                { "ShrineChanceSandy Variant", new PrefabEntry(PrefabType.ShrineChance, PrefabCategory.None) },
                { "ShrineChanceSnowy Variant", new PrefabEntry(PrefabType.ShrineChance, PrefabCategory.None) },
                { "ShrineCleanse", new PrefabEntry(PrefabType.ShrineCleanse, PrefabCategory.None) },

                // Drones
                { "Drone1Broken", new PrefabEntry(PrefabType.DroneGunner, PrefabCategory.Drone) },
                { "Drone2Broken", new PrefabEntry(PrefabType.DroneHealing, PrefabCategory.Drone) },
                { "Turret1Broken", new PrefabEntry(PrefabType.DroneTurret, PrefabCategory.Drone) },
                { "MissileDroneBroken", new PrefabEntry(PrefabType.DroneMissile, PrefabCategory.Drone) },
                { "FlameDroneBroken", new PrefabEntry(PrefabType.DroneIncinerator, PrefabCategory.Drone) },
                { "EquipmentDroneBroken", new PrefabEntry(PrefabType.DroneEquipment, PrefabCategory.Drone) },
                { "EmergencyDroneBroken", new PrefabEntry(PrefabType.DroneEmergency, PrefabCategory.Drone) },
                { "MegaDroneBroken", new PrefabEntry(PrefabType.DroneTC280, PrefabCategory.Drone) },
            };

            individualPrefabLimiters = new Dictionary<PrefabType, ConfigEntry<int>>
            {
                // Tiered Chests
                { PrefabType.ChestT1, ConfigHandler.MaxTier1Chests },
                { PrefabType.ChestT2, ConfigHandler.MaxTier2Chests },
                { PrefabType.ChestT3, ConfigHandler.MaxTier3Chests },
                { PrefabType.ChestAdaptive, ConfigHandler.MaxAdaptiveChests },
                { PrefabType.ChestCloaked, ConfigHandler.MaxCloakedChests },
                { PrefabType.ChestLunar, ConfigHandler.MaxLunarChests },

                // Barrels
                { PrefabType.BarrelMoney, ConfigHandler.MaxMoneyBarrels },
                { PrefabType.BarrelMoneyVoid, ConfigHandler.MaxVoidCoinBarrels },
                { PrefabType.BarrelEquipment, ConfigHandler.MaxEquipmentBarrels },

                // Scrapper
                { PrefabType.Scrapper, ConfigHandler.MaxScrappers },

                // Shrine
                { PrefabType.ShrineBlood, ConfigHandler.MaxBloodShrines },
                { PrefabType.ShrineCombat, ConfigHandler.MaxCombatShrines },
                { PrefabType.ShrineHealing, ConfigHandler.MaxWoodlandShrines },
                { PrefabType.ShrineMountain, ConfigHandler.MaxMountainShrines },
                { PrefabType.ShrineChance, ConfigHandler.MaxChanceShrines },
                { PrefabType.ShrineOrder, ConfigHandler.MaxOrderShrines },
                { PrefabType.ShrineShaping, ConfigHandler.MaxShapingShrines },
                { PrefabType.ShrineCleanse, ConfigHandler.MaxCleansingPools },

                // Void
                { PrefabType.VoidSeed, ConfigHandler.MaxVoidSeeds },
                { PrefabType.VoidCradle, ConfigHandler.MaxVoidCradles },
                { PrefabType.VoidTriple, ConfigHandler.MaxVoidTriples },

                // Shops
                { PrefabType.MultiShopSmall, ConfigHandler.MaxTier1Multishops },
                { PrefabType.MultiShopLarge, ConfigHandler.MaxTier2Multishops },
                { PrefabType.MultiShopEquipment, ConfigHandler.MaxEquipmentMultishops },
            };
        }

        public static PrefabEntry GetPrefabEntry(GameObject go)
        {
            if (go == null)
                return new PrefabEntry(PrefabType.Unknown, PrefabCategory.None);

            string prefabName = go.name;
            // Remove (Clone) from the end if present for matching
            if (prefabName.EndsWith("(Clone)", StringComparison.Ordinal))
            {
                prefabName = prefabName.Substring(0, prefabName.Length - "(Clone)".Length);
            }

            if (prefabMap.TryGetValue(prefabName, out var entry))
            {
                return entry;
            }
            return new PrefabEntry(PrefabType.Unknown, PrefabCategory.None);
        }

        public static bool IsSpawnAllowed(PrefabEntry entry)
        {
            // 1. Category config option limit checks
            switch (entry.Category)
            {
                case PrefabCategory.TieredChest:
                    if (ConfigHandler.MaxTieredChestsTotal.Value >= 0 &&
                        GetCategoryCount(PrefabCategory.TieredChest) >= ConfigHandler.MaxTieredChestsTotal.Value)
                        return false;
                    break;

                case PrefabCategory.Printer:
                    if (ConfigHandler.MaxPrinters.Value >= 0 &&
                        GetCategoryCount(PrefabCategory.Printer) >= ConfigHandler.MaxPrinters.Value)
                        return false;
                    break;

                case PrefabCategory.Drone:
                    if (ConfigHandler.MaxDronesTotal.Value >= 0 &&
                        GetCategoryCount(PrefabCategory.Drone) >= ConfigHandler.MaxDronesTotal.Value)
                        return false;
                    break;
            }

            // 2. Multi-prefab config option limit checks
            if (entry.Category == PrefabCategory.Drone &&
                ConfigHandler.MaxDronesPerType.Value >= 0 &&
                GetPrefabCount(entry.Prefab) >= ConfigHandler.MaxDronesPerType.Value)
                return false;

            if (entry.Category == PrefabCategory.CategorizedChest &&
                ConfigHandler.MaxPerCategoryChests.Value >= 0 &&
                GetPrefabCount(entry.Prefab) >= ConfigHandler.MaxPerCategoryChests.Value)
                return false;

            // 3. Individual (prefab <-> limiting config option) check
            if (individualPrefabLimiters.ContainsKey(entry.Prefab) &&
                individualPrefabLimiters[entry.Prefab].Value >= 0 &&
                GetPrefabCount(entry.Prefab) >= individualPrefabLimiters[entry.Prefab].Value)
                return false;

            // ALLOWED by all checks above:
            return true;
        }

        public static int GetPrefabCount(PrefabType prefab)
        {
            if (Main.CurrentSpawnTracker == null)
                return -1;

            if (Main.CurrentSpawnTracker.prefabCounts.TryGetValue(prefab, out int count))
                return count;
            return 0;
        }

        public static int GetCategoryCount(PrefabCategory category)
        {
            if (Main.CurrentSpawnTracker == null)
                return -1;

            if (Main.CurrentSpawnTracker.categoryCounts.TryGetValue(category, out int count))
                return count;
            return 0;
        }
    }
}