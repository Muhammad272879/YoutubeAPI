using Microsoft.AspNetCore.Mvc;
using YouTubeApiProject.Models;
using YouTubeApiProject.Services;

namespace YouTubeApiProject.Controllers
{
    public class YouTubeController : Controller
    {
        private readonly YouTubeApiService _youTubeApiService;

        public YouTubeController(YouTubeApiService youTubeApiService)
        {
            _youTubeApiService = youTubeApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(new List<YouTubeVideoModel>());
            }

            var videos = await _youTubeApiService.SearchVideosAsync(query);
            return View("Index",videos);
        }
    }
}
