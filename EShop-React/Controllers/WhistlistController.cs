using EShop_React.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EShop_React.Controllers
{
    [Route("api/whistlist")]
    [ApiController]
    [Authorize(Roles = "Admin,Customer")]
    public class WhistlistController : Controller
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetWhishlistForUser(string userId)
        {
            return Ok();
        }

        [HttpPut("add-product-wishlist/{userId}/{whistlistId}/{productId}")]
        public async Task<IActionResult> EditWishlist(string userId, int whistlistId, int productId)
        {
            return Ok();
        }

        [HttpDelete("whistlist-product/{productId}")]
        public async Task<IActionResult> DeleteProductInWhistlist(int productId)
        {
            return Ok();
        }
    }
}
