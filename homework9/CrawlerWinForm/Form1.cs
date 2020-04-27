using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleCrawler;

namespace CrawlerWinForm
{
    public partial class Form1 : Form
    {
        public Dictionary<string, string> urlStatus;
        Crawler crawler;
        public Form1()
        {
            InitializeComponent();
            urlStatus = new Dictionary<string, string>();

            crawler = new Crawler();
            crawler.Crawling += addStatus;

            dataGridView1.DataSource = (from x in urlStatus
                                        select new
                                        {
                                            Key = x.Key,
                                            Value = x.Value
                                        }).ToArray();
        }

        public void addStatus(object sender, CrawlEventArgs e)
        {
            urlStatus[e.url] = e.status;
            dataGridView1.DataSource = (from x in urlStatus
                                        select new
                                        {
                                            Key = x.Key,
                                            Value = x.Value
                                        }).ToArray();
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            string startUrl = urltxt.Text;
            crawler.Crawl(startUrl);
        }
    }
}
