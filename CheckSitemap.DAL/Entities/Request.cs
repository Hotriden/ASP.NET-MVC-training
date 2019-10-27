namespace CheckSitemap.DAL.Entities
{
    public class Request
    {
        public int Id { get; set; }

        public string SitemapUrl { get; set; }

        public double TimeRequest { get; set; }

        public Site site { get; set; }
        public int CurrentSiteId {get; set;}
    }
}
