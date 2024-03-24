using Blog.Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstractions
{
    public interface IArticleVisitorService
    {
        Task<bool> AddVisitorIfNotExistsAsync();
        Task<List<ArticleVisitor>> GetArticleVisitorsAsync();
        Task AddArticleVisitorAsync(Guid id);
    }
}
