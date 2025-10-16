using Board.AppServices.Contexts.Adverts.Services;
using Board.Contracts.Adverts;
using Microsoft.AspNetCore.Mvc;

namespace Board.Hosts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController(IAdvertService advertService) : ControllerBase
    {
        /// <summary>
        /// Создать advert
        /// </summary>
        /// <param name="advert"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateArticle(CreateAdvertDto advert, CancellationToken cancellationToken)
        {
            var id = await advertService.CreateAsync(advert, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, id);
        }

        /// <summary>
        /// Получить advert по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AdvertDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public async Task<IActionResult> GetArticleById(Guid id, CancellationToken cancellationToken)
        {
            var article = await advertService.GetByIdAsync(id, cancellationToken);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        /// <summary>
        /// Удалить advert по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AdvertDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public async Task<IActionResult> DeleteArticle(Guid id, CancellationToken cancellationToken)
        {
            await advertService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
