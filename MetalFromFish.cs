using System;
using System.Collections.Generic;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using UnityEngine;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections;
using SMLHelper.V2.Assets;

namespace MetalFromFish.craftable
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class MetalFromFish_SN : BaseUnityPlugin
    {
        private const string myGUID = "Daikael.MetalFromFish";
        private const string pluginName = "Metal From Fsh";
        private const string versionString = "1.0.1";
        private static readonly Harmony harmony = new Harmony(myGUID);

        public static ManualLogSource logger;

        private void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "loaded.");
            logger = Logger;
            TechData BladderfishCopperData = new TechData();
            TechData PeeperTitaniumData = new TechData();
            TechData BoomerangQuartzData = new TechData();
            TechData HoverfishGoldData = new TechData();
            TechData SpadefishSilverData = new TechData();
            TechData ReginaldDiamondData = new TechData();
            TechData EyeyeMagnetiteData = new TechData();
            TechData OculusLithiumData = new TechData();
            TechData HoopfishLeadData = new TechData();
            TechType BladderfishCopperType = TechTypeHandler.AddTechType("DTCopper", "Copper Extraction", "Copper extracted from a Bladderfish. Added by Metal From Fish.", SpriteManager.Get(TechType.Bladderfish));
            TechType PeeperTitaniumType = TechTypeHandler.AddTechType("DTTitanium", "Titanium Extraction", "Titanium extracted from a Peeper. Added by Metal From Fish.", SpriteManager.Get(TechType.Peeper));
            TechType BoomerangQuartzType = TechTypeHandler.AddTechType("DTQuartz", "Quartz Extraction", "Quartz extracted from a Boomerang. Added by Metal From Fish.", SpriteManager.Get(TechType.Boomerang));
            TechType HoverfishGoldType = TechTypeHandler.AddTechType("DTGold", "Gold Extraction", "Gold extracted from a Hoverfish. Added by Metal From Fish.", SpriteManager.Get(TechType.Hoverfish));
            TechType SpadefishSilverType = TechTypeHandler.AddTechType("DTSilver", "Silver Extraction", "Silver extracted from a Spadefish. Added by Metal From Fish.", SpriteManager.Get(TechType.Spadefish));
            TechType ReginaldDiamondType = TechTypeHandler.AddTechType("DTDiamond", "Diamond Extraction", "Diamonds extracted from a Reginald. Added by Metal From Fish.", SpriteManager.Get(TechType.Reginald));
            TechType EyeyeMagnetiteType = TechTypeHandler.AddTechType("DTMagnetite", "Magnetite Extraction", "Magnetite extracted from an Eyeye. Added by Metal From Fish.", SpriteManager.Get(TechType.Eyeye));
            TechType OculusLithiumType = TechTypeHandler.AddTechType("DTLithium", "Lithium Extraction", "Lithium extracted from an Oculus. Added by Metal From Fish.", SpriteManager.Get(TechType.Oculus));
            TechType HoopfishLeadType = TechTypeHandler.AddTechType("DTLead", "Lead Extraction", "Lead extracted from a Hoopfish. Added by Metal From Fish.", SpriteManager.Get(TechType.Hoopfish));
            Console.WriteLine("DT-1 Techdata and Techtype defines set");
            Console.WriteLine("DT-1 Loading Fabricator recipes");
            CraftTreeHandler.AddTabNode(CraftTree.Type.Fabricator, "MFF", "Fish Processing", SpriteManager.Get(TechType.Reginald), new string[]
            {
                "Resources"
            });
            BladderfishCopperData = new TechData
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Bladderfish, 3)
                },
                LinkedItems = new List<TechType>()
                {
                    TechType.Copper
                }
            };
            CraftDataHandler.SetTechData(BladderfishCopperType, BladderfishCopperData);
            PeeperTitaniumData = new TechData
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Peeper, 3)
                },
                LinkedItems = new List<TechType>()
                {
                    TechType.Titanium
                }
            };
            CraftDataHandler.SetTechData(PeeperTitaniumType, PeeperTitaniumData);
            BoomerangQuartzData = new TechData
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Boomerang, 3)
                },
                LinkedItems = new List<TechType>()
                {
                    TechType.Quartz
                }
            };
            CraftDataHandler.SetTechData(BoomerangQuartzType, BoomerangQuartzData);
            HoverfishGoldData = new TechData
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Hoverfish, 3)
                },
                LinkedItems = new List<TechType>()
                {
                    TechType.Gold
                }
            };
            CraftDataHandler.SetTechData(HoverfishGoldType, HoverfishGoldData);
            SpadefishSilverData = new TechData
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Spadefish, 3)
                },
                LinkedItems = new List<TechType>()
                {
                    TechType.Silver
                }
            };
            CraftDataHandler.SetTechData(SpadefishSilverType, SpadefishSilverData);
            ReginaldDiamondData = new TechData
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Reginald, 3)
                },
                LinkedItems = new List<TechType>()
                {
                    TechType.Diamond
                }
            };
            CraftDataHandler.SetTechData(ReginaldDiamondType, ReginaldDiamondData);
            EyeyeMagnetiteData = new TechData
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Eyeye, 3)
                },
                LinkedItems = new List<TechType>()
                {
                    TechType.Magnetite
                }
            };
            CraftDataHandler.SetTechData(EyeyeMagnetiteType, EyeyeMagnetiteData);
            OculusLithiumData = new TechData
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Oculus, 3)
                },
                LinkedItems = new List<TechType>()
                {
                    TechType.Lithium
                }
            };
            CraftDataHandler.SetTechData(OculusLithiumType, OculusLithiumData);
            HoopfishLeadData = new TechData
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Hoopfish, 3)
                },
                LinkedItems = new List<TechType>()
                {
                    TechType.Lead
                }
            };
            CraftDataHandler.SetTechData(HoopfishLeadType, HoopfishLeadData);
            Console.WriteLine("DT-1 Recipes set");
            Console.WriteLine("DT-1 Assosciating Recipes with Fabricator tabs");
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, BladderfishCopperType, new string[]
            {
            "Resources",
            "MFF"
            });
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, PeeperTitaniumType, new string[]
            {
            "Resources",
            "MFF"
            });
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, HoopfishLeadType, new string[]
            {
            "Resources",
            "MFF"
            });
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, BoomerangQuartzType, new string[]
            {
            "Resources",
            "MFF"
            });
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, HoverfishGoldType, new string[]
            {
            "Resources",
            "MFF"
            });
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, SpadefishSilverType, new string[]
            {
            "Resources",
            "MFF"
            });
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, ReginaldDiamondType, new string[]
            {
            "Resources",
            "MFF"
            });
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, EyeyeMagnetiteType, new string[]
            {
            "Resources",
            "MFF"
            });
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.Fabricator, OculusLithiumType, new string[]
            {
            "Resources",
            "MFF"
            });
            Console.WriteLine("DT-1 Fabricator loaded");
            Console.WriteLine("DT-1 Loading Models");
        }
    }
}
