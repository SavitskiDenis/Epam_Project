using System.Collections.Generic;
using SpecialInsulator.Common.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SpecialInsulator.BLL.Implementations;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.DAL.Interfaces;

namespace Special_Insulator.BLL.Tests
{
    [TestClass]
    public class DetaineeBusinessTest
    {
        IDetaineeService business;
        Mock<IDetaineeRepository> data;

        [TestInitialize]
        public void Initialize()
        {
            data = new Mock<IDetaineeRepository>();
            business = new DetaineeService(data.Object);
        }

        [TestMethod]
        public void AddDetainee_NullTest()
        {
            Detainee detainee = null;
            Person person = null;

            var result = business.AddDetainee(person,detainee);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteDetainee_NegativeIdTest()
        {
            int id = -3;

            var result = business.DeleteDetaineeById(id);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetDetaineeById_NullIdTest()
        {
            int? id = null;

            DetaineeWithName result = business.GetDeteineeById(id);

            Assert.AreEqual(result.detainee.Id,0);
        }

        [TestMethod]
        public void GetDetaineeById_Test()
        {
            int id = 1;
            data.Setup(x => x.GetDeteineeById(id)).Returns(new DetaineeWithName(new Detainee { Id=id},new Person()));

            DetaineeWithName result = business.GetDeteineeById(id);

            Assert.AreEqual(result.detainee.Id, id);
        }

        [TestMethod]
        public void EditDetainee_NullDetaineeTest()
        {
            DetaineeWithName detainee = null;

            var result = business.EditDetaineeInfo(detainee);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetAllDetainees_Test()
        {
            List<DetaineeWithName> detainees = null;
            data.Setup(x => x.GetAllDeteinees()).Returns(detainees);

            var result = business.GetAllDetainees();

            Assert.IsNotNull(result);
        }

    }
}
