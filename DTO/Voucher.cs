using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class Voucher
    {
        int id;
         string mucGiam;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string MucGiam
        {
            get { return mucGiam; }
            set { mucGiam = value; }
        }
        string tenVoucher;

        public string TenVoucher
        {
            get { return tenVoucher; }
            set { tenVoucher = value; }
        }


        public Voucher()
        {
            this.id = Id;
            this.tenVoucher = TenVoucher;
            this.mucGiam = MucGiam;

        }

    }
}
