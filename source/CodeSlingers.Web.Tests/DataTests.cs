using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeSlingers.Web.Data;
using CodeSlingers.Web.Models;
using CodeSlingers.Web.Services;

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

        //[TestMethod]
        //public void BusinessWithWines()
        //{
        //    using (var session = Db.CreateSession())
        //    {
        //        var b = session.Include<WineBusiness>(wb => wb.WineIds).Load<WineBusiness>("123abc");
        //        var wine1 = session.Load<Wine>(b.WineIds[0]);
        //    }
        //}

        [TestMethod]
        public void SeedWineBusiness()
        {
            using (var session = Db.CreateSession())
            {
                FourSquareApi api = new FourSquareApi();
                Random r = new Random();
                var venues = api.GetNearbyVenues(44.862253M, -93.346592M).Take(5).ToList();
                for (int j = 0; j < venues.Count; j++)
                {
                    WineBusiness b = new WineBusiness()
                    {
                        Id = venues[j].Id
                    };
                    for (int i = 0; i < r.Next(0, 5); i++)
                    {
                        Wine w = new Wine();
                        w.Name = "Wine " + j.ToString() + i.ToString();
                        w.Comments = "This is a tasty wine";
                        w.Country = "USA";
                        w.Pairing = "I'd drink this with Doritos";
                        w.PriceRange = PriceRanges.UnderTwentyFive;
                        w.Type = WineType.Red;
                        w.Varietal = RedVarietals.Merlot;
                        w.Vineyard = "Martha's";
                        w.Year = 1991;
                        w.CreateDate = DateTime.Today;

                        session.Store(w);
                        session.SaveChanges();
                        b.AddWine(w.Id);
                    }
                    session.Store(b);
                    session.SaveChanges();
                }
            }

        }

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

                var businesses = session.Query<WineBusiness>().ToList();
                foreach (var business in businesses)
                {
                    session.Delete(business);
                }

                session.SaveChanges();
            }

        }
    }
}
