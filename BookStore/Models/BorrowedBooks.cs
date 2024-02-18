using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BorrowedBooks
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public List<Book>? Books { get; set; }
        public DateTime RentalDate { get; set; }
        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        public string? SearchString { get; set; }

    }
}