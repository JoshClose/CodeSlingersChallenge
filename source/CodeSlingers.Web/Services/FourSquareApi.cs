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
        Business GetVenueById(string fourSquareId);
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

        public Business GetVenueById(string fourSquareId)
        {
            throw new NotImplementedException();
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
            business.Id = venueItem.Id;
            business.Name = venueItem.Name;
            business.Url = venueItem.Url;

            if (venueItem.Contact != null)
            {
                business.PhoneNumber = venueItem.Contact.Phone;
                business.FormattedPhoneNumber = venueItem.Contact.FormattedPhone;
            }

            if (venueItem.Categories != null && venueItem.Categories.Any())
            {
                business.Category = venueItem.Categories.First().Name;
            }

            if (venueItem.Location != null)
            {
                business.Latitude = venueItem.Location.Latitude;
                business.Longitude = venueItem.Location.Longitude;
                business.Distance = venueItem.Location.Distance;
                business.Address = venueItem.Location.Address;
                business.City = venueItem.Location.City;
                business.State = venueItem.Location.State;
            }
            
            return business;
        }
    }
}