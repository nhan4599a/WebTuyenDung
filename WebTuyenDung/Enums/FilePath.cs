using System;

namespace WebTuyenDung.Enums
{
    public enum FilePath
    {
        Post,
        CurriculumTitae
    }

    public static class ImagePathGenerator
    {
        public static string GetContentDirectory(this FilePath imagePath)
        {
            return imagePath switch
            {
                FilePath.Post => "Posts",
                FilePath.CurriculumTitae => "CurriculumVitae",
                _ => throw new NotImplementedException()
            } + "/";
        }
    }
}
