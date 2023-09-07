using fast_booze.application.Services.Interfaces;
using fast_booze.application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fast_booze.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [AllowAnonymous]
        [HttpGet("orders")]
        public IEnumerable<OrderListViewModel> GetAll()
        {
            return _orderServices.GetOrders();
        }

        [HttpPost("new-order")]
        public async Task<ActionResult<OrderViewModel>> Add([FromBody] OrderViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var poll = await _orderServices.Add(vm);
            return Ok(poll);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _orderServices.Remove(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}