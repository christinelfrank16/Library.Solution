using System.Collections.Generic;
namespace Library.Models
{
    public class Book
    {
        public int BookId{get;set;}
        public string Title {get;set;}
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