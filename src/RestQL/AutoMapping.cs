using AutoMapper;
using RestQL.Domain.AggregateModels.Person;
using RestQL.GraphQL;

namespace RestQL
{
    public class AutoMapping
        : Profile
    {
        public AutoMapping()
        {
            CreateMap<Person, PersonPayload>();
            
        }
    }
}