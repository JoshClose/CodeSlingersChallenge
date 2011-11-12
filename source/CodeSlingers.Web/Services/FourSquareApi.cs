using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using CodeSlingers.Web.Models.Contracts;
using CodeSlingers.Web.Models;

namespace CodeSlingers.Web.Services
{    
    public interface IFourSquareApi : IService
    {
        IList<Business> GetNearbyVenues(decimal latitude, decimal longitude);
    }

    public class FourSquareApi : IFourSquareApi
    {
        private const string _fourSquareApiUrl = "https://api.foursquare.com/v2/venues/search";
        private const string _clientId = "IKRTLFHA0MPRHIVLRITV2KFPEYJMZSCR4LLYFC5A032LNYA5";
        private const string _secret = "S5PR2ABWRQKUJJJQOI4OD5BV3A34DBGDK142ACOUP2GI0KAP";
        private readonly RestClient _restClient;

        public FourSquareApi()
        {
            _restClient = new RestClient(_fourSquareApiUrl);
        }

        public IList<Business> GetNearbyVenues(decimal latitude, decimal longitude)
        {
            string latlong = string.Format("{0},{1}", latitude, longitude);

            var restRequest = new RestRequest(Method.GET);
            restRequest.AddParameter("client_id", _clientId);
            restRequest.AddParameter("client_secret", _secret);
            restRequest.AddParameter("ll", latlong);

            var response = _restClient.Execute<FourSquareVenueResponse>(restRequest);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            var businesses = MapResponseToBusinessList(response.Data);
            return businesses;
        }

        private IList<Business> MapResponseToBusinessList(FourSquareVenueResponse response)
        {
            var businesses = new List<Business>();
            if (response != null && response.Response != null && response.Response.Groups != null)
            {
                foreach (var group in response.Response.Groups)
                {
                    if (group.Items != null)
                    {
                        foreach (var item in group.Items)
                        {
                            var business = MapVenueItemToBusiness(item);
                            businesses.Add(business);
                        }
                    }
                }
            }

            return businesses;
        }

        private Business MapVenueItemToBusiness(FourSquareItem venueItem)
        {
            var business = new Business();

            return business;
        }
    }
}