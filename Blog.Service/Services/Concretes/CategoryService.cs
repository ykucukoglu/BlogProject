using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.DTOs.Categories;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext.User;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);
            return map;
        }

        public async Task CreateCategoryAsync(CategoryAddDto categoryAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            Category category = new(categoryAddDto.Name, userEmail);
            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            await _unitOfWork.SaveAsync();

        }

        public async Task<Category> GetCategoryByGuid(Guid id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(id);
            return category;
        }

        public async Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await _unitOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == categoryUpdateDto.Id);

            category.ModifiedDate = DateTime.Now;
            category.ModifiedBy = userEmail;

            _mapper.Map(category, categoryUpdateDto);

            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();

            return category.Name;
        }

        public async Task<string> SafeDeleteCategoryAsync(Guid categoryId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);

            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;

            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();

            return category.Name;
        }
    }
}
