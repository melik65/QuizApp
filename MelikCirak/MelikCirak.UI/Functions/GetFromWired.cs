using System;
using System.Net;
using HtmlAgilityPack;

namespace MelikCirak.UI.Functions
{
    public class GetFromWired
    {
        public string Content { get; set; }
        public string Url { get; set; }
        public string XPath { get; set; }
        public WebClient Client { get; set; }
        public HtmlDocument Document { get; set; }
        public GetFromWired(string url, string xpath)
        {
            Url = url;
            XPath = xpath;
            Client = new WebClient();
            Document = new HtmlDocument();
        }
        public string GetPost()
        {
            var url = new Uri(Url);
            var html = Client.DownloadString(url);
            Document.LoadHtml(html);
            var data = Document.DocumentNode.SelectNodes(XPath)[0];
            if (data != null)
            {
                return data.InnerText;
            }
            return "Hata, veriler çekilemedi...";
        }
    }
}
