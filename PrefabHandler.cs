using System;
using System.Collections.Generic;
using UnityEngine;

public enum PrefabCategory
{
    None,
    TieredChest,
    CategoryChest,
    Drone,
    Shrine,
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
    Printer,
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

        public static void InitPrefabHandler()
        {
            PrefabCategory cloakedChestCategory = ConfigHandler.IgnoreCloakedChests.Value ? PrefabCategory.None : PrefabCategory.TieredChest;
            PrefabCategory redAndBossDuplicatorCategory = ConfigHandler.IgnoreRedAndBossPrinters.Value ? PrefabCategory.None : PrefabCategory.Printer;
            PrefabCategory tier3ChestCategory = ConfigHandler.IgnoreTier3Chests.Value ? PrefabCategory.None : PrefabCategory.TieredChest;

            prefabMap = new Dictionary<string, PrefabEntry>
            {
                // Tiered Chests
                { "Chest1", new PrefabEntry(PrefabType.ChestT1, PrefabCategory.TieredChest) },
                { "Chest2", new PrefabEntry(PrefabType.ChestT2, PrefabCategory.TieredChest) },
                { "GoldChest", new PrefabEntry(PrefabType.ChestT3, tier3ChestCategory) },

                // Category Chests
                { "CategoryChestDamage", new PrefabEntry(PrefabType.ChestCatDamage, PrefabCategory.CategoryChest) },
                { "CategoryChest2Damage Variant", new PrefabEntry(PrefabType.ChestCatDamage, PrefabCategory.CategoryChest) },
                { "CategoryChestHealing", new PrefabEntry(PrefabType.ChestCatHealing, PrefabCategory.CategoryChest) },
                { "CategoryChest2Healing Variant", new PrefabEntry(PrefabType.ChestCatHealing, PrefabCategory.CategoryChest) },
                { "CategoryChestUtility", new PrefabEntry(PrefabType.ChestCatUtility, PrefabCategory.CategoryChest) },
                { "CategoryChest2Utility Variant", new PrefabEntry(PrefabType.ChestCatUtility, PrefabCategory.CategoryChest) },

                // Misc
                { "Chest1StealthedVariant", new PrefabEntry(PrefabType.ChestCloaked, cloakedChestCategory) },
                { "Chest2StealthedVariant", new PrefabEntry(PrefabType.ChestCloaked, cloakedChestCategory) },
                { "CasinoChest", new PrefabEntry(PrefabType.ChestAdaptive, PrefabCategory.None) },
                { "LunarChest", new PrefabEntry(PrefabType.ChestLunar, PrefabCategory.None) },
                { "Barrel1", new PrefabEntry(PrefabType.BarrelMoney, PrefabCategory.None) },
                { "VoidCoinBarrel", new PrefabEntry(PrefabType.BarrelMoneyVoid, PrefabCategory.None) },
                { "EquipmentBarrel", new PrefabEntry(PrefabType.BarrelEquipment, PrefabCategory.None) },
                { "TripleShop", new PrefabEntry(PrefabType.MultiShopSmall, PrefabCategory.None) },
                { "TripleShopLarge", new PrefabEntry(PrefabType.MultiShopLarge, PrefabCategory.None) },
                { "TripleShopEquipment", new PrefabEntry(PrefabType.MultiShopEquipment, PrefabCategory.None) },

                // Void & Lunar
                { "VoidCamp", new PrefabEntry(PrefabType.VoidSeed, PrefabCategory.None) },
                { "VoidChest", new PrefabEntry(PrefabType.VoidCradle, PrefabCategory.None) },
                { "VoidTriple", new PrefabEntry(PrefabType.VoidTriple, PrefabCategory.None) },

                // Printers & Scrappers
                { "Duplicator", new PrefabEntry(PrefabType.Printer, PrefabCategory.Printer) },
                { "DuplicatorLarge", new PrefabEntry(PrefabType.Printer, PrefabCategory.Printer) },
                { "DuplicatorMilitary", new PrefabEntry(PrefabType.Printer, redAndBossDuplicatorCategory) },
                { "DuplicatorWild", new PrefabEntry(PrefabType.Printer, redAndBossDuplicatorCategory) },
                { "Scrapper", new PrefabEntry(PrefabType.Scrapper, PrefabCategory.None) },

                // Shrines
                { "ShrineBlood", new PrefabEntry(PrefabType.ShrineBlood, PrefabCategory.Shrine) },
                { "ShrineBloodSandy Variant", new PrefabEntry(PrefabType.ShrineBlood, PrefabCategory.Shrine) },
                { "ShrineBloodSnowy Variant", new PrefabEntry(PrefabType.ShrineBlood, PrefabCategory.Shrine) },
                { "ShrineCombat", new PrefabEntry(PrefabType.ShrineCombat, PrefabCategory.Shrine) },
                { "ShrineCombatSandy Variant", new PrefabEntry(PrefabType.ShrineCombat, PrefabCategory.Shrine) },
                { "ShrineCombatSnowy Variant", new PrefabEntry(PrefabType.ShrineCombat, PrefabCategory.Shrine) },
                { "ShrineBoss", new PrefabEntry(PrefabType.ShrineMountain, PrefabCategory.Shrine) },
                { "ShrineBossSandy Variant", new PrefabEntry(PrefabType.ShrineMountain, PrefabCategory.Shrine) },
                { "ShrineBossSnowy Variant", new PrefabEntry(PrefabType.ShrineMountain, PrefabCategory.Shrine) },
                { "ShrineHealing", new PrefabEntry(PrefabType.ShrineHealing, PrefabCategory.Shrine) },
                { "ShrineRestack", new PrefabEntry(PrefabType.ShrineOrder, PrefabCategory.Shrine) },
                { "ShrineRestackSandy Variant", new PrefabEntry(PrefabType.ShrineOrder, PrefabCategory.Shrine) },
                { "ShrineRestackSnowy Variant", new PrefabEntry(PrefabType.ShrineOrder, PrefabCategory.Shrine) },
                { "ShrineColossusAccess", new PrefabEntry(PrefabType.ShrineShaping, PrefabCategory.Shrine) },
                { "ShrineChance", new PrefabEntry(PrefabType.ShrineChance, PrefabCategory.Shrine) },
                { "ShrineChanceSandy Variant", new PrefabEntry(PrefabType.ShrineChance, PrefabCategory.Shrine) },
                { "ShrineChanceSnowy Variant", new PrefabEntry(PrefabType.ShrineChance, PrefabCategory.Shrine) },
                { "ShrineCleanse", new PrefabEntry(PrefabType.ShrineCleanse, PrefabCategory.Shrine) },

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
    }
}