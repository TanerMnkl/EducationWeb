﻿using AspNetCoreHero.ToastNotification.Abstractions;
using EducationApp.Business.Abstract;
using EducationApp.Entity.Concrete;
using EducationApp.MVC.EmailServices.Abstract;
using EducationApp.MVC.Extensions;
using EducationApp.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationApp.MVC.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly INotyfService _notify;
        private readonly IEmailSender _smtpEmailSender;
        private readonly ICartService _cartManager;
        private readonly IOrderService _orderManager;


        public AccountController(UserManager<User> userManager, INotyfService notify, SignInManager<User> signInManager, IEmailSender smtpEmailSender, ICartService cartManager, IOrderService orderManager)
        {
            _userManager = userManager;
            _notify = notify;
            _signInManager = signInManager;
            _smtpEmailSender = smtpEmailSender;
            _cartManager = cartManager;
            _orderManager = orderManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            LoginViewModel model = new LoginViewModel
            {
                IsPersistent = true,
                ReturnUrl = returnUrl
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    _notify.Error("Giriş bilgilerinde hata var, yeniden deneyiniz!");
                    return View(model);
                }
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.IsPersistent, true);
                if (result.Succeeded)
                {
                    _notify.Success("Başarıyla giriş yaptınız!");

                    return Redirect(model.ReturnUrl ?? "~/");
                }
                else if (result.IsLockedOut)
                {
                    var sure = _signInManager.Options.Lockout.DefaultLockoutTimeSpan.TotalMinutes;
                    _notify.Warning($"Hesabınız kilitlenmiştir. {sure} dakika sonra yeniden deneyiniz.");
                    return View(model);
                }
                else
                {
                    var kalanHak = _signInManager.Options.Lockout.MaxFailedAccessAttempts - await _userManager.GetAccessFailedCountAsync(user);
                    _notify.Warning($"{kalanHak} kez deneme hakkınız kaldı, hesabınız kilitlenecektir.");
                    return View(model);
                }
            }
            _notify.Error("Giriş bilgilerinde hata var, yeniden deneyiniz!");
            return View(model);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    
                    await _userManager.AddToRoleAsync(user, "User");
                    //Kayıt olan kullanıcıya bir cart oluşturmamız gerek.
                    await _cartManager.InitializeCart(user.Id);

                    _notify.Success("Kayıt işlemi başarıyla tamamlandı.Giriş yapabilirsiniz.");
                    return RedirectToAction("Login");
                }
                _notify.Error("Bir hata oluştu, yeniden deneyiniz.");
            }
            return View(model);
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {

                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    _notify.Success("Hesabınız başarıyla onaylanmıştır.");

                    return RedirectToAction("Login");
                }
            }
            _notify.Error("Bir sorun oluştu, lütfen admine başvurunuz.");
            //return RedirectToAction("Index", "Home");
            return Redirect("~/");
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (email == null)
            {
                ViewBag.EmailErrorMessage = "Lütfen mail adresinizi boş bırakmayınız";
                return View();
            }
            User user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ViewBag.EmailErrorMessage = "Böyle bir kullanıcı bulunamadı";
                return View();
            }
            #region Şifre Sıfırlama Maili Gönderme

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });

            var subject = "EducationApp Şifre Sıfırlama";
            var body = $"<h1>EducationApp Şifre Sıfırlama İşlemi</h1>" +
                $"<p>" +
                $"Lütfen şifrenizi değiştirmek için <a href='http://localhost:5200{url}'>tıklayınız</a>." +
                $"</p>";
            await _smtpEmailSender.SendEmailAsync(email, subject, body);
            #endregion
            _notify.Information("Mailinize iletilen link ile Şifrenizi değiştirin");
            return RedirectToAction("Login");
        }
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                _notify.Error("Bir sorun oluştu");
                return Redirect("~/");
            }
            User user = await _userManager.FindByIdAsync(userId);
            ResetPasswordViewModel model = new ResetPasswordViewModel
            {
                UserId = userId,
                Token = token
            };
            return View(model);
        }
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    _notify.Warning("Kullanıcı bulunamadı.");
                    return View();
                }
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    _notify.Success("Şifreniz başarıyla değiştirildi.");
                    return RedirectToAction("Login");
                }
            }
            _notify.Warning("Bir sorun oluştu.");
            return View();
        }
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<IActionResult> MyAccount(string id)
        {
            string name = id;
            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            User user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            List<SelectListItem> genderSelectList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="Kadın",
                    Value="Kadın",
                    Selected=user.Gender=="Kadın" ? true : false
                },
                new SelectListItem
                {
                    Text="Erkek",
                    Value="Erkek",
                    Selected=user.Gender=="Erkek" ? true : false
                }
            };
            DateTime today = DateTime.Now;
            int day = today.Day;
            int month = today.Month;
            int year = today.Year - 18;
            DateTime minDateOfBirth = new DateTime(year, month, day);
            UserAccountViewModel model = new UserAccountViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth == null ? minDateOfBirth : ((DateTime)user.DateOfBirth),
                UserName = user.UserName,
                Address = user.Address,
                City = user.City,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                GenderSelectList = genderSelectList
            };
            List<Order> orders = await _orderManager.GetAllOrdersAsync(user.Id, true);
            List<OrderViewModel> orderViewModels = orders.Select(o => new OrderViewModel
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                City = o.City,
                Address = o.Address,
                PhoneNumber = o.PhoneNumber,
                Email = o.Email,
                OrderDate = o.OrderDate,
                OrderItems = o.OrderItems,
                OrderStatus = o.OrderStatus.GetDisplayName()

            }).ToList();
            model.Orders = orderViewModels;
            return View(model);
        }
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public async Task<IActionResult> MyAccount(UserAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return NotFound();
                }
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Gender = model.Gender;
                user.DateOfBirth = model.DateOfBirth;
                user.UserName = model.UserName;
                user.Address = model.Address;
                user.City = model.City;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    _notify.Success("Profiliniz başarıyla güncellenmiştir.");
                    //await _signInManager.SignOutAsync();
                    await _signInManager.RefreshSignInAsync(user);
                    return RedirectToAction("Index", "Home");
                }

            }
            _notify.Warning("Bir sorun oluştu");
            List<SelectListItem> genderSelectList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="Kadın",
                    Value="Kadın",
                    Selected=model.Gender=="Kadın" ? true : false
                },
                new SelectListItem
                {
                    Text="Erkek",
                    Value="Erkek",
                    Selected=model.Gender=="Erkek" ? true : false
                }
            };
            model.GenderSelectList = genderSelectList;
            return View(model);


        }
    }
}
