using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace HelperUtil
{
    class RuleBuilder
    {
        public MemberInfo memberInfo;
        public DateTime propertyValueDatetime;
        public List<Func<int, int>> expressionsForInteger = new List<Func<int, int>>();
        public List<Func<string, string>> expressionsForString = new List<Func<string, string>>();
        public List<Func<DateTime>> expressionsForDate = new List<Func<DateTime>>();

        public RuleBuilder(MemberInfo val)
        {
            memberInfo = val;
        }

        public RuleBuilder add(int val)
        {
            var operation = Expression.Add(Expression.Constant(val), Expression.Parameter(typeof(int)));

            expressionsForInteger.Add(Expression.Lambda<Func<int, int>>(operation, Expression.Parameter(typeof(int))).Compile());

            return this;
        }
        public RuleBuilder SetEndDate()
        {
            var defaultdate = Expression.Constant(DateTime.MaxValue);

            expressionsForDate.Add(Expression.Lambda<Func<DateTime>>(defaultdate).Compile());

            return this;
        }
    }
}
