using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Domain.Users
{
    public static class Ensure
    {
        public static void NotNullOrEmpty([NotNull] string? value, [CallerArgumentExpression("value")] string? param = null)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(param));
            }
        }
    }
}
