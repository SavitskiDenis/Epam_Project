using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Common.Entity;
using Common.Reader;
using Common.SQLExecuter;

namespace Special_Insulator.DAL
{
    public class DetaineeData : IDetaineeData
    {
        private PersonData personData = new PersonData();
        private DetentionData detentionData = new DetentionData();
        public string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        public bool AddDetainee(Person person, Detainee detainee)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FirstName", person.FirstName),
                    new SqlParameter("@LastName", person.LastName),
                    new SqlParameter("@Patronymic", person.Patronymic)
                };
                var id = Executer.ExecuteScalar(connectionString, "AddPeople", parameters);

                parameters = new SqlParameter[]
                {
                    new SqlParameter("@PeopleId",id),
                    new SqlParameter("@BornDate",detainee.BornDate),
                    new SqlParameter("@Status",detainee.Status),
                    new SqlParameter("@Workplace",detainee.Workplace),
                    new SqlParameter( "@Photo",detainee.Photo),
                    new SqlParameter("@Address",detainee.Address),
                    new SqlParameter("@AdditionalInformation",detainee.AdditionalInformation)
                };
                id = Executer.ExecuteScalar(connectionString, "AddDetainee", parameters);

                Executer.ExecuteNonQuery(connectionString,
                                            "AddPhone",
                                            new SqlParameter("@DetaineeId", id),
                                            new SqlParameter("@Number", detainee.Phone));
            }
            catch
            {
                return false;
            }
            return true;

        }

        public bool DeletDetaineeById(int? id)
        {
            try
            {
                int myId = int.Parse(id.ToString());
                detentionData.DeleteDetentionByDetaineeId(myId);
                int personId = Executer.ExecuteRead(connectionString,
                                                    "Delete_Detainee",
                                                    new ReadId(),
                                                    new SqlParameter("@Id", id));
                personData.DeletePersonById(personId);
            }
            catch
            {
                return false;
            }
            return true;

        }

        public List<DetaineeWithName> GetAllDeteinees()
        {
            List<DetaineeWithName> fullList = new List<DetaineeWithName>();
            try
            {
                List<Detainee> detainees = Executer.ExecuteCollectionRead(connectionString,
                                                                            "SelectAllDetainees",
                                                                            new ReadDetainee(),
                                                                            null);

                foreach (var item in detainees)
                {
                    item.Phone = personData.GetPhoneByDetaineeId(item.Id);
                    fullList.Add(new DetaineeWithName(item, 
                                                        personData.GetPersonById(item.PeopleId)) {
                                                        lastDetention = detentionData.GetLastDetentionDateByDetaineeId(item.Id) });
                }
            }
            catch
            { }
           
            return fullList;
        }

        public DetaineeWithName GetDeteineeById(int? Id)
        {
            Detainee detainee;
            DetaineeWithName withName;
            try
            {
                detainee = Executer.ExecuteRead(connectionString, "SelectDetaineeById", new ReadDetainee(), new SqlParameter("@Id", Id));

                detainee.Detentions = detentionData.GetDetentionsByDetaineeId(detainee.Id);
                detainee.Phone = personData.GetPhoneByDetaineeId(detainee.Id);
                withName = new DetaineeWithName(detainee, personData.GetPersonById(detainee.PeopleId));
            }
            catch
            {
                return null;
            }


            return withName;
        }

        public bool EditDetaineeInfo(DetaineeWithName detaineeWithName)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@Id",detaineeWithName.detainee.Id),
                    new SqlParameter("@PeopleId",detaineeWithName.detainee.PeopleId),
                    new SqlParameter("@BornDate",detaineeWithName.detainee.BornDate),
                    new SqlParameter("@Status",detaineeWithName.detainee.Status),
                    new SqlParameter("@Workplace",detaineeWithName.detainee.Workplace),
                    new SqlParameter("@Photo",detaineeWithName.detainee.Photo),
                    new SqlParameter("@Address",detaineeWithName.detainee.Address),
                    new SqlParameter("@AdditionalInformation",detaineeWithName.detainee.AdditionalInformation)
                };
                detaineeWithName.person.Id = detaineeWithName.detainee.PeopleId;
                personData.EditPerson(detaineeWithName.person);
                Executer.ExecuteNonQuery(connectionString, "UpdateDetainee", parameters);
            }
            catch
            {
                return false;
            }
            return true;

        }

    }
}
