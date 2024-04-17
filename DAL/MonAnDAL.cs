using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class MonAnDAL
    {
        QL_NhaHangDataContext qlnh = new QL_NhaHangDataContext();
        public MonAnDAL()
        {

        }
        public List<MonAn> getThongTinMonAn()
        {
            var menuItems = from menu in qlnh.MENUs
                            select new MonAn
                            {
                                Stt=0,
                                Id_mon = menu.id_mon,
                                Id_loai = menu.id_loai,
                                Tenmon= menu.tenmon,
                                Giaban= menu.giaban *1000 ?? 0,
                                Ghichu=menu.ghichu,
                                Hinh = menu.hinh,
                                Icon = "" // Thay thế bằng đường dẫn cụ thể hoặc tên icon từ resource
                            };

            return menuItems.ToList();
        }


        public List<MonAn> getThongTinMonAnTheoMaMon(int id)
        {
            var menuItems = from menu in qlnh.MENUs
                            where menu.id_mon == id
                            select new MonAn
                            {
                                Stt = 0,
                                Id_mon = menu.id_mon,
                                Id_loai = menu.id_loai,
                                Tenmon = menu.tenmon,
                                Giaban = menu.giaban * 1000 ?? 0,
                                Ghichu = menu.ghichu,
                                Hinh = menu.hinh,
                                Icon = "" // Thay thế bằng đường dẫn cụ thể hoặc tên icon từ resource
                            };

            return menuItems.ToList();
        }

        public List<MonAn> getThongTinMonAnTheoLoai(int  idl )
        {
            var menuItems = from menu in qlnh.MENUs
                            where menu.id_loai == idl
                            select new MonAn
                            {
                                Stt = 0,
                                Id_mon = menu.id_mon,
                                Id_loai = menu.id_loai,
                                Tenmon = menu.tenmon,
                                Giaban = menu.giaban * 1000 ?? 0,
                                Ghichu = menu.ghichu,
                                Hinh = menu.hinh,
                                Icon = "iconstrash" // Thay thế bằng đường dẫn cụ thể hoặc tên icon từ resource
                            };

            return menuItems.ToList();
        }

        public List<MonAn> timKiem(string name)
        {
            var query = from menu in qlnh.MENUs
                        join loai in qlnh.LOAIs on menu.id_loai equals loai.id_loai
                        where (loai.tenloai == name || menu.tenmon == name)
                        select new MonAn
                        {
                            Stt = 0,
                            Id_mon = menu.id_mon,
                            Id_loai = menu.id_loai,
                            Tenmon = menu.tenmon,
                            Giaban = menu.giaban * 1000 ?? 0,
                            Ghichu = menu.ghichu,
                            Hinh = menu.hinh,
                            Icon = "iconstrash" // Thay thế bằng đường dẫn cụ thể hoặc tên icon từ resource
                        };

            var result = query.ToList();
            return result;

        }
        public int updateMonAn( int idmon, int idloai, string tenmon, int pGiaban, string pGhichu)
        {
            // Assuming you have a data context named dbContext
            var menuItem = qlnh.MENUs.FirstOrDefault(m => m.id_mon == idmon);

            if (menuItem != null)
            {
                // Update the properties
                menuItem.id_loai = idloai;
                menuItem.tenmon = tenmon;
                menuItem.giaban = pGiaban;
                menuItem.ghichu = pGhichu;
                // Save changes to the database
                qlnh.SubmitChanges();
                return 1;
            }
            return 0;

        }

        public int xoa(int id)
        {
            var nguyenLieuToDelete = qlnh.NGUYENLIEULAMMONs.Where(n => n.id_mon == id).ToList();
            if (nguyenLieuToDelete.Any())
            {
                qlnh.NGUYENLIEULAMMONs.DeleteAllOnSubmit(nguyenLieuToDelete);
                try
                {
                    qlnh.SubmitChanges();                  
                }
                catch
                {
                    return 0; // Thất bại
                }
            }
            var menuToDelete = qlnh.MENUs.SingleOrDefault(m => m.id_mon == id);
            if (menuToDelete != null)
            {
                qlnh.MENUs.DeleteOnSubmit(menuToDelete);
                try
                {
                   
                    qlnh.SubmitChanges();                
                }
                catch
                {
                    return 0; // Thất bại
                }               
            }
            return 1;
        }

        public int getMaxID()
        {
            var maxIdMon = qlnh.MENUs.Max(menu => menu.id_mon);
            return maxIdMon;
        }

        public int themMonAn(int pidMon, int pidLoai, string pName, int pGiaBan, string pGhiChu, string pHinh)
        {
            var newMenu = new MENU
            {
                id_mon = pidMon,
                id_loai = pidLoai,
                tenmon = pName,
                giaban = pGiaBan,
                ghichu = pGhiChu,
                hinh = pHinh
            };

             try
                {
                    qlnh.MENUs.InsertOnSubmit(newMenu);
                    qlnh.SubmitChanges();
                    return 1;
                }
                catch (Exception ex)
                {
                    return 0;
                }
             return 0;
        }


    }
}
