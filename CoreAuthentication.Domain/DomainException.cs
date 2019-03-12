using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAuthentication.Domain
{
    public class DomainException: Exception
    {
        public DomainException(string bussinessMessage): 
            base(bussinessMessage)
        {

        }
    }
}
