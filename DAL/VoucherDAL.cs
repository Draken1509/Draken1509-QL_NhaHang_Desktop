using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class VoucherDAL
    {
        QL_NhaHangDataContext qlnh = new QL_NhaHangDataContext();
        public int soLuongVoucher()
        {
            int totalNumberOfInvoices = qlnh.VOUCHERs.Count();
            return totalNumberOfInvoices;
        }
        public List<Voucher> loadVoucher()
        {
            var voucherData = qlnh.VOUCHERs
         .Select(v => new Voucher
         {
             Id = v.id_voucher,
             TenVoucher = v.tenvoucher,
             MucGiam = v.mucgiam
         })
         .ToList();

            return voucherData;

        }
        public List<VOUCHER> loadAllVoucher(int tongtien)
        {
            return (from a in qlnh.VOUCHERs where a.yeucau <= tongtien && a.ngaybatdau <= DateTime.Now && a.ngayhethan >= DateTime.Now select a).ToList();
        }
        public VOUCHER loadInfoOfVoucher(string tenvoucher)
        {
            return (from a in qlnh.VOUCHERs where a.tenvoucher.Equals(tenvoucher) select a).SingleOrDefault();
        }
        public List<VOUCHER> loadForFormVoucher()
        {
            return (from a in qlnh.VOUCHERs select a).ToList();
        }
    }
}
