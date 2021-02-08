using System;
using System.Collections.Generic;
using RestQL.Domain.AggregateModels.Person;

namespace RestQL.Infrastructure.Database
{
    public class DummyDatabase
    {
        private Guid RatanId = Guid.NewGuid();
        private Guid MahedeeId = Guid.NewGuid();
        private Guid KajalId = Guid.NewGuid();
        private Guid HanselmanId = Guid.NewGuid();

        public DummyDatabase()
        {
            SeedRatan();
            SeedMahedee();
            SeedKajal();
            SeedHanselman();  
        }

        private void SeedHanselman()
        {
            var hanselman = new Person(HanselmanId, "Scott", "Hanselman");
            hanselman.FollowPerson(RatanId);
            Persons.Add(hanselman);

        }

        private void SeedKajal()
        {
            var kajal = new Person(KajalId, "Aftab", "Kajal");
            kajal.FollowPerson(RatanId);
            Persons.Add(kajal);
        }

        private void SeedMahedee()
        {
            var mahedee = new Person(MahedeeId, "Mahedee", "Hasan");
            mahedee.FollowPerson(HanselmanId);
            Persons.Add(mahedee);
        }

        private void SeedRatan()
        {
            var ratan = new Person(RatanId, "Ratan Sunder", "Parai");
            ratan.FollowPerson(MahedeeId);
            ratan.FollowPerson(HanselmanId);
            ratan.FollowPerson(KajalId);
            Persons.Add(ratan);
        }

        public List<Person> Persons { get; } = new List<Person>();
    }
}