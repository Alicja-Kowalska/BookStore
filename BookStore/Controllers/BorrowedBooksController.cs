using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;
using System.Linq;

namespace BookStore.Controllers
{
    public class BorrowedBooksController : Controller
    {
        private readonly BookStoreContext _context;

        public BorrowedBooksController(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'BookStoreContext.Book'  is null.");
            }

            var books = from b in _context.Book
                        select b;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }

            var BorrowedBooksVM = new BorrowedBooks
            {
                Books = await books.ToListAsync()
            };

            return View(BorrowedBooksVM);
        }
    }
}

