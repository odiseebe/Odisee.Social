using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Odisee.Social.Api.Models;

namespace Odisee.Social.Api.ViewModels
{
    public class SocialProfileViewModel : Resource
    {
		public string Guid { get; set; }
        public string Name { get; set; }
		public string AccessToken { get; set; }
        public string Platform { get; set; }
    }
}
