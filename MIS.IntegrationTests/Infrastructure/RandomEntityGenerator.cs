using MIS.Data.Models;
using MIS.IntegrationTests.Base;
using MIS.IntegrationTests.Extensions;

namespace MIS.IntegrationTests.Infrastructure
{
    internal class RandomEntityGenerator //Only user for now
    {
        protected readonly Random rng = new Random();

        /// <summary>
        /// Email and/or Phone and Password
        /// </summary>
        public User User { get => GenerateRandomUser(); }

        protected virtual User GenerateRandomUser()
        {
            User user = new User();
            string rndEmail = rng.NextString(CharachterSets.Alphanumeric, (3, 40)) + "@test.net";
            string rndPhone = '+' + rng.NextString(CharachterSets.Numeric, (11, 14));
            string rndPassword = rng.NextString(CharachterSets.AplhanumericWithSpecialCharacters, (8, 50));

            switch (rng.Next(2))
            {
                case 0:
                    user.Email = rndEmail;
                    user.Phone = rndPhone;
                    user.Password = rndPassword;
                    break;
                case 1:
                    user.Email = rndEmail;
                    user.Password = rndPassword;
                    break;
                case 2:
                    user.Phone = rndPhone;
                    user.Password = rndPassword;
                    break;
            }

            return user;
        }
    }
}
