using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using Delivery.Utils.Enum;
using Delivery.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;
        private readonly CargoValidator _cargoValidator;
        private readonly UpdateCargoValidator _updateCargoValidator;
        private readonly DeleteCargoValidator _deleteCargoValidator;

        public CargoController(ICargoService cargoService,
                               CargoValidator cargoValidator,
                               UpdateCargoValidator updateCargoValidator,
                               DeleteCargoValidator deleteCargoValidator)
        {
            _cargoService = cargoService;
            _cargoValidator = cargoValidator;
            _updateCargoValidator = updateCargoValidator;
            _deleteCargoValidator = deleteCargoValidator;
        }

        /// <summary>
        /// Get list of cargos
        /// </summary>
        /// <param name="query">A searching field. Returns items containing specified query</param>
        /// <param name="filterField">A filtering field</param>
        /// <param name="sortBy">A sorting field. If not specifies sort by status</param>
        /// <param name="take">A number of items to be returned</param>
        /// <param name="skip">A number of items to skip</param>
        /// <returns></returns>
        /// <remarks>Get list of cargos</remarks>
        [HttpGet]
        [ProducesResponseType(typeof(Cargo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync([FromQuery] string query, [FromQuery] CargoFilterByEnum? filterField, [FromQuery] CargoSortByEnum? sortBy, [FromQuery]int? skip, [FromQuery] int? take)
        {
            var sort = sortBy.HasValue ? sortBy.Value : CargoSortByEnum.Status;
            var result = await _cargoService.GetAllAsync(query, filterField, sort, take, skip);

            if (result != null || Enumerable.Empty<Cargo>() != result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get cargo by id
        /// </summary>
        /// <param name="id">Id of item to return</param>
        /// <returns></returns>
        /// <remarks>Get cargo by id</remarks>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Cargo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _cargoService.GetByIdAsync(id);
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
        /// Create new cargo
        /// </summary>
        /// <param name="item">New cargo to create</param>
        /// <returns></returns>
        /// <remarks>Create new cargo</remarks>
        [HttpPost]
        [ProducesResponseType(typeof(Cargo), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] AddCargoModel item)
        {
            var result = _cargoValidator.Validate(item);
            if (result.IsValid)
            {
                int itemId = await _cargoService.CreateOrderAsync(item);
                return CreatedAtAction(nameof(Get), new { id = itemId }, item);
            }
            else
            {
                return BadRequest(result.Errors.Select(t => t.ErrorMessage));
            }
        }

        /// <summary>
        /// Update cargo
        /// </summary>
        /// <param name="id">Id of cargo to update</param>
        /// <param name="item">Updated cargo</param>
        /// <returns></returns>
        /// <remarks>Update cargo</remarks>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Cargo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCargoModel item)
        {
            item.Id = id;
            var result = _updateCargoValidator.Validate(item);

            if (result.IsValid)
            {
                var updated = await _cargoService.UpdateAsync(id, item);
                return Ok(updated);
            }
            else
            {
                return BadRequest(result.Errors.Select(t => t.ErrorMessage));
            }
        }

        /// <summary>
        /// Delete cargo
        /// </summary>
        /// <param name="id">Id of cargo to delete</param>
        /// <returns></returns>
        /// <remarks>Delete cargo</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var item = new DeleteCargoModel();
            item.Id = id;
            
            var result = _deleteCargoValidator.Validate(item);

            if (result.IsValid)
            {
                await _cargoService.DeleteAsync(id);
                return Accepted();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
