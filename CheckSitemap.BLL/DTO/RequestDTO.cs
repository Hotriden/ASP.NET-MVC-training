namespace CheckSitemap.BLL.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }

        public string SitemapUrl { get; set; }

        public double TimeRequest { get; set; }

        public SiteDTO siteDTO { get; set; }
        public int CurrentSiteId { get; set; }
    }
}
