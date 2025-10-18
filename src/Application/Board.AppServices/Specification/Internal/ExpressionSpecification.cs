using System.Linq.Expressions;

namespace Board.AppServices.Specification.Internal
{
    internal class ExpressionSpecification<TEntity> : Specification<TEntity>
    {
        public ExpressionSpecification(Expression<Func<TEntity, bool>> expression)
        {
            PredicateExpression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        public override Expression<Func<TEntity, bool>> PredicateExpression { get; }
    }
}
