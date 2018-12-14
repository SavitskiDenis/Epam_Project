using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Special_Insulator.WEB.Models
{
    public class CreateDetaineeWithName
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Не верный размер текста")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Не верный размер текста")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"\d{2}[.]\d{2}[.]\d{4}", ErrorMessage = "Дата должна быть в формате xx.xx.xxxx")]
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

        public string Additional_information { get; set; }
    }
}