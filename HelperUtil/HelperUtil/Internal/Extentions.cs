using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace HelperUtil.Internal
{
    public static class Extentions
    {
        /// <summary>
        /// Gets a MemberInfo from a member expression.
        /// </summary>
        public static MemberInfo GetMember(this LambdaExpression expression)
        {
            var memberExp = RemoveUnary(expression.Body) as MemberExpression;

            if (memberExp == null)
            {
                return null;
            }

            return memberExp.Member;
        }

        private static Expression RemoveUnary(Expression toUnwrap)
        {
            if (toUnwrap is UnaryExpression)
            {
                return ((UnaryExpression)toUnwrap).Operand;
            }

            return toUnwrap;
        }
    }
}
