using System;
using System.Linq.Expressions;

namespace Specification
{
    public abstract class AbstractSpecification<T> : ISpecification<T>
    {
        private readonly Expression<Func<T, bool>> _expression;

        protected AbstractSpecification(Expression<Func<T, bool>> expression)
        {
            _expression = expression;
        }

        public static AbstractSpecification<T> CreateDefault => new DefaultSpecification<T>(_ => true);

        public virtual bool IsSatisfiedBy(T obj)
        {
            return _expression.Compile()(obj);
        }

        public Expression<Func<T, bool>> GetExpression()
        {
            return _expression;
        }

        public ISpecification<T> And(ISpecification<T> specification)
        {
            var parameter = Expression.Parameter(typeof (T));

            var leftVisitor = new ReplaceExpressionVisitor(_expression.Parameters[0], parameter);
            var left = leftVisitor.Visit(_expression.Body);

            var rightVisitor = new ReplaceExpressionVisitor(specification.GetExpression().Parameters[0], parameter);
            var right = rightVisitor.Visit(specification.GetExpression().Body);

            var andExpression = Expression.Lambda<Func<T, bool>>(Expression.And(left, right), parameter);
            return new DefaultSpecification<T>(andExpression);
        }

        public ISpecification<T> Or(ISpecification<T> specification)
        {
            var parameter = Expression.Parameter(typeof (T));

            var leftVisitor = new ReplaceExpressionVisitor(_expression.Parameters[0], parameter);
            var left = leftVisitor.Visit(_expression.Body);

            var rightVisitor = new ReplaceExpressionVisitor(specification.GetExpression().Parameters[0], parameter);
            var right = rightVisitor.Visit(specification.GetExpression().Body);

            var orExpression = Expression.Lambda<Func<T, bool>>(Expression.Or(left, right), parameter);
            return new DefaultSpecification<T>(orExpression);
        }

        public ISpecification<T> Not()
        {
            var notExpression = Expression.Lambda<Func<T, bool>>(Expression.Not(_expression.Body), _expression.Parameters[0]);
            return new DefaultSpecification<T>(notExpression);
        }
    }
}