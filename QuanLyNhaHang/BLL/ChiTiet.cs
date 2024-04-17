using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using GUI.DAL;

namespace GUI.BLL
{
    public class ChiTiet
    {

        [BsonElement("id_mon")]
        public String id_mon { get; set; }

        [BsonElement("sl")]
        public int sl { get; set; }

        [BsonElement("giaban")]
        public String giaban { get; set; }

        [BsonElement("tenmon")]
        public String tenmon { get; set; }

        [BsonElement("tongtien")]
        public String tongtien { get; set; }

        private connectMongoDB con = new connectMongoDB();

        //public List<ChiTiet> GetChiTietDonHang()
        //{
        //    return con.getListKhachHang().Select(t => t).ToList();
        //}
    }
}
