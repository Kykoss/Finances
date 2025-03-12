using Finanzknabe.Contracts;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Finanzknabe.Components.Helper
{
    public static class TransactionTypeHelper
    {
        public static TypeConverter TransactionTypeConverter = TypeDescriptor.GetConverter(TransactionType.Uncategorized);

        public static TransactionType? GetTransactionTypeOrDefault(ChangeEventArgs e)
            => (TransactionType?)TransactionTypeHelper.TransactionTypeConverter.ConvertFrom((string)e!.Value!);

    }
}
