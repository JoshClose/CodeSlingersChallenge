using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeSlingers.Web.Services
{    
    public interface IFourSquareApi : IService
    {
        void GetNearbyVenues(decimal latitude, decimal longitude);
    }

    public class FourSquareApi : IFourSquareApi
    {
        private const string _fourSquareApiUrl = "";

        public void GetNearbyVenues(decimal latitude, decimal longitude)
        {

        }
    }
}