using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace tintucbongda.Models
{
    public class timkiem
    {
        public int Id { get; set; }
        [Display(Name = "giải đấu")]
        public string Title { get; set; }
        [Display(Name = "Ngày đá")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "cúp")]
        public string Genre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "tỉ số")]
        public decimal Price { get; set; }
    }
}
