using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelperUtil
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Date{ get; set; }
    }

    public class EmployeeValidator : AbstractValidator<Employee> {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name).Length(10);
            RuleFor(x => x.Age).GreaterThan(0);
        }
    }
}
