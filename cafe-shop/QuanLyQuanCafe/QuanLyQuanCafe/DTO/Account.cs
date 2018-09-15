using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Account
    {
        private string userName;
        private string password;
        private string displayName;
        private int type;

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public int Type { get => type; set => type = value; }

        public Account(string userName, string displayName, int type, string password = null)
        {
            this.displayName = displayName;
            this.type = type;
            this.userName = userName;
            this.password = password;
        }

        public Account(DataRow data)
        {
            this.displayName = data["DisplayName"].ToString();
            this.type = (int)data["type"];
            this.userName = data["UserName"].ToString();
            this.password = data["Password"].ToString();
        }
    }
}
