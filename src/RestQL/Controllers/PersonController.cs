using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestQL.Commands;
using RestQL.Domain.AggregateModels.Person;
using RestQL.Infrastructure.Database;

namespace RestQL.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonController
        : ControllerBase
    {
        private readonly DummyDatabase _database;

        public PersonController(DummyDatabase database)
        {
            _database = database ??
                throw new System.ArgumentNullException(nameof(database));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return _database.Persons;
        }

        [HttpGet("{personId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Person> GetById(Guid personId)
        {
            var person = _database
                .Persons
                .SingleOrDefault(p => p.Id == personId);

            if (person is null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult Create([FromBody] CreatePersonCommand command)
        {
            var person = new Person(command.FirstName, command.LastName);
            _database.Persons.Add(person);

            return CreatedAtAction(
                nameof(GetById),
                new { personId = person.Id },
                person);
        }

        [HttpPost("{personId}/follow")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult AddFriend(
            Guid personId,
            [FromBody] FollowPersonCommand command)
        {
            var person = _database
                .Persons
                .SingleOrDefault(p => p.Id == personId);

            if (person is null)
            {
                return NotFound();
            }

            person.FollowPerson(command.FriendId);

            return NoContent();
        }

        [HttpDelete("{personId}/follow")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UnFriend(
            Guid personId,
            [FromBody] UnFollowPersonCommand command)
        {
            var person = _database
                .Persons
                .SingleOrDefault(p => p.Id == personId);

            if (person is null)
            {
                return NotFound();
            }

            person.UnFollowPerson(command.FriendId);

            return NoContent();
        }

    }
}