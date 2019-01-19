using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Special_Insulator.WEB.Models
{
    public class DetentionPlaceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(200,MinimumLength = 5, ErrorMessage = "Не верный размер текста")]
        public string Address { get; set; }
    }
}