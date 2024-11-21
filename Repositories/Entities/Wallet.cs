using System;
using System.Collections.Generic;

namespace Repositories.Entities
{
    public partial class Wallet
    {
        public Wallet()
        {
            BookingTransactions = new HashSet<BookingTransaction>();
            Payments = new HashSet<Payment>();
        }

        public int WalletId { get; set; }
        public int StudentId { get; set; }
        public decimal? Balance { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual ICollection<BookingTransaction> BookingTransactions { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
