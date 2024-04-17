using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonAn
    {
        int stt, id_mon, id_loai;

        public int Id_loai
        {
            get { return id_loai; }
            set { id_loai = value; }
        }

        public int Id_mon
        {
            get { return id_mon; }
            set { id_mon = value; }
        }

        public int Stt
        {
            get { return stt; }
            set { stt = value; }
        }
        string tenmon, ghichu, hinh, icon;
        int giaban;

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public string Hinh
        {
            get { return hinh; }
            set { hinh = value; }
        }

        public string Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        public int Giaban
        {
            get { return giaban; }
            set { giaban = value; }
        }

        public string Tenmon
        {
            get { return tenmon; }
            set { tenmon = value; }
        }
        public MonAn()
        {


        }
    }
}
