using SocialNetwork.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;

namespace SocialNetwork.Data.Addons
{
    public class GenetateUsers
    {
        public List<User> Populate(int count)
        {
            var generator = new Faker<User>("ru")
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.BirthDate, f => f.Person.DateOfBirth)
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.UserName, f => f.Person.UserName);

            var users = new List<User>();
            for (int i = 1; i < count; i++)
            {
                var user = generator.Generate();
                user.Image = "https://thispersondoesnotexist.com/image";

                users.Add(user);
            }

            return users;
        }
    }
}
