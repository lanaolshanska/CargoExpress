using Delivery.BL.Contracts;
using Microsoft.AspNetCore.Mvc;
using Delivery.Models;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.Validators;
using Microsoft.AspNetCore.Http;
using Delivery.Models.DTO;
using System.Linq;
using Delivery.Utils.Enum;

namespace Delivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        private readonly WarehouseValidator _warehouseValidator;
        private readonly UpdateWarehouseValidator _updateWarehouseValidator;
        private readonly DeleteWarehouseValidator _deleteWarehouseValidator;

        public WarehouseController(IWarehouseService warehouseService,
                               WarehouseValidator warehouseValidator,
                               UpdateWarehouseValidator updateWarehouseValidator,
                               DeleteWarehouseValidator deleteWarehouseValidator)
        {
            _warehouseService = warehouseService;
            _warehouseValidator = warehouseValidator;
            _updateWarehouseValidator = updateWarehouseValidator;
            _deleteWarehouseValidator = deleteWarehouseValidator;
        }

        /// <summary>
        /// Get list of warehouses
        /// </summary>
        /// <param name="query">A searching field. Returns items containing specified query</param>
        /// <param name="filterField">A filtering field. Filters items by specified value</param>
        /// <param name="sortBy">A sorting field. If not specifies sort by state</param>
        /// <param name="take">A number of items to be returned</param>
        /// <param name="skip">A number of items to skip</param>
        /// <returns></returns>
        /// <remarks>Get list of warehouses</remarks>
        [HttpGet]
        [ProducesResponseType(typeof(Warehouse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync([FromQuery] string query, [FromQuery]  WarehouseFields? filterField, [FromQuery] WarehouseSortByEnum? sortBy, [FromQuery] int? take, [FromQuery]int? skip)
        {
            var sort = sortBy.HasValue ? sortBy.Value : WarehouseSortByEnum.State;
            var result = await _warehouseService.GetAllAsync(query, filterField, sortBy, take, skip);

            if (result != null || result.Any())
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get values of selected field
        /// </summary>
        /// <param name="field">Name of item field to return. If not specified returns state</param>
        /// <returns></returns>
        /// <remarks>Get values of selected field</remarks>
        [HttpGet]
        [Route("field/{field}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetField([FromRoute] WarehouseFields field)
        {
            var result = await _warehouseService.GetFieldAsync(field);
            if (result != null || result.Any())
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get warehouse by id
        /// </summary>
        /// <param name="id">Id of item to return</param>
        /// <returns></returns>
        /// <remarks>Get warehouse by id</remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Warehouse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _warehouseService.GetByIdAsync(id);
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
        /// Create new warehouse entity
        /// </summary>
        /// <param name="item">New warehouse to create</param>
        /// <returns></returns>
        /// <remarks>Create new warehouse entity</remarks>
        [HttpPost]
        [ProducesResponseType(typeof(Warehouse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] AddWarehouseModel item)
        {
            var result = _warehouseValidator.Validate(item);

            if (result.IsValid)
            {
                int itemId = await _warehouseService.CreateAsync(item);
                return CreatedAtAction(nameof(Get), new { id = itemId }, item);
            }
            else
            {
                return BadRequest(result.Errors.Select(t => t.ErrorMessage));
            }
        }

        /// <summary>
        /// Update warehouse entity
        /// </summary>
        /// <param name="id">Id of warehouse to update</param>
        /// <param name="item">Updated warehouse</param>
        /// <returns></returns>
        /// <remarks>Update warehouse entity</remarks>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Warehouse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateWarehouseModel item)
        {
            item.Id = id;
            var result = _updateWarehouseValidator.Validate(item);

            if (result.IsValid)
            {
                var updated = await _warehouseService.UpdateAsync(id, item);
                return Ok(updated);
            }
            else
            {
                return BadRequest(result.Errors.Select(t => t.ErrorMessage));
            }
        }

        /// <summary>
        /// Delete warehouse entity
        /// </summary>
        /// <param name="id">Id of warehouse to delete</param>
        /// <returns></returns>
        /// <remarks>Delete warehouse entity</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var item = new DeleteWarehouseModel();
            item.Id = id;

            var result = _deleteWarehouseValidator.Validate(item);

            if (result.IsValid)
            {
                await _warehouseService.DeleteAsync(id);
                return Accepted();
            }
            else
            {
                return NotFound();
            }
        }
    }
}