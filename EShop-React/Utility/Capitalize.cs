namespace EShop_React.Utility
{
    public class Capitalize
    {
        public static string CapitalizeFirstLetter(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return word;

            return char.ToUpper(word[0]) + word.Substring(1).ToLower();
        }
    }
}
