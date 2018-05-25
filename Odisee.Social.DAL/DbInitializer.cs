using System;
using System.Linq;
using Odisee.Social.Entities;

namespace Odisee.Social.DAL
{
    public static class DbInitializer
    {
		public static void Initialize(SocialContext context)
        {
            context.Database.EnsureCreated();

            // Look for any projects, if no projects where found seed the table
			if (!context.SocialProfiles.Any())
            {
                // Add data
				context.SocialProfiles.AddRange(
					new SocialProfile { Guid = "623091631112347", Name = "Odisee Hogeschool", Platform = "Facebook" },
					new SocialProfile { Guid = "270772759757245", Name = "Bachelor Agro- en biotechnologie", Platform = "Facebook" },
					new SocialProfile { Guid = "1489942714607341", Name = "Sociaal werk - Odisee", Platform = "Facebook" }
                );
            }

            context.SaveChanges();
        }
    }
}
