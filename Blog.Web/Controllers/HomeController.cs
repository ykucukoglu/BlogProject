using Blog.Service.Services.Abstractions;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IArticleVisitorService _articleVisitorService;

        public HomeController(IArticleService articleService, IArticleVisitorService articleVisitorService)
        {
            _articleService = articleService;
            _articleVisitorService = articleVisitorService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await _articleService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            return View(articles);
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
        public async Task<IActionResult> Detail(Guid id)
        {
            await _articleVisitorService.AddArticleVisitorAsync(id);

            var article = await _articleService.GetAllArticleWithCategoryNonDeletedAsync(id);
            return View(article);
        }
    }
}