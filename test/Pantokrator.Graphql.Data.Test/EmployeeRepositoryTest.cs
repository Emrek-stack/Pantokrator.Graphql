using System;
using NSubstitute;
using NUnit.Framework;
using Pantokrator.Graphql.Data.Repository;

namespace Pantokrator.Graphql.Data.Test
{
    [TestFixture]
    public class EmployeeRepositoryTest
    {
        private IEmployeeRepository _employeeRepository;

        [SetUp]
        public void Setup()
        {
            _employeeRepository = Substitute.For<IEmployeeRepository>();
        }

        [Test]
        public void Is_Employee_Not_Null()
        {
            var data = _employeeRepository.GetAll();
        }
    }
}
