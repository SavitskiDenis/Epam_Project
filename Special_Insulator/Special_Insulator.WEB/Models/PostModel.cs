using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Special_Insulator.WEB.Models
{
    public class PostModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Неверный размер текста")]
        public string PostName { get; set; }
    }
}