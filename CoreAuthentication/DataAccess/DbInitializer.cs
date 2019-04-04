using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAuthentication.DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(AEContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            var students = new User[]
               {
                 new User
                 {
                     Username = "hp@123",
                     RefreshToken = Guid.NewGuid().ToString(),
                     Password = "12345"
                 },
               };
            foreach (User s in students)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();
        }
    }
}
