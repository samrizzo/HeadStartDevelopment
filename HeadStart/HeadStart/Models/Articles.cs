using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HeadStart.Models
{
    class Articles
    {
        public int ArticleId { get; set; }
        public string AuthorName { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<Articles> GetArticles()
        {
            List<Articles> articleList = new List<Articles>();

            //foreach (var item in db.Articles)
            //{
            //    var article = new Articles
            //    {
            //        ArtcileId = item.ArticleId,
            //        AuthorName = item.AuthorName,
            //        DatePublished = item.DatePublished,
            //        Title = item.Title,
            //        Content = item.Content
            //    };

            //    articleList.Add(article);
            //}

            return articleList;
        }
    }
}