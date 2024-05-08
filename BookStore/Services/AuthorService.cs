using BookStore.Models;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class AuthorService
    {
        private ApplicationContext _applicationContext;

        public AuthorService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public List<AuthorModel> GetAllAuthors() => _applicationContext.Authors.ToList();

        public AuthorModel FindById(int id) => _applicationContext.Authors.SingleOrDefault(author => author.Id == id);

        public long Save(AuthorModel author)
        {
            _applicationContext.Authors.Add(author);
            _applicationContext.SaveChanges();
            return author.Id;
        }

         public void DeleteById(int id) 
        {
            var authorDelete = _applicationContext.Authors.SingleOrDefault(auth => auth.Id == id);
            
            if (authorDelete != null)
            {
                _applicationContext.Authors.Remove(authorDelete);
                _applicationContext.SaveChanges();
            }
        }

        public void UpdateAuthor(AuthorModel updatedAuthor)
        {
            var existingBook = _applicationContext.Authors.FirstOrDefault(book => book.Id == updatedAuthor.Id);
            if (existingBook != null)
            {
                existingBook.AuthorName = updatedAuthor.AuthorName;
                existingBook.AuthorSurname = updatedAuthor.AuthorSurname;


                _applicationContext.SaveChanges();
            }
        }
}
