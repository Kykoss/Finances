using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzknabe.Contracts
{
    public enum PaymentType
    {
        Unknown,

        DebitCard,

        CashPayout,

        PayPal,

        DirectBooking,

        PermanentDebit,

        MonthClosing,

        IncomingCredit
    }
}
