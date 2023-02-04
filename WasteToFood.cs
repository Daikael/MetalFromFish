using SMLHelper.V2.Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SMLHelper.V2.Crafting;
using Sprite = Atlas.Sprite;
using SMLHelper.V2.Utility;
using System.IO;

namespace MetalFromFish
{
    internal class WasteToFood : Craftable
    {
        public static TechType thisTechType;
        public static Sprite sprite = SpriteManager.Get(TechType.NutrientBlock);

        public WasteToFood() : base("DTNutrient", "Nutrient Reclemation", "A block of nutrients salvaged from biological waste. Edible, but barely.")
        {
            OnFinishedPatching += () =>
            {
                WasteToFood.thisTechType = base.TechType;
            };
        }

        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
        public override string[] StepsToFabricatorTab => new string[] { "Resources", "MFF", "MFFR" };
        public override float CraftingTime => 2f;

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.CreepvinePiece, 1),
                    new Ingredient(BioBottle.thisTechType, 1)
                },
                LinkedItems = new List<TechType>()
                {
                    TechType.NutrientBlock
                }
            };
        }

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            var task = CraftData.GetPrefabForTechTypeAsync(TechType.NutrientBlock);
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
    }
}
