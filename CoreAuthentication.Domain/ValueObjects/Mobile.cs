using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAuthentication.Domain.ValueObjects
{
    public class Mobile
    {
        private string _text;
        public Mobile(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new MobileShouldNotBeEmptyException("The 'Mobile' field is required");
            _text = text;
        }
    }
}
