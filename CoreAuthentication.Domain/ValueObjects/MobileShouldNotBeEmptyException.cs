using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAuthentication.Domain.ValueObjects
{
    public class MobileShouldNotBeEmptyException : DomainException
    {
        public MobileShouldNotBeEmptyException(string message) :
            base(message)
        {

        }
    }
}
