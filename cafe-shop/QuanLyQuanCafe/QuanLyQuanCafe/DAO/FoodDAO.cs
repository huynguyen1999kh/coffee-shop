using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            private set { instance = value; }
        }
        private FoodDAO() { }

        public List<Food> GetListFoodByCatetoryID(int id)
        {
            List<Food> list = new List<Food>();
            string query = "select * from dbo.Food where idCatetory = " + id.ToString();
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

        public DataTable GetListFood()
        {
            string query = "select f.id as [ID], f.name as [tên món], fc.name as [loại], price as [đơn giá] from dbo.Food as f,dbo.FoodCatetory as fc where f.idCatetory = fc.id";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            return data;
        }

        public DataTable GetListFoodBySearchName(string name)
        {
            string query = "select f.id as [ID], f.name as [tên món], fc.name as [loại], price as [đơn giá] from dbo.Food as f,dbo.FoodCatetory as fc where f.idCatetory = fc.id and dbo.fuConvertToUnsign1(f.name) like N'%'+ dbo.fuConvertToUnsign1(N'" + name + "') +'%'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            return data;
        }
        public bool InsertFood(Food food)
        {
            string query = string.Format("insert dbo.Food(name,idCatetory,price) values (N'{0}',{1},{2})", food.Name, food.IdCatetory, food.Price);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateFood(Food food,int id)
        {
            string query = string.Format("update dbo.Food set name = N'{0}', idCatetory = {1}, price = {2} where id = {3} ", food.Name, food.IdCatetory, food.Price,id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteFood(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(id);
            string query = string.Format("delete dbo.Food where id = {0}", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
