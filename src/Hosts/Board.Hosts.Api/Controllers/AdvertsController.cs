using Board.AppServices.Contexts.Adverts.Services;
using Board.Contracts.Adverts;
using Microsoft.AspNetCore.Mvc;

namespace Board.Hosts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController(IAdvertService advertService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateArticle(CreateAdvertDto advert, CancellationToken cancellationToken)
        {
            var id = await advertService.CreateAsync(advert, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, id);
        }
    }
}
