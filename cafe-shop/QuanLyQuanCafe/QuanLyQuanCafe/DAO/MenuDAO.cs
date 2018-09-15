using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return instance; }
            private set { instance = value; }
        }
        private MenuDAO() { }

        public List<Menu> GetListmenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();
            DataTable data = DataProvider.Instance.ExcuteQuery("select f.name, f.price , bi.count from dbo.Food as f, dbo.Bill as b, dbo.BillInfo as bi where f.id = bi.idFood and bi.idBill = b.id and b.status=0 and b.idTable = " + id.ToString());
            foreach(DataRow item in data.Rows)
            {
                Menu menuItem = new Menu(item);
                listMenu.Add(menuItem);
            }

            return listMenu;
        }
    }
}
