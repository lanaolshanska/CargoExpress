using System.Threading.Tasks;
using Delivery.BL.Contracts;
using Microsoft.AspNetCore.Mvc;
using Delivery.Models;
using Microsoft.AspNetCore.Http;
using Delivery.Utils.Enum;
using Delivery.Models.DTO;
using Delivery.Validators;
using System.Linq;

namespace Delivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ContactValidator _contactValidator;
        private readonly UpdateContactValidator _updateContactValidator;
        private readonly DeleteContactValidator _deleteContactValidator;

        public ContactController(IContactService contactService,
                                ContactValidator contactValidator,
                                UpdateContactValidator updateContactValidator,
                                DeleteContactValidator deleteContactValidator)
        {
            _contactService = contactService;
            _contactValidator = contactValidator;
            _updateContactValidator = updateContactValidator;
            _deleteContactValidator = deleteContactValidator;
        }

        /// <summary>
        /// Get list of contacts
        /// </summary>
        /// <param name="query">A searching field. Returns items containing specified query</param>
        /// <param name="filterField">A filtering field</param>
        /// <param name="sortBy">A sorting field. If not specifies sort by first name</param>
        /// <param name="take">A number of items to be returned</param>
        /// <param name="skip">A number of items to skip</param>
        /// <returns></returns>
        /// <remarks>Get list of contacts</remarks>
        [HttpGet]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync([FromQuery] string query, [FromQuery] ContactFilterByEnum? filterField, [FromQuery] ContactSortByEnum? sortBy, [FromQuery] int? take, [FromQuery]int? skip)
        {
            var sort = sortBy.HasValue ? sortBy.Value : ContactSortByEnum.FirstName;
            var result = await _contactService.GetAllAsync(query, filterField, sort, take, skip);
            
            if (result != null || Enumerable.Empty<Contact>() != result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get Contact by id
        /// </summary>
        /// <param name="id">Id of item to return</param>
        /// <returns></returns>
        /// <remarks>Get Contact by id</remarks>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _contactService.GetByIdAsync(id);
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
        /// Get contact by user id
        /// </summary>
        /// <param name="id">Returns contact with specified user id</param>
        /// <returns></returns>
        /// <remarks>Get contact by user id</remarks>
        [HttpGet]
        [Route("user/{id}")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUserId([FromRoute] int id)
        {
            var result = await _contactService.FindContactByUserIdAsync(id);
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
        /// Create new contact
        /// </summary>
        /// <param name="item">New contact to create</param>
        /// <returns></returns>
        /// <remarks>Create new contact</remarks>
        [HttpPost]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] AddContactModel item)
        {
            var result = _contactValidator.Validate(item);
            if (result.IsValid)
            {
                int itemId = await _contactService.CreateAsync(item);
                return CreatedAtAction(nameof(Get), new { id = itemId }, item);
            }
            else
            {
                return BadRequest(result.Errors.Select(t => t.ErrorMessage));
            }
        }

        /// <summary>
        /// Update contact
        /// </summary>
        /// <param name="id">Id of contact to update</param>
        /// <param name="item">Updated contact</param>
        /// <returns></returns>
        /// <remarks>Update contact</remarks>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateContactModel item)
        {
            item.Id = id;
            var result = _updateContactValidator.Validate(item);

            if (result.IsValid)
            {
                var updated = await _contactService.UpdateAsync(id, item);
                return Ok(updated);
            }
            else
            {
                return BadRequest(result.Errors.Select(t => t.ErrorMessage));
            }
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="id">Id of contact to delete</param>
        /// <returns></returns>
        /// <remarks>Delete contact</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var item = new DeleteContactModel();
            item.Id = id;

            var result = _deleteContactValidator.Validate(item);

            if (result.IsValid)
            {
                await _contactService.DeleteAsync(id);
                return Accepted();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
