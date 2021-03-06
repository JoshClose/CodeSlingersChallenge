﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using RestSharp;
using CodeSlingers.WP7.App.Models;
using System.Collections.Generic;
using CodeSlingers.Web.Models;
using System.Linq;
namespace CodeSlingers.WP7.App.Proxies
{
    public class UserProxy
    {
         private readonly RestClient _restClient;

        public UserProxy()
        {
            _restClient = new RestClient();
        }

        public void GetWinesByUser(string accessToken, Action<IList<WineModel>> callback)
        {
            string requestUrl = string.Format("{0}/Users/Wines?accessToken=" + accessToken, Globals.ServiceHostUrl);
            var request = new RestRequest(requestUrl, Method.GET);

            _restClient.ExecuteAsync<List<Wine>>(request, (response) =>
            {
                List<Wine> wines = response.Data;
                IList<WineModel> businessModels = wines.Select(w => Mapper.Map(w)).ToList();
                callback(businessModels);
            });
        }
    }
}
