using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutofacExample.Services
{
    public interface ITestService : IService
    {
        string DoStuff();
    }

    public class TestService : ITestService
    {
        public string DoStuff()
        {
            return "you did stuff";
        }
    }
}