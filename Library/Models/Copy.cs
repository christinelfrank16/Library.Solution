namespace Library.Models
{
    public class Copy
    {
        public int CopyId{get;set;}
        public int BookId{get;set;}
        public bool ToBeCheckedOut { get; set; }
        public int CheckoutId { get; set; }
        public Book Book { get; set; }
        public Copy()
        {
            ToBeCheckedOut = false;
        }

    }
}