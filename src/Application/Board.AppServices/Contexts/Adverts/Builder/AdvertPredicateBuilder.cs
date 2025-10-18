using Board.Domain.Entities;

namespace Board.AppServices.Contexts.Adverts.Builder
{
    public class AdvertPredicateBuilder : IAdvertPredicateBuilder
    {
        private IQueryable<Advert>? query;

        public IQueryable<Advert> Build()
        {
            return query;
        }

        public IAdvertPredicateBuilder OrderbyTitle()
        {
            query = query.OrderBy(x => x.Title);
            return this;
        }

        public IAdvertPredicateBuilder Paginate(int pageNumber, int pageSize)
        {
            query = query.Take(pageNumber).Skip(pageNumber * pageSize);
            return this;
        }
    }
}
