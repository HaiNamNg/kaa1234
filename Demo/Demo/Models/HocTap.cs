using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class HocTap
    {
        [Key]
        [Required(ErrorMessage = "Ten sinh vien khong duoc de trong")]
        public string HoVaTen { get; set; }
        [Required]
        public string MaSinhVien { get; set; }
        public string TenLop { get; set; }
        [ForeignKey("TenLop")]
        public virtual Lop Lop { get; set; }
    }
}