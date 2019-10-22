using System.Collections.Generic;

namespace Library.Models
{
    public class Transaction
    {
        public static List<Checkout> BookBag = new List<Checkout>();

        public int TransactionId { get; set; }
        public int CheckoutId { get; set; }
        public ICollection<Checkout> Checkouts { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Transaction()
        {
            this.Checkouts = new HashSet<Checkout>();
        }
    }
}