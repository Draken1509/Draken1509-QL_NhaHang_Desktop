using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Shared;

namespace GUI.BLL
{
    public class DonHangOnline
    {
        public DonHangOnline() { }

        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("id_dho")]
        public String id_dho{get; set;}

        [BsonElement("ngaydat")]
        public BsonDateTime ngaydat { get; set; }

        [BsonElement("tongtien")]
        public String tongtien { get; set; }

        [BsonElement("phuongthucthanhtoan")]
        public String phuongthucthanhtoan { get; set; }

        [BsonElement("tinhtranghoadon")]
        public bool tinhtranghoadon { get; set; }

        [BsonElement("tienship")]
        public String tienship { get; set; }

        [BsonElement("khachhang")]
        public KhachHang khachhang { get; set; }

        [BsonElement("chitiet")]
        public List<ChiTiet> chitiet { get; set; }
    }
}
