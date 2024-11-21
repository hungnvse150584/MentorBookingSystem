using System;
using System.Collections.Generic;

namespace Repositories.Entities
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int WalletId { get; set; }
        public decimal Amount { get; set; }

        public virtual Wallet Wallet { get; set; } = null!;
    }
}
