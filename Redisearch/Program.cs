﻿using NRediSearch;
using Redisearch.Model;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redisearch
{
    class Program
    {
        private static ConnectionMultiplexer _cnn;
        private IDatabase GetRedisDb()
        {
            _cnn = ConnectionMultiplexer.Connect("localhost");
            return _cnn.GetDatabase();
        }
        static void Main(string[] args)
        {
            Program p = new Program();

            //    IList<MarkIndex_Luke> markIndex_Lukes = p.GetAllFromDb();

            //  p.Add_Redis(markIndex_Lukes);
            p.SearchQuery();
        }

        public void SearchQuery()
        {
            var q = new Query("WIM")
              //  .AddFilter(new Query.NumericFilter("price", 1300, 1350))
              .Limit(0, 5);
            var db = GetRedisDb();
            Client client = new Client("MarkIndex_Luke", db);
            var res = client.Search(q);
        }

        public IList<MarkIndex_Luke> GetAllFromDb()
        {
            IList<MarkIndex_Luke> markIndex_Lukes;
            using (var db = new Redis())
            {       
                markIndex_Lukes = db.MarkIndex_Luke.ToList();               
            }
            return markIndex_Lukes;
        }

        public void Add_Redis(IList<MarkIndex_Luke> markIndex_Lukes)
        {
         

            var db = GetRedisDb();

            if (markIndex_Lukes.Count > 0)
            {

                foreach (MarkIndex_Luke m in markIndex_Lukes)
                {
                    try
                    {
                        var rsc = new Client("MarkIndex_Luke", db);
                        var doc = new Document(m.Id.ToString());
                        doc.Set("Id", m.Id);
                        doc.Set("WordsInMark", m.WordsInMark);
                        doc.Set("Translation", m.Translation);
                        doc.Set("Transliteration", m.Transliteration);

                        rsc.AddDocument(doc);
                    }
                    catch (Exception ex)
                    {
                        var msg = ex.Message;
                        throw;
                    }
                 
                }
            }

        }
    
    }
}
