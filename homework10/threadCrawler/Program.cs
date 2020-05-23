using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
//课堂作业：将上次作业的爬虫程序，使用并行处理进行优化，实现更快速的网页爬取。
namespace threadCrawler
{
    public class CrawlEventArgs : EventArgs
    {
        public string url;
        public string status;
    }

    public delegate void CrawlEventHandler(object sender, CrawlEventArgs e);

    public class Crawler
    {
        public event CrawlEventHandler Crawling;
        public string Starturl = null;
        public ConcurrentQueue<string> urlqueue = new ConcurrentQueue<string>();
        private int count = 0;
        static void Main(string[] args)
        {

        }

        public void Start()
        {
            Console.WriteLine("开始爬行了.... ");
            urlqueue.Enqueue(Starturl);
            List<Task> tasks = new List<Task>();
            while (tasks.Count<100)
            {
                string result;

                if (!urlqueue.TryDequeue(out result))
                {
                    Console.WriteLine("url池已空！");
                    break;
                }
                Crawl(result);
            
                Task task = Task.Run(() => Crawl(result));
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("爬行结束");
        }
        public void Crawl(string current)
        {
            Console.WriteLine("爬行" + current + "页面!");
            count++;
            try
            {
                string html = Download(current); // 下载
                Parse(html, current);//解析,并加入新的链接
                CrawlEventArgs args = new CrawlEventArgs();
                args.status = "success";
                args.url = current;
                Crawling(this, args);
            }
            catch (Exception ex)
            {
                CrawlEventArgs args = new CrawlEventArgs();
                args.status = ex.Message;
                args.url = current;
                Crawling(this, args);
                Console.WriteLine(ex.Message);

            }
        }
            private string Download(string url)
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
            foreach(Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                       .Trim('"', '\"', '#', '>');
                string fixedStr = Fix(strRef, url);
                if (!Regex.IsMatch(strRef, @"(.html/?)$")) continue;
                string site = Regex.Match(url, @"^https?://(?<site>[^/:]+(:\d*)?/?)").Groups["site"].Value;
                if (!fixedStr.Contains(site) || fixedStr == url || fixedStr == site) continue;
                if (!urlqueue.Contains(fixedStr)) urlqueue.Enqueue(fixedStr);
            }
        }

        private string Fix(string rawStr, string htmlUrl)
        {
            if (rawStr.Contains(@"javascript")) return null;
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
