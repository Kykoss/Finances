using Finanzknabe.Contracts;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Finanzknabe.Components.Converters
{
    public class EnumDescriptionTypeConverter : EnumConverter
    {
        public EnumDescriptionTypeConverter(Type type): base(type)
        {
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {

            if (value is TransactionType transactionType && destinationType == typeof(string))
            {
                return this.GetDescription(transactionType);
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string description)
            {
                foreach (var item in Enum.GetValues(typeof(TransactionType)))
                {
                    if (this.GetDescription((TransactionType)item) == description)
                    {
                        return item;
                    }
                }

                return null;
            }
            
            return base.ConvertFrom(context, culture, value);
        }

        private string GetDescription(TransactionType transactionType)
        {
            var field = transactionType.GetType().GetField(transactionType.ToString()!);

            var descripctionAttribute = field!.GetCustomAttribute<DescriptionAttribute>();
            if (descripctionAttribute != null)
            {
                return descripctionAttribute.Description;
            }

            return string.Empty;
        }
    }
}
