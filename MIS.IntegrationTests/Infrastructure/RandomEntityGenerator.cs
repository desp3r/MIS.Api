﻿using MIS.Business.Enums;
using MIS.Data.Models;
using MIS.IntegrationTests.Base;
using MIS.IntegrationTests.Extensions;
using System.Reflection.PortableExecutable;

namespace MIS.IntegrationTests.Infrastructure
{
    internal class RandomEntityGenerator //Only user and employee for now
    {
        protected readonly Random rng = new Random();

        /// <summary>
        /// Email and/or Phone and Password
        /// </summary>
        public User User { get => GenerateRandomUser(); }

        public Employee Employee { get => GenerateRandomEmployee(); }

        protected virtual User GenerateRandomUser()
        {
            string rndEmail = rng.NextString(CharacterSets.Alphanumeric, (3, 40)) + "@test.net";
            string rndPhone = '+' + rng.NextString(CharacterSets.Numeric, (11, 14));
            string rndPassword = rng.NextString(CharacterSets.AplhanumericWithSpecialCharacters, (8, 30));

            return new User()
            {
                Email = rndEmail,
                Phone = rndPhone,
                Password = rndPassword
            };
        }

        protected virtual Employee GenerateRandomEmployee()
        {
            Employee employee = new Employee()
            {
                UserId = new Guid(),
                OrganizationId = new Guid(),
                FirstName = rng.NextString(CharacterSets.Alphabetical, (2, 8)),
                MiddleName = rng.NextString(CharacterSets.Alphabetical, (2, 8)),
                LastName = rng.NextString(CharacterSets.Alphabetical, (2, 8)),
                EmployeeType = (EmployeeType)rng.Next(Enum.GetNames(typeof(EmployeeType)).Length),
                WorkingExpYears = rng.Next(60)
            };
            
            return employee;
        }
    }
}
