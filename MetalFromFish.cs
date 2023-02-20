using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using System;
using Sprite = Atlas.Sprite;
using System.IO;

namespace MetalFromFish.craftable
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class MetalFromFish_SN : BaseUnityPlugin
    {
        private const string myGUID = "Daikael.MetalFromFish";
        private const string pluginName = "Metal From Fsh";
        private const string versionString = "1.3.1";
        private static readonly Harmony harmony = new Harmony(myGUID);


        public static ManualLogSource logger;

        public static Atlas.Sprite GetSprite(string name)
        {
            return ImageUtils.LoadSpriteFromFile(Path.Combine(MetalFromFish_SNHelpers.assetFolderPath, name + ".png"));
        }

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
            new CrashfishCaveSulphur().Patch();
            new RedeyeyeCrystalSulphur().Patch();
            new SpinefishNickle().Patch();
            new HolefishTooth().Patch();
            new MagmarangKyanite().Patch();
            new WasteToFood().Patch();

            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "MFF", "Fish Economy", SpriteManager.Get(TechType.Reginald), new string[]
            {
                "Resources"
            });
            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "MFFP", "Fish Processing", GetSprite("DTBioBottle"), new string[]
{
                "Resources",
                "MFF"
});
            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "MFFR", "Food Recycling", SpriteManager.Get(TechType.NutrientBlock), new string[]
{
                "Resources",
                "MFF"
});
            Console.WriteLine("DT-1 Fabricator Tab loaded");

        }
    }
}
