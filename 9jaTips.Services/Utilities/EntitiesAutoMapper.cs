using System;
using _9jaTips.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace _9jaTips.Web.Utilities
{
    public class EntitiesAutoMapper
    {
        private readonly UserManager<AppUser> userManager;

        public EntitiesAutoMapper(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public static void InitializeMapper()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.Username, act => act.MapFrom(src => GetUserNameAsync(src.AppUserId)));
            });
        }

        public static string GetUserNameAsync(Guid appUserId)
        {
            return GetUserNameAsync(appUserId);
        }

        public async System.Threading.Tasks.Task<string> GetUsername(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            return user.Email.Split("@")[0];
        }
    }
}
