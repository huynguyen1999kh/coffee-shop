using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Catetory
    {
        private int iD;
        private string name;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }

        public Catetory(int id, string name)
        {
            this.iD = id;
            this.name = name;
        }

        public Catetory(DataRow data)
        {
            this.iD = (int) data["id"];
            this.name = data["name"].ToString();
        }
    }
}
