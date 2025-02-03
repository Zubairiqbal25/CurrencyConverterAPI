using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace CurrencyConverterAPI.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }

        public static void ThrowIfNull([NotNull] object? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
        {
            if (argument is null)
            {
                Throw(paramName);
            }
        }

        [DoesNotReturn]
        internal static void Throw(string? paramName) =>
                throw new KeyNotFoundException($"{paramName} not found");
    }
}
