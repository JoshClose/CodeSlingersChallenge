﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeSlingers.Web.Data;
using CodeSlingers.Web.Models;
using CodeSlingers.Web.Services;
using RestSharp;
using System.Threading;

namespace CodeSlingers.Web.Tests
{
    [TestClass]
    public class DataTests
    {
        [TestMethod]
        [Ignore]
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
                    for (int i = 0; i < r.Next(2, 6); i++)
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
                        w.CreatedByUserId = 16906171;
                        w.CreateDate = DateTime.Today;
                        w.AddParentBusiness(b.Id);
                        w.PhotoPath = "default.bmp";
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
        public void SeedUsers()
        {
            // Run after seed Wine Business

            //Eric
            //16906171

            //Ryan
            //100002330284367

            //Josh
            //508037125
            List<Wine> availableWines;
            using(var session = Db.CreateSession())
            {
                availableWines = session.Query<Wine>().ToList();
            }

            var eric = new User();
            eric.Id = 16906171;
            eric.AddWine(availableWines[0].Id);
            eric.AddWine(availableWines[1].Id);
            eric.AddWine(availableWines[2].Id);

            var ryan = new User();
            ryan.Id = 100002330284367;
            ryan.AddWine(availableWines[3].Id);
            ryan.AddWine(availableWines[1].Id);
            ryan.AddWine(availableWines[2].Id);

            var josh = new User();
            josh.Id = 508037125;
            josh.AddWine(availableWines[3].Id);
            josh.AddWine(availableWines[4].Id);

            using (var session = Db.CreateSession())
            {
                session.Store(eric);
                session.Store(ryan);
                session.Store(josh);
                session.SaveChanges();
            }

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

                var businesses = session.Query<WineBusiness>().ToList();
                foreach (var business in businesses)
                {
                    session.Delete(business);
                }

                session.SaveChanges();
            }

        }

        [Ignore]
        [TestMethod]
        public void FuckSilverlight()
        {
            var _restClient = new RestClient();
            string requestUrl = string.Format("{0}/Users/Wines?accessToken=AAACWuuQ2bSIBAGIXgUT2oxaMxvkLnGGZBjAMI6WZB8lvjBZAddWuqFexZBD06eLK8sBhHWNvE8nZCG7YCjee6G2ZBmC9xwHZBMZD", "http://localhost");
            var request = new RestRequest(requestUrl, Method.GET);

            _restClient.ExecuteAsync<List<Wine>>(request, (response) =>
            {
                List<Wine> wines = response.Data;
                
            });
            Thread.Sleep(4000);
        }
    }
}
