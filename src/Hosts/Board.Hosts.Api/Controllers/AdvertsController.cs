using Board.AppServices.Contexts.Adverts.Interfaces;
using Board.Contracts.Adverts;
using Board.Contracts.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Board.Hosts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    public class AdvertsController(IAdvertService advertService) : ControllerBase
    {
        /// <summary>
        /// Создать advert
        /// </summary>
        /// <param name="advert"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Guid</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAdvert(CreateAdvertDto advert, CancellationToken cancellationToken)
        {
            var id = await advertService.CreateAsync(advert, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, id);
        }

        /// <summary>
        /// Получить advert по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>AdvertDto</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AdvertDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAdvertById(Guid id, CancellationToken cancellationToken)
        {
            var advert = await advertService.GetByIdAsync(id, cancellationToken);
            if (advert == null)
            {
                return NotFound();
            }

            return Ok(advert);
        }

        /// <summary>
        /// Удалить advert по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AdvertDto), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAdvert(Guid id, CancellationToken cancellationToken)
        {
            await advertService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
