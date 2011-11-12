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

        [TestMethod]
        public void SeedDatabase()
        {
            var business1 = new Business()
            {
                Id = "123abc",
                Address = "123 Fake Street",
                Name = "Good Liquor Store",
            };
            var business2 = new Business()
            {
                Id = "456def",
                Address = "456 Evergreen Way",
                Name = "Fancy restaurant"
            };
            var business3 = new Business()
            {
                Id = "789ghi",
                Address = "789 Viking Dr",
                Name = "Hip Wine Bar"
            };

            using (var session = Db.CreateSession())
            {
                session.Store(business1);
                session.Store(business2);
                session.Store(business3);
                session.SaveChanges();
            }
            
            var wines = new List<Wine>()
            {
                new Wine()
                {
                    Name = "Awesome Shiraz",
                    
                }
            };
        }

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
