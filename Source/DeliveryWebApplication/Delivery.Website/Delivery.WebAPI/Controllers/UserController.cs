using Delivery.BL;
using Delivery.Models;
using Delivery.Validators;
using Microsoft.AspNetCore.Http;
using Delivery.Utils.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Delivery.Models.DTO;
using System.Linq;

namespace Delivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserValidator _userValidator;
        private readonly UpdateUserValidator _updateUserValidator;
        private readonly DeleteUserValidator _deleteUserValidator;

        public UserController(IUserService userService,
                               UserValidator userValidator,
                               UpdateUserValidator updateUserValidator,
                               DeleteUserValidator deleteUserValidator)
        {
            _userService = userService;
            _userValidator = userValidator;
            _updateUserValidator = updateUserValidator;
            _deleteUserValidator = deleteUserValidator;
        }

        /// <summary>
        /// Get list of users
        /// </summary>
        /// <param name="query">A searching field. Returns items containing specified query</param>
        /// <param name="filterField">A filtering field</param>
        /// <param name="sortBy">A sorting field. If not specifies sort by role</param>
        /// <param name="take">A number of items to be returned</param>
        /// <param name="skip">A number of items to skip</param>
        /// <returns></returns>
        /// <remarks>Get list of users</remarks>
        [HttpGet]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync([FromQuery] string query, [FromQuery] UserFilterByEnum? filterField, [FromQuery] UserSortByEnum? sortBy, [FromQuery] int? take, [FromQuery]int? skip)
        {
            var sort = sortBy.HasValue ? sortBy.Value : UserSortByEnum.Role;
            var result = await _userService.GetAllAsync(query, filterField, sort, take, skip);

            if (result != null || Enumerable.Empty<User>() != result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">Id of item to return</param>
        /// <returns></returns>
        /// <remarks>Get user by id</remarks>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="item">New user to create</param>
        /// <returns></returns>
        /// <remarks>Create new user</remarks>
        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] AddUserModel item)
        {
            var result = _userValidator.Validate(item);
            if (result.IsValid)
            {
                int itemId = await _userService.CreateAsync(item);
                return CreatedAtAction(nameof(Get), new { id = itemId }, item);
            }
            else
            {
                return BadRequest(result.Errors.Select(t => t.ErrorMessage));
            }
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id">Id of user to update</param>
        /// <param name="item">Updated user</param>
        /// <returns></returns>
        /// <remarks>Update user</remarks>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserModel item)
        {
            item.Id = id;
            var result = _updateUserValidator.Validate(item);

            if (result.IsValid)
            {
                var updated = await _userService.UpdateAsync(id, item);
                return Ok(updated);
            }
            else
            {
                return BadRequest(result.Errors.Select(t => t.ErrorMessage));
            }
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id">Id of user to delete</param>
        /// <returns></returns>
        /// <remarks>Delete user</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var item = new DeleteUserModel();
            item.Id = id;

            var result = _deleteUserValidator.Validate(item);

            if (result.IsValid)
            {
                await _userService.DeleteAsync(id);
                return Accepted();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
