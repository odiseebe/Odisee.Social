using System;

namespace Odisee.Social.Entities
{
    public class SocialProfile
    {
		public int Id { get; set; }
		public string Guid { get; set; }
        public string Name { get; set; }
		public string AccessToken { get; set; }
        public string Platform { get; set; }
    }
}
