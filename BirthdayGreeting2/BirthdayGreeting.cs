using System;
using BirthdayGreetingTest.Repository;
using NUnit.Framework;
using System.Collections.Generic;

namespace BirthdayGreeting2
{
    public class BirthdayGreeting
    {
       
        private IRepository repository;
        private ISender sender;

       

        public BirthdayGreeting(IRepository repository, ISender sender)
        {
            this.repository = repository;
            this.sender = sender;
        }

        public void Send(Employee employee)
        {
            sender.Send(employee);
        }

        public List<Candidate> ObtainsCandidateList()
        {
            return repository.ObtainsCandidateList();
        }
    }
}