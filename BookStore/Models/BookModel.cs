using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorModel Author { get; set; }
        public int AuthorId { get; set; }
        public int? PageNumber { get; set;}
    }
}
