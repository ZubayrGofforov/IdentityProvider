namespace SignInTechnologys.Common.Helpers;
public class ImageHelper
{
    public static string UniqueName(string fileName)
    {
        string extension = Path.GetExtension(fileName);
        string name = "IMG_" + Guid.NewGuid().ToString();
        return name + extension;
    }
}
