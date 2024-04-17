using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiDAL
    {
        QL_NhaHangDataContext qlnh = new QL_NhaHangDataContext();
        public List<LOAI> getLoai()
        {
            return (from a in qlnh.LOAIs select a).ToList();
        }
    }
}
