using System;
using System.Threading.Tasks;
using _9jaTips.Entities;
using _9jaTips.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace _9jaTips.Services.Utilities
{
    public class MappingProfile : Profile
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IFixtures _fixtures;

        public MappingProfile(UserManager<AppUser> userManager, IFixtures fixtures)
        {
            this.userManager = userManager;
            _fixtures = fixtures;
        }

        public MappingProfile()
        {

            CreateMap<Comment, CommentDto>()
                .ForMember(des => des.Username,
                            act => act.MapFrom(src => GetUsernameAsync(src.AppUserId)))
                .ForMember(des => des.Streak,
                            act => act.MapFrom(src => _fixtures.GetUserStreak(src.AppUserId)))
                .ForMember(dest => dest.UserId,
                            act => act.MapFrom(src => src.AppUserId));

            CreateMap<Post, PostItem>()
                .ForMember(dest => dest.UserId,
                            act => act.MapFrom(src => src.AppUserId))
                .ForMember(dest => dest.Likes,
                            act => act.MapFrom(src => src.Likes.Count))
                .ForMember(dest => dest.Comments,
                            act => act.MapFrom(src => src.Comments.Count));
            CreateMap<Post, PostDetailsDto>()
                .ForMember(dest => dest.UserId,
                            act => act.MapFrom(src => src.AppUserId));
        }

        private async Task<string> GetUsernameAsync(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            var userName = user.Email.Split("@")[0];
            return userName;
        }
    }
}
