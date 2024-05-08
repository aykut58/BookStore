using BookStore.DTO;
using BookStore.Models;
using BookStore.Response;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("{id}")]
        public IActionResult GetByAuthor(int id) 
        {
            var author =_authorService.FindById(id);
            if(author == null)
                return NotFound(new ResponseMessage { Message = "Böyle Bir Yazar Yok" });
            return Ok(author);
        }
        [HttpGet]
        public IActionResult GetAllAuthor() 
        {
            var author = _authorService.GetAllAuthors();
            return Ok(author);
        }
        [HttpPost]
        public  IActionResult AddAuthor(AuthorDTO authorDto) 
        {
            long id = _authorService.Save
                (
                new AuthorModel 
                {
                    AuthorName = authorDto.AuthorName,
                    AuthorSurname = authorDto.AuthorSurname,
                });
            return Ok(new AddResponse { SavedId = id });
        }
        [HttpDelete]
        public IActionResult DeleteAuthor(int id) 
        {
            var author = _authorService.FindById(id);
            if (author == null)
                return NotFound(new ResponseMessage { Message = "Böyle Bir Kayıt Bulunamadı." });
            _authorService.DeleteById(id);
            return Ok(new ResponseMessage { Message = "İşlem Başarılı" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, AuthorDTO updatedAuthor)
        {
            var existingBook = _authorService.FindById(id);
            if (existingBook == null)
                return NotFound(new ResponseMessage { Message = "Böyle Bir Kayıt Bulunamadı." });

            existingBook.AuthorName = updatedAuthor.AuthorName;
            existingBook.AuthorSurname = updatedAuthor.AuthorSurname;

            _authorService.UpdateAuthor(existingBook);

            return Ok(new ResponseMessage { Message = "Kitap Başarıyla Güncellendi" });
        }

    }
}
