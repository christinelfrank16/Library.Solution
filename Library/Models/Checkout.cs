using System;
namespace Library.Models
{
    public class Checkout
    {
        public int CheckoutId { get; set; }
        public int TransactionId { get; set; }
        public bool ToBeCheckedOut { get; set; }
        public int PatronId { get; set; }
        public int CopyId { get; set; }

        public Patron Patron { get; set; }
        public Copy Copy { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime DueDate { get; set; }

        public Checkout()
        {
            ToBeCheckedOut = false;
        }

    }
}