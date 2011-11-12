using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeSlingers.Web.Data;
using CodeSlingers.Web.Models;

namespace CodeSlingers.Web.Tests
{
    [TestClass]
    public class DataTests
    {
        [TestMethod]
        public void RavenConnectivityTest()
        {
            Wine wine;
            using (var session = Db.CreateSession())
            {
                wine = new Wine()
                {
                    Name = "Woop Woop",
                    Varietal = "Shiraz",
                    Year = 2009,
                    Type = WineType.Red,
                    Vineyard = "Unknown",
                    Country = "Australia",
                    PhotoPath = "c:\\Awesome.jpg"
                };

                session.Store(wine);
                session.SaveChanges();
            }
            Assert.IsTrue(wine.Id > 0);

            using (var session = Db.CreateSession())
            {
                var savedWine = session.Load<Wine>(wine.Id);
                Assert.AreEqual("Australia", savedWine.Country);
            }

        }

        [TestMethod]
        public void GetMyWinesTest()
        {
        }

        //[TestMethod]
        //public void SeedDatabase()
        //{
        //    var wines = new List<Wine>()
        //    {
        //        new Wine()
        //        {
        //        }
        //    }
        //}

        [Ignore]
        [TestMethod]
        public void CleanupDB()
        {
            using (var session = Db.CreateSession())
            {
                var wines = session.Query<Wine>().ToList();
                foreach (var wine in wines)
                {
                    session.Delete(wine);
                }

                var users = session.Query<User>().ToList();
                foreach (var user in users)
                {
                    session.Delete(user);
                }

                var businesses = session.Query<Business>().ToList();
                foreach (var business in businesses)
                {
                    session.Delete(business);
                }

                session.SaveChanges();
            }

        }
    }
}
