using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO //singerton
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance;}
            private set { instance = value; }
        }
        private AccountDAO() { }

        public bool login(string userName, string Password)
        {
            string query = "exec dbo.USP_GetAccountByUserNameAndPassword @userName , @password ";
            /*
             * bug
             * if user enter password = 'or 1=1 --
             * or username = 'or 1=1 --
             * the username/password return true due to 1=1 statment
             */
            try
            {
                int result = (int)DataProvider.Instance.ExcuteScarar(query, new object[] { userName, Password });
                return result > 0;
            }  catch
            {
                return false;
            }
            
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newpass)
        {
            int data = DataProvider.Instance.ExcuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword ", new object[] { userName, displayName, pass, newpass });
            return data > 0;
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from dbo.Account where userName = N'" + userName +"'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        public DataTable GetListAccount()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select userName as [tên tài khoản],displayName as [tên hiển thị],name as [loại tài khoản] from dbo.Account,dbo.Accounttype where type = dbo.Accounttype.id");
            return data;
        }
        public DataTable GetListAccountType()
        {
            return DataProvider.Instance.ExcuteQuery("select * from dbo.Accounttype");
        }
    }
}
