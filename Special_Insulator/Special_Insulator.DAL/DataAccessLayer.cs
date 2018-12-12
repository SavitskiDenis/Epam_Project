using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entity;

namespace Special_Insulator.DAL
{
    public class DataAccessLayer : IDataAccessLayer
    {
        public string connectionString = @"Data Source=.\;Initial Catalog=SIDb;Integrated Security=True";
        public List<DetaineeWithName> GetAllDeteinees()
        {
            List<Person> people = new List<Person>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM [People]";

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read()) 
                    {
                        people.Add(new Person { Id= (int)reader.GetValue(0), FirstName = (string)reader.GetValue(1), LastName = (string)reader.GetValue(2) });
                    }
                }

                reader.Close();
            }




            return new List<DetaineeWithName>
            {
                new DetaineeWithName(new Detainee
                    {
                    People_Id = 1,
                    BornDate = new DateTime(1971, 1, 1),
                    Status = "Женат",
                    Additional_information = "",
                    Address = "г.Могилев,ул.Ленина,д.17,кв.4",
                    Phone = "+375299113118",
                    Photo = "http://www.garant-barnaul.ru/company_news/news_2015/LoorI.I..jpg",
                    Workplace = "Нет"
                    },   people[0]),

                new DetaineeWithName(new Detainee
                {
                    People_Id = 2,
                    BornDate = new DateTime(1971, 3, 11),
                    Status = "Замужем",
                    Additional_information = "",
                    Address = "г.Могилев,ул.Ленина,д.7,кв.12",
                    Phone = "+375293111734",
                    Photo ="http://old.newcinemaschool.com/upload/iblock/760/76080db7efcfad1e3ce965420c2d64c4.jpg",
                    Workplace = "Нdsfghjkl;lkjhgfdfghjkhdfghgfdghjhgeghjjhreghjk,hrghj"
                }
                    ,  people[1] )
             };  
        }
    }
}
