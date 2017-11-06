using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayGreeting2
{
    public class CandidatesRepository
    {
        private List<Candidate> list;

        public CandidatesRepository(List<Candidate> list)
        {
            this.list = list;
        }


        public int BirthdayIs(int day, int month)
        {
            return list.Count(c => c.IsThisBirthday(day,month));
        }
    }
}