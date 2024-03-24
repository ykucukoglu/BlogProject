using Blog.Data.UnitOfWorks;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Web.Filters.ArticleVisitors
{
    public class ArticleVisitorFilter : IAsyncActionFilter
    {
        private readonly IArticleVisitorService _articleVisitorService;

        public ArticleVisitorFilter(IArticleVisitorService articleVisitorService)
        {
            _articleVisitorService = articleVisitorService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Ziyaretçi servisini kullanarak ziyaretçiyi ekleyelim
            await _articleVisitorService.AddVisitorIfNotExistsAsync();

            // Sonraki adıma devam edelim
            await next();
        }
    }
}
