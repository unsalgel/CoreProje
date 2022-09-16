using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProje.Models
{
    public class ResetPasswordViewModel
    {
        [Display(Name="Mail Adresiniz.")]
        [EmailAddress(ErrorMessage = "Lütfen uygun formatta e-posta adresi giriniz.")]
        public string Email { get; set; }   
    }
}
