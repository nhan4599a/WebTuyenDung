using System.ComponentModel.DataAnnotations;

namespace WebTuyenDung.Validations
{
    public class LengthBoundaryAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }

        public int MaxLength { get; set; }

        public LengthBoundaryAttribute(int minLength, int maxLength)
        {
            if (minLength > maxLength)
            {
                (minLength, maxLength) = (maxLength, minLength);
            }

            MinLength = minLength;
            MaxLength = maxLength;

            ErrorMessage = $"{{0}} must be at least {MinLength} and maximum is {MaxLength} characters";
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            if (value is not string)
                return false;

            var stringValue = value.ToString()!;

            return stringValue.Length >= MinLength && stringValue.Length <= MaxLength;
        }
    }
}
