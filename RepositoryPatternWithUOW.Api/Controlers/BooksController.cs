using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Conests;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.Core.Repositories;

namespace RepositoryPatternWithUOW.Api.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Books.GetById(1));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName() 
        {
            return Ok(_unitOfWork.Books.Find(b => b.Title == "NewBook", new[] { "Author"}));
        }

        [HttpGet("GetAllwithAuthors")]
        public IActionResult GetAllwithAuthors()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains( "Book"), new[] { "Author" }));
        }

        [HttpGet("GetOrderd")]
        public IActionResult GetOrderd()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("Book"), null, null, b => b.Id,OrderBy.Descending));
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = _unitOfWork.Books.Add(new Book { Title = "Test 4", AuthorId = 1 });
            _unitOfWork.Complete();
            return Ok(book);
        }
    }
}
