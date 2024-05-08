using BookStore.Models;
using BookStore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class BookService
    {
        private ApplicationContext _applicationContext;
 
        public BookService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public List<BookModel> GetAllBooks() => _applicationContext.Books.Include("Author").ToList();
        public BookModel FindById(int id) => _applicationContext.Books.SingleOrDefault(book => book.Id == id);

        public long Save (BookModel book) 
        {
            _applicationContext.Books.Add(book);
            _applicationContext.SaveChanges();
            return book.Id;
        }
        public void DeleteById(int id)
        {
            var bookToDelete = _applicationContext.Books.FirstOrDefault(book => book.Id == id);
            if (bookToDelete != null)
            {
                _applicationContext.Books.Remove(bookToDelete);
                _applicationContext.SaveChanges();
            }
        }

        public  void Update (BookModel updatedBook) 
        {
            var existingBook = _applicationContext.Books.FirstOrDefault(book => book.Id == updatedBook.Id);
            if(existingBook != null) 
            {
                existingBook.Title = updatedBook.Title;
                existingBook.Description = updatedBook.Description; 
                existingBook.AuthorId = updatedBook.AuthorId;
                existingBook.PageNumber = updatedBook.PageNumber;

                _applicationContext.SaveChanges();
            }
        }

    }
}
