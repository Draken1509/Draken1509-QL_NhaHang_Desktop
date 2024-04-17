using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MenuDAL
    {
        QL_NhaHangDataContext qlnh = new QL_NhaHangDataContext();
        public List<MENU> getMenu()
        {
            return (from a in qlnh.MENUs select a).ToList(); 
        }
        public List<MENU> getMenuFollowFilterCategory(String tenloai)
        {
            var query = (from a in qlnh.MENUs
                         join b in qlnh.LOAIs on a.id_loai equals b.id_loai
                         where b.tenloai.Equals(tenloai) select a);
            return query.ToList();
        }
        public MENU getDetailOfFood(String tenmon)
        {
            return (from a in qlnh.MENUs where a.tenmon.Equals(tenmon) select a).SingleOrDefault();
        }
        public List<MENU> findFood(String tenmon)
        {
            var results = from c in qlnh.MENUs
                          where c.tenmon.Contains(tenmon) 
                          select c;
            return results.ToList();
        }
        public int getIdMon(String tenmon)
        {
            return (from a in qlnh.MENUs where a.tenmon.Equals(tenmon) select a.id_mon).First();
        }
    }
}
