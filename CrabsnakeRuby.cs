﻿using SMLHelper.V2.Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SMLHelper.V2.Crafting;
using Sprite = Atlas.Sprite;
using SMLHelper.V2.Utility;
using System.IO;

namespace MetalFromFish
{
    internal class CrabsnakeRuby : Craftable
    {
        public static TechType thisTechType;
        public static Sprite sprite = GetSprite("DTRuby");

        public CrabsnakeRuby() : base("DTRuby", "Ruby Extraction", "Ruby extracted from a Crabsnake.")
        {
            OnFinishedPatching += () =>
            {
                CrabsnakeRuby.thisTechType = base.TechType;
            };
        }

        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
        public override string[] StepsToFabricatorTab => new string[] { "Resources", "MFF", "MFFP" };
        public override float CraftingTime => 2f;

        protected override TechData GetBlueprintRecipe()
        {
            // Obtain the output and byproduct values from the configuration
            int outputCount = MetalFromFish_SNHelpers.Config.Output;
            int byproductCount = MetalFromFish_SNHelpers.Config.Byproduct;

            // Create a list to hold the linked items
            List<TechType> linkedItems = new List<TechType>();

            // Add the appropriate number of TechType.AluminumOxide entries to the linkedItems list
            for (int i = 0; i < outputCount; i++)
            {
                linkedItems.Add(TechType.AluminumOxide);
            }

            // Add the appropriate number of BioBottle.thisTechType entries to the linkedItems list
            for (int i = 0; i < byproductCount; i++)
            {
                linkedItems.Add(BioBottle.thisTechType);
            }

            // Create and return the TechData object
            return new TechData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
        {
            new Ingredient(TechType.Crabsnake, MetalFromFish_SNHelpers.Config.RCost)
        },
                LinkedItems = linkedItems
            };
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            var task = CraftData.GetPrefabForTechTypeAsync(TechType.AluminumOxide);
            yield return task;
            var modifiedPrefab = GameObject.Instantiate(task.GetResult());

            var vfxFabricating = modifiedPrefab.GetComponentInChildren<Renderer>().gameObject.AddComponent<VFXFabricating>();
            vfxFabricating.localMinY = -0.42f;
            vfxFabricating.localMaxY = 0.15f;
            vfxFabricating.scaleFactor = 0.5f;
            vfxFabricating.posOffset = new Vector3(0f, 0.1f, 0f);
            vfxFabricating.eulerOffset = new Vector3(0f, 90f, 0f);

            gameObject.Set(modifiedPrefab);
        }

        protected override Sprite GetItemSprite()
        {
            var ChangedSprite = sprite;
            return ChangedSprite;
        }

        public static Atlas.Sprite GetSprite(string name)
        {
            return ImageUtils.LoadSpriteFromFile(Path.Combine(MetalFromFish_SNHelpers.assetFolderPath, name + ".png"));
        }
    }
}
