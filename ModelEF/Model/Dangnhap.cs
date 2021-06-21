namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dangnhap")]
    public partial class Dangnhap
    {
        [Key]
        [StringLength(15)]
        [Display(Name ="Tên Đăng Nhập")]
        public string users { get; set; }

        [StringLength(15)]
        [Display(Name = "Mật Khẩu")]
        public string passwords { get; set; }
    }
}
