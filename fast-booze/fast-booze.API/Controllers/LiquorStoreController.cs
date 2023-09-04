using fast_booze.application.Services.Interfaces;
using fast_booze.application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fast_booze.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiquorStoreController : ControllerBase
    {
        private readonly ILiquorStoreServices _liquorStoreServices;

        public LiquorStoreController(ILiquorStoreServices liquorStoreServices)
        {
            _liquorStoreServices = liquorStoreServices;
        }

        [AllowAnonymous]
        [HttpGet("liquorStores")]
        public async Task<IEnumerable<LiquorStoreViewModel>> GetAll()
        {
            return _liquorStoreServices.GetLiquorStores();
        }

        [HttpPost("add-store")]
        public async Task<ActionResult<LiquorStoreViewModel>> Add([FromBody] LiquorStoreViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var poll = await _liquorStoreServices.Add(vm);
            return Ok(poll);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LiquorStoreViewModel>> Update([FromBody] LiquorStoreViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _liquorStoreServices.Update(vm);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _liquorStoreServices.Remove(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}