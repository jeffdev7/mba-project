using fast_booze.application.Services.Interfaces;
using fast_booze.application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fast_booze.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeverageController : ControllerBase
    {
        private readonly IBeverageServices _beverageServices;

        public BeverageController(IBeverageServices beverageServices)
        {
            _beverageServices = beverageServices;
        }

        [AllowAnonymous]
        [HttpGet("beverages")]
        public async Task<IEnumerable<BeverageViewModel>> GetAll()
        {
            return _beverageServices.GetBeverages();
        }

        [HttpPost("add-beverage")]
        public async Task<ActionResult<BeverageViewModel>> Add([FromBody] BeverageViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var poll = await _beverageServices.Add(vm);
            return Ok(poll);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeverageViewModel>> Update([FromBody] BeverageViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _beverageServices.Update(vm);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _beverageServices.Remove(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}