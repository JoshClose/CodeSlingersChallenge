using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using Newtonsoft.Json.Linq;
using CodeSlingers.Web.Models;
using CodeSlingers.Web.Data;

namespace CodeSlingers.Web.Controllers
{
    public class UsersController : Controller
    {
        // AAACWuuQ2bSIBAGIXgUT2oxaMxvkLnGGZBjAMI6WZB8lvjBZAddWuqFexZBD06eLK8sBhHWNvE8nZCG7YCjee6G2ZBmC9xwHZBMZD
        public ActionResult Wines(string accessToken)
        {
            var userId = GetUserIdFromAccessToken(accessToken);
            List<Wine> wines = new List<Wine>();
            using (var session = Db.CreateSession())
            {
                var user = session.Include<User>(u => u.WineIds).Load<User>(userId);
                foreach (var wineId in user.WineIds)
                {
                    wines.Add(session.Load<Wine>(wineId));
                }
            }

            return Json(wines, JsonRequestBehavior.AllowGet);
        }


        public long GetUserIdFromAccessToken(string accessToken)
        {
            RestClient client = new RestClient("https://graph.facebook.com");
            RestRequest request = new RestRequest("me?access_token=" + accessToken, Method.GET);
            return client.Execute<FacebookUser>(request).Data.Id;
        }

    }
}