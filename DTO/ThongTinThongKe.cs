using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongTinThongKe
    {
        int soLuongHd;

        public int SoLuongHd
        {
            get { return soLuongHd; }
            set { soLuongHd = value; }
        }
        int doanhThu;

        public int DoanhThu
        {
            get { return doanhThu; }
            set { doanhThu = value; }
        }
        int soVoucher;

        public int SoVoucher
        {
            get { return soVoucher; }
            set { soVoucher = value; }
        }
        int soTienMat;

        public int SoTienMat
        {
            get { return soTienMat; }
            set { soTienMat = value; }
        }
        int soChuyenKhoan;

        public int SoChuyenKhoan
        {
            get { return soChuyenKhoan; }
            set { soChuyenKhoan = value; }
        }
        int tongTienMat;

        public int TongTienMat
        {
            get { return tongTienMat; }
            set { tongTienMat = value; }
        }
        int tongChuyenKhoan;

        public int TongChuyenKhoan
        {
            get { return tongChuyenKhoan; }
            set { tongChuyenKhoan = value; }
        }
        int soDonOffline;

        public int SoDonOffline
        {
            get { return soDonOffline; }
            set { soDonOffline = value; }
        }
        int soDonOnline;

        public int SoDonOnline
        {
            get { return soDonOnline; }
            set { soDonOnline = value; }
        }
        int soDonDangVanChuyen;

        public int SoDonDangVanChuyen
        {
            get { return soDonDangVanChuyen; }
            set { soDonDangVanChuyen = value; }
        }
        int soDonDaHuy;

        public int SoDonDaHuy
        {
            get { return soDonDaHuy; }
            set { soDonDaHuy = value; }
        }


        int tongTienDonOffline;

        public int TongTienDonOffline
        {
            get { return tongTienDonOffline; }
            set { tongTienDonOffline = value; }
        }
        int tongTienDonOnline;

        public int TongTienDonOnline
        {
            get { return tongTienDonOnline; }
            set { tongTienDonOnline = value; }
        }
        public ThongTinThongKe()
        {
            this.soLuongHd = SoLuongHd;
            this.doanhThu = DoanhThu;
            this.soVoucher = SoVoucher;
            this.soTienMat = SoTienMat;
            this.soChuyenKhoan = SoChuyenKhoan;
            this.tongTienMat = TongTienMat;
            this.tongChuyenKhoan = TongChuyenKhoan;
            this.soDonOnline = SoDonOnline;
            this.soDonOffline = SoDonOffline;
            this.soDonDangVanChuyen = SoDonDangVanChuyen;
            this.soDonDaHuy = SoDonDaHuy;
            this.tongTienDonOffline = TongTienDonOffline;
            this.tongTienDonOnline = TongTienDonOnline;
        }


    }
}
