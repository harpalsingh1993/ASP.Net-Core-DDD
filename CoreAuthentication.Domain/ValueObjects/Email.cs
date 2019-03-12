using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAuthentication.Domain.ValueObjects
{
    public sealed class Email
    {
        private string _text;
        public Email(string text)
        {

            if (string.IsNullOrWhiteSpace(text))
                throw new EmailShouldNotBeEmptyException("The 'Mobile' field is required");
            _text = text;
        }

        public static implicit operator Email(string text)
        {
            return new Email(text);
        }

        public static implicit operator string(Email email)
        {
            return email._text;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is string)
            {
                return obj.ToString() == _text;
            }

            return ((Email)obj)._text == _text;
        }
    }
}
