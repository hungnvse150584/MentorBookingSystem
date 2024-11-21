using System;
using System.Collections.Generic;

namespace Repositories.Entities
{
    public partial class BookingTransaction
    {
        public int TransactionId { get; set; }
        public int BookingId { get; set; }
        public int WalletId { get; set; }
        public decimal BookingAmount { get; set; }
        public string BookingStatus { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual Wallet Wallet { get; set; } = null!;
    }
}
