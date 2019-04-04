using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAuthentication.Domain.User
{
    public interface IUserRespository
    {
        bool CreateUser(User user);
    }
}
