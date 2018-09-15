using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int status;
        private int iD;
        private int discount;

        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
        public int ID { get => iD; set => iD = value; }
        public int Discount { get => discount; set => discount = value; }

        public Bill(int ID, DateTime? dateCheckIn, DateTime? dateCheckOut, int status, int discount)
        {
            this.ID = ID;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            this.status = status;
            this.discount = discount;
        }
        public Bill(DataRow data)
        {
            this.ID = (int) data["id"];
            this.dateCheckIn = (DateTime?) data["dateCheckIn"];
            if (data["dateCheckOut"].ToString() != "")
                this.dateCheckOut = (DateTime?)data["dateCheckOut"];
            this.status = (int) data["status"];
            this.discount = int.Parse(data["discount"].ToString());
        }
    }
}
