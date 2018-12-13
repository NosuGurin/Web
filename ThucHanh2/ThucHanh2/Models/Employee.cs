using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThucHanh2.Models
{
    public class Employee
    {
        [Required,EmailAddress(ErrorMessage ="Vui lòng nhập đúng dữ liệu email !")]
        public string Email { get; set; }
        [Required,Compare("Email",ErrorMessage ="Vui lòng nhập giống email đã nhập !")]
        public string ConfirmEmail { get; set; }
        [Range(16,65, ErrorMessage = "Chọn độ tuổi từ 16 đến 65")]
        public int Age { get; set; }
        [Range(2000000,double.MaxValue,ErrorMessage ="Lương tối thiểu là 2 triệu")]
        public double Salary { get; set; }
        [CreditCard(ErrorMessage ="Vui lòng nhập đúng số thẻ tín dụng")]
        public string CreditCard { get; set; }
        [Url(ErrorMessage = "Bạn vui lòng nhập đúng đường link website")]
        public string Website { get; set; }
        [DataType(DataType.ImageUrl, ErrorMessage = "Vui lòng chọn đúng file hình ảnh")]
        public string Photo { get; set; }
        [RegularExpression(@"5\d-[A-Z]\d-((\d{4})|(\d{3}\.\d{2}))", ErrorMessage = "Vui lòng nhập đúng biển số")]
        public string SaigonMotoNumber { get; set; }
        [StringLength(255),DataType(DataType.MultilineText,ErrorMessage ="Vui lòng nhập tối đạ 255 ký tự")]
        public string Description { get; set; }
    }
}