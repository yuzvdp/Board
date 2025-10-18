using Board.AppServices.Contexts.Users.Interfaces;
using Board.Contracts.Errors;
using Board.Contracts.Users;
using Board.Domain.RabbitMQMessages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Board.Hosts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    public class UsersController(IUserService userService, IPublishEndpoint publishEndpoint) : ControllerBase
    {
        /// <summary>
        /// Создать User
        /// </summary>
        /// <param name="user">CreateUserDto</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Guid</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUser(CreateUserDto user, CancellationToken cancellationToken)
        {
            var id = await userService.CreateAsync(user, cancellationToken);

            if (id != null)
            {
                // отправляем сообщение кролику!
                await publishEndpoint.Publish<UserCreated>(new
                {
                    user.Username,
                });
            }

            return StatusCode(StatusCodes.Status201Created, id);
        }

        /// <summary>
        /// Получить User по id
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken"></param>
        /// <returns>UserDto</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            var user = await userService.GetByIdAsync(id, cancellationToken);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Удалить User по id
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken"></param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            await userService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
