using fast_booze.application.Services.Interfaces;
using fast_booze.application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fast_booze.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockServices _stockServices;

        public StockController(IStockServices stockServices)
        {
            _stockServices = stockServices;
        }

        [AllowAnonymous]
        [HttpGet("stock")]
        public IEnumerable<StockListViewModel> GetAll()
        {
            return _stockServices.GetStock();
        }

        [HttpPost("add-stock")]
        public async Task<ActionResult<StockViewModel>> Add([FromBody] StockViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var poll = await _stockServices.Add(vm);
            return Ok(poll);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult<StockViewModel>> Update([FromBody] StockViewModel vm)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var user = await _stockServices.Update(vm);
        //    return Ok(user);
        //}
    }
}