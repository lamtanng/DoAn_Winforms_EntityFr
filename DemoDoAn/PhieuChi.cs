using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class PhieuChi
    {
        string id;
        string chucvu;
        string loaitien;
        int tien;
        DateTime ngaygio;

        public string ID { get { return id; } set { id = value; } }
        public string CHUCVU { get { return chucvu; } set { chucvu = value; } }
        public string LOAITIEN { get { return loaitien; } set { loaitien = value; } }
        public int TIEN { get { return tien; } set { tien = value; } }
        public DateTime NGAYGIO { get { return ngaygio; } set { ngaygio = value; } }

        public PhieuChi()
        {
        }
        public PhieuChi(string id, string chucvu, string loaitien, int tien, DateTime ngaygio)
        {
            this.id = id;
            this.chucvu = chucvu;
            this.loaitien = loaitien;
            this.tien = tien;
            this.ngaygio = ngaygio;
        }
    }
}
