using Board.AppServices.Contexts.Categories.Interfaces;
using Board.Contracts.Categories;
using Board.Contracts.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Board.Hosts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        /// <summary>
        /// Создать category
        /// </summary>
        /// <param name="category"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Guid</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto category, CancellationToken cancellationToken)
        {
            var id = await categoryService.CreateAsync(category, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, id);
        }

        /// <summary>
        /// Получить category по id
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken"></param>
        /// <returns>CategoryDto</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CreateCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoryById(Guid id, CancellationToken cancellationToken)
        {
            var category = await categoryService.GetByIdAsync(id, cancellationToken);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        /// <summary>
        /// Удалить category по id
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCategory(Guid id, CancellationToken cancellationToken)
        {
            await categoryService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
