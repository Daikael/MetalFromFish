using System.IO;
using System.Reflection;

internal static class MetalFromFish_SNHelpers
{
    internal static Assembly assembly = Assembly.GetExecutingAssembly();
    internal static string assetFolderPath = Path.Combine(Path.GetDirectoryName(assembly.Location), "Assets");
}