using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core.Configuration;
using GUI.BLL;

namespace GUI.DAL
{
    public class connectMongoDB
    {
        public static IMongoClient dbClient = new MongoClient("mongodb://localhost:27017");
        public static IMongoDatabase db = dbClient.GetDatabase("QL_NhaHang");
        public static IMongoCollection<DonHangOnline> collection = db.GetCollection<DonHangOnline>("donhangonline");
        public connectMongoDB()
        {
            //db = dbClient.GetDatabase(DBName);
        }
        public IMongoCollection<DonHangOnline> getCollectionDonHangOnline()
        {
            return db.GetCollection<DonHangOnline>("donhangonline");
        }

    }
}
