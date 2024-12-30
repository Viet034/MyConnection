using System.Text.RegularExpressions;

namespace ConnectMySql.Utils;

public static class Validator
{
    public static bool IsBlank(string value) => string.IsNullOrWhiteSpace(value);

    public static bool IsEmpty(string value)
    {
        return string.IsNullOrEmpty(value);
    }

    public static bool IsCharacter(string value)
    {
        Regex regex = GetRegex(@"^[\p{L}\p{M}\s0-9]+$");
        return regex.IsMatch(value);
    }

    public static Regex GetRegex(string regexStr) => new Regex(regexStr);
}
