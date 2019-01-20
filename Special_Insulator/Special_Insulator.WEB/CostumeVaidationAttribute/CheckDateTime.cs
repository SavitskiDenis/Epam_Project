using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Special_Insulator.WEB.CostumeVaidationAttribute
{
    public class CheckDateTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            DateTime oldDate = new DateTime(1900,1,1);
            if(value != null && DateTime.TryParse(value.ToString(),out date))
            {
                if(date <= DateTime.Today && date > oldDate)
                {
                    return true;
                }
                else
                {
                    this.ErrorMessage = "Не допустимая дата";
                }
            }
            return false;
        }
    }
}