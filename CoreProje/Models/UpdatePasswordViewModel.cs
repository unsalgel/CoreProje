using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProje.Models
{
    public class UpdatePasswordViewModel
    {
        [Display(Name = "Yeni Şifre")]
        [Required(ErrorMessage = "Lütfen şifreyi boş geçmeyiniz.")]
        [DataType(DataType.Password)] // şifrenin noktalı olarak görünmesi için 
        public string Password { get; set; }
        //public string Token { get; set; }
        //public string Email { get; set; }
    }
}
