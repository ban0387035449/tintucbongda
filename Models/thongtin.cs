using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tintucbongda.Models
{
    public class thongtin
    {
        public int Id { get; set; }
        [Display(Name = "giải đấu")]
        public string giaidau { get; set; }
        [Display(Name = "Ngày đấu")]
        [DataType(DataType.Date)]
        public DateTime ngaydau { get; set; }
        [Display(Name = "địa điểm")]
        public string diadiem { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "tỉ số")]
        public string tiso { get; set; }
    }
}
