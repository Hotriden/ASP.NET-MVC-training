using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Diagnostics;
using CheckSitemap.BLL.Infrastracture;
using CheckSitemap.DAL.Entities;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CheckSitemap.Test")]
namespace CheckSitemap.BLL.BusinessModels
{
    
    internal class GetSiteMap
    {

        internal List<Request> requests = new List<Request>();

        internal GetSiteMap(string site)
        {
            string requestString = null;
            string response;
            string[] ar;

            if (site == null)
                throw new ValidationException("Input site to check", "");
            else if (site.StartsWith("http"))
            {
                requestString = site;
            }
            else if (site.StartsWith("www"))
            {
                requestString = "https://" + site;
            }
            else
                throw new ValidationException("Site format does not approach to request", "");

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("user-agent", "Googlebot");
                response = webClient.DownloadString(requestString);

                ar = response.Split(new string[] { "<loc>" }, StringSplitOptions.None);

                foreach (string siteUrl in ar)
                {
                    if (siteUrl.StartsWith("http"))
                    {
                        Request _request = new Request();
                        int tegIndex = siteUrl.IndexOf("</loc>");
                        string finalResult = siteUrl.Remove(tegIndex, siteUrl.Length - tegIndex);
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(finalResult);

                        Stopwatch timer = new Stopwatch();
                        timer.Start();
                        HttpWebResponse responce = (HttpWebResponse)request.GetResponse();
                        responce.Close();
                        timer.Stop();
                        TimeSpan timeTaken = timer.Elapsed;

                        double wastertime = Math.Truncate(timeTaken.TotalSeconds * 100) / 100;
                        _request.SitemapUrl = finalResult;
                        _request.TimeRequest = wastertime;

                        requests.Add(_request);
                    }
                }
            }
        }
    }
}