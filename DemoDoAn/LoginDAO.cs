//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn
{
    internal class LoginDAO
    {
        DBConnection dbConn = new DBConnection();

        //tai bang thong tin full
        public DataTable loadFull()
        {
            string sqlStr = string.Format("SELECT * FROM FULL_THONGTIN");
            return dbConn.LayDanhSach(sqlStr);
        }

        //tai bang acc
        public DataTable loadAccount()
        {
            string sqlStr = string.Format("SELECT CONCAT(AccID_Adm,AccID_Stu, AccID_Tea) as AccID, " +
                                        "CONCAT(ACCOUNTS_ADMIN.username, ACCOUNTS_STUDENT.username, ACCOUNTS_TEACHER.username) as username, " +
                                        "CONCAT(ACCOUNTS_ADMIN.pass, ACCOUNTS_STUDENT.pass, ACCOUNTS_TEACHER.pass) as pass, " +
                                        "CONCAT(ACCOUNTS_ADMIN.Remember, ACCOUNTS_STUDENT.Remember, ACCOUNTS_TEACHER.Remember) as remember "+
                                        "FROM ACCOUNTS_ADMIN full join ACCOUNTS_STUDENT on ACCOUNTS_ADMIN.AccID_Adm = ACCOUNTS_STUDENT.AccID_Stu " +
                                        "full join ACCOUNTS_TEACHER on ACCOUNTS_ADMIN.AccID_Adm = ACCOUNTS_TEACHER.AccID_Tea");
            return dbConn.LayDanhSach(sqlStr);
        }

        //check acc
        public DataTable Login(string username, string password, string accTable)
        {
            string sqlStr = string.Format("Select * From {0} Where username = '{1}' and pass = '{2}'",  accTable, username, password);
            return dbConn.LayDanhSach(sqlStr);
        }

        //check remember pass
        public DataTable updateRememberPass(string username, string accTable, int remember)
        {
            string sqlStr = string.Format("Update {0} Set Remember = {1} Where username = '{2}'", accTable, remember,username);
            return dbConn.LayDanhSach(sqlStr);
        }


    }
}
