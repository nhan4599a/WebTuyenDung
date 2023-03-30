using System;

namespace WebTuyenDung.Enums
{
    public enum ImagePath
    {
        Post
    }

    public static class ImagePathGenerator
    {
        public static string GetContentDirectory(this ImagePath imagePath)
        {
            return imagePath switch
            {
                ImagePath.Post => "Blogs",
                _ => throw new NotImplementedException()
            } + "/";
        }
    }
}
