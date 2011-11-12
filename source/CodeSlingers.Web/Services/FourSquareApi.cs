using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using CodeSlingers.Web.Models.Contracts;

namespace CodeSlingers.Web.Services
{    
    public interface IFourSquareApi : IService
    {
        FourSquareVenueResponse GetNearbyVenues(decimal latitude, decimal longitude);
    }

    public class FourSquareApi : IFourSquareApi
    {
        private const string _fourSquareApiUrl = "https://api.foursquare.com/v2/venues/search";
        private const string _clientId = "IKRTLFHA0MPRHIVLRITV2KFPEYJMZSCR4LLYFC5A032LNYA5";
        private const string _secret = "S5PR2ABWRQKUJJJQOI4OD5BV3A34DBGDK142ACOUP2GI0KAP";

        private RestClient _restClient;

        //?ll=44.862253,-93.346592&client_id=&client_secret=";

        public FourSquareApi()
        {
            _restClient = new RestClient(_fourSquareApiUrl);
        }

        public FourSquareVenueResponse GetNearbyVenues(decimal latitude, decimal longitude)
        {
            string latlong = string.Format("{0},{1}", latitude, longitude);

            var restRequest = new RestRequest(Method.GET);
            restRequest.AddParameter("client_id", _clientId);
            restRequest.AddParameter("client_secret", _secret);
            restRequest.AddParameter("ll", latlong);

            var response = _restClient.Execute<FourSquareVenueResponse>(restRequest);
            return response.Data;
        }
    }
}