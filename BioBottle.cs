using SMLHelper.V2.Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SMLHelper.V2.Crafting;
using Sprite = Atlas.Sprite;
using SMLHelper.V2.Utility;
using System.IO;
using SMLHelper.V2.Handlers;

namespace MetalFromFish
{
    internal class BioBottle : Craftable
    {
        public static TechType thisTechType;
        public static Sprite sprite = GetSprite("DTBioBottle");
        private static GameObject processedPrefab;

        public BioBottle() : base("DTBioBottle", "Processed Biological Byproduct", "Waste biological material produced durring resource extraction. Can be further utilized.")
        {
            OnFinishedPatching += () =>
            {
                thisTechType = TechType;
            };
        }
        public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
        public override string[] StepsToFabricatorTab => new string[] { "Resources", "MFF" };
        public override float CraftingTime => 2f;
        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Oculus, 3)
                }
            };
        }
        public override GameObject GetGameObject()
        {
            if (processedPrefab is null)
            {
                var bottleprefab = MetalFromFish_SNHelpers.assetbundle.LoadAsset<GameObject>("BioBottle");
                var gameObject = Object.Instantiate(bottleprefab, Vector3.zero, Quaternion.identity);
                var componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
                Shader marmo = Shader.Find("MarmosetUBER");
                gameObject.GetComponent<Rigidbody>().detectCollisions = false;

                foreach (var uniqueIdentifier in gameObject.GetComponentsInChildren<UniqueIdentifier>())
                    uniqueIdentifier.classId = ClassID;

                gameObject.GetComponent<TechTag>().type = TechType;
                gameObject.GetComponent<SkyApplier>().renderers = gameObject.GetComponentsInChildren<Renderer>(true);

                processedPrefab = gameObject;
            }
            return processedPrefab;
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
