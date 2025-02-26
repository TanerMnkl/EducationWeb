﻿using EducationApp.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Concrete.EfCore.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol Bilgileri
            List<Role> roles = new List<Role>
            {
                new Role { Name="Admin", Description="Yöneticilerin rolü bu.", NormalizedName="ADMIN"},
                new Role { Name="User", Description="Diğer tüm kullanıcıların rolü bu.", NormalizedName="USER"}
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion
            #region Kullanıcı Bilgileri
            List<User> users = new List<User>
            {
                new User
                {
                    FirstName="Taner",
                    LastName="Münüklü",
                    UserName="admin",
                    NormalizedUserName="ADMIN",
                    Email="tanermunuklu5@gmail.com",
                    NormalizedEmail="TANERMUNUKLU5@GMAIL.COM",
                    Gender="ERKEK",
                    DateOfBirth= new DateTime(1998,1,05),
                    Address="İsmet inönü caddesi gülçin sokak",
                    City="İstanbul",
                    EmailConfirmed=true,
                    SecurityStamp="",
                    LockoutEnabled=true
                },new User
                {
					 FirstName="Emre",
					LastName="Candar",
					UserName="admin",
					NormalizedUserName="ADMIN",
					Email="emrecandar@gmail.com",
					NormalizedEmail="EMRECANDAR@GMAIL.COM",
					Gender="ERKEK",
					DateOfBirth= new DateTime(1998,2,19),
					Address="İsmet inönü caddesi gülçin sokak",
					City="İstanbul",
					EmailConfirmed=true,
					SecurityStamp="",
					LockoutEnabled=true
				}
               
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion
            #region Şifre İşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            #endregion
            #region Rol Atama İşlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{ UserId=users[0].Id, RoleId=roles[0].Id },
                new IdentityUserRole<string>{ UserId=users[1].Id, RoleId=roles[1].Id }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion
            #region Alışveriş Sepeti İşlemleri
            List<Cart> carts = new List<Cart>
            {
                new Cart{ Id=1, UserId=users[0].Id},
                new Cart{ Id=2, UserId=users[1].Id}
            };
            modelBuilder.Entity<Cart>().HasData(carts);
            #endregion
        }
    }
}
