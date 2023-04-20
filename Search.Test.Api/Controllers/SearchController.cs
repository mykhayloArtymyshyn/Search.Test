using Search.Test.Contracts;
using Microsoft.AspNetCore.Mvc;
using Search.Test.Domain.Interfaces;

namespace Search.Test.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchRequest request)
        {
            var results = await _searchService.SearchAsync(request.Email, request.Category, request.Query);
            var result = new SearchResponse
            {
                Results = results
            };
            return Ok(result);
        }
    }

}