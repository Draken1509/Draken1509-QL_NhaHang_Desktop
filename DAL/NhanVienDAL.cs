using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhanVienDAL
    {
        QL_NhaHangDataContext qlnh = new QL_NhaHangDataContext();
        public NHANVIEN getEmployee(string username, string password)
        {
            NHANVIEN employee = qlnh.NHANVIENs
                                .FirstOrDefault(e => e.username == username && e.password == password);
            return employee;
        }
        public List<NhanVien> loadNhanVien()
        {
            return (from a in qlnh.NHANVIENs
                    select new NhanVien
                    {
                        id_nv = a.id_nv,
                        tennv = a.tennv,
                        Tinhtranglamviec = a.tinhtranglamviec.ToString()
                    }).ToList();
        }
        public List<PhanQuyen> loadPhanQuyen()
        {
            return (from a in qlnh.PHANQUYENs
                    select new PhanQuyen
                    {
                        id_quyen = a.id_quyen,
                        phanquyen = a.phanquyen1
                    }).ToList();
        }
        public NHANVIEN getThongTinNhanVien(int id_nv)
        {
            return (from a in qlnh.NHANVIENs where a.id_nv == id_nv select a).SingleOrDefault();
        }
        public bool addNhanVien(int id_quyen, String tennv, bool tinhtranglamviec, String username, String password)
        {
            try
            {
                NHANVIEN nv = new NHANVIEN();
                nv.tennv = tennv;
                nv.id_quyen = id_quyen;
                nv.tinhtranglamviec = tinhtranglamviec;
                nv.username = username;
                nv.password = password;

                qlnh.NHANVIENs.InsertOnSubmit(nv);

                qlnh.SubmitChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool deleteNhanVien(int id_nv)
        {
            try
            {
                NHANVIEN nv = (from a in qlnh.NHANVIENs where a.id_nv == id_nv select a).SingleOrDefault();

                qlnh.NHANVIENs.DeleteOnSubmit(nv);

                qlnh.SubmitChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool editNhanVien(int id_quyen, String tennv, bool tinhtranglamviec, String username, int id_nv)
        {
            try
            {
                NHANVIEN nv = (from a in qlnh.NHANVIENs where a.id_nv == id_nv select a).SingleOrDefault();

                nv.id_quyen = id_quyen;
                nv.tennv = tennv;
                nv.tinhtranglamviec = tinhtranglamviec;
                nv.username = username;

                qlnh.SubmitChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
