using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static int tableWith = 100;
        public static int tableHeigh = 100;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return instance; }
            private set { instance = value; }
        }
        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExcuteQuery("exec USP_GetTableFood");

            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public DataTable GetTable()
        {
            return DataProvider.Instance.ExcuteQuery("select id as [ID], name as [tên bàn], status as [trạng thái] from dbo.TableFood");
        }

        public void SwitchTable(int id1, int id2)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("exec USP_SwitchTable_A @idTable1 , @idTable2", new object[] { id1,id2 });
        }

        public bool InsertTable(Table table)
        {
            string query = string.Format("insert dbo.TableFood(name,status) values (N'{0}',N'{1}')", table.Name,table.Status);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTable(Table table)
        {
            string query = string.Format("update dbo.TableFood set name = N'{0}', status = N'{1}' where id = {2}", table.Name,table.Status,table.ID);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTable(int id)
        {
            string query = string.Format("delete dbo.TableFood where id = {0}", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
