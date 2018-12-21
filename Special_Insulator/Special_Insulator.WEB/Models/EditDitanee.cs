using Common.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Special_Insulator.WEB.Models
{
    public class EditDitanee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string Status { get; set; }


        public string Workplace { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string Address { get; set; }


        public string AdditionalInformation { get; set; }
        
    }
}