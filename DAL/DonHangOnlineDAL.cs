using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonHangOnlineDAL
    {
        QL_NhaHangDataContext qlnh = new QL_NhaHangDataContext();
        public List<DONHANGONLINE> getDonHangOnline(int dieukien)
        {
            if (dieukien == -1)
            {
                return (from a in qlnh.DONHANGONLINEs select a).ToList();
            }
            return (from a in qlnh.DONHANGONLINEs where a.tinhtranghoadon == dieukien select a).ToList();
        }
        public List<CHITIETDONHANGONLINE> getChiTietDonHangOnline(int id_dho)
        {
            return (from a in qlnh.CHITIETDONHANGONLINEs where a.id_dho == id_dho select a).ToList();
        }
        public bool editStatus(int id_dho, int tinhtrang)
        {
            try
            {
                DONHANGONLINE result = (from a in qlnh.DONHANGONLINEs where a.id_dho == id_dho select a).SingleOrDefault();

                result.tinhtranghoadon = tinhtrang;

                qlnh.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
