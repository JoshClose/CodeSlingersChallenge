using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutofacExample.Services
{
    public interface ISecondService : IService
    {
        string DoSecondThing();
    }

    public class SecondService : ISecondService
    {
        public string DoSecondThing()
        {
            return "second thing was done";
        }
    }
}