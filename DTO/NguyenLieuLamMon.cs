using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguyenLieuLamMon
    {
        int idNguyenLieuLamMon;

        public int IdNguyenLieuLamMon
        {
            get { return idNguyenLieuLamMon; }
            set { idNguyenLieuLamMon = value; }
        }
        string tenNguyenLieu;

        public string TenNguyenLieu
        {
            get { return tenNguyenLieu; }
            set { tenNguyenLieu = value; }
        }
        string icon;

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        public NguyenLieuLamMon()
        {

        }
    }
}
