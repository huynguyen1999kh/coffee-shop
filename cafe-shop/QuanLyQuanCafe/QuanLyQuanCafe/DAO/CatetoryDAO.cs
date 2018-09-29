using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class CatetoryDAO
    {
        private static CatetoryDAO instance;

        public static CatetoryDAO Instance
        {
            get { if (instance == null) instance = new CatetoryDAO(); return instance; }
            private set { instance = value; }
        }
        private CatetoryDAO() { }

        public List<Catetory> GetListCatetory()
        {
            List<Catetory> list = new List<Catetory>();
            string query = "select * from dbo.FoodCatetory";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                Catetory catetory = new Catetory(item);
                list.Add(catetory);
            }
            return list;
        }

        public int GetIDCatetoryByName(string name)
        {
            int id = (int) DataProvider.Instance.ExcuteScarar("select id from dbo.FoodCatetory where name = N'" + name + "'");
            return id;
        }
    }
}
