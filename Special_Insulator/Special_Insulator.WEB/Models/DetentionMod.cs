using Common.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Special_Insulator.WEB.Models
{
    public class DetentionMod
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d", ErrorMessage = "Дата должна быть в формате xx.xx.xxxx")]
        public string DetentionDate { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d", ErrorMessage = "Дата должна быть в формате xx.xx.xxxx")]
        public string DeliveryDate { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d", ErrorMessage = "Дата должна быть в формате xx.xx.xxxx")]
        public string LiberationDate { get; set; }

        public int DetainWorkerId { get; set; }

        public int DeliveryWorkerId { get; set; }

        public int ReleaseWorkerId { get; set; }

        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"[0-9]{1,8}\.[0-9]{2}", ErrorMessage = "Сумма должна быть в формате XXXX.YY")]
        public string AccruedAmount { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [RegularExpression(@"[0-9]{1,8}\.[0-9]{2}", ErrorMessage = "Сумма должна быть в формате XXXX.YY")]
        public string PaidAmount { get; set; }

        public int DetaineeId { get; set; }
}
}