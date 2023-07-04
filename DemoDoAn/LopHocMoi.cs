using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class LopHocMoi
    {
        private string khoahoc;
        private string tenlop;
        private int hocphi;
        private string trangthai;
        public string KHOAHOC { get { return khoahoc; } }
        public string Tenlop { get { return tenlop; } }
        public int Hocphi { get { return hocphi; } }
        public string Transgthai { get { return trangthai; } }
        public LopHocMoi(string khoahoc, string tenlop,int hocphi, string trangthai)
        {
            
            this.trangthai = trangthai;
            this.hocphi = hocphi;
            this.khoahoc = khoahoc;
            this.tenlop = tenlop;
        }

    }
}
