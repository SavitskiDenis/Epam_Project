using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Reader;
using SpecialInsulator.Common.SQLExecuter;
using SpecialInsulator.DAL.Interfaces;

namespace SpecialInsulator.DAL.Implementations
{
    public class DetaineeRepository : IDetaineeRepository
    {
        private IPersonRepository personRepository = new PersonRepository();
        private IDetentionRepository detentionRepository = new DetentionRepository();
        private readonly string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

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
                    new SqlParameter("@StatusId",detainee.Status.Id),
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
                detentionRepository.DeleteDetentionByDetaineeId(myId);
                int personId = Executer.ExecuteRead(connectionString,
                                                    "DeleteDetainee",
                                                    new ReadId(),
                                                    new SqlParameter("@Id", id));

                personRepository.DeletePersonById(personId);
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
                    fullList.Add(new DetaineeWithName(item, personRepository.GetPersonById(item.PeopleId))
                                { lastDetention = detentionRepository.GetLastDetentionDateByDetaineeId(item.Id) });

                }
            }
            catch
            {
                return null;
            }
           
            return fullList;
        }

        public DetaineeWithName GetDeteineeById(int? Id)
        {
            Detainee detainee;
            DetaineeWithName withName;
            try
            {
                detainee = Executer.ExecuteRead(connectionString,
                                                "SelectDetaineeById",
                                                new ReadDetainee(),
                                                new SqlParameter("@Id", Id));

                detainee.Detentions = detentionRepository.GetDetentionsByDetaineeId(detainee.Id);
                withName = new DetaineeWithName(detainee, personRepository.GetPersonById(detainee.PeopleId));
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
                    new SqlParameter("@StatusId",detaineeWithName.detainee.Status.Id),
                    new SqlParameter("@Workplace",detaineeWithName.detainee.Workplace),
                    new SqlParameter("@Photo",detaineeWithName.detainee.Photo),
                    new SqlParameter("@Address",detaineeWithName.detainee.Address),
                    new SqlParameter("@AdditionalInformation",detaineeWithName.detainee.AdditionalInformation)
                };

                detaineeWithName.person.Id = detaineeWithName.detainee.PeopleId;
                personRepository.EditPerson(detaineeWithName.person);

                Executer.ExecuteNonQuery(connectionString, "UpdateDetainee", parameters);
                Executer.ExecuteNonQuery(connectionString, 
                                        "UpdatePhone",
                                        new SqlParameter("@DetaineeId", detaineeWithName.detainee.Id),
                                        new SqlParameter("@Number", detaineeWithName.detainee.Phone));
            }
            catch
            {
                return false;
            }
            return true;

        }

    }
}
