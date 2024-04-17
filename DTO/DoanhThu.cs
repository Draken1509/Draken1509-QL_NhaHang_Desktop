using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DoanhThu
    {

        int  thang;

        public int Thang
        {
            get { return thang; }
            set { thang = value; }
        }
        int doanhthu;

        public int Doanhthu
        {
            get { return doanhthu; }
            set { doanhthu = value; }
        }
        public DoanhThu()
        {
            this.thang = Thang;
            this.doanhthu = Doanhthu;
        }
    }
}
