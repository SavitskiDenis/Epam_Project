using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entity;

namespace Special_Insulator.DAL
{
    public class DataAccessLayer : IDataAccessLayer
    {
        public List<Detainee> GetAllDeteinees()
        {
            return new  List<Detainee>
            {
                new Detainee
                {
                    FullName = "Иванов Иван Иванович",
                    BornDate = new DateTime(1971, 1, 1),
                    Status = Marital_status.Divorced,
                    Additional_information = "",
                    Address = "г.Могилев,ул.Ленина,д.17,кв.4",
                    Phone = "+375299113118",
                    Photo = "http://www.garant-barnaul.ru/company_news/news_2015/LoorI.I..jpg",
                    Workplace = "Нет"
                },
                new Detainee
                {
                    FullName = "Павлова Екатериан Степановна",
                    BornDate = new DateTime(1971, 3, 11),
                    Status = Marital_status.Married,
                    Additional_information = "",
                    Address = "г.Могилев,ул.Ленина,д.7,кв.12",
                    Phone = "+375293111734",
                    Photo ="http://old.newcinemaschool.com/upload/iblock/760/76080db7efcfad1e3ce965420c2d64c4.jpg",
                    Workplace = "Нdsfghjkl;lkjhgfdfghjkhdfghgfdghjhgeghjjhreghjk,hrghj"
                }
            };
        }
    }
}
