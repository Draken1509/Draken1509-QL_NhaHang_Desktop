using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhoangThoiGian
    {
        DateTime ngayBatDau;

        public DateTime NgayBatDau
        {
            get { return ngayBatDau; }
            set { ngayBatDau = value; }
        }
        DateTime ngayKetThuc;

        public DateTime NgayKetThuc
        {
            get { return ngayKetThuc; }
            set { ngayKetThuc = value; }
        }
        public KhoangThoiGian()
        {

        }
        //public KhoangThoiGian()
        //{
        //    this.ngayBatDau = NgayBatDau;
        //    this.ngayKetThuc = NgayKetThuc;
        //}
    }
}
