using HarmonyLib;
using UnityEngine;
using RoR2;

namespace InteractableCreditMultiplier
{
    [HarmonyPatch(
        typeof(SceneDirector),
        "Start"
    )]
    public class CalculationPatch
    {
        public static void Prefix()
        {
            ClassicStageInfo csi = SceneInfo.instance.GetComponent<ClassicStageInfo>();
            int originalCredits = csi.sceneDirectorInteractibleCredits;
            float mult = Main.InteractableCreditMultiplier.Value;
            csi.sceneDirectorInteractibleCredits = (int)(originalCredits * mult);
        }
    }
}
