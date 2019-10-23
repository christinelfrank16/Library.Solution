
using System.Collections.Generic;
using Library.Models;

namespace Library.ViewModels
{
    public class TransactionIndexViewModel
    {
        public List<Transaction> Transactions { get; set; }
        public List<Checkout> Checkouts { get; set; }
        public List<Copy> Books {get;set;}
    }
}