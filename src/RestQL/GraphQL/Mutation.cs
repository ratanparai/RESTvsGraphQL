using System.Linq;
using AutoMapper;
using HotChocolate;
using RestQL.Commands;
using RestQL.Domain.AggregateModels.Person;
using RestQL.Infrastructure.Database;

namespace RestQL.GraphQL
{
    public class Mutation
    {
        public PersonPayload AddPerson(
            CreatePersonCommand command, 
            [Service] DummyDatabase database,
            [Service] IMapper mapper)
        {
            var person = new Person(command.FirstName, command.LastName);
            database.Persons.Add(person);

            return mapper.Map<PersonPayload>(person);
        }

        public PersonPayload? Follow(
            FollowPersonInput input, 
            [Service] DummyDatabase database,
            [Service] IMapper mapper)
        {
            var person = database.Persons.FirstOrDefault(p => p.Id == input.FollowerId);

            if (person is null)
            {
                return null;
            }

            person.FollowPerson(input.FollowedId);

            return mapper.Map<PersonPayload>(person);
        }
    }
}