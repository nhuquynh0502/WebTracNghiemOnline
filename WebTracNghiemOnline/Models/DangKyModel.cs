using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTracNghiemOnline.Models
{
    public class DangKyModel
    {
        public string HoTen { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }

    }
}