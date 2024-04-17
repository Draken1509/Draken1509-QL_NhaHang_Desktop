using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DoanhThuDAL
    {
        QL_NhaHangDataContext qlnh = new QL_NhaHangDataContext();
        public DoanhThuDAL()
        {

        }
        public List<int> getAllNam()
        {
            var distinctYears = (
             from hoadon in qlnh.HOADONs
             where hoadon.ngayxuat.HasValue
             let namXuat = hoadon.ngayxuat.Value.Year
             select namXuat
         )
         .Union(
             from donhang in qlnh.DONHANGONLINEs
             where donhang.ngaydat.HasValue
             let namDat = donhang.ngaydat.Value.Year
             select namDat
         )
         .Distinct();
            return distinctYears.ToList();

        }
        public List<DoanhThu> getDoanhThuTheoNam(int nam)
        {           
            int targetYear = nam;       
            var query = (
                from hoadon in qlnh.HOADONs
                where hoadon.ngayxuat.HasValue && hoadon.ngayxuat.Value.Year == targetYear
                select new { Month = hoadon.ngayxuat.Value.Month, TongTien = hoadon.tongtien }
            )
            .Union(
                from donhang in qlnh.DONHANGONLINEs
                where donhang.ngaydat.HasValue && donhang.tinhtranghoadon == 3 && donhang.ngaydat.Value.Year == targetYear
                select new { Month = donhang.ngaydat.Value.Month, TongTien = donhang.tongtien }
            )
            .GroupBy(x => x.Month)
            .Select(group => new DoanhThu
            {
                Thang = group.Key ,
                Doanhthu = group.Sum(x => x.TongTien)*1000 ?? 0,
            })
            .OrderBy(x => x.Thang)
            .ToList();
            return query;
        }

        public List<DoanhThu> getDoanhThuTheoThangNam(int nam, int thang)
        {
            var targetYear = nam;
            var targetMonth = thang;

            var dailyData = (
                from hoadon in qlnh.HOADONs
                where hoadon.ngayxuat.HasValue && hoadon.ngayxuat.Value.Year == targetYear && hoadon.ngayxuat.Value.Month == targetMonth
                select new { Ngay = hoadon.ngayxuat.Value.Day, TongTien = hoadon.tongtien }
            )
            .Concat(
                from donhang in qlnh.DONHANGONLINEs
                where donhang.tinhtranghoadon == 3 && donhang.ngaydat.HasValue && donhang.ngaydat.Value.Year == targetYear && donhang.ngaydat.Value.Month == targetMonth
                select new { Ngay = donhang.ngaydat.Value.Day, TongTien = donhang.tongtien }
            )
            .GroupBy(x => x.Ngay)
            .Select(group => new DoanhThu
            {
                Thang = group.Key,
                Doanhthu = group.Sum(x => x.TongTien)*1000?? 0,
            })
            .OrderBy(x => x.Thang);
            return dailyData.ToList();

            // Kết quả có thể được sử dụng trong ứng dụng của bạn, ví dụ: dailyData.ToList();


            // Kết quả có thể được sử dụng trong ứng dụng của bạn, ví dụ: dailyData.ToList();


        }
    }
}
