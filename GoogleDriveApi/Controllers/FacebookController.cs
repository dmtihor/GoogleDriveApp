using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;
using GoogleDriveApi.Models;
using MemoryCache;
using Newtonsoft.Json.Linq;

namespace GoogleDriveApi.Controllers
{
    public class FacebookController : Controller
    {
        // GET: Facebook
        public ActionResult Index()
        {
            var myAccessToken = "EAACEdEose0cBAKKOhYqQ9gYDhdUJlazT2f8ZAtyj1hXoNlVW3NKJ4bwKsA8B12JypzVLvCePFj9f6LMJGoUJkGSUHzS6coqMm20hm5NKV7XV4kjITCZAkcfZBESbiSCspyOJjoNtaLpSXLT24tz7wAxweoyY2G0imZC9JQxUvd2XeBIMBIQ0Wrobw5NehwwZD";
            var client = new FacebookClient(myAccessToken);

            var friendListData = client.Get("/me/friends");
            var friendListJson = JObject.Parse(friendListData.ToString());

            var fbUsers = new List<FbUser>();

            if (!Cache.Exists("friends"))
            {
                fbUsers = friendListJson["data"].Children().Select(friend => new FbUser
                {
                    Id = friend["id"].ToString().Replace("\"", ""),
                    Name = friend["name"].ToString().Replace("\"", "")
                }).ToList();

                Cache.Store("friends", fbUsers);
            }

            return View();
        }
    }
}