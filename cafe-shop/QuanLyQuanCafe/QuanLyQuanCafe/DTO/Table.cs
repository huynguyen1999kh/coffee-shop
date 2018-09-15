using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Table
    {
        private int iD;
        private string name;
        private string status;

        public int ID { get => iD; set => iD = value; }
        public string Status { get => status; set => status = value; }
        public string Name { get => name; set => name = value; }

        public Table(int ID, string name, string status)
        {
            this.iD = ID;
            this.name = name;
            this.status = status;
        }

        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.name = row["name"].ToString();
            this.status = row["status"].ToString();
        }
    }
}
