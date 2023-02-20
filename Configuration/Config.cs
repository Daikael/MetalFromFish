using HarmonyLib;
using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;
using System.Collections.Generic;
using UnityEngine;

namespace MetalFromFish.Configuration
{
    [Menu("Metal From Fish")]
    public class Config : ConfigFile
    {
        private static readonly Harmony harmony = new Harmony(myGUID);
        private const string myGUID = "Daikael.MetalFromFish";
        [Slider("Recipe Cost", 1, 8, DefaultValue = 3, Step = 1f, Tooltip = "Controls how many fish are used per craft operation"), OnChange(nameof(ApplyOptions))]
        public int RCost = 3;

        [Slider("Recipe output", 1, 8, DefaultValue = 1, Step = 1f, Tooltip = "Controls the resource output of each craft operation"), OnChange(nameof(ApplyOptions))]
        public int Output = 1;

        [Slider("Byproduct output", 0, 8, DefaultValue = 1, Step = 1f, Tooltip = "Controls the Byproduct volume per craft operation, set to 0 to disable"), OnChange(nameof(ApplyOptions))]
        public int Byproduct = 1;
        public void ApplyOptions()
        {
            harmony.PatchAll();
            new BladderFishCopper().Patch();
            new PeeperTitanium().Patch();
            new BoomerangQuartz().Patch();
            new ReginaldDiamond().Patch();
            new HoopfishLead().Patch();
            new OculusLithium().Patch();
            new EyeyeMagnetite().Patch();
            new SpadefishSilver().Patch();
            new HoverfishGold().Patch();
            new CrashfishCaveSulphur().Patch();
            new RedeyeyeCrystalSulphur().Patch();
            new SpinefishNickle().Patch();
            new HolefishTooth().Patch();
            new MagmarangKyanite().Patch();
            //Applyoptions
        }
    }
}
