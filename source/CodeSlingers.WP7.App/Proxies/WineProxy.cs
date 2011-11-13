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
using RestSharp;
using CodeSlingers.WP7.App.Models;
using System.Collections.Generic;
using CodeSlingers.Web.Models;
using System.Linq;

namespace CodeSlingers.WP7.App.Proxies
{
    public class WineProxy
    {
        private readonly RestClient _restClient;

        public WineProxy()
        {
            _restClient = new RestClient();
        }

        public void GetWinesByBusiness(string businessId, Action<IList<WineModel>> callback)
        {
            string requestUrl = string.Format("{0}/Wines/ByLocation", Globals.ServiceHostUrl);
            var request = new RestRequest(requestUrl, Method.GET);
            request.AddParameter("businessId", businessId);

            _restClient.ExecuteAsync<List<Wine>>(request, (response) =>
            {
                List<Wine> wines = response.Data;
                IList<WineModel> businessModels = wines.Select(w => Mapper.Map(w)).ToList();
                callback(businessModels);
            });
        }

        public void GetWineDetail(string wineId, Action<WineModel> callback)
        {
            string requestUrl = string.Format("{0}/Wines/ById", Globals.ServiceHostUrl);
            var request = new RestRequest(requestUrl, Method.GET);
            request.AddParameter("wineId", wineId);

            _restClient.ExecuteAsync<Wine>(request, (response) =>
            {
                Wine wine = response.Data;
                WineModel windeModel = Mapper.Map(wine);
                callback(windeModel);
            });
        }

        public void SaveNewWine(WineModel wineModel, string userAccessToken, Action<WineModel> callback)
        {
            Wine wine = Mapper.Map(wineModel);

            string requestUrl = string.Format("{0}/Wines/Create", Globals.ServiceHostUrl);
            var request = new RestRequest(requestUrl, Method.PUT);
            request.AddBody(wine);
            request.AddParameter("createdByUserAccessToken", userAccessToken);

            _restClient.ExecuteAsync<Wine>(request, (response) =>
            {
                Wine savedWine = response.Data;
                WineModel windeModel = Mapper.Map(savedWine);
                callback(windeModel);
            });
        }
    }
}
