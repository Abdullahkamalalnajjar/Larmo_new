using System.Text.RegularExpressions;
using FluentValidation;

namespace Larmo.Shared.Extension;

public static class CustomValidators
{
    private const string SpecialCharacters = "!@#$%^&*()_+'.\\-";
    private const string SpecialArabicLetters = $"\u0621-\u064A-{SpecialCharacters}";
    private const string SpecialEnglishLetters = $"a-zA-Z-{SpecialCharacters}";
    private const string NumbersRegex = "0-9";

    public static IRuleBuilderOptions<T, string> IsEnglish<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        bool allowSpaces = true,
        bool allowNumbers = true)
    {
        var numbers = allowNumbers ? NumbersRegex : "";

        var regex = allowSpaces
            ? $"^[{SpecialEnglishLetters}{numbers} ]*$"
            : $"^[{SpecialEnglishLetters}{numbers}]*$";
        var message = allowNumbers
            ? "'{PropertyName}' must contains English letters and numbers"
            : "'{PropertyName}' must contains English letters only";

        if (allowSpaces)
        {
            message += " and could contain spaces";
        }

        message += ".";

        return ruleBuilder.Matches(regex).WithMessage(message);
    }

    public static IRuleBuilderOptions<T, string> IsArabic<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        bool allowSpaces = true,
        bool allowNumbers = true)
    {
        var numbers = allowNumbers ? NumbersRegex : "";

        var regex = allowSpaces
            ? $"^[{SpecialArabicLetters}{numbers} ]*$"
            : $"^[{SpecialArabicLetters}{numbers}]*$";
        var message = allowNumbers
            ? "'{PropertyName}' must contains Arabic letters and numbers only"
            : "'{PropertyName}' must contains Arabic letters only";

        if (allowSpaces)
        {
            message += " and could contain spaces";
        }

        message += ".";

        return ruleBuilder.Matches(regex).WithMessage(message);
    }

    public static IRuleBuilderOptions<T, string> IsNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        const string regex = $"^[{NumbersRegex}]*$";
        const string message = "'{PropertyName}' must be numbers only.";

        return ruleBuilder.Matches(regex).WithMessage(message);
    }

    public static IRuleBuilderOptions<T, string> IsNumberWithDigitsAfterDecimalPoint<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        const string commaSeparatedNumberPattern = "^[0-9]{2,3}(?:[.][0-9]{0,3})?$";
        Regex commaSeparatedNumberRegex = new(commaSeparatedNumberPattern);

        return ruleBuilder.Must((_, text) => commaSeparatedNumberRegex.IsMatch(text));
    }

    public static IRuleBuilderOptions<T, string> NoSpecialCharactersOrNumbers<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        const string pattern = "[0123456789~`!@#$%^&()_={}[\\]:;,.<>+\\/?-]";
        Regex regex = new(pattern);
        return ruleBuilder.Must((_, text) => !regex.IsMatch(text));
    }

    public static IRuleBuilderOptions<T, string> NoSpecialCharacters<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        const string pattern = "[~`!@#$%^&()_={}[\\]:;,.<>+\\/?-]";
        Regex regex = new(pattern);
        return ruleBuilder.Must((_, text) => !regex.IsMatch(text));
    }

    public static IRuleBuilderOptions<T, string> MustMeetPasswordCriteria<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must((_, password) =>
        {
            if (password.Length < 8)
                return false;

            if (!Regex.IsMatch(password, "[A-Z]"))
                return false;

            if (!Regex.IsMatch(password, "[a-z]"))
                return false;

            string specialChars = "[~`!@#$%^&*()_+=\\-{}\\[\\]:;\"'<>,.?/|\\\\]";
            if (!Regex.IsMatch(password, specialChars))
                return false;

            return true;
        });
    }

    public static IRuleBuilderOptions<T, string> IsValidUserName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        const string pattern = "[~`!@#$%^&()={}[\\]:;,<>+\\/?]";
        Regex regex = new(pattern);
        return ruleBuilder.Must((_, text) => !regex.IsMatch(text));
    }

    public static IRuleBuilderOptions<T, string> NoSpaces<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must((_, text) => !text.Contains(" "));
    }

    public static IRuleBuilderOptions<T, DateTime> IsUniversalTimeZone<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder)
    {
        return ruleBuilder.Must((_, dateTime) => dateTime.IsUniversalTimeZone());
    }

    public static IRuleBuilderOptions<T, string> IsSaudiPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must((_, value) =>
        {
            if (value == null)
            {
                return false;
            }

            return value.StartsWith("+9665") && value.Length == 13;
        });
    }

    public static IRuleBuilderOptions<T, string> IsEgyptianPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must((_, value) =>
        {
            if (value == null)
            {
                return false;
            }

            return Regex.IsMatch(value, "^01[0125][0-9]{8}$");
        });
    }
}