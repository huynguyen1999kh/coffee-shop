using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value;}
        }

        public fTableManager(Account account)
        {
            InitializeComponent();
            this.loginAccount = account;
            changeAccount(loginAccount.Type);
            setDefault();
        }

        #region methods
        void setDefault()
        {
            LoadTable();
            LoadCaterory(); this.comboBoxCatetory.SelectedIndex = 0;
            LoadComboboxTable(this.comboBoxSwichTable);
        }
        void changeAccount(int type)
        {
                this.adminToolStripMenuItem.Enabled = type == 2;
        }
        private void LoadCaterory()
        {
            List<Catetory> list = CatetoryDAO.Instance.GetListCatetory();
            this.comboBoxCatetory.DataSource = list;
            this.comboBoxCatetory.DisplayMember = "name";
        }

        private void LoadFoodByCatetoryID(int idCatetory)
        {
            List<Food> list = FoodDAO.Instance.GetListFoodByCatetoryID(idCatetory);
            this.comboBoxFood.DataSource = list;
            this.comboBoxFood.DisplayMember = "name";
        }
        private void LoadTable()
        {
            this.flowLayoutPanelTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table items in tableList)
            {
                Button button = new Button() { Width = TableDAO.tableWith, Height = TableDAO.tableHeigh };
                button.Text = items.Name + Environment.NewLine + items.Status;
                button.Tag = items;
                button.Click += button_Click;

                switch(items.Status)
                {
                    case "trống":
                        button.BackColor = System.Drawing.Color.Aqua;
                        break;
                    default:
                        button.BackColor = System.Drawing.Color.LightPink;
                        break;
                }
                this.flowLayoutPanelTable.Controls.Add(button);
            }
        }

        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "name";
        }

        void showBill(int id)
        {
            this.numericUpDownDiscountPercent.Value = 0;
            this.listViewFood.Items.Clear();
            List<DTO.Menu> ListMenu = MenuDAO.Instance.GetListmenuByTable(id);
            float total = 0;

            foreach (DTO.Menu item in ListMenu)
            {
                total += item.TotalPrice;
                
                ListViewItem viewItem = new ListViewItem(item.FoodName.ToString());
                viewItem.SubItems.Add(item.Price.ToString());
                viewItem.SubItems.Add(item.Count.ToString());
                viewItem.SubItems.Add(item.TotalPrice.ToString());

                this.listViewFood.Items.Add(viewItem);
            }
            //CultureInfo culture = new CultureInfo("vi-VN");
            this.textBoxTotalPrice.Tag = total;
            updateTextBoxTotalPrice(total);
        }
        void updateTextBoxTotalPrice(float total)
        {
            this.textBoxTotalPrice.Text = ((total * (100 - (int)this.numericUpDownDiscountPercent.Value)) / 100).ToString();
        }
        #endregion

        #region events
        void button_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            this.listViewFood.Tag = (sender as Button).Tag;
            showBill(tableID);
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accountProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile accountProfile = new fAccountProfile(loginAccount);
            accountProfile.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin admin = new fAdmin();
            admin.InsertFood += admin_inserFood;
            admin.UpdateFood += admin_updateFood;
            admin.DeleteFood += admin_deleteFood;

            admin.ShowDialog();
            setDefault();
        }

        private void admin_deleteFood(object sender, EventArgs e)
        {
        }

        private void admin_updateFood(object sender, EventArgs e)
        {
        }

        private void admin_inserFood(object sender, EventArgs e)
        {
        }
        #endregion

        private void comboBoxCatetory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem != null)
            {
                Catetory catetory = cb.SelectedItem as Catetory;
                id = catetory.ID;
            }
            LoadFoodByCatetoryID(id);
        }

        private void buttonAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                Table table = listViewFood.Tag as Table;
                int idFood = (this.comboBoxFood.SelectedItem as Food).Id;
                int count = (int)this.numericUpDownFood.Value;

                int idBill = BillDAO.Instance.GetUncheckBillByTableID(table.ID);
                if (idBill == -1)
                {
                    if (count > 0)
                    {
                        BillDAO.Instance.InsertBill(table.ID);
                        BillInfoDAO.Instance.InsertBillInfo(BillInfoDAO.Instance.GetMaxIDBill(), idFood, count);
                    }
                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
                }
                showBill(table.ID);
                LoadTable();
            }
            catch
            {
                MessageBox.Show("bạn chưa chọn bàn", "thông báo");
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            Table tb = this.listViewFood.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckBillByTableID(tb.ID);
            if (MessageBox.Show("bạn muốn thanh toán bàn " + tb.Name.ToString() + "?", "xác thực", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int discount = (int)this.numericUpDownDiscountPercent.Value;
                float totalPrice = float.Parse(this.textBoxTotalPrice.Text);
                BillDAO.Instance.checkOut(idBill, discount, totalPrice);
                showBill(tb.ID);
                LoadTable();
            }            
        }

        private void numericUpDownDiscountPercent_ValueChanged(object sender, EventArgs e)
        {
            float total = (float)this.textBoxTotalPrice.Tag;
            updateTextBoxTotalPrice(total);
        }

        private void buttonDiscount_Click(object sender, EventArgs e)
        {
            float total = (float)this.textBoxTotalPrice.Tag;
            updateTextBoxTotalPrice(total);
        }

        private void buttonSwitchTable_Click(object sender, EventArgs e)
        {
            int id1 = (listViewFood.Tag as Table).ID;
            int id2 = (comboBoxSwichTable.SelectedItem as Table).ID;

            if (MessageBox.Show("chuyển " + (listViewFood.Tag as Table).Name.ToString() + " sang " + (comboBoxSwichTable.SelectedItem as Table).Name.ToString() + "?", "xác thực", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);
                setDefault();
            }
        }
    }
}
