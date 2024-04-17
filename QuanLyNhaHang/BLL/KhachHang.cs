using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace GUI.BLL
{
    public class KhachHang
    {
        [BsonElement("diachi")]
        public String diachi { get; set; }

        [BsonElement("hoten")]
        public String hoten { get; set; }

        [BsonElement("sdt")]
        public String sdt { get; set; }

        [BsonElement("email")]
        public String email { get; set; }
    }
}
