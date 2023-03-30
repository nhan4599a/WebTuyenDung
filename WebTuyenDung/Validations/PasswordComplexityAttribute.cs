using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebTuyenDung.Helper;

namespace WebTuyenDung.Validations
{
    public class PasswordComplexityAttribute : ValidationAttribute
    {
        private static readonly HashSet<char> InvalidPasswordCharacters = new()
        {
            '$', '&', '<', '>', '(', ')', '/', '\\', '\'', '"', '`', '{', '}', ',', '~'
        };

        private static readonly Func<int, int> IncreaseIntegerFunc = (value) => value + 1;

        public PasswordComplexityAttribute()
        {
            ErrorMessage = "Password must include lower, upper, digit and at least one of following characters ['.', '!', '@', '#', '%', '^']";
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            var password = value.ToString();
            if (string.IsNullOrWhiteSpace(password)) return false;

            Dictionary<PasswordCharacterKind, int> characterKindCount = new();

            foreach (var character in password)
            {
                if (InvalidPasswordCharacters.Contains(character))
                    return false;
                if (char.IsControl(character))
                    return false;

                if (char.IsDigit(character))
                {
                    characterKindCount
                        .AddOrUpdate(
                            PasswordCharacterKind.Digit,
                            0,
                            IncreaseIntegerFunc);
                }
                else if (char.IsLetter(character))
                {
                    if (char.IsUpper(character))
                    {
                        characterKindCount
                            .AddOrUpdate(
                                PasswordCharacterKind.Upper,
                                0,
                                IncreaseIntegerFunc);
                    }
                    else
                    {
                        characterKindCount
                            .AddOrUpdate(
                                PasswordCharacterKind.Lower,
                                0,
                                IncreaseIntegerFunc);
                    }
                }
                else
                {
                    characterKindCount
                        .AddOrUpdate(
                            PasswordCharacterKind.Special,
                            0,
                            IncreaseIntegerFunc);
                }

                if (characterKindCount.Count == 4)
                    return true;
            }

            return false;
        }
    }

    enum PasswordCharacterKind
    {
        Lower,
        Upper,
        Digit,
        Special
    }
}
