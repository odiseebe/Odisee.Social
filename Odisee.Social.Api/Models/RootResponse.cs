using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odisee.Social.Api.Models
{
    public class RootResponse : Resource
    {
        public Link SocialProfiles { get; set; }
    }
}
