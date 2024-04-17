using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongTinDonNhapHang
    {
        public int id_dnh { get; set; }
        public int id_ncc { get; set; }
        public DateTime ngaynhap { get; set; }
        public bool tinhtrangnhanhang { get; set; }
        public int tongtien { get; set; }
        public String tenncc { get; set; }
    }
}
