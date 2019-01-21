using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Special_Insulator.WEB.Models
{
    public class UserEditModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Неверный размер текста")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Неверный размер текста")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Неверный размер текста")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string RePassword { get; set; }


        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [EmailAddress(ErrorMessage = "Некорректный e-mail")]
        public string Email { get; set; }

        public string OldLogin { get; set; }
    }
}