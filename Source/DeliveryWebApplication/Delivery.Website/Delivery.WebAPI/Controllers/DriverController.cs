using Delivery.BL.Contracts;
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
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly DriverValidator _driverValidator;
        private readonly UpdateDriverValidator _updateDriverValidator;
        private readonly DeleteDriverValidator _deleteDriverValidator;

        public DriverController(IDriverService driverService,
                                DriverValidator driverValidator, 
                                UpdateDriverValidator updateDriverValidator,
                                DeleteDriverValidator deleteDriverValidator)
        {
            _driverService = driverService;
            _driverValidator = driverValidator;
            _updateDriverValidator = updateDriverValidator;
            _deleteDriverValidator = deleteDriverValidator;
        }

        /// <summary>
        /// Get list of drivers
        /// </summary>
        /// <param name="query">A searching field. Returns items containing specified query</param>
        /// <param name="filterField">A filtering field</param>
        /// <param name="sortBy">A sorting field. If not specifies sort by status</param>
        /// <param name="take">A number of items to be returned</param>
        /// <param name="skip">A number of items to skip</param>
        /// <returns></returns>
        /// <remarks>Get list of drivers</remarks>
        [HttpGet]
        [ProducesResponseType(typeof(Driver), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync([FromQuery] string query, [FromQuery] DriverFilterByEnum? filterField, [FromQuery] DriverSortByEnum? sortBy, [FromQuery] int? take, [FromQuery]int? skip)
        {
            var sort = sortBy.HasValue ? sortBy.Value : DriverSortByEnum.Status;
            var result = await _driverService.GetAllAsync(query, filterField, sort, take, skip);

            if (result != null || Enumerable.Empty<Driver>() != result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get driver by id
        /// </summary>
        /// <param name="id">Id of item to return</param>
        /// <returns></returns>
        /// <remarks>Get driver by id</remarks>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Driver), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _driverService.GetByIdAsync(id);
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
        /// Get driver by user id
        /// </summary>
        /// <param name="id">Returns driver with specified user id</param>
        /// <returns></returns>
        /// <remarks>Get driver by user id</remarks>
        [HttpGet]
        [Route("user/{id}")]
        [ProducesResponseType(typeof(Driver), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUserId([FromRoute] int id)
        {
            var result = await _driverService.FindByUserIdAsync(id);
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
        /// Create new driver
        /// </summary>
        /// <param name="item">New driver to create</param>
        /// <returns></returns>
        /// <remarks>Create new driver</remarks>
        [HttpPost]
        [ProducesResponseType(typeof(Driver), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] AddDriverModel item)
        {
            var result = _driverValidator.Validate(item);
            if (result.IsValid)
            {
                int itemId = await _driverService.CreateAsync(item);
                return CreatedAtAction(nameof(Get), new { id = itemId }, item);
            }
            else
            {
                return BadRequest(result.Errors.Select(t => t.ErrorMessage));
            }
        }

        /// <summary>
        /// Update driver
        /// </summary>
        /// <param name="id">Id of driver to update</param>
        /// <param name="item">Updated driver</param>
        /// <returns></returns>
        /// <remarks>Update driver</remarks>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Driver), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDriverModel item)
        {
            item.Id = id;
            var result = _updateDriverValidator.Validate(item);

            if (result.IsValid)
            {
                var updated = await _driverService.UpdateAsync(id, item);
                return Ok(updated);
            }
            else
            {
                return BadRequest(result.Errors.Select(t => t.ErrorMessage));
            }
        }

        /// <summary>
        /// Delete driver
        /// </summary>
        /// <param name="id">Id of driver to delete</param>
        /// <returns></returns>
        /// <remarks>Delete driver</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var item = new DeleteDriverModel();
            item.Id = id;

            var result = _deleteDriverValidator.Validate(item);

            if (result.IsValid)
            {
                await _driverService.DeleteAsync(id);
                return Accepted();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
