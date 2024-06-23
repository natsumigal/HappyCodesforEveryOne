using System;
using System.Text;

namespace HappytoHelp.RandomHelpers
{
    public static class stringToBase64Extension
    {
        public static string ToBase64string(this string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }
        public static string FromBase64(this string value)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }
    }
}
