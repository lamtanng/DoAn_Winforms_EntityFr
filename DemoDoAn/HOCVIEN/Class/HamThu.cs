using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDoAn.HOCVIEN.Class
{
    internal class HamThu
    {
        string mathu;
        string idgui;
        string idnhan;
        string hoten;
        string tieude;
        string noidung;
        DateTime ngay;
        DateTime gio;
        bool danhdau;
        string chucvu;

        public string Mathu { get { return mathu; } set { mathu = value; } }
        public string Hoten { get { return hoten; } set { hoten = value; } }
        public string IDGui { get { return idgui; } set { idgui = value; } }
        public string IDNhan { get { return idnhan; } set { idnhan = value; } }
        public string Tieude { get { return tieude; } set { tieude = value; } }
        public DateTime Gio { get { return gio; } set { gio = value; } }
        public bool Danhdau { get { return danhdau; } set {  danhdau = value;} }
        public string Noidung { get { return noidung; } set {noidung = value; } }
        public DateTime Ngay { get { return ngay; } set { ngay = value; } }
        public string ChucVu { get { return chucvu; } set { chucvu = value; } }

        //
        public HamThu(string idgui, string tieude, string noidung, DateTime ngay, DateTime gio, bool danhdau, string idnhan, string chucvu)
        {
            this.idgui = idgui;
            this.tieude = tieude;
            this.noidung = noidung;
            this.ngay = ngay;
            this.gio = gio;
            this.danhdau = danhdau;
            this.idnhan = idnhan;
            this.chucvu = chucvu;

        }
        public HamThu()
        { }
    }
}
