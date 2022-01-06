using AspNetApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetApi.Controllers {

    [ApiController]
    [Route("coin-price")]
    public class CoinPriceController : Controller {
        
        private CoinpaprikaAPI.Client coin_client;
        
        public CoinPriceController(ICoinClient coin_client) {
            this.coin_client = coin_client.GetClient;
        }
        
        [HttpGet("get/{name:required}")]
        public async Task<IActionResult> GetCoinInfo(string name) {
            var coins = await coin_client.GetLatestOhlcForCoinAsync(name, "USD");
            if(coins == null || coins.Value == null)
            {
                return StatusCode(500);
            }
            return Ok(coins.Value);
        }

        [HttpGet("getallids")]
        public async Task<IActionResult> GetAllCoinIds() {
            var coins = await coin_client.GetCoinsAsync();
            if(coins == null || coins.Value == null)
            {
                return StatusCode(500);
            }
            return Ok(coins.Value);
        }

    }
}