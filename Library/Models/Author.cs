using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Library.Models
{
    public class Author
    {
        public int AuthorId{get;set;}
       [Display(Name = "First Name")]
        public string FirstName {get;set;}
        [Display(Name = "Last Name")]
        public string LastName {get;set;}
        public string WholeName {
            get{return string.Format("{0} {1}", FirstName, LastName);}
        }

        
        public Author()
        {
            this.Books = new HashSet<AuthorBook>();
        }
        public ICollection<AuthorBook> Books {get;set;}
    }
}