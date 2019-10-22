using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Library.Models
{
    public class Book
    {
        public int BookId{get;set;}
        public string Title {get;set;}
        [Display(Name = "Year Published")]
        public int PublishYear {get;set;}
        public string Format {get;set;}
        public string Genre {get;set;} 

        
        public Book()
        {
            this.Authors = new HashSet<AuthorBook>();
        }
        public ICollection<AuthorBook> Authors { get;}
    }
}