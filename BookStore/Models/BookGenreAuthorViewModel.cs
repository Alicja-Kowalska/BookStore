using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookStore.Models
{
    public class BookGenreAuthorViewModel
    {
        public List<Book>? Books { get; set; }
        public SelectList? Genres { get; set; }
        public string? BookGenre { get; set; }
        public SelectList? Authors { get; set; }
        public string? Author { get; set; }
        public string? SearchString { get; set; }
    }
}
