using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DonNhapHangDAL
    {
        QL_NhaHangDataContext qlnh = new QL_NhaHangDataContext();

        public List<ThongTinDonNhapHang> LayThongTinHaiBang()
        {
            var thongTin = (from don in qlnh.DONNHAPHANGs
                            join ncc in qlnh.NHACUNGCAPs on don.id_ncc equals ncc.id_ncc
                            select new ThongTinDonNhapHang
                            {
                                id_dnh = don.id_dnh,
                                id_ncc = don.id_ncc,
                                ngaynhap = don.ngaynhap ?? new DateTime(2023, 10, 30),
                                tinhtrangnhanhang = don.tinhtrangnhanhang.HasValue ? don.tinhtrangnhanhang.Value : false,
                                tongtien = don.tongtien.HasValue ? don.tongtien.Value : 0,
                                tenncc = ncc.tenncc
                            }).ToList();

            return thongTin;
        }

        public List<ThongTinDonNhapHang> TimTheoIDDNH(int id_dnh)
        {
            var danhSachThongTin = LayThongTinHaiBang();
            var thongTinCanTim = danhSachThongTin.FirstOrDefault(don => don.id_dnh == id_dnh);
            List<ThongTinDonNhapHang> lst = new List<ThongTinDonNhapHang>();
            lst.Add(thongTinCanTim);
            return lst;
        }

        public List<ThongTinDonNhapHang> LoadTheoNCC(int id_ncc)
        {
            var thongTin = (from don in qlnh.DONNHAPHANGs
                            join ncc in qlnh.NHACUNGCAPs on don.id_ncc equals ncc.id_ncc
                            where don.id_ncc == id_ncc
                            select new ThongTinDonNhapHang
                            {
                                id_dnh = don.id_dnh,
                                id_ncc = don.id_ncc,
                                ngaynhap = don.ngaynhap ?? new DateTime(2023, 10, 30),
                                tinhtrangnhanhang = don.tinhtrangnhanhang.HasValue ? don.tinhtrangnhanhang.Value : false,
                                tongtien = don.tongtien.HasValue ? don.tongtien.Value : 0,
                                tenncc = ncc.tenncc
                            }).ToList();

            return thongTin;
        }

        public List<ThongTinDonNhapHang> LoadTheoTinhTrang(bool trangThai)
        {
            var thongTin = (from don in qlnh.DONNHAPHANGs
                            join ncc in qlnh.NHACUNGCAPs on don.id_ncc equals ncc.id_ncc
                            where don.tinhtrangnhanhang == trangThai
                            select new ThongTinDonNhapHang
                            {
                                id_dnh = don.id_dnh,
                                id_ncc = don.id_ncc,
                                ngaynhap = don.ngaynhap ?? DateTime.Now,
                                tinhtrangnhanhang = don.tinhtrangnhanhang.HasValue ? don.tinhtrangnhanhang.Value : false,
                                tongtien = don.tongtien.HasValue ? don.tongtien.Value : 0,
                                tenncc = ncc.tenncc
                            }).ToList();

            return thongTin;
        }

        // Chi tiết đơn nhập hàng
        public List<ChiTietDonNhapHang> loadChietnhaphang(int id_dnh)
        {
            var thongtin = (from ct in qlnh.CHITIETDONNHAPHANGs
                            join nl in qlnh.NGUYENLIEUs on ct.id_nguyenlieu equals nl.id_nguyenlieu
                            join dnh in qlnh.DONNHAPHANGs on ct.id_dnh equals dnh.id_dnh
                            where ct.id_dnh == id_dnh
                            select new ChiTietDonNhapHang
                            {
                                tennl = nl.tennguyenlieu,
                                gianhap = nl.gianhap.GetValueOrDefault(),
                                ngaynhap = dnh.ngaynhap ?? DateTime.Now,
                                khoiluong = ct.khoiluongnhap.GetValueOrDefault(),
                                id_nl = nl.id_nguyenlieu,
                                thanhtien = nl.gianhap.GetValueOrDefault() * ct.khoiluongnhap.GetValueOrDefault()
                            }).ToList();
            return thongtin;
        }

        public void CapNhatTinhTrangNhanHang(int id_dnh, bool tinhTrangMoi)
        {
            var donNhapHang = qlnh.DONNHAPHANGs.FirstOrDefault(don => don.id_dnh == id_dnh);
            if (donNhapHang != null)
            {
                donNhapHang.tinhtrangnhanhang = tinhTrangMoi;
                qlnh.SubmitChanges();
            }
            else
            {
                throw new ArgumentException("Không tìm thấy đơn hàng có ID đã chỉ định.");
            }
        }

        public void CapNhatSoLuongNguyenLieu(int id_nguyenlieu, int soLuongCanThem)
        {
            var nguyenLieu = qlnh.NGUYENLIEUs.FirstOrDefault(nl => nl.id_nguyenlieu == id_nguyenlieu);
            if (nguyenLieu != null)
            {
                nguyenLieu.khoiluongnguyenlieu += soLuongCanThem;
                qlnh.SubmitChanges();
            }
            else
            {
                throw new ArgumentException("Không tìm thấy nguyên liệu có ID đã chỉ định.");
            }
        }

        //Lấy nhà cung cấp
        public List<NHACUNGCAP> loadNCC()
        {
            return (from a in qlnh.NHACUNGCAPs select a).ToList();
        }

        public List<NGUYENLIEU> loadNL()
        {
            return (from a in qlnh.NGUYENLIEUs select a).ToList();
        }

        public int loaddonnhaphang()
        {
            return (from a in qlnh.DONNHAPHANGs select a).ToList().Count;
        }


        public List<NGUYENLIEU> loadNguyenLieu(int id_ncc)
        {
            var danhsach = loadNL();
            var thongTinCanTim = danhsach.Where(don => don.id_ncc == id_ncc).ToList();
            return thongTinCanTim;
        }

        public void ThemDonNhapHang(DONNHAPHANG donnhaphang)
        {
            try
            {
                qlnh.DONNHAPHANGs.InsertOnSubmit(donnhaphang);
                qlnh.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ThemChiTietDonNhapHang(CHITIETDONNHAPHANG ctdnh)
        {
            try
            {
                qlnh.CHITIETDONNHAPHANGs.InsertOnSubmit(ctdnh);
                qlnh.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public NGUYENLIEU LayNguyenLieuTheoID(int id_nguyenlieu)
        {
            var nguyenLieu = qlnh.NGUYENLIEUs.FirstOrDefault(nl => nl.id_nguyenlieu == id_nguyenlieu);

            if (nguyenLieu == null)
            {
                throw new ArgumentException("Không tìm thấy nguyên liệu có ID đã chỉ định.");
            }

            return nguyenLieu;
        }
    }
}
