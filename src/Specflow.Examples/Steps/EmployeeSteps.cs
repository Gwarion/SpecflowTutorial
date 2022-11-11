using Specflow.DomainModel;
using Specflow.DomainModel.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Specflow.Examples.Steps
{
    [Binding, Scope(Feature = "Employee")]
    public class EmployeeSteps
    {
        private Employee _employee;
        private Exception _generatedException;
        private string _fullNameResult;

        [Given(@"The following Employee")]
        public void GivenTheFollowingEmployee(Table table)
        {
            _employee = table.CreateInstance<Employee>();
        }

        [Given(@"An Employee with the firstname '([^']*)' and the lastname '([^']*)'")]
        public void GivenAnEmployeeWithTheFirstnameAndTheLastname(string firstName, string lastName)
        {
            _employee = new()
            {
                FirstName = firstName,
                LastName = lastName
            };
        }

        [Given(@"An Employee with the status '([^']*)' and the rank '([^']*)'")]
        public void GivenAnEmployeeWithTheStatusAndTheRank(string status, string rank)
        {
            _employee = new()
            {
                Status = status.ToEnum<Status>(),
                Rank = rank.ToEnum<Rank>()
            };
        }

        [When(@"I call the method GetfullName")]
        public void WhenICallTheMethodGetfullName()
        {
            try
            {
                _fullNameResult = _employee.GetFullName();
            }
            catch(Exception e)
            {
                _generatedException = e;
            }
        }

        [When(@"I call the method Fire")]
        public void WhenICallTheMethodFire()
        {
            try
            {
                _employee.Fire();
            }
            catch (Exception e)
            {
                _generatedException = e;
            }
        }

        [Then(@"No exception occurs")]
        public void ThenNoExceptionOccurs()
        {
            Assert.Null(_generatedException);
        }

        [Then(@"I get the FullName (.*)")]
        public void ThenIGetTheFullName(string expectedResult)
        {
            Assert.Equal(expectedResult, _fullNameResult);
        }

        [Then(@"An exception of type '([^']*)' occurs")]
        public void ThenAnExceptionOfTypeOccurs(string exceptionType)
        {
            Assert.NotNull(_generatedException);
            Assert.Equal(exceptionType, _generatedException.GetType().Name);
        }
    }
}
