using System;
using System.Collections.Generic;
using RestQL.Domain.Exceptions;

namespace RestQL.Domain.AggregateModels.Person
{
    public class Person
    {

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            Id = Guid.NewGuid();
            _followings = new List<Guid>();
        }

        public Person(Guid id, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            Id = id;
            _followings = new List<Guid>();
        }

        public Guid Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string FullName 
        {
            get 
            {
                return $"{FirstName} {LastName}";
            }
        }

        public IEnumerable<Guid> Followings => _followings.AsReadOnly();

        private readonly List<Guid> _followings;

        public void FollowPerson(Guid personId)
        {
            if (_followings.Contains(personId))
            {
                throw new PersonbookDomainException(
                    $"You are already friend with the person with Id {personId}");
            }

            _followings.Add(personId);
        }

        public void UnFollowPerson(Guid personId)
        {
            if(!_followings.Contains(personId))
            {
                throw new PersonbookDomainException(
                    $"You are not friend with the person with Id {personId}");
            }

            _followings.Remove(personId);
        }
    }
}