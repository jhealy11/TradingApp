using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Trading.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellStockController : ControllerBase
    {
        public async Task<IActionResult> SellStock()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
