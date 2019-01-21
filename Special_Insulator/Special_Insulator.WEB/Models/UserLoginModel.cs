using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Неверный размер текста")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Неверный размер текста")]
        public string Password { get; set; }

    }
}