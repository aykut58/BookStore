using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class AuthorModel 
    {
       
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }

        public ICollection<BookModel> Books { get; set; }   

    }
}
