using Special_Insulator.WEB.CostumeVaidationAttribute;
using SpecialInsulator.Common.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Special_Insulator.WEB.Models
{
    [CompareDateTime]
    public class DetentionModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d", ErrorMessage = "Неверно введенная дата")]
        [CheckDateTime]
        public string DetentionDate { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d", ErrorMessage = "Неверно введенная дата")]
        [CheckDateTime]
        public string DeliveryDate { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d", ErrorMessage = "Неверно введенная дата")]
        [CheckDateTime]
        public string LiberationDate { get; set; }

        public int DetainWorkerId { get; set; }

        public int DeliveryWorkerId { get; set; }

        public int ReleaseWorkerId { get; set; }

        public int DetentionPlaceId { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"[0-9]{1,8}(?:[.,][0-9]{2})?", ErrorMessage = "Неверный формат ")]
        public string AccruedAmount { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"[0-9]{1,8}(?:[.,][0-9]{2})?", ErrorMessage = "Неверный формат ")]
        public string PaidAmount { get; set; }

        public int DetaineeId { get; set; }
}
}