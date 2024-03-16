using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using Blog.Entity.Enums;
using Blog.Service.Extensions;
using Blog.Service.Helpers.Images;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concretes
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly IImageHelper _imageHelper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext.User;
            _imageHelper = imageHelper;
        }

        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            var imageUpload = await _imageHelper.Upload(articleAddDto.Title, articleAddDto.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName, articleAddDto.Photo.ContentType, userEmail);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);

            var article = new Article(articleAddDto.Title, articleAddDto.Content, userId, userEmail, articleAddDto.CategoryId, image.Id);
            await _unitOfWork.GetRepository<Article>().AddAsync(article);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
            var map = _mapper.Map<List<ArticleDto>>(articles);
            return map;
        }

        public async Task<ArticleDto> GetAllArticleWithCategoryNonDeletedAsync(Guid articleId)
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, i => i.Image);
            var map = _mapper.Map<ArticleDto>(articles);
            return map;

        }

        public async Task<string> UpdataArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category, i => i.Image);
           
            if(articleUpdateDto.Image != null)
            {
                _imageHelper.Delete(article.Image.FileName);
                var imageUpload = await _imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, articleUpdateDto.Photo.ContentType, userEmail);
                await _unitOfWork.GetRepository<Image>().AddAsync(image);
                article.ImageId = image.Id;
            }
            
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;

            string articleTitleBeforeUpdate = article.Title;
            _mapper.Map(article, articleUpdateDto);
            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
            return articleTitleBeforeUpdate;
        }

        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
            return article.Title;
        }
    }
}
