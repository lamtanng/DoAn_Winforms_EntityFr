using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoDoAn
{
    internal class PhieuThu
    {
        private string MaPT;
        private string hvid;
        string maLop;
        private string LoaiPT;
        private DateTime ngaythu;
        private int tongtien;

        public string MAPT { get { return MaPT; } set{ MaPT = value; }}
        public string LOAIPT { get { return LoaiPT; } set { LoaiPT = value; } }
        public DateTime NGAYTHU { get { return ngaythu; } set { ngaythu = value; } }
        public int TONGTIEN { get { return tongtien; } set { tongtien = value; } }
        public string HVID { get { return hvid; } set { hvid = value; } }
        public string MALOP { get { return maLop; } set {  maLop = value; }  }

        public PhieuThu() { }
        public PhieuThu(string MaPT, string LoaiPT, DateTime ngaythu, int tongtien, string hvid, string maLop)
        {
            this.MaPT = MaPT;
            this.LoaiPT = LoaiPT;
            this.ngaythu = ngaythu;
            this.tongtien = tongtien;
            this.hvid = hvid;
            this.maLop = maLop;
        }
    }
}
