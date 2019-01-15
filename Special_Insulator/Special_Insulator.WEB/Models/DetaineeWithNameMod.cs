﻿using System;
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

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Не верный размер текста")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d", ErrorMessage = "Дата должна быть в формате xx.xx.xxxx")]
        public string BornDate { get; set; }
        
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string Status { get; set; }

        public byte[] Photo { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string Workplace { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^((8|\+3)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage = "Не верный формат")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string Address { get; set; }

        public string AdditionalInformation { get; set; }
    }
}