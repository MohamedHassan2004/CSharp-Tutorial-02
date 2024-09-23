using System.Runtime.CompilerServices;

namespace ContactTask
{
    internal static class ContactExtension
    {
        public static bool IsValidEmail(this Contact c)
        {
            if (c.Email.EndsWith("@gmail.com")) return true;
            else return false;
        }
    }
}
