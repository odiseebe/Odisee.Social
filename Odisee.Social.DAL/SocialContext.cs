using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Odisee.Social.Entities;

namespace Odisee.Social.DAL
{
	public class SocialContext : DbContext
    {
		public DbSet<SocialProfile> SocialProfiles { get; set; }

		public SocialContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			
        }
    }
}
