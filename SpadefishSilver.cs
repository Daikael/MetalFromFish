using SMLHelper.V2.Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SMLHelper.V2.Crafting;
using Sprite = Atlas.Sprite;
using SMLHelper.V2.Utility;
using System.IO;
using System.Reflection;

namespace MetalFromFish
{
    internal class SpadefishSilver : Craftable
    {
        public static TechType thisTechType;
        public static Sprite sprite = GetSprite("DTSilver");

        public SpadefishSilver() : base("DTSilver", "Silver Extraction", "Silver extracted from a Spadefish. Added by Metal From Fish.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
            };
        }

        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
        public override string[] StepsToFabricatorTab => new string[] { "Resources", "MFF", "MFFP" };
        public override float CraftingTime => 2f;

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Spadefish, 3)
                },
                LinkedItems = new List<TechType>()
                {
                    TechType.Silver,
                    BioBottle.thisTechType
                }
            };
        }
        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            var task = CraftData.GetPrefabForTechTypeAsync(TechType.Silver);
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
