using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace tintucbongda.Models
{
    public class timkiemGenreViewModel
    {
        public List<timkiem>? timkiems { get; set; }
        public SelectList? Genres { get; set; }
        public string? timkiemGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
