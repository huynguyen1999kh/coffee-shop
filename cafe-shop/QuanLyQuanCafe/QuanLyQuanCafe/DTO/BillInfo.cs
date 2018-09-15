using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class BillInfo
    {
        private int iD;
        private int iDFood;
        private int iDBill;
        private int count;

        public int ID { get => iD; set => iD = value; }
        public int IDFood { get => iDFood; set => iDFood = value; }
        public int IDBill { get => iDBill; set => iDBill = value; }
        public int Count { get => count; set => count = value; }

        public BillInfo(int id, int idfood, int idbill, int count)
        {
            this.iD = id;
            this.iDFood = idfood;
            this.IDBill = iDBill;
            this.count = count;
        }

        public BillInfo(DataRow data)
        {
            this.iD = (int) data["id"];
            this.iDFood = (int) data["idFood"];
            this.IDBill = (int) data["idBill"];
            this.count = (int) data["count"];
        }
    }
}
