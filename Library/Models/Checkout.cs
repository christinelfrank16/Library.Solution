using System;
using System.Collections.Generic;
namespace Library.Models
{
    public class Checkout
    {
        public int CheckoutId { get; set; }
        public int TransactionId { get; set; }
       
        public int PatronId { get; set; }
        public int CopyId { get; set; }
        public static List<Copy> BookBag = new List<Copy>();

        public Patron Patron { get; set; }
        public Copy Copy { get; set; }
        public Transaction Transaction {get;set;}
        public DateTime CheckoutDate { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime DueDate { get; set; }

        
    }
}