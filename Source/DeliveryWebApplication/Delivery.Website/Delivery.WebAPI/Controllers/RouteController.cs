using Delivery.BL;
using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Utils.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        /// <summary>
        /// Get list of routes
        /// </summary>
        /// <param name="query">A searching field. Returns items containing specified query</param>
        /// <param name="filterField">A filtering field</param>
        /// <param name="sortBy">A sorting field. If not specifies sort by id</param>
        /// <param name="take">A number of items to be returned</param>
        /// <param name="skip">A number of items to skip</param>
        /// <returns></returns>
        /// <remarks>Get list of routes</remarks>
        [HttpGet]
        [ProducesResponseType(typeof(Route), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync([FromQuery] string query, [FromQuery] RouteFilterByEnum? filterField, [FromQuery] RouteSortByEnum? sortBy, [FromQuery]int? skip, [FromQuery] int? take)
        {
            var sort = sortBy.HasValue ? sortBy.Value : RouteSortByEnum.Distance;
            var result = await _routeService.GetAllAsync(query, filterField, sort, take, skip);

            if (result != null || Enumerable.Empty<Route>() != result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get route by id
        /// </summary>
        /// <param name="id">Id of item to return</param>
        /// <returns></returns>
        /// <remarks>Get route by id</remarks>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Route), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _routeService.GetByIdAsync(id);
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
        /// Get route id by warehouses id
        /// </summary>
        /// <param name="origId">Origin warehouse id</param>
        /// <param name="destId">Destination warehouse id</param>
        /// <returns></returns>
        /// <remarks>Get route id by warehouses id</remarks>
        [HttpGet]
        [Route("warehouses/{origId}/{destId}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByWarehousesId([FromRoute] int origId, [FromRoute] int destId)
        {
            var result = await _routeService.GetRouteByWarehousesIdAsync(origId, destId);
            if (result != default(int))
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}