using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Odisee.Social.DAL;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Odisee.Social.Api.ViewModels;

namespace Odisee.Social.Api.Services
{
	public class DefaultSocialProfileService : IDataAccessService<SocialProfileViewModel>
    {
		private readonly SocialContext _context;

		public DefaultSocialProfileService(SocialContext context)
        {
            _context = context;
        }

		public async Task<SocialProfileViewModel> GetSingleRecordAsync(int id, CancellationToken ct)
        {
			var entity = await _context.SocialProfiles.SingleOrDefaultAsync(p => p.Id == id, ct);
            if (entity == null) return null;

			return Mapper.Map<SocialProfileViewModel>(entity);
        }

		public async Task<IEnumerable<SocialProfileViewModel>> GetMultipleRecordsAsync(CancellationToken ct)
        {
			var query = _context.SocialProfiles
			                    .ProjectTo<SocialProfileViewModel>();

            return await query.ToArrayAsync();
        }
    }
}
