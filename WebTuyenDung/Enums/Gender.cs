using System;

namespace WebTuyenDung.Enums
{
    public enum Gender : byte
    {
        Male,
        Female
    }

    public static class GenderRepresentation
    {
        public static string GetRepresentation(this Gender gender)
        {
            return gender switch
            {
                Gender.Male => "Nam",
                Gender.Female => "Nữ",
                _ => throw new NotImplementedException()
            };
        }
    }
}
