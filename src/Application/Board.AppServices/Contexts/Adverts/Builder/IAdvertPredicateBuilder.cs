using Board.Domain.Entities;

namespace Board.AppServices.Contexts.Adverts.Builder
{
    public interface IAdvertPredicateBuilder
    {
        IAdvertPredicateBuilder OrderbyTitle();
        IAdvertPredicateBuilder Paginate(int pageNumber, int pageSize);
        IQueryable<Advert> Build();
    }
}
