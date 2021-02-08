using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using RestQL.Infrastructure.Database;

namespace RestQL.GraphQL
{
    public class PersonPayload 
    {
        public Guid Id { get; set; }

        public string FirstName {get;set;} = string.Empty;

        public string LastName {get;set;} = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public IEnumerable<Guid> Followings {get; set; } = new List<Guid>();

        public IEnumerable<PersonPayload> GetFollowings(
            [Service] DummyDatabase database)
        {
            return database.Persons
                .Where(p => Followings.Contains(p.Id))
                .Select(p => new PersonPayload
                    {
                        Id = p.Id,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        FullName = p.FullName,
                        Followings = p.Followings,
                    });
        }
    }
}