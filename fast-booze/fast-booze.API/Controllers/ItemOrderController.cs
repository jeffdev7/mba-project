using fast_booze.application.Services.Interfaces;
using fast_booze.application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fast_booze.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemOrderController : ControllerBase
    {
        private readonly IItemOrderServices _itemOrderServices;

        public ItemOrderController(IItemOrderServices itemOrderServices)
        {
            _itemOrderServices = itemOrderServices;
        }

        [AllowAnonymous]
        [HttpGet("itemOrders")]
        public async Task<IEnumerable<ItemOrderViewModel>> GetAll()
        {
            return _itemOrderServices.GetItemOrders();
        }

        //[HttpPost("add-itemOrder")]
        //public async Task<ActionResult<ItemOrderViewModel>> Add([FromBody] ItemOrderViewModel vm)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var poll = await _itemOrderServices.Add(vm);
        //    return Ok(poll);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<ItemOrderViewModel>> Update([FromBody] ItemOrderViewModel vm)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var user = await _itemOrderServices.Update(vm);
        //    return Ok(user);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    var status = await _itemOrderServices.Remove(id);
        //    if (!status) return BadRequest();
        //    return Ok(status);
        //}
    }
}