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
    internal class BioBottle : Spawnable
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
