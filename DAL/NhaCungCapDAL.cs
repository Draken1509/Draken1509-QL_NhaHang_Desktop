using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaCungCapDAL
    {
        QL_NhaHangDataContext qlnh = new QL_NhaHangDataContext();
        public List<NHACUNGCAP> getncc()
        {
            return (from a in qlnh.NHACUNGCAPs select a).ToList();
        }
    }
}
