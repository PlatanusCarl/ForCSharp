using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

/*
 *（1）只爬取起始网站上的网页 
 *（2）只有当爬取的是html文本时，才解析并爬取下一级URL。
 *（3）相对地址转成绝对地址进行爬取。
 *（4）尝试使用Winform来配置初始URL，启动爬虫，显示已经爬取的URL和错误的URL信息。
 */

namespace SimpleCrawler
{
    public class CrawlEventArgs:EventArgs
    {
        public string url;
        public string status;
    }

    public delegate void CrawlEventHandler(object sender, CrawlEventArgs e);


    public class Crawler
    {
        public event CrawlEventHandler Crawling;

        public Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {

        }

        public void Crawl(string Starturl)
        {
            urls.Clear();
            count = 0;
            Console.WriteLine("开始爬行了.... ");
            urls[Starturl] = false;
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null)
                {
                    Console.WriteLine("url池已空！");
                    break;
                }
                else if (count > 10)
                {
                    Console.WriteLine("url池超额");
                    break;
                }
                Console.WriteLine("爬行" + current + "页面!");
                try {
                    string html = DownLoad(current); // 下载
                    urls[current] = true;
                    count++;
                    Parse(html, current);//解析,并加入新的链接
                    Console.WriteLine("爬行结束");
                    CrawlEventArgs args = new CrawlEventArgs();
                    args.status = "success";
                    args.url = current;
                    Crawling(this, args);
                }
                catch(Exception ex)
                {
                    CrawlEventArgs args = new CrawlEventArgs();
                    args.status = ex.Message;
                    args.url = current;
                    Crawling(this, args);
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string DownLoad(string url)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string html = webClient.DownloadString(url);
            string fileName = count.ToString();
            File.WriteAllText(fileName, html, Encoding.UTF8);
            return html;
        }

        private void Parse(string html, string url)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (!Regex.IsMatch(strRef, @"(.html/?)$")) continue;
                if (strRef.Length == 0) continue;
                string fixedStr = Fix(strRef, url);
                string site = Regex.Match(url, @"^https?://(?<site>[^/:]+(:\d*)?/?)").Groups["site"].Value;
                if (!fixedStr.Contains(site)) continue;
                if (urls[fixedStr] == null) urls[fixedStr] = false;
            }
        }

        private string Fix(string rawStr, string htmlUrl)
        {
            if (rawStr.Contains(@"://")) return rawStr;
            if (rawStr.StartsWith(@"../"))
            {
                string file = rawStr.Substring(3);
                int index = htmlUrl.LastIndexOf("/");
                string site = htmlUrl.Substring(0, index);
                return Fix(file, site);
            }
            if (rawStr.StartsWith(@"./"))
            {
                string file = rawStr.Substring(2);
                return Fix(file, htmlUrl);
            }
            if (rawStr.StartsWith("/"))
            {
                string siteRef = @"^(https?://[^/:]+)(:\d*)?/?";
                string site = Regex.Match(htmlUrl, siteRef).Value;
                if (site.EndsWith("/"))
                    return site + rawStr.Substring(1);
                return site + rawStr;
            }
            int lastIndex = htmlUrl.LastIndexOf("/");
            return htmlUrl.Substring(0, lastIndex) + "/" + rawStr;
        }
    }
}
