using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTracNghiemOnline.Models;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace WebTracNghiemOnline.Helpers
{
    public class AccountHelper
    {
        public bool DangKy(DangKyModel model,out string err)
        {
            err = "";
            try
            {
                using (var dbcontext = new WebTracNghiemOnline())
                {
                    // kiem tra ten tai khoan da ton tai?
                    if (dbcontext.Users.Any(x => x.Username == model.TenDangNhap))
                    {
                        err = "Tài khoản đã tồn tại!";
                        return false;
                    }

                    //neu chua tao user
                    User user = new User();
                    user.Name = model.HoTen;
                    user.Date_of_Birth = model.NgaySinh;
                    user.Sex = model.GioiTinh;
                    user.Address = model.DiaChi;
                    user.Phone = model.SoDienThoai;
                    user.Mail = model.Email;
                    user.Username = model.TenDangNhap;
                    user.Password = model.MatKhau;

                    dbcontext.Users.Add(user);
                    dbcontext.SaveChanges();
                }
                return true;
            }
            catch
            {
                err = "Lỗi hệ thống!";
                return false;
            }
        }
        public bool DangNhap(DangNhapModel model, out string err)
        {
            err = "";
            try
            {
                using (var dbcontext = new WebTracNghiemOnline())
                {
                    //neu tim thay tai khoan
                    if(dbcontext.Users.Any(x => x.Username == model.TenDangNhap && x.Password == model.MatKhau))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                err = "Lỗi hệ thống!";
                return false;
            }
        }
        public bool QuenMatKhau(string email,out string err)
        {
            err = "";
            try
            {
                using (var dbcontext = new WebTracNghiemOnline())
                {
                    if(dbcontext.Users.Any(x => x.Mail == email))
                    {
                        int Min = 50;
                        int Max = 100;
                        string matKhau = "";
                        int doDai = 8;

                        Random randNum = new Random();
                        for (int i = 0; i < doDai; i++)
                        {
                            matKhau  += (char)randNum.Next(Min, Max);
                        }

                        try
                        {
                            MailMessage mail = new MailMessage();
                            mail.To.Add(email);
                            mail.From = new MailAddress("phucnipy3@gmail.com");
                            mail.Subject = "Mật khẩu mới!";
                            mail.Body = "Mật khẩu mới của bạn là: " + matKhau;
                            mail.IsBodyHtml = true;
                            mail.Priority = MailPriority.High;

                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.vn";
                            smtp.Credentials = new System.Net.NetworkCredential("phucnipy3@gmail.com", "PhucNipy1999xyz");
                            smtp.Port = 587;
                            smtp.EnableSsl = true;
                            smtp.Send(mail);

                            return true;
                        }
                        catch
                        {
                            err = "Lỗi không gửi được mail!";
                            return false;
                        }
                    }
                    else
                    {
                        err = "Mail không tồn tại!";
                        return false;
                    }
                }
            }
            catch
            {
                err = "Lỗi hệ thống!";
                return false;
            }
        }
    }
}