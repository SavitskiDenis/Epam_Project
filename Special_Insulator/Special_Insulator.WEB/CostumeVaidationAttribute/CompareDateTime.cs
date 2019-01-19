using Special_Insulator.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Special_Insulator.WEB.CostumeVaidationAttribute
{
    public class CompareDateTime: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                DetentionModel model = value as DetentionModel;
                DateTime firstDate, secondDate, thirdDate;
                if (DateTime.TryParse(model.DetentionDate, out firstDate) &&
                    DateTime.TryParse(model.DeliveryDate, out secondDate) &&
                    DateTime.TryParse(model.LiberationDate, out thirdDate))
                {
                    if (thirdDate >= secondDate && thirdDate >= firstDate && secondDate >= firstDate)
                    {
                        return true;
                    }
                    else
                    {
                        this.ErrorMessage = "Не верная последовательность дат";
                    }
                }
               
            }
            return false;
        }
    }
}