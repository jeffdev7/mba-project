using fast_booze.application.Services.Interfaces;
using fast_booze.application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fast_booze.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [AllowAnonymous]
        [HttpGet("customers")]
        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            return _customerServices.GetCustomers();
        }

        [HttpPost("add-customer")]
        public async Task<ActionResult<CustomerViewModel>> Add([FromBody] CustomerViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var poll = await _customerServices.Add(vm);
            return Ok(poll);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerViewModel>> Update([FromBody] CustomerViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _customerServices.Update(vm);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _customerServices.Remove(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}