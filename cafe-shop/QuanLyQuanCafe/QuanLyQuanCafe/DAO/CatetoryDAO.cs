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

        public DataTable GetCatetory()
        {
            string query = "select id as [ID], name as [danh mục thức ăn] from dbo.FoodCatetory";
            return DataProvider.Instance.ExcuteQuery(query);
        }

        public int GetIDCatetoryByName(string name)
        {
            int id = (int) DataProvider.Instance.ExcuteScarar("select id from dbo.FoodCatetory where name = N'" + name + "'");
            return id;
        }

        public bool InsertCatetory(Catetory cate)
        {
            string query = string.Format("insert dbo.FoodCatetory(name) values (N'{0}')", cate.Name);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCatetory(Catetory cate)
        {
            string query = string.Format("update dbo.FoodCatetory set name = N'{0}' where id = {1}", cate.Name,cate.ID);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCatetory(int id)
        {
            string query = string.Format("delete dbo.FoodCatetory where id = {0}", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
