using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class NguyenLieuDAL
    {
        QL_NhaHangDataContext qlnh = new QL_NhaHangDataContext();
        public NguyenLieuDAL()
        {

        }

        public List<NGUYENLIEU> getnl()
        {
            return (from a in qlnh.NGUYENLIEUs select a).ToList();
        }

        public List<NguyenLieuLamMon> getNguyenLieuLamMon( int idMon)
        {
                   var result = from nlmm in qlnh.NGUYENLIEULAMMONs
                     join nl in qlnh.NGUYENLIEUs on nlmm.id_nguyenlieu equals nl.id_nguyenlieu
                     where nlmm.id_mon == idMon
                     select new NguyenLieuLamMon
                     {
                         IdNguyenLieuLamMon = nlmm.id_nguyenlieu,
                         TenNguyenLieu = nl.tennguyenlieu,
                         Icon="iconstrash"
                     };       
            return result.ToList();

        }
        public List<NguyenLieuLamMon> getALLNguyenLieuLamMon()
        {
            var result = from nl in qlnh.NGUYENLIEUs                           
                                  select new NguyenLieuLamMon
                                  {
                                      IdNguyenLieuLamMon = nl.id_nguyenlieu,
                                      TenNguyenLieu = nl.tennguyenlieu,
                                      IsSelected = false
                                  };
            return result.ToList();


        }
        
        public int xoaNguyenLieu(int idMon, int idNguyenLieu)
        {
            var nguyenLieuLamMonToDelete = qlnh.NGUYENLIEULAMMONs
                                  .SingleOrDefault(nlmm => nlmm.id_mon == idMon && nlmm.id_nguyenlieu == idNguyenLieu);
            try
            {
                if (nguyenLieuLamMonToDelete != null)
                {
                    qlnh.NGUYENLIEULAMMONs.DeleteOnSubmit(nguyenLieuLamMonToDelete);
                    qlnh.SubmitChanges();                  
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;

        }
        public int themNguyenLieu(int idMon, int idNguyenLieu)
        {
            var newNguyenLieuLamMon = new NGUYENLIEULAMMON
            {
                id_mon = idMon,
                id_nguyenlieu = idNguyenLieu,
            };
            try
            {
                qlnh.NGUYENLIEULAMMONs.InsertOnSubmit(newNguyenLieuLamMon);
                qlnh.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;

            }
            return 1;

        }
        public int ktNguyenLieu(int idMon, int idNguyenLieu)  // trả về id nguyên liẹu
        {
            var query = from nlm in qlnh.NGUYENLIEULAMMONs
                        where nlm.id_mon == idMon && nlm.id_nguyenlieu == idNguyenLieu
                        select nlm.id_nguyenlieu;
            int? result = query.SingleOrDefault();
            

            if (result != null)
            {
                return result ?? 0;
            }
            else
            {
                  return 0;
            }
        }

        public List<NguyenLieuLamMon> timNguyenLieuLamMon(string tenNL)
        {
            var result = from nl in qlnh.NGUYENLIEUs
                         where nl.tennguyenlieu == tenNL
                         select new NguyenLieuLamMon
                         {
                             IdNguyenLieuLamMon = nl.id_nguyenlieu,
                             TenNguyenLieu = nl.tennguyenlieu,
                             IsSelected = false
                         };
            return result.ToList();
        }

    }
}
