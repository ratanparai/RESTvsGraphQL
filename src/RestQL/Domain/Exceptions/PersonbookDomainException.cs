using System;

namespace RestQL.Domain.Exceptions
{
    public class PersonbookDomainException
        : Exception
    {
        public PersonbookDomainException()
        {
            
        }

        public PersonbookDomainException(string message)
            : base(message)
        {
            
        }

        public PersonbookDomainException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }
    }
}