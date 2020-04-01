using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechLibrary.Data;
using TechLibrary.Domain;
using TechLibrary.Models;

namespace TechLibrary.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int bookid);
        Task<List<Book>> GetBooksFilteredPagedAsync(int limit, int skip, string searchText);
        Task<List<Book>> GetBooksPagedAsync(int limit, int skip);
        Task<int> GetBooksCountAsync(string searchText);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
    }

    public class BookService : IBookService
    {
        private readonly DataContext _dataContext;

        public BookService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var queryable = _dataContext.Books.AsQueryable();

            return await queryable.ToListAsync();
        }

        public async Task<int> GetBooksCountAsync(string searchText)
        {
            if (searchText =="")
            {
                return await _dataContext.Books.CountAsync();
            }
            else
            {
                return await _dataContext.Books.Where(x => x.Title.ToLower().Contains(searchText) || x.LongDescr.ToLower().Contains(searchText) || x.ShortDescr.ToLower().Contains(searchText)).CountAsync();
            }
           
        }

        public async Task<Book> GetBookByIdAsync(int bookid)
        {
            return await _dataContext.Books.SingleOrDefaultAsync(x => x.BookId == bookid);
        }

        public async Task<List<Book>> GetBooksPagedAsync(int limit, int skip)
        {
                 return await _dataContext.Books.Skip(skip).Take(limit).ToListAsync();
        }

        public async Task<List<Book>> GetBooksFilteredPagedAsync(int limit, int skip, string searchText)
        {
            var queryable = _dataContext.Books.Where(x => x.Title.ToLower().Contains(searchText) || x.LongDescr.ToLower().Contains(searchText) || x.ShortDescr.ToLower().Contains(searchText)).Skip(skip).Take(limit);

            return await queryable.ToListAsync();
        }

        public async Task AddBookAsync(Book book)
        {
                 _dataContext.Books.Add(book);
                 await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
                var bookUpdate = _dataContext.Books.SingleOrDefault(x => x.BookId == book.BookId);
                bookUpdate.ShortDescr = book.ShortDescr;
                await _dataContext.SaveChangesAsync();
        }

    }
}
