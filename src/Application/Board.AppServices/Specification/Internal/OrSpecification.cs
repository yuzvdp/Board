using Board.AppServices.Specification.Extentions;
using System.Linq.Expressions;

namespace Board.AppServices.Specification.Internal
{
    internal class OrSpecification<TEntity> : Specification<TEntity> // Copied
    {
        /// <inheritdoc />
        public override Expression<Func<TEntity, bool>> PredicateExpression { get; }

        /// <summary>
        /// Инициализирует экземпляр спецификации <see cref="OrSpecification{TEntity}"/>.
        /// </summary>
        public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));

            PredicateExpression = left.PredicateExpression.Or(right.PredicateExpression);
        }
    }
}
