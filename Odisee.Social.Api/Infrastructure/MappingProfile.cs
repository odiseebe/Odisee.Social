using AutoMapper;
using Odisee.Social.Api.ViewModels;
using Odisee.Social.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Odisee.Social.Api.Models;
using Odisee.Social.Entities;

namespace Odisee.Social.Api.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
			CreateMap<SocialProfile, SocialProfileViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Guid))
				.ForMember(dest => dest.AccessToken, opt => opt.MapFrom(src => src.AccessToken))
                .ForMember(
                    dest => dest.Self, 
                    opt => opt.MapFrom(
						src => Link.To(nameof(SocialProfilesController.GetSocialProfileByIdAsync), new { socialprofileId = src.Id })
                    )
                );
        }
        
    }
}
