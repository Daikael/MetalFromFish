using System.IO;
using System.Reflection;
using UnityEngine;

internal static class MetalFromFish_SNHelpers
{
    internal static Assembly assembly = Assembly.GetExecutingAssembly();
    internal static string ModPath = Path.GetDirectoryName(assembly.Location);
    internal static string assetFolderPath = Path.Combine(MetalFromFish_SNHelpers.ModPath, @"Assets\Icons");
    internal static string textureFolderPath = Path.Combine(MetalFromFish_SNHelpers.ModPath, @"Assets\Textures");
    internal static string modelFolderPath = Path.Combine(MetalFromFish_SNHelpers.ModPath, @"Assets\Models");
    internal static AssetBundle bottleassetbundle = AssetBundle.LoadFromFile(Path.Combine(modelFolderPath, "BioBottle.subasset"));
}