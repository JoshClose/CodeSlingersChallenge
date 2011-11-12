using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Raven.Client.Document;

namespace CodeSlingers.Web.Data
{
    public class Db
    {
        private static IDocumentStore documentStore;
        private static object sync = new object();

        private static IDocumentStore DocumentStore
        {
            get
            {
                if(documentStore == null)
                {
                    lock (sync)
                    {
                        if (documentStore == null)
                        {
                            documentStore = new DocumentStore() { Url = "http://173.11.37.173:8080" };
                            documentStore.Initialize();
                        }
                    }
                }
                return documentStore;
            }
        }

        public static IDocumentSession CreateSession()
        {
            return DocumentStore.OpenSession();
        }
    }
}