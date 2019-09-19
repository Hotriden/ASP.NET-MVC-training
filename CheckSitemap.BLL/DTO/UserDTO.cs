using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CheckSitemap.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please check your URL")]
        [RegularExpression(@"\S*\.xml", ErrorMessage = "Link should be end with /sitemap.xml")]
        public string Url { get; set; }

        public double SummaryTime { get; set; }

        public string UserIp { get; set; }

        public DateTime UserTimeRequest { get; set; }
    }
}
