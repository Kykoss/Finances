using Finanzknabe.Components.Converters;
using System.ComponentModel;

namespace FinanzberaterHenno.Contracts
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum TransactionType
    {
        [Description("Unbekannt")]
        Uncategorized,

        [Description("Gehalt")]
        Salary,

        [Description("Sonst. Einkommen")]
        MiscIncome,

        [Description("Konzert")]
        Concert,

        [Description("Spende")]
        Donation,

        [Description("Spiele")]
        Games,

        [Description("Tanken")]
        Fuel,

        [Description("Restaurant")]
        Restaurant,

        [Description("Reisen")]
        Travel,

        [Description("Lebensmittel")]
        Groceries,

        [Description("Events")]
        Events,

        [Description("Merchandise")]
        Merchandise,

        [Description("Wohnung")]
        Home,

        [Description("Hobbies/Freizeit")]
        Hobbies
        
    }
}
