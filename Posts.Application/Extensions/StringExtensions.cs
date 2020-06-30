using System.Linq;

namespace Posts.Application.Extensions
{
    public static class StringExtensions
    {
        public static string Clear(this string source)
        {
            if (source != null)
            {
                if (!source.All(char.IsWhiteSpace))
                {
                    return source.Trim();
                }
            }

            return null;
        }
    }
}