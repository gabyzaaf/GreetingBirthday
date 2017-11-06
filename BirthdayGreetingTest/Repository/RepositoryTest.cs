using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayGreeting2;
using NFluent;
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

        [Test]
        public void Should_Obtains_The_Candidates_List_From_Specific_Birthday()
        {
            // SETUP
            var repository = NSubstitute.Substitute.For<IRepository>();
            var sender = NSubstitute.Substitute.For<ISender>();
            int day = 29;
            int month = 09;
            
            // RUN
            var birthdayGreeting = new BirthdayGreeting(repository, sender);
            repository.ObtainsCandidateList().Returns(new List<Candidate>()
            {
                new Candidate("zaafrani", "Gabriel", "gabriel.zaafrani@tuto.fr", new DateTime(1990, 09, 29)),
                new Candidate("zaafrani", "Michael", "Michael.zaafrani@tuto.fr", new DateTime(1975, 12, 02)),
                new Candidate("zaafrani", "Salomon", "salomon.zaafrani@tuto.fr", new DateTime(1956, 09, 19))

            });
            var candidateRepo = birthdayGreeting.ObtainsCandidateList();
            
            // ARRANGE
            var birthdayNumber = candidateRepo.BirthdayIs(day, month);
            Check.That(birthdayNumber).IsEqualTo(1);

        }
    }
}
