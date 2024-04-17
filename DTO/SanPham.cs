using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string tensp;

        public string Tensp
        {
            get { return tensp; }
            set { tensp = value; }
        }
        int soluong;

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        int doanhthu;

        public int Doanhthu
        {
            get { return doanhthu; }
            set { doanhthu = value; }
        }
        public SanPham()
        {
            this.Id = id;
            this.Tensp = tensp;
            this.Soluong = soluong;
            this.Doanhthu = doanhthu;
        }
    }
}
