using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BookStoreContext>>()))
        {
            // Look for any books.
            if (context.Book.Any())
            {
                return;   // DB has been seeded
            }
            context.Book.AddRange(
                new Book
                {
                    Title = "Głosy z zaświatów",
                    Author = "Remigiusz Mróz",
                    Genre = "kryminał",
                    RentalDate = DateTime.Parse("2024-10-01"),
                    ReturnDate =  DateTime.Parse("2024-10-03")
                }
            );
            context.SaveChanges();
        }
    }
}