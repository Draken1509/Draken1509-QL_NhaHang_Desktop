using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public int id_nv { get; set; }
        public String tennv { get; set; }
        private String tinhtranglamviec;

        public String Tinhtranglamviec
        {
            get { return tinhtranglamviec; }
            set
            {
                if (value == "0")
                {
                    tinhtranglamviec = "Đã nghỉ việc";
                }
                else
                {
                    tinhtranglamviec = "Đang làm việc";
                }
            }
        }
    }
}
