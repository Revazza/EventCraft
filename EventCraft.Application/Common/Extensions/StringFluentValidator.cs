using FluentValidation;
using System.Text.RegularExpressions;

namespace EventCraft.Application.Common.Extensions;

public static class StringFluentValidator
{
    public static IRuleBuilderOptions<T, string> MustBeEnglish<T>(
        this IRuleBuilderOptions<T, string> ruleBuilder)
    {
        return ruleBuilder.Must(s => Regex.IsMatch(s.Replace(" ", ""), "^[a-zA-Z0-9]*$")).WithMessage("'{PropertyName}' must be English");
    }
}