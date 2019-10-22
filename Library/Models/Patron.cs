using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Patron
    {
        public int CopyId{get;set;}
        public int CheckoutId {get;set;}
        public int PatronId {get;set;}
        [Display(Name = "First Name")]
        public string FirstName {get;set;}
        [Display(Name = "Last Name")]
        public string LastName {get;set;}
        public string Email {get;set;}
        public string WholeName {
            get{return string.Format("{0} {1}", FirstName, LastName);}
        }
        public ICollection<Checkout> Copies {get;set;}

        public Patron()
        {
            this.Copies = new HashSet<Checkout>();
        }

    
    }
}