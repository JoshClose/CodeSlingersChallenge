using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using CodeSlingers.WP7.App.Models;
using System.Collections.Generic;
using RestSharp;
using CodeSlingers.Web.Models;
using System.Linq;

namespace CodeSlingers.WP7.App.Proxies
{
    public class LocationProxy
    {
        //http://localhost/CodeSlingers.Web/Location/NearbyBusinesses?latitude=44.862253&longitude=-93.346592
        private readonly string _nearbyBusinessUrl = "";
        private readonly string _businessByIdUrl = "";
        private readonly RestClient _restClient;

        public LocationProxy()
        {
            _restClient = new RestClient();
        }

        public void GetNearbyBusiness(decimal latitude, decimal longitude, Action<IList<BusinessModel>> callback)
        {
            var request = new RestRequest(_nearbyBusinessUrl, Method.POST);

            _restClient.ExecuteAsync<List<Business>>(request, (response) =>
            {
                List<Business> businesses = response.Data;
                IList<BusinessModel> businessModels = businesses.Select(b => Mapper.Map(b)).ToList();
                callback(businessModels);
            });
        }
    }
}
