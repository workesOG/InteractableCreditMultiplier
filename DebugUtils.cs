using RoR2;
using UnityEngine;

namespace InteractableCreditMultiplier
{
    public class DebugUtils
    {
        public static void InitDebugHooks()
        {
            On.RoR2.SceneDirector.PopulateScene += (orig, self) =>
            {
                if (ConfigHandler.VerboseLogging.Value) Debug.Log($"[InteractableCreditMultiplier] [DEBUG] Final credits: {self.interactableCredit}");
                orig(self);
            };

            SceneDirector.onPrePopulateSceneServer += (self) =>
            {
                if (ConfigHandler.VerboseLogging.Value) Debug.Log($"[InteractableCreditMultiplier] [DEBUG] PrePopulate: {self.interactableCredit}");
            };

            SceneDirector.onPostPopulateSceneServer += (self) =>
            {
                if (ConfigHandler.VerboseLogging.Value) Debug.Log($"[InteractableCreditMultiplier] [DEBUG] PostPopulate: {self.interactableCredit}");
            };

            On.RoR2.SceneDirector.PlaceTeleporter += (orig, self) =>
            {
                if (ConfigHandler.VerboseLogging.Value) Debug.Log($"[ICM DEBUG] Before Teleporter: {self.interactableCredit}");
                orig(self);
                if (ConfigHandler.VerboseLogging.Value) Debug.Log($"[ICM DEBUG] After Teleporter: {self.interactableCredit}");
            };
        }
    }
}