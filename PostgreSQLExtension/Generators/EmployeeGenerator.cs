using Bogus;
using PostgreSQLExtension.Models;
using System;
using System.Collections.Generic;

namespace PostgreSQLExtension.Generators
{
    internal class EmployeeGenerator
    {
        private readonly Faker<Employee> employeeFaker;

        public EmployeeGenerator()
        {
            employeeFaker = new Faker<Employee>()
                .RuleFor(o => o.Id, f => Guid.NewGuid())
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.Title, f => f.Name.JobTitle());
        }

        public IList<Employee> Generate(int count)
        {
            return employeeFaker.Generate(count);
        }
    }
}
