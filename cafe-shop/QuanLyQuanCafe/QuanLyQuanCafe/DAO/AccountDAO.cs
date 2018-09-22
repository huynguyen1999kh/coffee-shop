using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(Password);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string query = "exec dbo.USP_GetAccountByUserNameAndPassword @userName , @password ";

            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            //var list = hasData.ToString();
            //list.Reverse();
            /*
             * bug
             * if user enter password = 'or 1=1 --
             * or username = 'or 1=1 --
             * the username/password return true due to 1=1 statment
             */
            try
            {
                int result = (int)DataProvider.Instance.ExcuteScarar(query, new object[] { userName, hasPass });
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
        public bool InsertAccount(string userName, string displayName, int type)
        {
            string query = string.Format("insert dbo.Account(UserName, DisplayName, type, Password) values(N'{0}', N'{1}',{2} , N'1962026656160185351301320480154111117132155')", userName, displayName, type);
            int data = DataProvider.Instance.ExcuteNonQuery(query);
            return data > 0;
        }
        public bool UpdateAccount(string userName, string displayName, int type)
        {
            string query = string.Format("update dbo.Account set DisplayName = N'{0}',type = {1} where UserName = N'{2}'", displayName, type, userName);
            int data = DataProvider.Instance.ExcuteNonQuery(query);
            return data > 0;
        }
        public int GetIDAccountTypeByName(string name)
        {
            string query = "select id from dbo.Accounttype where name = N'" + name +"'";
            return (int) DataProvider.Instance.ExcuteScarar(query);
        }
        public bool DeleteAccount(string userName)
        {
            string query = string.Format("delete dbo.Account where UserName = N'"+userName+"'");
            int data = DataProvider.Instance.ExcuteNonQuery(query);
            return data > 0;
        }
        public bool SetdefaultPassword(string userName)
        {
            int data = DataProvider.Instance.ExcuteNonQuery("update dbo.Account set Password = N'1962026656160185351301320480154111117132155' where UserName = N'" + userName + "'");
            return data > 0;
        }
    }
}
