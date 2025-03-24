using Finanzknabe.Contracts;

namespace Finanzknabe.Components.Extensions
{
    public static class RecipientExtensions
    {
        public static string GetDisplayName(this Recipient recipient)
            => string.IsNullOrEmpty(recipient.CustomName) ? recipient.Name : recipient.CustomName;
    }
}
