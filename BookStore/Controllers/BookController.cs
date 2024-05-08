using BookStore.DTO;
using BookStore.Response;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private BookService _bookService;
        public BookController(BookService bookService) 
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAllBook()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult GetByLink(int id) 
        {
            var book = _bookService.FindById(id);
            if (book == null)
                return NotFound(new ResponseMessage { Message ="Böyle Bir Kayıt Bulunamadı."});
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook (BookDTO bookDTO) 
        {
            long id = _bookService.Save
                (
                    new Models.BookModel 
                    {
                        Title = bookDTO.Title,
                        Description = bookDTO.Description,
                        AuthorId = bookDTO.AuthorId,
                        PageNumber = bookDTO.PageNumber,
                        
                    }
                );
            return Ok(new AddResponse { SavedId = id});
        }
        [HttpDelete]
        public IActionResult DeleteBook(int  id) 
        {
            var book = _bookService.FindById (id);
            if(book == null)
                return NotFound(new ResponseMessage { Message = "Böyle Bir Kayıt Bulunamadı." });
            _bookService.DeleteById(id);
            return Ok(new ResponseMessage { Message = "İşlem Başarılı" });
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookDTO updatedBook)
        {
            var existingBook = _bookService.FindById(id);
            if (existingBook == null)
                return NotFound(new ResponseMessage { Message = "Böyle Bir Kayıt Bulunamadı." });

            existingBook.Title = updatedBook.Title;
            existingBook.Description = updatedBook.Description;
            existingBook.AuthorId = updatedBook.AuthorId;
            existingBook.PageNumber = updatedBook.PageNumber;
            // Diğer özellikleri de güncelleyebilirsiniz

            _bookService.Update(existingBook);

            return Ok(new ResponseMessage { Message = "Kitap Başarıyla Güncellendi" });
        }

    }
}
