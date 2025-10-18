using Board.AppServices.Specification.Extentions;
using System.Linq.Expressions;

namespace Board.AppServices.Specification.Internal
{
    internal class NotSpecification<TEntity> : Specification<TEntity> // Copied
    {
        /// <inheritdoc />
        public override Expression<Func<TEntity, bool>> PredicateExpression { get; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="NotSpecification{TEntity}"/>.
        /// </summary>
        public NotSpecification(ISpecification<TEntity> specification)
        {
            if (specification == null) throw new ArgumentNullException(nameof(specification));
            PredicateExpression = specification.PredicateExpression.Not();
        }
    }
}
