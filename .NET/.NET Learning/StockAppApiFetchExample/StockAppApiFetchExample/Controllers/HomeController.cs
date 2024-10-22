using Microsoft.AspNetCore.Mvc;
using StockAppApiFetchExample.Models;
using StockAppApiFetchExample.ServiceContracts;
using StockAppApiFetchExample.Services;

namespace StockAppApiFetchExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFinnhubService _finnhubService;
        private readonly IConfiguration _configuration;

        public HomeController(IFinnhubService finnhubService, IConfiguration configuration)
        {
            _finnhubService = finnhubService;
            _configuration = configuration;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            var stockSymbol = _configuration["TradingOptions:DefaultStockSymbol"];

            if (stockSymbol == null)
            {
                stockSymbol = "AAPL";
            }

            var stockData = await _finnhubService.GetStockPrice(stockSymbol);

            Stock stock = new Stock
            {
                StockSymbol = stockSymbol,
                CurrentPrice = Convert.ToDouble(stockData["c"].ToString()),
                HighestPrice = Convert.ToDouble(stockData["h"].ToString()),
                LowestPrice = Convert.ToDouble(stockData["l"].ToString()),
                OpenPrice = Convert.ToDouble(stockData["o"].ToString()),
            };


            return View(stock);
        }
    }
}
