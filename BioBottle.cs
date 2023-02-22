using SMLHelper.V2.Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SMLHelper.V2.Crafting;
using Sprite = Atlas.Sprite;
using SMLHelper.V2.Utility;
using System.IO;
using SMLHelper.V2.Handlers;
using Unity.Audio;
using System;

namespace MetalFromFish
{
    internal class BioBottle : Spawnable
    {
        public static TechType thisTechType;
        public static Sprite sprite = GetSprite("DTBioBottle");

        public BioBottle() : base("DTBioBottle", "Processed Biological Byproduct", "Waste biological material produced durring resource extraction. Can be further utilized.")
        {
            OnFinishedPatching += () =>
            {
                int bpower = MetalFromFish_SNHelpers.Config.BPower;
                BioBottle.thisTechType = base.TechType;
                BioReactorHandler.SetBioReactorCharge(BioBottle.thisTechType, bpower);
            };
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
        public override GameObject GetGameObject()
        {
            var bundle = MetalFromFish_SNHelpers.bottleassetbundle;
            var obj = bundle.LoadAsset<GameObject>("Biohazardtank");
            return obj;
        }
        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            gameObject.Set(GetGameObject());
            yield return null;
        }
    }
}
