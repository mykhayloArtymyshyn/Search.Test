using Microsoft.AspNetCore.Mvc;
using Search.Test.Contracts;
using Search.Test.Domain.Interfaces;
using Search.Test.Web.Models;
using System.Diagnostics;

namespace Search.Test.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchService _searchService;

        public HomeController(ISearchService searchService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _searchService = searchService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(SearchRequest request)
        {
            var results = await _searchService.SearchAsync(request.Email, request.Category, request.Query);
            var result = new SearchResponse
            {
                Category = request.Category,
                Query = request.Query,
                Email = request.Email,
                Results = results
            };
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}