using BooksApp.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data.Concrete.EfCore.Extensions
{
    public static class ModelBuilderExtension 
    {
        public static void SeedData(this ModelBuilder modelBuilder)  /*bu sayede benim model builderimda çalışacak bir metot hazırlıyoru.*/
        {
            #region Rol Bilgileri
            List<Role> roles = new List<Role>
            {
                new Role { Id="1", Name="Admin", Description="Yöneticilerin rolü bu.", NormalizedName="ADMIN"},
                new Role { Id="2", Name="User", Description="Diğer tüm kullanıcıların rolü bu.", NormalizedName="USER"}
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion
            #region Kullanıcı Bilgileri
            List<User> users = new List<User>
            {
                new User
                {
                    Id="1",
                    FirstName="Deniz",
                    LastName="Foça",
                    UserName="deniz",
                    NormalizedUserName="DENIZ",
                    Email="denizfoca@gmail.com",
                    NormalizedEmail="DENIZFOCA@GMAIL.COM",
                    Gender="Kadın",
                    DateOfBirth= new DateTime(1985,7,12),
                    Address="Kemalpaşa Mh. Zühtübey Sk. No:12 D:3 Üsküdar",
                    City="İstanbul",
                    EmailConfirmed=true
                },
                new User
                {
                    Id="2",
                    FirstName="Murat",
                    LastName="Kendirli",
                    UserName="murat",
                    NormalizedUserName="MURAT",
                    Email="muratkendirli@gmail.com",
                    NormalizedEmail="MURATKENDIRLI@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth= new DateTime(1983,9,10),
                    Address="Barbaros Bulvarı Feda İş Hanı K:5 D:23 Beşiktaş",
                    City="İstanbul",
                    EmailConfirmed=true
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
                new IdentityUserRole<string>{ UserId="1", RoleId="1" },
                new IdentityUserRole<string>{ UserId="2", RoleId="2" }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion
            #region Alışveriş Sepeti İşlemleri

            #endregion


        }

    }
}
