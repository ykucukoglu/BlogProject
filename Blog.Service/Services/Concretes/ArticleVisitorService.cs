using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concretes
{
    public class ArticleVisitorService : IArticleVisitorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ArticleVisitorService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> AddVisitorIfNotExistsAsync()
        {
            string getIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            string getUserAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];

            var visitor = new Visitor(getIp, getUserAgent);

            var existingVisitor = await _unitOfWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == visitor.IpAddress);

            if (existingVisitor == null)
            {
                await _unitOfWork.GetRepository<Visitor>().AddAsync(visitor);
                await _unitOfWork.SaveAsync();
                return true; // Yeni ziyaretçi eklendi.
            }

            return false; // Ziyaretçi zaten var.
        }

        public async Task<List<ArticleVisitor>> GetArticleVisitorsAsync()
        {
            var articleVisitors = await _unitOfWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x => x.Visitor, y => y.Article);
            return articleVisitors;
        }

        public async Task AddArticleVisitorAsync(Guid id)
        {
            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var articeVisitors = await GetArticleVisitorsAsync();
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.Id == id);
            var visitor = await _unitOfWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress);
            var addArticleVisitors = new ArticleVisitor(article.Id, visitor.Id);
            if (!articeVisitors.Any(x => x.VisitorId == addArticleVisitors.VisitorId && x.ArticleId == addArticleVisitors.ArticleId))
            {
                await _unitOfWork.GetRepository<ArticleVisitor>().AddAsync(addArticleVisitors);
                article.ViewCount += 1;
                await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
                await _unitOfWork.SaveAsync();
            }           
        }
    }
}