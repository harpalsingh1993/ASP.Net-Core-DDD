using CoreAuthentication.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAuthentication.Domain.User
{
    public class Customer : IEntity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Mobile Mobile { get; private set; }

        public Customer(Name name, Email email, Mobile mobile)
        {
            Id = new Guid();
            Name = name;
            Email = email;
            Mobile = mobile;
        }

        private Customer() { }

        public static Customer Load(Guid id, Name name, Email email, Mobile mobile)
        {
            Customer customer = new Customer
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
