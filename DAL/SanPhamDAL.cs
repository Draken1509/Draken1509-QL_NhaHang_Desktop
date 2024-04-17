using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class SanPhamDAL
    {
        QL_NhaHangDataContext qlnh = new QL_NhaHangDataContext();
        public SanPhamDAL()
        {

        }
        // Theo doanh thu - hàng hóa 
        public List<SanPham> getThongTinCacSanPhamBanChay() // get tất cả theo doanh thu, hang hoa
        {
            var combinedData = (
                from traditionalOrder in qlnh.CHITIETHOADONs
                join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
                join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
                group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
                select new SanPham
                {
                    Id = groupedTraditional.Key.id_mon,
                    Tensp = groupedTraditional.Key.tenmon,
                    Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                    Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban)*1000 ?? 0,
                }
            )
            .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3
                group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_mon,
                    Tensp = groupedOnline.Key.tenmon,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) *1000 ?? 0,
                }
            );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10Products;


        }
        public List<SanPham> getThongTinCacSanPhamBanChay_HomNay() // get ngày hôm nay theo doanh thu, hang hoa
        {
            DateTime ngayDaChuyen = layNgayHomNay();
            var combinedData = (
               from traditionalOrder in qlnh.CHITIETHOADONs
               join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
               join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
               where hoadon.ngayxuat == ngayDaChuyen
               group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
               select new SanPham
               {
                   Id = groupedTraditional.Key.id_mon,
                   Tensp = groupedTraditional.Key.tenmon,
                   Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                   Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban)*1000 ?? 0,
               }
           )
           .Union(
               from onlineOrder in qlnh.CHITIETDONHANGONLINEs
               join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
               join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
               where donhangonline.ngaydat == ngayDaChuyen && donhangonline.tinhtranghoadon == 3
               group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
               select new SanPham
               {
                   Id = groupedOnline.Key.id_mon,
                   Tensp = groupedOnline.Key.tenmon,
                   Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                   Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban)*1000 ?? 0,
               }
           );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_HomQua() // get ngày hôm nay theo doanh thu, hang hoa
        {
            DateTime ngayDaChuyen = layNgayHomQua();
            var combinedData = (
              from traditionalOrder in qlnh.CHITIETHOADONs
              join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
              join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
              where hoadon.ngayxuat == ngayDaChuyen
              group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
              select new SanPham
              {
                  Id = groupedTraditional.Key.id_mon,
                  Tensp = groupedTraditional.Key.tenmon,
                  Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                  Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban)*1000 ?? 0,
              }
          )
          .Union(
              from onlineOrder in qlnh.CHITIETDONHANGONLINEs
              join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
              join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
              where donhangonline.ngaydat == ngayDaChuyen && donhangonline.tinhtranghoadon == 3
              group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
              select new SanPham
              {
                  Id = groupedOnline.Key.id_mon,
                  Tensp = groupedOnline.Key.tenmon,
                  Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                  Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban)*1000 ?? 0,
              }
          );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_NNgayQua(int n) // get ngày hôm nay theo doanh thu, hang hoa
        {
            DateTime ngayDaChuyen = layNNgayQua(n);
            var combinedData = (
              from traditionalOrder in qlnh.CHITIETHOADONs
              join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
              join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
              where hoadon.ngayxuat >= ngayDaChuyen
              group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
              select new SanPham
              {
                  Id = groupedTraditional.Key.id_mon,
                  Tensp = groupedTraditional.Key.tenmon,
                  Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                  Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban)*1000 ?? 0,
              }
          )
          .Union(
              from onlineOrder in qlnh.CHITIETDONHANGONLINEs
              join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
              join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
              where donhangonline.ngaydat >= ngayDaChuyen && donhangonline.tinhtranghoadon == 3
              group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
              select new SanPham
              {
                  Id = groupedOnline.Key.id_mon,
                  Tensp = groupedOnline.Key.tenmon,
                  Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                  Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban)*1000?? 0,
              }
          );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_TuanNay() // get ngày hôm nay theo doanh thu, hang hoa
        {
            KhoangThoiGian tg = layTuanNay();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
               from traditionalOrder in qlnh.CHITIETHOADONs
               join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
               join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
               where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
               group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
               select new SanPham
               {
                   Id = groupedTraditional.Key.id_mon,
                   Tensp = groupedTraditional.Key.tenmon,
                   Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                   Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
               }
           )
           .Union(
               from onlineOrder in qlnh.CHITIETDONHANGONLINEs
               join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
               join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
               where donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc 
               && donhangonline.tinhtranghoadon == 3
               group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
               select new SanPham
               {
                   Id = groupedOnline.Key.id_mon,
                   Tensp = groupedOnline.Key.tenmon,
                   Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                   Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
               }
           );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_ThangNay() // get ngày hôm nay theo doanh thu, hang hoa
        {
            KhoangThoiGian tg = layThangNay();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
               from traditionalOrder in qlnh.CHITIETHOADONs
               join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
               join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
               where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
               group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
               select new SanPham
               {
                   Id = groupedTraditional.Key.id_mon,
                   Tensp = groupedTraditional.Key.tenmon,
                   Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                   Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
               }
           )
           .Union(
               from onlineOrder in qlnh.CHITIETDONHANGONLINEs
               join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
               join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
               where donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
               && donhangonline.tinhtranghoadon == 3
               group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
               select new SanPham
               {
                   Id = groupedOnline.Key.id_mon,
                   Tensp = groupedOnline.Key.tenmon,
                   Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                   Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
               }
           );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_TuanTruoc() // get ngày hôm nay theo doanh thu, hang hoa
        {
            KhoangThoiGian tg = layTuanTruoc();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
               from traditionalOrder in qlnh.CHITIETHOADONs
               join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
               join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
               where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
               group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
               select new SanPham
               {
                   Id = groupedTraditional.Key.id_mon,
                   Tensp = groupedTraditional.Key.tenmon,
                   Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                   Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
               }
           )
           .Union(
               from onlineOrder in qlnh.CHITIETDONHANGONLINEs
               join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
               join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
               where donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
               && donhangonline.tinhtranghoadon == 3
               group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
               select new SanPham
               {
                   Id = groupedOnline.Key.id_mon,
                   Tensp = groupedOnline.Key.tenmon,
                   Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                   Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
               }
           );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_ThangTruoc() // get ngày hôm nay theo doanh thu, hang hoa
        {
            KhoangThoiGian tg = layThangTruoc();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
               from traditionalOrder in qlnh.CHITIETHOADONs
               join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
               join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
               where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
               group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
               select new SanPham
               {
                   Id = groupedTraditional.Key.id_mon,
                   Tensp = groupedTraditional.Key.tenmon,
                   Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                   Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
               }
           )
           .Union(
               from onlineOrder in qlnh.CHITIETDONHANGONLINEs
               join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
               join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
               where donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
               && donhangonline.tinhtranghoadon == 3
               group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
               select new SanPham
               {
                   Id = groupedOnline.Key.id_mon,
                   Tensp = groupedOnline.Key.tenmon,
                   Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                   Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
               }
           );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_KhoangThoiGian(DateTime ngaybd, DateTime ngaykt) // get ngày hôm nay theo doanh thu, hang hoa
        {

            DateTime ngayDaChuyen_batdau = ngaybd;
            DateTime ngayDaChuyen_kethuc = ngaykt;

            var combinedData = (
               from traditionalOrder in qlnh.CHITIETHOADONs
               join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
               join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
               where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
               group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
               select new SanPham
               {
                   Id = groupedTraditional.Key.id_mon,
                   Tensp = groupedTraditional.Key.tenmon,
                   Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                   Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
               }
           )
           .Union(
               from onlineOrder in qlnh.CHITIETDONHANGONLINEs
               join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
               join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
               where donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
               && donhangonline.tinhtranghoadon == 3
               group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
               select new SanPham
               {
                   Id = groupedOnline.Key.id_mon,
                   Tensp = groupedOnline.Key.tenmon,
                   Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                   Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
               }
           );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10Products;
        }
        //------------------------------------------------------------------------------------------------

        public List<SanPham> getThongTinCacSanPhamBanChay_TheoSoLuong()
        {
            var combinedData = (
               from traditionalOrder in qlnh.CHITIETHOADONs
               join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
               join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
               group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
               select new SanPham
               {
                   Id = groupedTraditional.Key.id_mon,
                   Tensp = groupedTraditional.Key.tenmon,
                   Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                   Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
               }
           )
           .Union(
               from onlineOrder in qlnh.CHITIETDONHANGONLINEs
               join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
               join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
               where donhangonline.tinhtranghoadon==3
               group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
               select new SanPham
               {
                   Id = groupedOnline.Key.id_mon,
                   Tensp = groupedOnline.Key.tenmon,
                   Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                   Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
               }
           );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10Products;

        }
        public List<SanPham> getThongTinCacSanPhamBanChay_HomNay_TheoSoLuong() // get ngày hôm nay theo doanh thu, hang hoa
        {
            DateTime ngayDaChuyen = layNgayHomNay();
            var combinedData = (
               from traditionalOrder in qlnh.CHITIETHOADONs
               join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
               join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
               where hoadon.ngayxuat == ngayDaChuyen
               group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
               select new SanPham
               {
                   Id = groupedTraditional.Key.id_mon,
                   Tensp = groupedTraditional.Key.tenmon,
                   Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                   Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
               }
           )
           .Union(
               from onlineOrder in qlnh.CHITIETDONHANGONLINEs
               join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
               join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
               where donhangonline.ngaydat == ngayDaChuyen && donhangonline.tinhtranghoadon == 3
               group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
               select new SanPham
               {
                   Id = groupedOnline.Key.id_mon,
                   Tensp = groupedOnline.Key.tenmon,
                   Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                   Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
               }
           );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_HomQua_TheoSoluong() // get ngày hôm nay theo doanh thu, hang hoa
        {
            DateTime ngayDaChuyen = layNgayHomQua();
            var combinedData = (
              from traditionalOrder in qlnh.CHITIETHOADONs
              join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
              join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
              where hoadon.ngayxuat == ngayDaChuyen
              group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
              select new SanPham
              {
                  Id = groupedTraditional.Key.id_mon,
                  Tensp = groupedTraditional.Key.tenmon,
                  Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                  Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
              }
          )
          .Union(
              from onlineOrder in qlnh.CHITIETDONHANGONLINEs
              join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
              join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
              where donhangonline.ngaydat == ngayDaChuyen && donhangonline.tinhtranghoadon == 3
              group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
              select new SanPham
              {
                  Id = groupedOnline.Key.id_mon,
                  Tensp = groupedOnline.Key.tenmon,
                  Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                  Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
              }
          );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_NNgayQua_TheoSoLuong(int n) // get ngày hôm nay theo doanh thu, hang hoa
        {
            DateTime ngayDaChuyen = layNNgayQua(n);
            var combinedData = (
              from traditionalOrder in qlnh.CHITIETHOADONs
              join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
              join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
              where hoadon.ngayxuat >= ngayDaChuyen
              group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
              select new SanPham
              {
                  Id = groupedTraditional.Key.id_mon,
                  Tensp = groupedTraditional.Key.tenmon,
                  Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                  Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
              }
          )
          .Union(
              from onlineOrder in qlnh.CHITIETDONHANGONLINEs
              join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
              join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
              where donhangonline.ngaydat >= ngayDaChuyen && donhangonline.tinhtranghoadon == 3
              group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
              select new SanPham
              {
                  Id = groupedOnline.Key.id_mon,
                  Tensp = groupedOnline.Key.tenmon,
                  Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                  Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
              }
          );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_TuanNay_TheoSoLuong() // get ngày hôm nay theo doanh thu, hang hoa
        {
            KhoangThoiGian tg = layTuanNay();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
               from traditionalOrder in qlnh.CHITIETHOADONs
               join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
               join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
               where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
               group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
               select new SanPham
               {
                   Id = groupedTraditional.Key.id_mon,
                   Tensp = groupedTraditional.Key.tenmon,
                   Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                   Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
               }
           )
           .Union(
               from onlineOrder in qlnh.CHITIETDONHANGONLINEs
               join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
               join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
               where donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
               && donhangonline.tinhtranghoadon == 3
               group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
               select new SanPham
               {
                   Id = groupedOnline.Key.id_mon,
                   Tensp = groupedOnline.Key.tenmon,
                   Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                   Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
               }
           );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_ThangNay_TheoSoLuong() // get ngày hôm nay theo doanh thu, hang hoa
        {
            KhoangThoiGian tg = layThangNay();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
               from traditionalOrder in qlnh.CHITIETHOADONs
               join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
               join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
               where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
               group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
               select new SanPham
               {
                   Id = groupedTraditional.Key.id_mon,
                   Tensp = groupedTraditional.Key.tenmon,
                   Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                   Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
               }
           )
           .Union(
               from onlineOrder in qlnh.CHITIETDONHANGONLINEs
               join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
               join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
               where donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
               && donhangonline.tinhtranghoadon == 3
               group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
               select new SanPham
               {
                   Id = groupedOnline.Key.id_mon,
                   Tensp = groupedOnline.Key.tenmon,
                   Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                   Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
               }
           );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_TuanTruoc_TheoSoLuong() // get ngày hôm nay theo doanh thu, hang hoa
        {
            KhoangThoiGian tg = layTuanTruoc();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
               from traditionalOrder in qlnh.CHITIETHOADONs
               join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
               join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
               where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
               group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
               select new SanPham
               {
                   Id = groupedTraditional.Key.id_mon,
                   Tensp = groupedTraditional.Key.tenmon,
                   Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                   Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
               }
           )
           .Union(
               from onlineOrder in qlnh.CHITIETDONHANGONLINEs
               join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
               join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
               where donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
               && donhangonline.tinhtranghoadon == 3
               group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
               select new SanPham
               {
                   Id = groupedOnline.Key.id_mon,
                   Tensp = groupedOnline.Key.tenmon,
                   Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                   Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
               }
           );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_ThangTruoc_TheoSoLuong() // get ngày hôm nay theo doanh thu, hang hoa
        {
            KhoangThoiGian tg = layThangTruoc();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
               from traditionalOrder in qlnh.CHITIETHOADONs
               join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
               join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
               where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
               group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
               select new SanPham
               {
                   Id = groupedTraditional.Key.id_mon,
                   Tensp = groupedTraditional.Key.tenmon,
                   Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                   Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
               }
           )
           .Union(
               from onlineOrder in qlnh.CHITIETDONHANGONLINEs
               join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
               join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
               where donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
               && donhangonline.tinhtranghoadon == 3
               group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
               select new SanPham
               {
                   Id = groupedOnline.Key.id_mon,
                   Tensp = groupedOnline.Key.tenmon,
                   Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                   Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
               }
           );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10Products;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_KhoangThoiGian_TheoSoLuong(DateTime ngaybd, DateTime ngaykt) // get ngày hôm nay theo doanh thu, hang hoa
        {

            DateTime ngayDaChuyen_batdau = ngaybd;
            DateTime ngayDaChuyen_kethuc = ngaykt;

            var combinedData = (
               from traditionalOrder in qlnh.CHITIETHOADONs
               join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
               join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
               where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
               group new { menu, traditionalOrder } by new { menu.id_mon, menu.tenmon } into groupedTraditional
               select new SanPham
               {
                   Id = groupedTraditional.Key.id_mon,
                   Tensp = groupedTraditional.Key.tenmon,
                   Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                   Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.menu.giaban) * 1000 ?? 0,
               }
           )
           .Union(
               from onlineOrder in qlnh.CHITIETDONHANGONLINEs
               join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
               join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
               where donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
               && donhangonline.tinhtranghoadon == 3
               group new { menu, onlineOrder } by new { menu.id_mon, menu.tenmon } into groupedOnline
               select new SanPham
               {
                   Id = groupedOnline.Key.id_mon,
                   Tensp = groupedOnline.Key.tenmon,
                   Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                   Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.menu.giaban) * 1000 ?? 0,
               }
           );

            var top10Products = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10Products;
        }

        //***********************************************************************************************************************************

        public List<SanPham> getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa()
        {
            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd   
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
                    {
                        Id = groupedTraditional.Key.id_loai,
                        Tensp = groupedTraditional.Key.tenloai,
                        Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                        Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
                    }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho        
                where donhangonline.tinhtranghoadon == 3
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
            {
                Id = groupedOnline.Key.id_loai,
                Tensp = groupedOnline.Key.tenloai,
                Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
            }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_HomNay()
        {
            DateTime ngayDaChuyen = layNgayHomNay();
            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat==ngayDaChuyen
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat==ngayDaChuyen
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_HomQua()
        {
            DateTime ngayDaChuyen = layNgayHomQua();
            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat == ngayDaChuyen
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat == ngayDaChuyen
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_NNgayQua(int n)
        {
            DateTime ngayDaChuyen = layNNgayQua(n);
            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat >= ngayDaChuyen
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat >= ngayDaChuyen
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_TuanNay()
        {
            KhoangThoiGian tg = layTuanNay();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <=ngayDaChuyen_kethuc
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_ThangNay()
        {
            KhoangThoiGian tg = layThangNay();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_TuanTruoc()
        {
            KhoangThoiGian tg = layTuanTruoc();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_ThangTruoc()
        {
            KhoangThoiGian tg = layThangTruoc();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_KhoangThoiGian(DateTime ngaybd, DateTime ngaykt)
        {
         

            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat >= ngaybd && hoadon.ngayxuat <= ngaykt
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat >= ngaybd && donhangonline.ngaydat <= ngaykt
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Doanhthu)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }


       //---------------------------------------------------------------------------------------------------------------
        // soluongnhomhanghoa
        public List<SanPham> getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa()
        {
            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_HomNay()
        {
            DateTime ngayDaChuyen = layNgayHomNay();
            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat == ngayDaChuyen
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat == ngayDaChuyen
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_HomQua()
        {
            DateTime ngayDaChuyen = layNgayHomQua();
            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat == ngayDaChuyen
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat == ngayDaChuyen
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_NNgayQua(int n)
        {
            DateTime ngayDaChuyen = layNNgayQua(n);
            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat >= ngayDaChuyen
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat >= ngayDaChuyen
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_TuanNay()
        {
            KhoangThoiGian tg = layTuanNay();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_ThangNay()
        {
            KhoangThoiGian tg = layThangNay();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_TuanTruoc()
        {
            KhoangThoiGian tg = layTuanTruoc();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_ThangTruoc()
        {
            KhoangThoiGian tg = layThangTruoc();
            DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
            DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat >= ngayDaChuyen_batdau && donhangonline.ngaydat <= ngayDaChuyen_kethuc
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }
        public List<SanPham> getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_KhoangThoiGian(DateTime ngaybd, DateTime ngaykt)
        {


            var combinedData = (
            from traditionalOrder in qlnh.CHITIETHOADONs
            join menu in qlnh.MENUs on traditionalOrder.id_mon equals menu.id_mon
            join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
            join hoadon in qlnh.HOADONs on traditionalOrder.id_hd equals hoadon.id_hd
            where hoadon.ngayxuat >= ngaybd && hoadon.ngayxuat <= ngaykt
            group new { loai, traditionalOrder } by new { loai.id_loai, loai.tenloai } into groupedTraditional
            select new SanPham
            {
                Id = groupedTraditional.Key.id_loai,
                Tensp = groupedTraditional.Key.tenloai,
                Soluong = groupedTraditional.Sum(x => x.traditionalOrder.soluong) ?? 0,
                Doanhthu = groupedTraditional.Sum(x => x.traditionalOrder.soluong * x.traditionalOrder.MENU.giaban) * 1000 ?? 0
            }
                )
             .Union(
                from onlineOrder in qlnh.CHITIETDONHANGONLINEs
                join menu in qlnh.MENUs on onlineOrder.id_mon equals menu.id_mon
                join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                join donhangonline in qlnh.DONHANGONLINEs on onlineOrder.id_dho equals donhangonline.id_dho
                where donhangonline.tinhtranghoadon == 3 && donhangonline.ngaydat >= ngaybd && donhangonline.ngaydat <= ngaykt
                group new { loai, onlineOrder } by new { loai.id_loai, loai.tenloai } into groupedOnline
                select new SanPham
                {
                    Id = groupedOnline.Key.id_loai,
                    Tensp = groupedOnline.Key.tenloai,
                    Soluong = groupedOnline.Sum(x => x.onlineOrder.sl) ?? 0,
                    Doanhthu = groupedOnline.Sum(x => x.onlineOrder.sl * x.onlineOrder.MENU.giaban) * 1000 ?? 0,
                }
        );

            var top10LoaiProducts = combinedData
                .GroupBy(x => new { x.Id, x.Tensp })
                .Select(groupedData => new SanPham
                {
                    Id = groupedData.Key.Id,
                    Tensp = groupedData.Key.Tensp,
                    Soluong = groupedData.Sum(x => x.Soluong),
                    Doanhthu = groupedData.Sum(x => x.Doanhthu),
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();
            return top10LoaiProducts;
        }

        public DateTime layNgayHomNay()
        {
            DateTime ngayHienTai = DateTime.Now;
            string ngayHienTaiFormatted = ngayHienTai.ToString("yyyy/MM/dd");
            DateTime ngayDaChuyen = DateTime.ParseExact(ngayHienTaiFormatted, "yyyy/MM/dd", null);
            return ngayDaChuyen;
        }
        public DateTime layNgayHomQua()
        {
            DateTime ngayHienTai = DateTime.Now;
            DateTime ngayHomQua = ngayHienTai.AddDays(-1);
            string ngayHomQuaFormatted = ngayHomQua.ToString("yyyy/MM/dd");
            DateTime ngayDaChuyen = DateTime.ParseExact(ngayHomQuaFormatted, "yyyy/MM/dd", null);
            return ngayDaChuyen;
        }
        public DateTime layNNgayQua(int n)
        {
            DateTime ngayDaChuyen = DateTime.Now;
            if (n == 7)
            {
                DateTime ngayHienTai = DateTime.Now;
                DateTime ngayThuBay = ngayHienTai.AddDays(-n);
                string ngayThuBayFormatted = ngayThuBay.ToString("yyyy/MM/dd");
                ngayDaChuyen = DateTime.ParseExact(ngayThuBayFormatted, "yyyy/MM/dd", null);
            }
            else if (n == 14)
            {
                DateTime ngayHienTai = DateTime.Now;
                DateTime ngayThuBay = ngayHienTai.AddDays(-n);
                string ngayThuBayFormatted = ngayThuBay.ToString("yyyy/MM/dd");
                ngayDaChuyen = DateTime.ParseExact(ngayThuBayFormatted, "yyyy/MM/dd", null);
            }
            else if (n == 30)
            {
                DateTime ngayHienTai = DateTime.Now;
                DateTime ngayThuBay = ngayHienTai.AddDays(-n);
                string ngayThuBayFormatted = ngayThuBay.ToString("yyyy/MM/dd");
                ngayDaChuyen = DateTime.ParseExact(ngayThuBayFormatted, "yyyy/MM/dd", null);
            }
            return ngayDaChuyen;
        }
        public KhoangThoiGian layTuanNay()
        {

            KhoangThoiGian tg = new KhoangThoiGian();
            DateTime ngayTrongTuan = DateTime.Now;
            // Lấy ngày bắt đầu và kết thúc của tuần hiện tại
            DateTime ngayBatDauTuan = GetFirstDayOfWeek(ngayTrongTuan);
            DateTime ngayKetThucTuan = GetLastDayOfWeek(ngayTrongTuan);

            string ngayBatDauTuanFormatted = ngayBatDauTuan.ToString("yyyy/MM/dd");
            string ngayKetThucTuanFormatted = ngayKetThucTuan.ToString("yyyy/MM/dd");

            DateTime ngayDaChuyen_batdau = DateTime.ParseExact(ngayBatDauTuanFormatted, "yyyy/MM/dd", null);
            DateTime ngayDaChuyen_kethuc = DateTime.ParseExact(ngayKetThucTuanFormatted, "yyyy/MM/dd", null);

            tg.NgayBatDau = ngayDaChuyen_batdau;
            tg.NgayKetThuc = ngayDaChuyen_kethuc;
            return tg;
        }
        public KhoangThoiGian layThangNay()
        {
            KhoangThoiGian tg = new KhoangThoiGian();
            DateTime ngayTrongTuan = DateTime.Now;
            // Lấy ngày bắt đầu và kết thúc của tuần hiện tại
            DateTime ngayBatDauTuan = GetFirstDayOfMonth(ngayTrongTuan);
            DateTime ngayKetThucTuan = GetLastDayOfMonth(ngayTrongTuan);
            string ngayBatDauTuanFormatted = ngayBatDauTuan.ToString("yyyy/MM/dd");
            string ngayKetThucTuanFormatted = ngayKetThucTuan.ToString("yyyy/MM/dd");
            DateTime ngayDaChuyen_batdau = DateTime.ParseExact(ngayBatDauTuanFormatted, "yyyy/MM/dd", null);
            DateTime ngayDaChuyen_kethuc = DateTime.ParseExact(ngayKetThucTuanFormatted, "yyyy/MM/dd", null);
            tg.NgayBatDau = ngayDaChuyen_batdau;
            tg.NgayKetThuc = ngayDaChuyen_kethuc;
            return tg;
        }

        public KhoangThoiGian layTuanTruoc()
        {
            KhoangThoiGian tg = new KhoangThoiGian();
            DateTime ngayTrongTuan = DateTime.Now;
            // Lấy ngày bắt đầu và kết thúc của tuần hiện tại
            DateTime ngayBatDauTuan = GetFirstDayOfPreviousWeek(ngayTrongTuan);
            DateTime ngayKetThucTuan = GetLastDayOfPreviousWeek(ngayTrongTuan);

            string ngayBatDauTuanFormatted = ngayBatDauTuan.ToString("yyyy/MM/dd");
            string ngayKetThucTuanFormatted = ngayKetThucTuan.ToString("yyyy/MM/dd");
            DateTime ngayDaChuyen_batdau = DateTime.ParseExact(ngayBatDauTuanFormatted, "yyyy/MM/dd", null);
            DateTime ngayDaChuyen_kethuc = DateTime.ParseExact(ngayKetThucTuanFormatted, "yyyy/MM/dd", null);
            tg.NgayBatDau = ngayDaChuyen_batdau;
            tg.NgayKetThuc = ngayDaChuyen_kethuc;
            return tg;
        }
        public KhoangThoiGian layThangTruoc()
        {
            KhoangThoiGian tg = new KhoangThoiGian();
            DateTime ngayTrongTuan = DateTime.Now;
            // Lấy ngày bắt đầu và kết thúc của tuần hiện tại
            DateTime ngayBatDauTuan = GetFirstDayOfPreviousMonth(ngayTrongTuan);
            DateTime ngayKetThucTuan = GetLastDayOfPreviousMonth(ngayTrongTuan);
            string ngayBatDauTuanFormatted = ngayBatDauTuan.ToString("yyyy/MM/dd");
            string ngayKetThucTuanFormatted = ngayKetThucTuan.ToString("yyyy/MM/dd");
            DateTime ngayDaChuyen_batdau = DateTime.ParseExact(ngayBatDauTuanFormatted, "yyyy/MM/dd", null);
            DateTime ngayDaChuyen_kethuc = DateTime.ParseExact(ngayKetThucTuanFormatted, "yyyy/MM/dd", null);
            tg.NgayBatDau = ngayDaChuyen_batdau;
            tg.NgayKetThuc = ngayDaChuyen_kethuc;
            return tg;
        }

        static DateTime GetFirstDayOfWeek(DateTime date)
        {
            int offset = (7 + (int)date.DayOfWeek - (int)DayOfWeek.Monday) % 7;
            DateTime ngayBatDauTuan = date.AddDays(-offset);
            return ngayBatDauTuan.Date;

        }
        // Hàm lấy ngày kết thúc của tuần
        static DateTime GetLastDayOfWeek(DateTime date)
        {
            //int offset = (int)DayOfWeek.Sunday - (int)date.DayOfWeek;
            //DateTime ngayKetThucTuan = date.AddDays(offset);
            //return ngayKetThucTuan.Date;

            int offset = (7 - (int)date.DayOfWeek + (int)DayOfWeek.Sunday) % 7;
            DateTime ngayKetThucTuan = date.AddDays(offset);
            return ngayKetThucTuan.Date;
        }

        static DateTime GetFirstDayOfMonth(DateTime date)
        {
            DateTime ngayBatDauThang = new DateTime(date.Year, date.Month, 1);
            return ngayBatDauThang.Date;
        }

        // Hàm lấy ngày kết thúc của tháng
        static DateTime GetLastDayOfMonth(DateTime date)
        {
            DateTime ngayKetThucThang = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            return ngayKetThucThang.Date;
        }
        static DateTime GetFirstDayOfPreviousWeek(DateTime date)
        {
            int offset = ((int)date.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            DateTime ngayBatDauTuanTruoc = date.AddDays(-offset - 7);
            return ngayBatDauTuanTruoc.Date;
        }

        // Hàm lấy ngày kết thúc của tuần trước
        static DateTime GetLastDayOfPreviousWeek(DateTime date)
        {
            DayOfWeek firstDayOfWeek = DayOfWeek.Monday; // Tuỳ chọn ngày bắt đầu tuần

            int offset = (int)date.DayOfWeek - (int)firstDayOfWeek;
            if (offset < 0) offset += 7;

            DateTime ngayKetThucTuanTruoc = date.AddDays(-offset - 1);
            return ngayKetThucTuanTruoc.Date;
        }

        static DateTime GetFirstDayOfPreviousMonth(DateTime date)
        {
            DateTime ngayBatDauThangTruoc = date.AddMonths(-1);
            ngayBatDauThangTruoc = new DateTime(ngayBatDauThangTruoc.Year, ngayBatDauThangTruoc.Month, 1);
            return ngayBatDauThangTruoc.Date;
        }

        // Hàm lấy ngày kết thúc của tháng trước
        static DateTime GetLastDayOfPreviousMonth(DateTime date)
        {
            DateTime ngayKetThucThangTruoc = date.AddDays(-date.Day);
            return ngayKetThucThangTruoc.Date;
        }

    }
}
