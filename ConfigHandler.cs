using BepInEx.Configuration;
using RiskOfOptions;
using RiskOfOptions.OptionConfigs;
using RiskOfOptions.Options;

namespace InteractableCreditMultiplier
{
    public class ConfigHandler
    {
        public static ConfigEntry<float> InteractableCreditMultiplier { get; private set; }
        public static ConfigEntry<bool> VerboseLogging { get; private set; }

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

            ModSettingsManager.AddOption(new StepSliderOption(InteractableCreditMultiplier, new StepSliderConfig() { min = 0.5f, max = 100f, increment = 0.25f }));
            ModSettingsManager.AddOption(new CheckBoxOption(VerboseLogging));
        }
    }
}