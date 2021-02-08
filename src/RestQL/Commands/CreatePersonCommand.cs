using System.Runtime.Serialization;

namespace RestQL.Commands
{
    public record CreatePersonCommand(
        string FirstName,
        string LastName);
}