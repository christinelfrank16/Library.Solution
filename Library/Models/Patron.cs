using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Patron
    {
        public int PatronId {get;set;}

        [Display(Name = "First Name")]
        public string FirstName {get;set;}
        [Display(Name = "Last Name")]
        public string LastName {get;set;}
        public string WholeName {
            get{return string.Format("{0} {1}", FirstName, LastName);}
        }
        public ICollection<Transaction> Transactions {get;set;}

        public virtual ApplicationUser User { get; set; }

        public Patron()
        {
            this.Transactions = new HashSet<Transaction>();
        }

    
    }
}