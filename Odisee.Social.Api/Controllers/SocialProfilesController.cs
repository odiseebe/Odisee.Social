using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odisee.Social.Api.Services;
using Odisee.Social.Api.Models;
using Odisee.Social.Api.ViewModels;

namespace Odisee.Social.Api.Controllers
{
    [Route("/[controller]")]
	public class SocialProfilesController : Controller
    {
		private readonly IDataAccessService<SocialProfileViewModel> _socialprofileService;

		public SocialProfilesController(IDataAccessService<SocialProfileViewModel> socialprofileService)
        {
			_socialprofileService = socialprofileService;
        }

		[HttpGet(Name = nameof(GetSocialProfilesAsync))]
		public async Task<IActionResult> GetSocialProfilesAsync(CancellationToken ct)
        {
			var socialprofiles = await _socialprofileService.GetMultipleRecordsAsync(ct);

			var collectionLink = Link.ToCollection(nameof(GetSocialProfilesAsync));
			var collection = new Collection<SocialProfileViewModel>
            {
                Self = collectionLink,
				Value = socialprofiles.ToArray()
            };

            return Ok(collection);
        }

        [HttpGet("{socialprofileId}", Name = nameof(GetSocialProfileByIdAsync))]
		public async Task<IActionResult> GetSocialProfileByIdAsync(int socialprofileId, CancellationToken ct)
        {
			var socialprofile = await _socialprofileService.GetSingleRecordAsync(socialprofileId, ct);
			if (socialprofile == null) return NotFound();

			return Ok(socialprofile);
        }
    }
}
