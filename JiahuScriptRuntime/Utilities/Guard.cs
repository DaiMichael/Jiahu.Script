using System;

namespace JiahuScriptRuntime.Utilities
{
    public static class Guard
    {
        public static void ThrowOnNull(object checkObject, string name)
        {
            if (checkObject == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void ThrowOnNullOrEmpty(string value, string name)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
