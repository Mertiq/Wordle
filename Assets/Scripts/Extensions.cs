public static class Extensions
{
    public static bool IsLetter(string input)
    {
        return !string.IsNullOrEmpty(input) && char.IsLetter(input[0]);
    }
}