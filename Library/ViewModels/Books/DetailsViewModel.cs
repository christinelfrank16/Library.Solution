
using System.Collections.Generic;
using Library.Models;

namespace Library.ViewModels
{
    public class BookDetailsViewModel
    {

        public Book Book { get; set; }

        public List<Author> Authors { get; set; }
    }
}