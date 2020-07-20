using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace HelperUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            //EmployeeValidator validations = new EmployeeValidator();
            //var result = validations.Validate(new Employee { Name = "Sumit", Age = 10 });

            EmployeeChecker cherkers = new EmployeeChecker();
            var res = cherkers.Check(new Employee { Name = "Sumit", Age = 10 });

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        public static Func<string, string?> ConstructGreetingExpression()
        {
            var personNameParameter = Expression.Parameter(typeof(string));

            // Condition
            var isNullOrWhiteSpaceMethod = typeof(string)
                .GetMethod(nameof(string.IsNullOrWhiteSpace));

            var condition = Expression.Not(
                Expression.Call(isNullOrWhiteSpaceMethod, personNameParameter));

            // True clause
            var concatMethod = typeof(string)
                .GetMethod(nameof(string.Concat), new[] { typeof(string), typeof(string) });

            var trueClause = Expression.Call(
                concatMethod,
                Expression.Constant("Greetings, "),
                personNameParameter);

            // False clause
            var falseClause = Expression.Constant(null, typeof(string));

            var conditional = Expression.Condition(condition, trueClause, falseClause);

            var lambda = Expression.Lambda<Func<string, string?>>(conditional, personNameParameter);

            return lambda.Compile();
        }
    }

    internal class EmployeeChecker : AbstractChecker<Employee>
    {
        public EmployeeChecker()
        {
            //var x = Checkfor(x => x.Age).add(5);
            var d = Checkfor(x => x.Date).SetEndDate();
            Console.WriteLine(d);
        }
    }

}
