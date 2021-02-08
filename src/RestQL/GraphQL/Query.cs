using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HotChocolate;
using HotChocolate.Types.Relay;
using RestQL.Domain.AggregateModels.Person;
using RestQL.Infrastructure.Database;

namespace RestQL.GraphQL
{
    public class Query
    {
        public IEnumerable<PersonPayload> GetPersons(
            [Service] DummyDatabase database, 
            [Service] IMapper mapper)
        {
            return database.Persons.Select(p => mapper.Map<PersonPayload>(p));
        }

        public PersonPayload? GetPerson(
            Guid personId, 
            [Service] DummyDatabase database,
            [Service] IMapper mapper)
        {
            var person = database.Persons.FirstOrDefault(p => p.Id == personId);

            if (person is null)
            {
                return null;
            }

            return mapper.Map<PersonPayload>(person);
        }
    }
}