using HelperUtil.Internal;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace HelperUtil
{
    class AbstractChecker<T>
    {
        RuleBuilder builder;
        public AbstractChecker()
        {

        }

        public RuleBuilder Checkfor(Expression<Func<T, DateTime>> expression)
        {
            var oo = expression.GetMember();
            RuleBuilder myBuilder = new RuleBuilder(oo);
            builder = myBuilder;
            return myBuilder;
        }
        public RuleBuilder Checkfor(Expression<Func<T, int>> expression)
        {
            var properties = typeof(Employee).GetProperties()[0];

            var personNameParameter = Expression.Parameter(typeof(string), expression.GetMember().Name);

            //var operation = Expression.Invoke(expression, personNameParameter);

            //var mem = MemberExpression.Invoke( (expression, personNameParameter);
            var oo = expression.GetMember();
            PropertyInfo propertyInfo;

            if (expression.Body is UnaryExpression)
            {
                propertyInfo = ((MemberExpression)((UnaryExpression)expression.Body).Operand).Member as PropertyInfo;
            }
            else
            {
                propertyInfo = ((MemberExpression)expression.Body).Member as PropertyInfo;
            }



            if (propertyInfo == null)
            {
                throw new ArgumentException("The lambda expression 'property' should point to a valid Property");
            }

            string parentClassName = ((MemberInfo)propertyInfo).DeclaringType.Name;
            string propertyName = propertyInfo.Name;
            object propertyValue = expression.Compile();
            string propertyType = propertyInfo.GetMethod.ReturnType.Name; //string, int, double

            RuleBuilder myBuilder = new RuleBuilder(oo);
            builder = myBuilder;
            return myBuilder;
        }

        public int Check(T e)
        {
            DateTime date = new DateTime();
            var property = GetValue(builder.memberInfo, e);

            //if (Type.GetTypeCode(x.GetType()) == TypeCode.Int32)
            //{
            //    builder.propertyValue = (Int32)x;
            //    finalval = builder.expressions[0](builder.propertyValue);
            //}

            if (Type.GetTypeCode(property.GetType()) == TypeCode.DateTime)
            {
                date = builder.expressionsForDate[0]();
            }

            return 0;
        }
        public object GetValue(MemberInfo memberInfo, object forObject)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)memberInfo).GetValue(forObject);
                case MemberTypes.Property:
                    return ((PropertyInfo)memberInfo).GetValue(forObject);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
