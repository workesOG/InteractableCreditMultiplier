using BepInEx.Configuration;
using RiskOfOptions;
using RiskOfOptions.OptionConfigs;
using RiskOfOptions.Options;

namespace InteractableCreditMultiplier
{
    public class ConfigHandler
    {
        // General
        public static ConfigEntry<float> InteractableCreditMultiplier { get; private set; }

        // Chest Limits
        public static ConfigEntry<int> MaxTieredChestsTotal { get; private set; }
        public static ConfigEntry<int> MaxTier1Chests { get; private set; }
        public static ConfigEntry<int> MaxTier2Chests { get; private set; }
        public static ConfigEntry<int> MaxTier3Chests { get; private set; }
        public static ConfigEntry<int> MaxPerCategoryChests { get; private set; }
        public static ConfigEntry<int> MaxAdaptiveChests { get; private set; }
        public static ConfigEntry<int> MaxCloakedChests { get; private set; }
        public static ConfigEntry<int> MaxLunarChests { get; private set; }
        public static ConfigEntry<bool> IgnoreTier3Chests { get; private set; }
        public static ConfigEntry<bool> IgnoreCloakedChests { get; private set; }

        // Barrel limits
        public static ConfigEntry<int> MaxMoneyBarrels { get; private set; }
        public static ConfigEntry<int> MaxVoidCoinBarrels { get; private set; }
        public static ConfigEntry<int> MaxEquipmentBarrels { get; private set; }

        // Printer & Scrapper limits
        public static ConfigEntry<int> MaxPrinters { get; private set; }
        public static ConfigEntry<int> MaxScrappers { get; private set; }
        public static ConfigEntry<bool> IgnoreRedAndBossPrinters { get; private set; }

        // Shrine Limits
        public static ConfigEntry<int> MaxMountainShrines { get; private set; }
        public static ConfigEntry<int> MaxBloodShrines { get; private set; }
        public static ConfigEntry<int> MaxCombatShrines { get; private set; }
        public static ConfigEntry<int> MaxWoodlandShrines { get; private set; }
        public static ConfigEntry<int> MaxChanceShrines { get; private set; }
        public static ConfigEntry<int> MaxOrderShrines { get; private set; }
        public static ConfigEntry<int> MaxShapingShrines { get; private set; }
        public static ConfigEntry<int> MaxCleansingPools { get; private set; }

        // Void Limits
        public static ConfigEntry<int> MaxVoidSeeds { get; private set; }
        public static ConfigEntry<int> MaxVoidCradles { get; private set; }
        public static ConfigEntry<int> MaxVoidTriples { get; private set; }

        // Drone & Turret Limits
        public static ConfigEntry<int> MaxDronesTotal { get; private set; }
        public static ConfigEntry<int> MaxDronesPerType { get; private set; }

        // Shops Limits
        public static ConfigEntry<int> MaxMultishops { get; private set; }

        // Limit Pity System
        public static ConfigEntry<bool> EnableSoftCaps { get; private set; }
        public static ConfigEntry<float> SoftCapBypassChance { get; private set; }
        public static ConfigEntry<bool> SoftCapScaling { get; private set; }

        // Debug
        public static ConfigEntry<bool> VerboseLogging { get; private set; }
        public static ConfigEntry<bool> LogSpawnedPrefabs { get; private set; }
        public static ConfigEntry<bool> LogUncategorizedPrefabs { get; private set; }

        public static void InitConfig(ConfigFile config)
        {
            InteractableCreditMultiplier = config.Bind(
                "General",
                "InteractableCreditMultiplier",
                1.5f,
                "A fixed multiplier for your interactable credits"
            );
            VerboseLogging = config.Bind(
                "Debug",
                "VerboseLogging",
                false,
                "Enable verbose logging for debugging purposes"
            );

            MaxTieredChestsTotal = config.Bind(
                "ChestLimits",
                "MaxTieredChestsTotal",
                25,
                "Maximum total number of tiered chests allowed"
            );
            MaxTier1Chests = config.Bind(
                "ChestLimits",
                "MaxTier1Chests",
                15,
                "Maximum number of Tier 1 chests allowed"
            );
            MaxTier2Chests = config.Bind(
                "ChestLimits",
                "MaxTier2Chests",
                8,
                "Maximum number of Tier 2 chests allowed"
            );
            MaxTier3Chests = config.Bind(
                "ChestLimits",
                "MaxTier3Chests",
                3,
                "Maximum number of Tier 3 chests allowed"
            );
            MaxPerCategoryChests = config.Bind(
                "ChestLimits",
                "MaxPerCategoryChests",
                5,
                "Maximum number of categorized chests allowed per-type"
            );
            MaxAdaptiveChests = config.Bind(
                "ChestLimits",
                "MaxAdaptiveChests",
                5,
                "Maximum number of adaptive chests allowed"
            );
            MaxCloakedChests = config.Bind(
                "ChestLimits",
                "MaxCloakedChests",
                5,
                "Maximum number of cloaked chests allowed"
            );
            MaxLunarChests = config.Bind(
                "ChestLimits",
                "MaxLunarChests",
                2,
                "Maximum number of lunar chests allowed"
            );
            IgnoreTier3Chests = config.Bind(
                "ChestLimits",
                "IgnoreTier3Chests",
                true,
                "If enabled, the limiter system will never touch legendary chests"
            );
            IgnoreCloakedChests = config.Bind(
                "ChestLimits",
                "IgnoreCloakedChests",
                true,
                "If enabled, the limiter system will never touch cloaked chests"
            );

            MaxMoneyBarrels = config.Bind(
                "BarrelLimits",
                "MaxMoneyBarrels",
                10,
                "Maximum number of barrels allowed"
            );
            MaxVoidCoinBarrels = config.Bind(
                "BarrelLimits",
                "MaxVoidCoinBarrels",
                10,
                "Maximum number of void coin \"barrels\" (The ones that look like stalks) allowed"
            );
            MaxEquipmentBarrels = config.Bind(
                "BarrelLimits",
                "MaxEquipmentBarrels",
                3,
                "Maximum number of equipment barrels"
            );

            MaxPrinters = config.Bind(
                "PrinterAndScrapperLimits",
                "MaxPrinters",
                5,
                "Maximum number of printers allowed"
            );
            MaxScrappers = config.Bind(
                "PrinterAndScrapperLimits",
                "MaxScrappers",
                3,
                "Maximum number of scrappers allowed"
            );
            IgnoreRedAndBossPrinters = config.Bind(
                "PrinterAndScrapperLimits",
                "IgnoreRedAndBossPrinters",
                true,
                "If enabled, the limiter system will never touch red or boss item printers"
            );

            MaxMountainShrines = config.Bind(
                "ShrineLimits",
                "MaxMountainShrines",
                3,
                "Maximum number of mountain shrines allowed"
            );
            MaxBloodShrines = config.Bind(
                "ShrineLimits",
                "MaxBloodShrines",
                3,
                "Maximum number of blood shrines allowed"
            );
            MaxCombatShrines = config.Bind(
                "ShrineLimits",
                "MaxCombatShrines",
                3,
                "Maximum number of combat shrines allowed"
            );
            MaxWoodlandShrines = config.Bind(
                "ShrineLimits",
                "MaxWoodlandShrines",
                3,
                "Maximum number of woodland shrines allowed"
            );
            MaxChanceShrines = config.Bind(
                "ShrineLimits",
                "MaxChanceShrines",
                3,
                "Maximum number of chance shrines allowed"
            );
            MaxOrderShrines = config.Bind(
                "ShrineLimits",
                "MaxOrderShrines",
                3,
                "Maximum number of order shrines allowed"
            );
            MaxShapingShrines = config.Bind(
                "ShrineLimits",
                "MaxShapingShrines",
                3,
                "Maximum number of shaping shrines allowed"
            );
            MaxCleansingPools = config.Bind(
                "ShrineLimits",
                "MaxCleansingPools",
                3,
                "Maximum number of cleansing pools allowed"
            );

            MaxVoidSeeds = config.Bind(
                "VoidLimits",
                "MaxVoidSeeds",
                2,
                "Maximum number of void seeds allowed"
            );
            MaxVoidCradles = config.Bind(
                "VoidLimits",
                "MaxVoidCradles",
                5,
                "Maximum number of void cradles allowed"
            );
            MaxVoidTriples = config.Bind(
                "VoidLimits",
                "MaxVoidTriples",
                5,
                "Maximum number of void triple cradles allowed"
            );

            MaxDronesTotal = config.Bind(
                "DroneLimits",
                "MaxDronesTotal",
                10,
                "Maximum total number of drones allowed"
            );
            MaxDronesPerType = config.Bind(
                "DroneLimits",
                "MaxDronesPerType",
                4,
                "Maximum number of drones of a single type allowed"
            );

            MaxMultishops = config.Bind(
                "ShopsLimits",
                "MaxMultishops",
                5,
                "Maximum number of multishops allowed"
            );

            EnableSoftCaps = config.Bind(
                "PitySystem",
                "EnableSoftCaps",
                true,
                "Enable soft caps in the pity system"
            );
            SoftCapBypassChance = config.Bind(
                "PitySystem",
                "SoftCapBypassChance",
                0.2f,
                "Chance to bypass the soft cap"
            );
            SoftCapScaling = config.Bind(
                "PitySystem",
                "SoftCapScaling",
                true,
                "Scale the soft cap effect for every failed attempt, resets on success"
            );

            LogSpawnedPrefabs = config.Bind(
                "Debug",
                "LogSpawnedPrefabs",
                false,
                "Log details about spawned prefabs"
            );
            LogUncategorizedPrefabs = config.Bind(
                "Debug",
                "LogUncategorizedPrefabs",
                false,
                "Log details about uncategorized prefabs"
            );

            ModSettingsManager.AddOption(new StepSliderOption(InteractableCreditMultiplier, new StepSliderConfig { min = 0.5f, max = 100f, increment = 0.25f }));

            // General & Debug
            ModSettingsManager.AddOption(new CheckBoxOption(VerboseLogging));
            ModSettingsManager.AddOption(new CheckBoxOption(LogSpawnedPrefabs));
            ModSettingsManager.AddOption(new CheckBoxOption(LogUncategorizedPrefabs));

            // Chest Limits
            ModSettingsManager.AddOption(new IntSliderOption(MaxTieredChestsTotal, new IntSliderConfig { min = -1, max = 100 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxTier1Chests, new IntSliderConfig { min = -1, max = 50 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxTier2Chests, new IntSliderConfig { min = -1, max = 50 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxTier3Chests, new IntSliderConfig { min = -1, max = 20 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxPerCategoryChests, new IntSliderConfig { min = -1, max = 50 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxAdaptiveChests, new IntSliderConfig { min = -1, max = 50 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxCloakedChests, new IntSliderConfig { min = -1, max = 50 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxLunarChests, new IntSliderConfig { min = -1, max = 25 }));
            ModSettingsManager.AddOption(new CheckBoxOption(IgnoreTier3Chests));
            ModSettingsManager.AddOption(new CheckBoxOption(IgnoreCloakedChests));

            // Barrel limits
            ModSettingsManager.AddOption(new IntSliderOption(MaxMoneyBarrels, new IntSliderConfig { min = -1, max = 100 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxVoidCoinBarrels, new IntSliderConfig { min = -1, max = 50 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxEquipmentBarrels, new IntSliderConfig { min = -1, max = 20 }));

            // Printer & Scrapper limits
            ModSettingsManager.AddOption(new IntSliderOption(MaxPrinters, new IntSliderConfig { min = -1, max = 50 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxScrappers, new IntSliderConfig { min = -1, max = 50 }));
            ModSettingsManager.AddOption(new CheckBoxOption(IgnoreRedAndBossPrinters));

            // Shrine Limits
            ModSettingsManager.AddOption(new IntSliderOption(MaxMountainShrines, new IntSliderConfig { min = -1, max = 25 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxBloodShrines, new IntSliderConfig { min = -1, max = 25 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxCombatShrines, new IntSliderConfig { min = -1, max = 25 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxWoodlandShrines, new IntSliderConfig { min = -1, max = 25 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxChanceShrines, new IntSliderConfig { min = -1, max = 25 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxOrderShrines, new IntSliderConfig { min = -1, max = 25 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxShapingShrines, new IntSliderConfig { min = -1, max = 25 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxCleansingPools, new IntSliderConfig { min = -1, max = 25 }));

            // Void Limits
            ModSettingsManager.AddOption(new IntSliderOption(MaxVoidSeeds, new IntSliderConfig { min = -1, max = 5 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxVoidCradles, new IntSliderConfig { min = -1, max = 25 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxVoidTriples, new IntSliderConfig { min = -1, max = 25 }));

            // Drone & Shop Limits
            ModSettingsManager.AddOption(new IntSliderOption(MaxDronesTotal, new IntSliderConfig { min = -1, max = 100 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxDronesPerType, new IntSliderConfig { min = -1, max = 20 }));
            ModSettingsManager.AddOption(new IntSliderOption(MaxMultishops, new IntSliderConfig { min = -1, max = 20 }));

            // Limit Pity System
            ModSettingsManager.AddOption(new CheckBoxOption(EnableSoftCaps));
            ModSettingsManager.AddOption(new SliderOption(SoftCapBypassChance));
            ModSettingsManager.AddOption(new CheckBoxOption(SoftCapScaling));
        }
    }
}