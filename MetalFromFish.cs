using System;
using SMLHelper.V2.Handlers;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using System.IO;

namespace MetalFromFish.craftable
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class MetalFromFish_SN : BaseUnityPlugin
    {
        private const string myGUID = "Daikael.MetalFromFish";
        private const string pluginName = "Metal From Fsh";
        private const string versionString = "1.2.1";
        private static readonly Harmony harmony = new Harmony(myGUID);

        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "loaded.");
            logger = Logger;
            new BioBottle().Patch();
            new BladderFishCopper().Patch();
            new PeeperTitanium().Patch();
            new BoomerangQuartz().Patch();
            new ReginaldDiamond().Patch();
            new HoopfishLead().Patch();
            new OculusLithium().Patch();
            new EyeyeMagnetite().Patch();
            new SpadefishSilver().Patch();
            new HoverfishGold().Patch();

            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "MFF", "Fish Processing", SpriteManager.Get(TechType.Reginald), new string[]
            {
                "Resources"
            });
            Console.WriteLine("DT-1 Fabricator Tab loaded");
        }
    }
}
