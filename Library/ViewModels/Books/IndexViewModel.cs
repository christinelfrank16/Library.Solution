
using System.Collections.Generic;
using Library.Models;

namespace Library.ViewModels
{
    public class BookIndexViewModel
    {
        public List<Book> Books { get; set; }
        public List<Copy> Copies { get; set; }
    }
}