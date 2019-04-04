using CoreAuthentication.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAuthentication.Domain.User
{
    public class User : IEntity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Mobile Mobile { get; private set; }

        public User(Name name, Email email, Mobile mobile)
        {
            Id = new Guid();
            Name = name;
            Email = email;
            Mobile = mobile;
        }

        private User() { }

        public static User Load(Guid id, Name name, Email email, Mobile mobile)
        {
            User customer = new User
            {
                Id = id,
                Name = name,
                Mobile = mobile,
                Email = email
            };
            return customer;
        }
    }
}
