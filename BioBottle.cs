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
                BioBottle.thisTechType = base.TechType;
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
                var bottleprefab = MetalFromFish_SNHelpers.bottleassetbundle.LoadAsset<GameObject>("BioBottle.subasset");
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

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            var task = MetalFromFish_SNHelpers.bottleassetbundle.LoadAsset<GameObject>("BioBottle.subasset");
            yield return task;
            var modifiedPrefab = GameObject.Instantiate(task);

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
