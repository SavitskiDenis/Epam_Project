using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Models
{
    public class DetaineeWithNameMod
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int PeopleId { get; set; }


        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Не верный размер текста")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Не верный размер текста")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d", ErrorMessage = "Дата должна быть в формате xx.xx.xxxx")]
        public string BornDate { get; set; }
        
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string Status { get; set; }

        public string Photo { get; set; }
        
        public string Workplace { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"\+\([0-9]{3}\)-[0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Номер должен быть в формате +(nnn)-nn-nnn-nn-nn")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string Address { get; set; }

        public string AdditionalInformation { get; set; }
    }
}