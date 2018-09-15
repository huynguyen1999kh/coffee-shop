using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set { instance = value; }
        }
        private BillDAO() { }

        public int GetUncheckBillByTableID(int IDTable)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from dbo.Bill where idTable= " + IDTable + " and status = 0");
            if (data.Rows.Count >0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }

        public void InsertBill(int idTable)
        {
            DataProvider.Instance.ExcuteNonQuery("exec USP_InsertBill @idTable ", new object[] { idTable});
        }

        public void checkOut(int id, int discount, float totalPrice)
        {
            string query = "update dbo.Bill set status = 1, dateCheckOut = getDate() , discount = " + discount.ToString() +", totalPrice = " + totalPrice + " where id = " + id.ToString();
            DataProvider.Instance.ExcuteNonQuery(query);
        }

        public DataTable GetListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            DataTable data;
            string query = "exec USP_GetListBillByDay @checkIn , @checkOut";
            data = DataProvider.Instance.ExcuteQuery(query, new object[] { checkIn, checkOut });
            return data;
        }
    }
}
