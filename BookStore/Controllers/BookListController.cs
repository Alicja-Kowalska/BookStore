using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class BookListController : Controller
    {
        private readonly BookStoreContext _context;

        public BookListController(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string bookGenre, string author, string searchString)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'BookStoreContext.Book'  is null.");
            }
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Book
                                            orderby b.Genre
                                            select b.Genre;

            IQueryable<string> authorQuery = from b in _context.Book
                                             orderby b.Author
                                             select b.Author;
            var books = from b in _context.Book
                        select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(bookGenre))
            {
                books = books.Where(x => x.Genre == bookGenre);
            }

            if (!String.IsNullOrEmpty(author))
            {
                books = books.Where(x => x.Author == author);
            }

            var bookGenreAuthorVM = new BookGenreAuthorViewModel

            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Authors = new SelectList(await authorQuery.Distinct().ToListAsync()),
                Books = await books.ToListAsync()
            };

            return View(bookGenreAuthorVM);
        }
    }
}
