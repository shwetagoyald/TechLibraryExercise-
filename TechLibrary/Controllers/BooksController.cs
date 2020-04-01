using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TechLibrary.Domain;
using TechLibrary.Models;
using TechLibrary.Services;
using System.Net;

namespace TechLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(ILogger<BooksController> logger, IBookService bookService, IMapper mapper)
        {
            _logger = logger;
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Get all books");

            var books = await _bookService.GetBooksAsync();

            var bookResponse = _mapper.Map<List<BookResponse>>(books);

            return Ok(bookResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"Get book by id {id}");

            var book = await _bookService.GetBookByIdAsync(id);

            var bookResponse = _mapper.Map<BookResponse>(book);

            return Ok(bookResponse);
        }

        [HttpGet("new")]
        public Book GetNewBook()
        {
            return new Book();
        }

        [HttpGet("Books/{limit}/{skip}/{searchText}")]
        public async Task<IActionResult> GetBooksFiltered(int limit, int skip, string searchText)
        {
            try
            {
                _logger.LogInformation($"Get filtered books by pagination {limit},{skip},{searchText}");

                var books = await _bookService.GetBooksFilteredPagedAsync(limit, skip, searchText);

                var bookResponse = _mapper.Map<List<BookResponse>>(books);

                return Ok(bookResponse);
            }
            catch (Exception exception)
            {
                _logger.LogError("Error returning filtered book items", exception);

                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }


        [HttpGet("Books/{limit}/{skip}")]
        public async Task<IActionResult> GetBooksByPagination(int limit, int skip)
        {
            try
            {
                _logger.LogInformation($"Get all books by pagination {limit},{skip}");

                var book = await _bookService.GetBooksPagedAsync(limit, skip);

                var bookResponse = _mapper.Map<List<BookResponse>>(book);

                return Ok(bookResponse);
            }
            catch (Exception exception)
            {
                _logger.LogError("Error returning paged book items", exception);

                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("BooksCount")]
        public async Task<IActionResult> GetBooksCount()
        {
            try
            {
                _logger.LogInformation("Get total count of books");

                var count = await _bookService.GetBooksCountAsync("");

                return Ok(count);
            }
            catch (Exception exception)
            {
                _logger.LogError("Error returning books count", exception);

                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("BooksCount/{searchText}")]
        public async Task<IActionResult> GetBooksFilteredCount(string searchText)
        {
            try
            {
                _logger.LogInformation("Get total count of filtered books");

                var count = await _bookService.GetBooksCountAsync(searchText);

                return Ok(count);
            }
            catch (Exception exception)
            {
                _logger.LogError("Error returning searched books count", exception);

                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateBook([FromBody]Book book)
        {
            try
            {
                _logger.LogInformation($"Save book Desc with id {book.BookId}");

                await _bookService.UpdateBookAsync(book);

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError("Error updating book", exception);

                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("{Add}")]
        public async Task<IActionResult> AddBook([FromBody]Book book)
        {
            try
            {
                _logger.LogInformation("Add book");

                await _bookService.AddBookAsync(book);

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError("Error adding book", exception);

                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

    }
}
