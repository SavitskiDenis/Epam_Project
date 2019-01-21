using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Special_Insulator.WEB.Models
{
    public class WorkerWithNameModel
    {
        public int Id { get; set; }

        public int PeopleId { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Неверный размер текста")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Неверный размер текста")]
        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Неверный размер текста")]
        public string Patronymic { get; set; }

        public string LF { get { return LastName + " " + FirstName + " " + Patronymic; } }

        public int WorkerPostId { get; set; }
    }
}