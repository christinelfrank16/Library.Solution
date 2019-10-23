using System.Collections.Generic;

namespace Library.Models
{
    public class Transaction
    {
       

        public int TransactionId { get; set; }
        public ICollection<Checkout> Checkouts { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Transaction()
        {
            this.Checkouts = new HashSet<Checkout>();
        }
    }
}