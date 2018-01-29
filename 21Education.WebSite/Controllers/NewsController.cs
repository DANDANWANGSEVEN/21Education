﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.COMMON;
using _21Education.DATA;
using _21Education.WebSite.ViewModels;
namespace _21Education.WebSite.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class NewsController : Controller
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            return View();
        }
        #region 新闻列表页面
        public ActionResult NewsList(string id)
        {
            var path = RouteData.GetPath();
            var page = RouteData.GetPage();
            return View(NewsListTest(page));
        }

        NewsListViewModel NewsListTest(int page)
        {
            var newsList = new List<MODEL.News>();
            for (int i = 0; i < 1000; i++)
            {
                newsList.Add(new MODEL.News
                {
                    NewsId = i,
                    Title = "新闻标题" + i,
                    Content = "新闻内容新闻内容新闻内容新闻内容新闻内容新闻内容新闻内容新闻内容新闻内容新闻内容新闻内容新闻内容新闻内容新闻内容新闻内容",
                    ImgPath = "/image/about_14.jpg",
                    PubDate = DateTime.Now,
                    ReadCount = 300
                });
            }
            var pagin = new Pagination(pageIndex: page - 1, recordCount: newsList.Count(), pageSize: 6);
            return new NewsListViewModel(newsList.Skip(pagin.PageIndex * pagin.PageSize).Take(pagin.PageSize).ToList())
            {
                Pagination = pagin
            };
        }
        #endregion

        #region 新闻内容页
        public ActionResult NewsContent()
        {
            return View();
        }
        #endregion



    }
}
