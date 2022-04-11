using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBookByID;
using  WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.BookOperations_Get;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("Controller")]
    public class WebApi:ControllerBase
    {
        private readonly BookStoreDBContext _context;

        public WebApi(BookStoreDBContext context)
        {
            _context=context;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBooks create = new CreateBooks(_context);
            try
            {
                create.Model=newBook;
                create.handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery get = new GetBooksQuery(_context);
            var result = get.handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(string id)
        {
            GetByID get = new GetByID(_context);
            get.Id=Convert.ToInt32(id);
            var result = get.handle();
            return Ok(result);
        }

        /*
        [HttpGet]
        public Book GetBook([FromQuery] string id)
        {
            var Book = BookList.Find(i=>i.Id==id);
            return Book;
        }
        */

        

        [HttpPut("{Id}")]
        public IActionResult UpdateBook(string id, [FromBody] UpdateModel UpdateBook)
        {
            UpdateBooks up = new UpdateBooks(_context);
            try
            {
                up.Id=Convert.ToInt32(id);
                up.model=UpdateBook;
                up.handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}