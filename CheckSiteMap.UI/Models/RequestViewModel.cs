using System.Runtime.Serialization;

namespace CheckSiteMap.UI.Models
{
    [DataContract]
    public class RequestViewModel
    {
        public int Id { get; set; }

        [DataMember(Name = "label")]
        public string SitemapUrl { get; set; }

        [DataMember(Name = "y")]
        public double TimeRequest { get; set; }
    }
}