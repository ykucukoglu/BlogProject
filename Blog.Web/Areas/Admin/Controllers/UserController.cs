﻿using AutoMapper;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Blog.Web.ResultMessages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Reflection;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IToastNotification _toastNotification;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IToastNotification toastNotification)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var map = _mapper.Map<List<UserDto>>(users);

            foreach (var user in map)
            {
                var findUser = await _userManager.FindByIdAsync(user.Id.ToString());
                var role = string.Join("", await _userManager.GetRolesAsync(findUser));

                user.Role = role;
            }
            return View(map);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(new UserAddDto { Roles = roles });
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = _mapper.Map<AppUser>(userAddDto);
            var roles = await _roleManager.Roles.ToListAsync();

            if (ModelState.IsValid)
            {
                map.UserName = userAddDto.Email;
                var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
                if (result.Succeeded)
                {
                    var findRole = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                    await _userManager.AddToRoleAsync(map, findRole.ToString());
                    _toastNotification.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    foreach (var errors in result.Errors)
                        ModelState.AddModelError("", errors.Description);
                    return View(new UserAddDto { Roles = roles });
                }
            }
            return View(new UserAddDto { Roles = roles });
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var roles = await _roleManager.Roles.ToListAsync();
            var map = _mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;

            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await _userManager.FindByIdAsync(userUpdateDto.Id.ToString());
            if (user != null)
            {
                var userRole = string.Join("", await _userManager.GetRolesAsync(user));
                var roles = await _roleManager.Roles.ToListAsync();
                if (ModelState.IsValid)
                {
                    _mapper.Map(userUpdateDto, user);
                    user.UserName = userUpdateDto.Email;
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await _userManager.RemoveFromRoleAsync(user, userRole);
                        var findRole = await _roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                        await _userManager.AddToRoleAsync(user, findRole.Name);
                        _toastNotification.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
                        return RedirectToAction("Index", "User", new { Area = "Admin" });
                    }
                    else
                    {
                        foreach (var errors in result.Errors)
                            ModelState.AddModelError("", errors.Description);
                        return View(new UserUpdateDto { Roles = roles });
                    }
                }
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage(Messages.User.Delete(user.Email), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                foreach (var errors in result.Errors)
                    ModelState.AddModelError("", errors.Description);
            }
            return NotFound();
        }
    }
}
