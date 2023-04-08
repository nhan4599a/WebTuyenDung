using System;

namespace WebTuyenDung.Enums
{
    public enum FilePath
    {
        Post,
        CurriculumTitae,
        Avatar
    }

    public static class ImagePathGenerator
    {
        public static string GetContentDirectory(this FilePath imagePath)
        {
            return imagePath switch
            {
                FilePath.Post => "Posts",
                FilePath.CurriculumTitae => "CV",
                FilePath.Avatar => "Avatar",
                _ => throw new NotImplementedException()
            } + "/";
        }
    }
}
