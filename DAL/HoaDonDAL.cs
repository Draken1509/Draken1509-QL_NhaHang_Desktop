using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Globalization;
namespace DAL
{
    public class HoaDonDAL
    {
        QL_NhaHangDataContext qlnh = new QL_NhaHangDataContext();
        //bool all = false;
        //bool homnay = false;
        //bool homqua = false;
        //bool bayngayqua = false;
        //bool muoibonngayqua = false;
        //bool bamuoingayqua = false;
        //bool tuannay = false;
        //bool thangnay = false;
        //bool tuantruoc = false;
        //bool thangtruoc = false;              
        public ThongTinThongKe getThongKe(bool all, bool homnay, bool homqua, bool bayngayqua, bool muoibonngayqua, bool bamuoingayqua, bool tuannay, bool thangnay, bool tuantruoc, bool thangtruoc, DateTime ngaybd, DateTime ngaykt, int trangthai)
        {
            ThongTinThongKe tk = new ThongTinThongKe();
            tk.SoLuongHd = getSoLuongHoaDon(3, all, homnay, homqua, bayngayqua, muoibonngayqua, bamuoingayqua, tuannay, thangnay, tuantruoc, thangtruoc, ngaybd, ngaykt);
            tk.DoanhThu = getDoanhThu(3, all, homnay, homqua, bayngayqua, muoibonngayqua, bamuoingayqua, tuannay, thangnay, tuantruoc, thangtruoc, ngaybd, ngaykt);

            tk.SoTienMat = getSoLuongHoaDon(3, all, homnay, homqua, bayngayqua, muoibonngayqua, bamuoingayqua, tuannay, thangnay, tuantruoc, thangtruoc, ngaybd, ngaykt);
            tk.TongTienMat = getDoanhThu(3, all, homnay, homqua, bayngayqua, muoibonngayqua, bamuoingayqua, tuannay, thangnay, tuantruoc, thangtruoc, ngaybd, ngaykt);
            tk.SoChuyenKhoan = 0;
            tk.TongChuyenKhoan = 0;

            tk.SoDonDaHuy = getSoLuongDonHuy(3, all, homnay, homqua, bayngayqua, muoibonngayqua, bamuoingayqua, tuannay, thangnay, tuantruoc, thangtruoc, ngaybd, ngaykt);


            int slDonOnline = getSoLuongDonOnline(3, all, homnay, homqua, bayngayqua, muoibonngayqua, bamuoingayqua, tuannay, thangnay, tuantruoc, thangtruoc, ngaybd, ngaykt);
            tk.SoDonOnline = slDonOnline;
            tk.SoDonOffline = tk.SoLuongHd - slDonOnline;
            int tongTienDonOffline = getTongTienDonOffline(3, all, homnay, homqua, bayngayqua, muoibonngayqua, bamuoingayqua, tuannay, thangnay, tuantruoc, thangtruoc, ngaybd, ngaykt);
            tk.TongTienDonOffline = tongTienDonOffline;
            tk.TongTienDonOnline = tk.DoanhThu - tongTienDonOffline;

            tk.SoVoucher = getSoLuongVoucher(3, all, homnay, homqua, bayngayqua, muoibonngayqua, bamuoingayqua, tuannay, thangnay, tuantruoc, thangtruoc, ngaybd, ngaykt);

            return tk;
        }
        public int getSoLuongHoaDon(int trangthai, bool all, bool homnay, bool homqua, bool bayngayqua, bool muoibonngayqua, bool bamuoingayqua, bool tuannay, bool thangnay, bool tuantruoc, bool thangtruoc, DateTime ngaybd, DateTime ngaykt)
        {
            var t = 0;
            if (all)
            {
                var sohd = qlnh.HOADONs.Count();
                var donOnline = qlnh.DONHANGONLINEs.Count(dh => dh.tinhtranghoadon == trangthai);
                if (sohd == null)
                    t = donOnline;
                else if (donOnline == null)
                    t = donOnline;
                else
                    t = sohd + donOnline;
                // t = sohd + donOnline;
                all = false;
            }
            else if (homnay)
            {
                DateTime ngayDaChuyen = layNgayHomNay();
                var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat == ngayDaChuyen);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat == ngayDaChuyen && hd.tinhtranghoadon == trangthai);
                if (sohd == null)
                    t = donOnline;
                else if (donOnline == null)
                    t = donOnline;
                else
                    t = sohd + donOnline;
                homnay = false;
            }
            else if (homqua)
            {
                DateTime ngayDaChuyen = layNgayHomQua();
                var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat == ngayDaChuyen);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat == ngayDaChuyen && hd.tinhtranghoadon == trangthai);
                if (sohd == null)
                    t = donOnline;
                else if (donOnline == null)
                    t = donOnline;
                else
                    t = sohd + donOnline;
                homqua = false;
            }
            else if (bayngayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(7);
                var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat >= ngayDaChuyen);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen && hd.tinhtranghoadon == trangthai);
                if (sohd == null)
                    t = donOnline;
                else if (donOnline == null)
                    t = donOnline;
                else
                    t = sohd + donOnline;
                t = sohd + donOnline;
            }
            else if (muoibonngayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(14);
                var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat >= ngayDaChuyen);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen && hd.tinhtranghoadon == trangthai);
                if (sohd == null)
                    t = donOnline;
                else if (donOnline == null)
                    t = donOnline;
                else
                    t = sohd + donOnline;

            }
            else if (bamuoingayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(30);
                var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat >= ngayDaChuyen);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen && hd.tinhtranghoadon == trangthai);

                if (sohd == null)
                    t = donOnline;
                else if (donOnline == null)
                    t = donOnline;
                else
                    t = sohd + donOnline;
            }
            else if (tuannay)
            {
                KhoangThoiGian tg = layTuanNay();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

                var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen_batdau && hd.ngaydat <= ngayDaChuyen_kethuc && hd.tinhtranghoadon == trangthai);
                if (sohd == null)
                    t = donOnline;
                else if (donOnline == null)
                    t = donOnline;
                else
                    t = sohd + donOnline;
            }
            else if (thangnay)
            {
                KhoangThoiGian tg = layThangNay();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen_batdau && hd.ngaydat <= ngayDaChuyen_kethuc && hd.tinhtranghoadon == trangthai);
                t = sohd + donOnline;
            }
            else if (tuantruoc)
            {
                KhoangThoiGian tg = layTuanTruoc();

                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen_batdau && hd.ngaydat <= ngayDaChuyen_kethuc && hd.tinhtranghoadon == trangthai);
                if (sohd == null)
                    t = donOnline;
                else if (donOnline == null)
                    t = donOnline;
                else
                    t = sohd + donOnline;
            }
            else if (thangtruoc)
            {
                KhoangThoiGian tg = layThangTruoc();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen_batdau && hd.ngaydat <= ngayDaChuyen_kethuc && hd.tinhtranghoadon == trangthai);
                if (sohd == null)
                    t = donOnline;
                else if (donOnline == null)
                    t = donOnline;
                else
                    t = sohd + donOnline;
            }
            else
            {

                var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat >= ngaybd && hd.ngayxuat <= ngaykt);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngaybd && hd.ngaydat <= ngaykt && hd.tinhtranghoadon == trangthai);
                if (sohd == null)
                    t = donOnline;
                else if (donOnline == null)
                    t = donOnline;
                else
                    t = sohd + donOnline;
            }
            return t;

        }
        public int getDoanhThu(int trangthai, bool all, bool homnay, bool homqua, bool bayngayqua, bool muoibonngayqua, bool bamuoingayqua, bool tuannay, bool thangnay, bool tuantruoc, bool thangtruoc, DateTime ngaybd, DateTime ngaykt)
        {
            var t = 0;
            if (all)
            {
                var tongTienDonOffline = qlnh.HOADONs.Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                                .Where(dh => dh.tinhtranghoadon == 3)
                                .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    t = donOnline ?? 0;
                else if (donOnline == null)
                    t = tongTienDonOffline ?? 0;
                else
                    t = tongTienDonOffline + donOnline ?? 0;


            }
            else if (homnay)
            {
                DateTime ngayDaChuyen = layNgayHomNay();
                var tongTienDonOffline = qlnh.HOADONs
                                .Where(hd => hd.ngayxuat == ngayDaChuyen)
                                .Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                    .Where(dh => dh.tinhtranghoadon == 3 && dh.ngaydat == ngayDaChuyen)
                    .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    t = donOnline ?? 0;
                else if (donOnline == null)
                    t = tongTienDonOffline ?? 0;
                else
                    t = tongTienDonOffline + donOnline ?? 0;
                homqua = false;
            }
            else if (homqua)
            {
                DateTime ngayDaChuyen = layNgayHomQua();
                var tongTienDonOffline = qlnh.HOADONs
                              .Where(hd => hd.ngayxuat == ngayDaChuyen)
                              .Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                    .Where(dh => dh.tinhtranghoadon == 3 && dh.ngaydat == ngayDaChuyen)
                    .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    t = donOnline ?? 0;
                else if (donOnline == null)
                    t = tongTienDonOffline ?? 0;
                else
                    t = tongTienDonOffline + donOnline ?? 0;

            }
            else if (bayngayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(7);
                var tongTienDonOffline = qlnh.HOADONs
                                        .Where(hd => hd.ngayxuat >= ngayDaChuyen)
                                        .Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                                .Where(dh => dh.ngaydat > ngayDaChuyen && dh.tinhtranghoadon == 3)
                                .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    t = donOnline ?? 0;
                else if (donOnline == null)
                    t = tongTienDonOffline ?? 0;
                else
                    t = tongTienDonOffline + donOnline ?? 0;

            }
            else if (muoibonngayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(14);
                var tongTienDonOffline = qlnh.HOADONs
                                        .Where(hd => hd.ngayxuat >= ngayDaChuyen)
                                        .Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                                .Where(dh => dh.ngaydat > ngayDaChuyen && dh.tinhtranghoadon == 3)
                                .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    t = donOnline ?? 0;
                else if (donOnline == null)
                    t = tongTienDonOffline ?? 0;
                else
                    t = tongTienDonOffline + donOnline ?? 0;

            }
            else if (bamuoingayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(30);
                var tongTienDonOffline = qlnh.HOADONs
                                        .Where(hd => hd.ngayxuat >= ngayDaChuyen)
                                        .Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                                .Where(dh => dh.ngaydat > ngayDaChuyen && dh.tinhtranghoadon == 3)
                                .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    t = donOnline ?? 0;
                else if (donOnline == null)
                    t = tongTienDonOffline ?? 0;
                else
                    t = tongTienDonOffline + donOnline ?? 0;

            }
            else if (tuannay)
            {
                KhoangThoiGian tg = layTuanNay();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

                var tongTienDonOffline = qlnh.HOADONs
                            .Where(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc)
                            .Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                            .Where(dh => dh.ngaydat >= ngayDaChuyen_batdau && dh.ngaydat <= ngayDaChuyen_kethuc && dh.tinhtranghoadon == 3)
                            .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    t = donOnline ?? 0;
                else if (donOnline == null)
                    t = tongTienDonOffline ?? 0;
                else
                    t = tongTienDonOffline + donOnline ?? 0;


            }
            else if (thangnay)
            {
                KhoangThoiGian tg = layThangNay();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                var tongTienDonOffline = qlnh.HOADONs
                                            .Where(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc)
                                            .Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                            .Where(dh => dh.ngaydat >= ngayDaChuyen_batdau && dh.ngaydat <= ngayDaChuyen_kethuc && dh.tinhtranghoadon == 3)
                            .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    t = donOnline ?? 0;
                else if (donOnline == null)
                    t = tongTienDonOffline ?? 0;
                else
                    t = tongTienDonOffline + donOnline ?? 0;

            }
            else if (tuantruoc)
            {
                KhoangThoiGian tg = layTuanTruoc();

                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                var tongTienDonOffline = qlnh.HOADONs
                                       .Where(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc)
                                       .Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                            .Where(dh => dh.ngaydat >= ngayDaChuyen_batdau && dh.ngaydat <= ngayDaChuyen_kethuc && dh.tinhtranghoadon == 3)
                            .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    t = donOnline ?? 0;
                else if (donOnline == null)
                    t = tongTienDonOffline ?? 0;
                else
                    t = tongTienDonOffline + donOnline ?? 0;

            }
            else if (thangtruoc)
            {
                KhoangThoiGian tg = layThangTruoc();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                var tongTienDonOffline = qlnh.HOADONs
                                       .Where(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc)
                                       .Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                            .Where(dh => dh.ngaydat >= ngayDaChuyen_batdau && dh.ngaydat <= ngayDaChuyen_kethuc && dh.tinhtranghoadon == 3)
                            .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    t = donOnline ?? 0;
                else if (donOnline == null)
                    t = tongTienDonOffline ?? 0;
                else
                    t = tongTienDonOffline + donOnline ?? 0;
            }
            else
            {

                var tongTienDonOffline = qlnh.HOADONs
                                       .Where(hd => hd.ngayxuat >= ngaybd && hd.ngayxuat <= ngaykt)
                                       .Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                            .Where(dh => dh.ngaydat >= ngaybd && dh.ngaydat <= ngaykt && dh.tinhtranghoadon == 3)
                            .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    t = donOnline ?? 0;
                else if (donOnline == null)
                    t = tongTienDonOffline ?? 0;
                else
                    t = tongTienDonOffline + donOnline ?? 0;
            }
            return t;
        }
        public int getSoLuongVoucher(int trangthai, bool all, bool homnay, bool homqua, bool bayngayqua, bool muoibonngayqua, bool bamuoingayqua, bool tuannay, bool thangnay, bool tuantruoc, bool thangtruoc, DateTime ngaybd, DateTime ngaykt)
        {
            var t = 0;
            if (all)
            {
                var countResult = qlnh.HOADONs.Count(hoadon => hoadon.id_voucher != null);
                if (countResult == null)
                    countResult = 0;
                t = countResult;
            }
            else if (homnay)
            {
                DateTime ngayDaChuyen = layNgayHomNay();
                var countResult = qlnh.HOADONs
                .Count(hoadon => hoadon.id_voucher != null && hoadon.ngayxuat == ngayDaChuyen);
                if (countResult == null)
                    countResult = 0;
                t = countResult;
            }
            else if (homqua)
            {
                DateTime ngayDaChuyen = layNgayHomQua();
                var countResult = qlnh.HOADONs
              .Count(hoadon => hoadon.id_voucher != null && hoadon.ngayxuat == ngayDaChuyen);
                if (countResult == null)
                    countResult = 0;
                t = countResult;

            }
            else if (bayngayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(7);
                var countResult = qlnh.HOADONs
              .Count(hoadon => hoadon.id_voucher != null && hoadon.ngayxuat >= ngayDaChuyen);
                if (countResult == null)
                    countResult = 0;
                t = countResult;

            }
            else if (muoibonngayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(14);
                var countResult = qlnh.HOADONs
               .Count(hoadon => hoadon.id_voucher != null && hoadon.ngayxuat >= ngayDaChuyen);
                if (countResult == null)
                    countResult = 0;
                t = countResult;

            }
            else if (bamuoingayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(30);
                var countResult = qlnh.HOADONs
               .Count(hoadon => hoadon.id_voucher != null && hoadon.ngayxuat >= ngayDaChuyen);
                if (countResult == null)
                    countResult = 0;
                t = countResult;

            }
            else if (tuannay)
            {
                KhoangThoiGian tg = layTuanNay();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

                var countResult = qlnh.HOADONs
                .Count(hoadon => hoadon.id_voucher != null &&
                    hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc);
                if (countResult == null)
                    countResult = 0;
                t = countResult;




            }
            else if (thangnay)
            {
                KhoangThoiGian tg = layThangNay();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                var countResult = qlnh.HOADONs
.Count(hoadon => hoadon.id_voucher != null &&
hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc);
                if (countResult == null)
                    countResult = 0;
                t = countResult;

            }
            else if (tuantruoc)
            {
                KhoangThoiGian tg = layTuanTruoc();

                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

                var countResult = qlnh.HOADONs
                .Count(hoadon => hoadon.id_voucher != null &&
                hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc);
                if (countResult == null)
                    countResult = 0;
                t = countResult;

            }
            else if (thangtruoc)
            {
                KhoangThoiGian tg = layThangTruoc();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                var countResult = qlnh.HOADONs
                    .Count(hoadon => hoadon.id_voucher != null &&
                    hoadon.ngayxuat >= ngayDaChuyen_batdau && hoadon.ngayxuat <= ngayDaChuyen_kethuc);
                if (countResult == null)
                    countResult = 0;
                t = countResult;
            }
            else
            {
                var countResult = qlnh.HOADONs
                    .Count(hoadon => hoadon.id_voucher != null &&
                    hoadon.ngayxuat >= ngaybd && hoadon.ngayxuat <= ngaykt);
                if (countResult == null)
                    countResult = 0;
                t = countResult;
            }
            return t;
        }
        public int getSoLuongTienMatALL()
        {
            var sohd = qlnh.HOADONs.Count();
            var sumResult = qlnh.DONHANGONLINEs
                .Where(d => d.phuongthucthanhtoan == "Tiền mặt")
                .Sum(d => 1);
            var t = sohd + sumResult;
            return t;
        }
        public int getTongTienMatALL()
        {

            var sumResult = qlnh.DONHANGONLINEs
            .Where(d => d.phuongthucthanhtoan == "Tiền mặt")
            .Sum(d => d.tongtien);

            return sumResult ?? 0;
        }
        public int getSoLuongDonOffline()
        {
            return 0;
        }
        public int getSoLuongDonOnline(int trangthai, bool all, bool homnay, bool homqua, bool bayngayqua, bool muoibonngayqua, bool bamuoingayqua, bool tuannay, bool thangnay, bool tuantruoc, bool thangtruoc, DateTime ngaybd, DateTime ngaykt)
        {
            var t = 0;
            if (all)
            {
                //var sohd = qlnh.HOADONs.Count();
                var donOnline = qlnh.DONHANGONLINEs.Count(dh => dh.tinhtranghoadon == trangthai);
                if (donOnline == null)
                    donOnline = 0;
                t = donOnline;

            }
            else if (homnay)
            {
                DateTime ngayDaChuyen = layNgayHomNay();

                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat == ngayDaChuyen && hd.tinhtranghoadon == trangthai);
                if (donOnline == null)
                    donOnline = 0;
                t = donOnline;
            }
            else if (homqua)
            {
                DateTime ngayDaChuyen = layNgayHomQua();
                var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat == ngayDaChuyen);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat == ngayDaChuyen && hd.tinhtranghoadon == trangthai);
                if (donOnline == null)
                    donOnline = 0;
                t = donOnline;

            }
            else if (bayngayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(7);

                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen && hd.tinhtranghoadon == trangthai);
                if (donOnline == null)
                    donOnline = 0;
                t = donOnline;
            }
            else if (muoibonngayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(14);

                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen && hd.tinhtranghoadon == trangthai);
                if (donOnline == null)
                    donOnline = 0;
                t = donOnline;

            }
            else if (bamuoingayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(30);

                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen && hd.tinhtranghoadon == trangthai);

                if (donOnline == null)
                    donOnline = 0;
                t = donOnline;
            }
            else if (tuannay)
            {
                KhoangThoiGian tg = layTuanNay();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

                // var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen_batdau && hd.ngaydat <= ngayDaChuyen_kethuc && hd.tinhtranghoadon == trangthai);
                if (donOnline == null)
                    donOnline = 0;
                t = donOnline;
            }
            else if (thangnay)
            {
                KhoangThoiGian tg = layThangNay();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                //var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen_batdau && hd.ngaydat <= ngayDaChuyen_kethuc && hd.tinhtranghoadon == trangthai);
                if (donOnline == null)
                    donOnline = 0;
                t = donOnline;
            }
            else if (tuantruoc)
            {
                KhoangThoiGian tg = layTuanTruoc();

                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                //  var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen_batdau && hd.ngaydat <= ngayDaChuyen_kethuc && hd.tinhtranghoadon == trangthai);
                if (donOnline == null)
                    donOnline = 0;
                t = donOnline;
            }
            else if (thangtruoc)
            {
                KhoangThoiGian tg = layThangTruoc();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                //   var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngayDaChuyen_batdau && hd.ngaydat <= ngayDaChuyen_kethuc && hd.tinhtranghoadon == trangthai);
                if (donOnline == null)
                    donOnline = 0;
                t = donOnline;
            }
            else
            {

                //   var sohd = qlnh.HOADONs.Count(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc);
                var donOnline = qlnh.DONHANGONLINEs.Count(hd => hd.ngaydat >= ngaybd && hd.ngaydat <= ngaykt && hd.tinhtranghoadon == trangthai);
                if (donOnline == null)
                    donOnline = 0;
                t = donOnline;
            }
            return t;
        }
        public int getTongTienDonOffline(int trangthai, bool all, bool homnay, bool homqua, bool bayngayqua, bool muoibonngayqua, bool bamuoingayqua, bool tuannay, bool thangnay, bool tuantruoc, bool thangtruoc, DateTime ngaybd, DateTime ngaykt)
        {
            var t = 0;
            if (all)
            {
                var tongTienDonOffline = qlnh.HOADONs.Sum(hd => hd.tongtien);
                if (tongTienDonOffline == null)
                    tongTienDonOffline = 0;
                t = tongTienDonOffline ?? 0;


            }
            else if (homnay)
            {
                DateTime ngayDaChuyen = layNgayHomNay();
                var tongTienDonOffline = qlnh.HOADONs
                                .Where(hd => hd.ngayxuat == ngayDaChuyen)
                                .Sum(hd => hd.tongtien);
                if (tongTienDonOffline == null)
                    tongTienDonOffline = 0;
                t = tongTienDonOffline ?? 0;
            }
            else if (homqua)
            {
                DateTime ngayDaChuyen = layNgayHomQua();
                var tongTienDonOffline = qlnh.HOADONs
                              .Where(hd => hd.ngayxuat == ngayDaChuyen)
                              .Sum(hd => hd.tongtien);
                if (tongTienDonOffline == null)
                    tongTienDonOffline = 0;
                t = tongTienDonOffline ?? 0;

            }
            else if (bayngayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(7);
                var tongTienDonOffline = qlnh.HOADONs
                                        .Where(hd => hd.ngayxuat >= ngayDaChuyen)
                                        .Sum(hd => hd.tongtien);
                if (tongTienDonOffline == null)
                    tongTienDonOffline = 0;
                t = tongTienDonOffline ?? 0;

            }
            else if (muoibonngayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(14);
                var tongTienDonOffline = qlnh.HOADONs
                                        .Where(hd => hd.ngayxuat >= ngayDaChuyen)
                                        .Sum(hd => hd.tongtien);
                if (tongTienDonOffline == null)
                    tongTienDonOffline = 0;
                t = tongTienDonOffline ?? 0;

            }
            else if (bamuoingayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(30);
                var tongTienDonOffline = qlnh.HOADONs
                                        .Where(hd => hd.ngayxuat >= ngayDaChuyen)
                                        .Sum(hd => hd.tongtien);
                if (tongTienDonOffline == null)
                    tongTienDonOffline = 0;
                t = tongTienDonOffline ?? 0;

            }
            else if (tuannay)
            {
                KhoangThoiGian tg = layTuanNay();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                var tongTienDonOffline = qlnh.HOADONs
                            .Where(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc)
                            .Sum(hd => hd.tongtien);
                if (tongTienDonOffline == null)
                    tongTienDonOffline = 0;
                t = tongTienDonOffline ?? 0;


            }
            else if (thangnay)
            {
                KhoangThoiGian tg = layThangNay();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                var tongTienDonOffline = qlnh.HOADONs
                                            .Where(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc)
                                            .Sum(hd => hd.tongtien);
                if (tongTienDonOffline == null)
                    tongTienDonOffline = 0;
                t = tongTienDonOffline ?? 0;

            }
            else if (tuantruoc)
            {
                KhoangThoiGian tg = layTuanTruoc();

                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                var tongTienDonOffline = qlnh.HOADONs
                                       .Where(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc)
                                       .Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                            .Where(dh => dh.ngaydat >= ngayDaChuyen_batdau && dh.ngaydat <= ngayDaChuyen_kethuc && dh.tinhtranghoadon == 3)
                            .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    tongTienDonOffline = 0;
                t = tongTienDonOffline ?? 0;

            }
            else if (thangtruoc)
            {
                KhoangThoiGian tg = layThangTruoc();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;
                var tongTienDonOffline = qlnh.HOADONs
                                       .Where(hd => hd.ngayxuat >= ngayDaChuyen_batdau && hd.ngayxuat <= ngayDaChuyen_kethuc)
                                       .Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                            .Where(dh => dh.ngaydat >= ngayDaChuyen_batdau && dh.ngaydat <= ngayDaChuyen_kethuc && dh.tinhtranghoadon == 3)
                            .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    tongTienDonOffline = 0;
                t = tongTienDonOffline ?? 0;
            }
            else
            {
                var tongTienDonOffline = qlnh.HOADONs
                                     .Where(hd => hd.ngayxuat >= ngaybd && hd.ngayxuat <= ngaykt)
                                     .Sum(hd => hd.tongtien);
                var donOnline = qlnh.DONHANGONLINEs
                            .Where(dh => dh.ngaydat >= ngaybd && dh.ngaydat <= ngaykt && dh.tinhtranghoadon == 3)
                            .Sum(dh => dh.tongtien);
                if (tongTienDonOffline == null)
                    tongTienDonOffline = 0;
                t = tongTienDonOffline ?? 0;
            }
            return t;
        }
        public int getTongTienDonOnline(int trangthai, bool all, bool homnay, bool homqua, bool bayngayqua, bool muoibonngayqua, bool bamuoingayqua, bool tuannay, bool thangnay, bool tuantruoc, bool thangtruoc, DateTime ngaybd, DateTime ngaykt)
        {
            return 0;
        }
        public int getSoLuongDonHuy(int trangthai, bool all, bool homnay, bool homqua, bool bayngayqua, bool muoibonngayqua, bool bamuoingayqua, bool tuannay, bool thangnay, bool tuantruoc, bool thangtruoc, DateTime ngaybd, DateTime ngaykt)
        {
            var t = 0;
            if (all)
            {
                var sumResult = qlnh.DONHANGONLINEs
                    .Count(d => d.tinhtranghoadon == 4);

                if (sumResult == null)
                    sumResult = 0;
                else
                    t = sumResult;

            }
            else if (homnay)
            {
                DateTime ngayDaChuyen = layNgayHomNay();
                var sumResult = qlnh.DONHANGONLINEs
                            .Count(donHang => donHang.tinhtranghoadon == 4 && donHang.ngaydat == ngayDaChuyen);
                if (sumResult == null)
                    sumResult = 0;
                else
                    t = sumResult;

            }
            else if (homqua)
            {
                DateTime ngayDaChuyen = layNgayHomQua();
                var sumResult = qlnh.DONHANGONLINEs
    .Count(donHang => donHang.tinhtranghoadon == 4 && donHang.ngaydat == ngayDaChuyen);
                if (sumResult == null)
                    sumResult = 0;
                else
                    t = sumResult;
            }
            else if (bayngayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(7);
                var sumResult = qlnh.DONHANGONLINEs
                                .Count(donHang => donHang.tinhtranghoadon == 4 && donHang.ngaydat >= ngayDaChuyen);
                if (sumResult == null)
                    sumResult = 0;
                else
                    t = sumResult;
            }
            else if (muoibonngayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(14);
                var sumResult = qlnh.DONHANGONLINEs
                                .Count(donHang => donHang.tinhtranghoadon == 4 && donHang.ngaydat >= ngayDaChuyen);
                if (sumResult == null)
                    sumResult = 0;
                else
                    t = sumResult;

            }
            else if (bamuoingayqua)
            {
                DateTime ngayDaChuyen = layNNgayQua(30);
                var sumResult = qlnh.DONHANGONLINEs
                               .Count(donHang => donHang.tinhtranghoadon == 4 && donHang.ngaydat >= ngayDaChuyen);
                if (sumResult == null)
                    sumResult = 0;
                else
                    t = sumResult;
            }
            else if (tuannay)
            {
                KhoangThoiGian tg = layTuanNay();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

                var sumResult = qlnh.DONHANGONLINEs
    .Count(donHang => donHang.tinhtranghoadon == 4 && donHang.ngaydat >= ngayDaChuyen_batdau && donHang.ngaydat <= ngayDaChuyen_kethuc);

                if (sumResult == null)
                    sumResult = 0;
                else
                    t = sumResult;
            }
            else if (thangnay)
            {
                KhoangThoiGian tg = layThangNay();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

                var sumResult = qlnh.DONHANGONLINEs
    .Count(donHang => donHang.tinhtranghoadon == 4 && donHang.ngaydat >= ngayDaChuyen_batdau && donHang.ngaydat <= ngayDaChuyen_kethuc);

                if (sumResult == null)
                    sumResult = 0;
                else
                    t = sumResult;
            }
            else if (tuantruoc)
            {
                KhoangThoiGian tg = layTuanTruoc();

                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

                var sumResult = qlnh.DONHANGONLINEs
    .Count(donHang => donHang.tinhtranghoadon == 4 && donHang.ngaydat >= ngayDaChuyen_batdau && donHang.ngaydat <= ngayDaChuyen_kethuc);

                if (sumResult == null)
                    sumResult = 0;
                else
                    t = sumResult;
            }
            else if (thangtruoc)
            {
                KhoangThoiGian tg = layThangTruoc();
                DateTime ngayDaChuyen_batdau = tg.NgayBatDau;
                DateTime ngayDaChuyen_kethuc = tg.NgayKetThuc;

                var sumResult = qlnh.DONHANGONLINEs
    .Count(donHang => donHang.tinhtranghoadon == 4 && donHang.ngaydat >= ngayDaChuyen_batdau && donHang.ngaydat <= ngayDaChuyen_kethuc);

                if (sumResult == null)
                    sumResult = 0;
                else
                    t = sumResult;
            }
            else
            {
                var sumResult = qlnh.DONHANGONLINEs
         .Count(donHang => donHang.tinhtranghoadon == 4 && donHang.ngaydat >= ngaybd && donHang.ngaydat <= ngaykt);

                if (sumResult == null)
                    sumResult = 0;
                else
                    t = sumResult;
            }
            return t;

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

        public bool thao_addInvoices(int id_voucher, int id_nv, int tongtien, String ghichu)
        {
            try
            {
                HOADON hd = new HOADON();
                if (id_voucher == 0)
                {
                    hd.id_voucher = null;
                }
                else
                {
                    hd.id_voucher = id_voucher;
                }
                hd.id_nv = id_nv;

                //ngay xuat hoa don
                DateTime dateAndTime = DateTime.Now.Date;
                String date = dateAndTime.ToString();
                DateTime MyAwesomeDateTime2 = DateTime.Parse(date);
                hd.ngayxuat = MyAwesomeDateTime2;

                hd.tongtien = tongtien;
                hd.ghichu = ghichu;

                qlnh.HOADONs.InsertOnSubmit(hd);
                qlnh.SubmitChanges();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool thao_addDetailsOfInvoice(int id_hd, int id_mon, int soluong, int giaban)
        {
            try
            {
                CHITIETHOADON cthd = new CHITIETHOADON();
                cthd.id_hd = id_hd;
                cthd.id_mon = id_mon;
                cthd.soluong = soluong;
                cthd.giaban = giaban;
                cthd.thanhtien = giaban * soluong;

                qlnh.CHITIETHOADONs.InsertOnSubmit(cthd);
                qlnh.SubmitChanges();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public int thao_getIdHD()
        {
            return (from u in qlnh.HOADONs
                    orderby u.id_hd descending
                    select u.id_hd).First();
        }
    }
}
