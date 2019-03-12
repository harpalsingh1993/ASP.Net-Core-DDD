using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAuthentication.Domain.ValueObjects
{
    public class EmailShouldNotBeEmptyException : DomainException
    {
        public EmailShouldNotBeEmptyException(string message) :
            base(message)
        {

        }
    }
}
