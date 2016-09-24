using System;
using System.Collections.Generic;
using MongoDB.Driver;
using NHLStatsModel;

namespace NHLDatabaseController
{
    class Program
    {
        private const string k_DatabaseName = "test";
        private const string k_CollectionName = "testViews";

        static void Main(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase(k_DatabaseName);
            var views = db.GetCollection<NHLGame>(k_CollectionName);

            List<NHLGame> allgames = new List<NHLGame>();
            
            for (int i= 1; i <= 30; i ++)
            {
                DateTime date = new DateTime(2016, 04, i);                             
                List<NHLGame> games = NHLGameParser.GetNHLGames(date);
                allgames.AddRange(games);                
            }          

            Console.ReadLine();
        }
    }
}
