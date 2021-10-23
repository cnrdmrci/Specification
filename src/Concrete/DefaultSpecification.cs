using System;
using System.Linq.Expressions;

namespace Specification
{
    public class DefaultSpecification<T> : AbstractSpecification<T>
    {
        public DefaultSpecification(Expression<Func<T, bool>> expression) : base(expression)
        {
        }
    }
}