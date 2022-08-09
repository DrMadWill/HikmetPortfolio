using HikmetRecebli.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HikmetRecebli.Data
{
    public static class AppDbIntailazer
    {

        public const string DefaultRole = "Admin";
        public const string DefaultUserName = "HikmetRecebli";
        public const string DefaultEmail = "rajalorem@gmail.com";
        public const string DefaultPassword = "HelloLalorem1";
        public static async Task<bool> SeedDefaultUserAndRoleAysnc(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            IdentityResult roleCreated;
            if(await roleManager.FindByNameAsync(DefaultRole) == null)
            {
                var defaultRole = new IdentityRole
                {
                    Name = DefaultRole
                };
                roleCreated = await roleManager.CreateAsync(defaultRole);
            }
            else
            {
                roleCreated = IdentityResult.Success;
            }

            IdentityResult userCreated = IdentityResult.Failed();
            if(roleCreated == IdentityResult.Success)
            {
                if(await userManager.FindByEmailAsync(DefaultEmail) == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = DefaultUserName,
                        Email = DefaultEmail,
                    };

                    var result = await userManager.CreateAsync(user,DefaultPassword);
                    if (result.Succeeded)
                    {
                        userCreated = await userManager.AddToRoleAsync(user, DefaultRole);
                    }
                }
            }
            return userCreated.Succeeded;
        }


        public static void SeedDataAdd(ModelBuilder builder)
        {

            builder.Entity<Portfolio>()
                .HasData(
                    new Portfolio
                    {
                        Id = 1,
                        Image = "https://images.unsplash.com/photo-1498050108023-c5249f4df085?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80",
                        Name = "Testing",
                        Link = "https://www.youtube.com/watch?v=A1kzr5ldsbU&list=RDR59wcejIp0c&index=12"
                    },
                    new Portfolio
                    {
                        Id = 2,
                        Image = "https://images.unsplash.com/photo-1498050108023-c5249f4df085?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80",
                        Name = "Testing",
                        Link = "https://www.youtube.com/watch?v=A1kzr5ldsbU&list=RDR59wcejIp0c&index=12"
                    },
                    new Portfolio
                    {
                        Id = 3,
                        Image = "https://images.unsplash.com/photo-1498050108023-c5249f4df085?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80",
                        Name = "Testing",
                        Link = "https://www.youtube.com/watch?v=A1kzr5ldsbU&list=RDR59wcejIp0c&index=12"
                    }
                );

            builder.Entity<Address>()
                .HasData(
                    new Address
                    {
                        Id = 1,
                        Email = "iamrajabli@outlook.com",
                        Number = "+994 55 233 19 19",
                        Location = "Azerbaijan, Baku, AZ1000",
                    }
                );

            builder.Entity<OnlineAddress>()
                .HasData(
                    new OnlineAddress { Id = 1 ,Name = "Git Hub",Link = "https://github.com/iamrajabli", Icon= "<i class='fa-brands fa-github'></i>", AddressId = 1 },
                    new OnlineAddress { Id = 2 ,Name = "LinkedIn",Link = "https://linkedin.com/in/iamrajabli", Icon= "<i class='fa-brands fa-linkedin'></i>", AddressId = 1 },
                    new OnlineAddress { Id = 3 ,Name = "Facebook",Link = "https://facebook.com/iamrajabli", Icon= "<i class='fa-brands fa-facebook-square'></i>", AddressId = 1 },
                    new OnlineAddress { Id = 4 ,Name = "Hacker Rank",Link = "https://hackerrank.com/iamrajabli", Icon= "<i class='fa-brands fa-hackerrank'></i>", AddressId = 1 }
                );


        } 
    }
}
