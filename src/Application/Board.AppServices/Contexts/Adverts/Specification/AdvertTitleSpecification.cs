using Board.AppServices.Specification;
using Board.Domain.Entities;
using System.Linq.Expressions;

namespace Board.AppServices.Contexts.Adverts.Specification
{
    public class AdvertTitleSpecification(string title) : Specification<Advert>
    {
        public override Expression<Func<Advert, bool>> PredicateExpression =>
        a => a.Title.Contains(title);
    }
}
