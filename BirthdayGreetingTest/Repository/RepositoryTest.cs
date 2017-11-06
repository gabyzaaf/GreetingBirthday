using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayGreeting2;
using NSubstitute;
using NUnit.Framework;

namespace BirthdayGreetingTest.Repository
{
    class RepositoryTest
    {
       

        [Test]
        public void Should_Get_Candidate_List_From_Repository()
        {
            // SETUP
            var repository = NSubstitute.Substitute.For<IRepository>();
            var sender = NSubstitute.Substitute.For<ISender>();
            // RUN
            var birthdayGreeting = new BirthdayGreeting(repository, sender);
            var candidateList = birthdayGreeting.ObtainsCandidateList();
            // ARRANGE
            repository.Received().ObtainsCandidateList();

        }
    }
}
