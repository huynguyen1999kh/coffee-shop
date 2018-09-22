using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            SetDefault();
        }

        #region methods
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            int page = (int) this.numericUpDown1.Value;
            this.dataGridViewViewBill.DataSource = BillDAO.Instance.GetListBillByDateAndPage(checkIn, checkOut,page);
        }
        void SetDefault()
        {
            DateTime today = DateTime.Now;
            dateTimePickerFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dateTimePickerToDate.Value = dateTimePickerFromDate.Value.AddMonths(1).AddDays(-1);
            LoadListBillByDate(this.dateTimePickerFromDate.Value, this.dateTimePickerToDate.Value);
            SetMaxBillPage(this.dateTimePickerFromDate.Value, this.dateTimePickerToDate.Value);

            this.dataGridViewFood.DataSource = FoodDAO.Instance.GetListFood();
            this.comboBoxFoodCatetory.DataSource = CatetoryDAO.Instance.GetListCatetory();
            this.comboBoxFoodCatetory.DisplayMember = "name";
            addFoodBiding();

            this.dataGridViewAccount.DataSource = AccountDAO.Instance.GetListAccount();
            this.comboBoxAccountType.DataSource = AccountDAO.Instance.GetListAccountType();
            this.comboBoxAccountType.DisplayMember = "name";
            addAccountBiding();
        }
        void addFoodBiding()
        {
            textBoxFoodName.DataBindings.Clear();
            textBoxFoodID.DataBindings.Clear();
            comboBoxFoodCatetory.DataBindings.Clear();
            numericUpDownFoodPrice.DataBindings.Clear();
            textBoxFoodName.DataBindings.Add(new Binding("Text", this.dataGridViewFood.DataSource, "tên món", true, DataSourceUpdateMode.Never));
            textBoxFoodID.DataBindings.Add(new Binding("Text", this.dataGridViewFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            comboBoxFoodCatetory.DataBindings.Add(new Binding("Text", this.dataGridViewFood.DataSource, "loại", true, DataSourceUpdateMode.Never));
            numericUpDownFoodPrice.DataBindings.Add(new Binding("Value", this.dataGridViewFood.DataSource, "đơn giá", true, DataSourceUpdateMode.Never));
        }

        void addAccountBiding()
        {
            textBoxUserName.DataBindings.Clear();
            textBoxDisplayName.DataBindings.Clear();
            comboBoxAccountType.DataBindings.Clear();
            textBoxUserName.DataBindings.Add(new Binding("Text", this.dataGridViewAccount.DataSource, "tên tài khoản", true, DataSourceUpdateMode.Never));
            textBoxDisplayName.DataBindings.Add(new Binding("Text", this.dataGridViewAccount.DataSource, "tên hiển thị", true, DataSourceUpdateMode.Never));
            comboBoxAccountType.DataBindings.Add(new Binding("Text", this.dataGridViewAccount.DataSource, "loại tài khoản", true, DataSourceUpdateMode.Never));
        }

        void SetMaxBillPage(DateTime checkIn, DateTime checkOut)
        {
            int Bills = BillDAO.Instance.GetMaxBillByDate(checkIn, checkOut);
            int result = Bills / 10;
            if (result % 10 != 0)
                result++;
            if (result == 0)
                result = 1;
            this.numericUpDown1.Maximum = result;
        }
        #endregion

        #region events

        private void buttonViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(this.dateTimePickerFromDate.Value, this.dateTimePickerToDate.Value);
            SetMaxBillPage(this.dateTimePickerFromDate.Value, this.dateTimePickerToDate.Value);
        }
        private void buttonViewFood_Click(object sender, EventArgs e)
        {
            this.dataGridViewFood.DataSource = FoodDAO.Instance.GetListFood();
            addFoodBiding();
        }
        #endregion

        private void buttonAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                Food food = new Food(this.textBoxFoodName.Text, 1, CatetoryDAO.Instance.GetIDCatetoryByName(comboBoxFoodCatetory.Text), (float)this.numericUpDownFoodPrice.Value);
                if (FoodDAO.Instance.InsertFood(food))
                {
                    MessageBox.Show("thêm thành công");
                    this.dataGridViewFood.DataSource = FoodDAO.Instance.GetListFoodBySearchName(this.textBoxSearch.Text);
                    addFoodBiding();
                    if (insertFood != null)
                        insertFood(this, new EventArgs());
                }
                else
                    MessageBox.Show("đã xảy ra lỗi");
            }
            catch { MessageBox.Show("đã xảy ra lỗi"); }
        }

        private void buttonEditFood_Click(object sender, EventArgs e)
        {
            try
            {
                Food food = new Food(this.textBoxFoodName.Text, int.Parse(this.textBoxFoodID.Text), CatetoryDAO.Instance.GetIDCatetoryByName(comboBoxFoodCatetory.Text), (float)this.numericUpDownFoodPrice.Value);
                if (FoodDAO.Instance.UpdateFood(food, int.Parse(this.textBoxFoodID.Text)))
                {
                    MessageBox.Show("sửa thành công");
                    this.dataGridViewFood.DataSource = FoodDAO.Instance.GetListFoodBySearchName(this.textBoxSearch.Text);
                    addFoodBiding();
                    if (updateFood != null)
                        updateFood(this, new EventArgs());
                }
                else
                    MessageBox.Show("đã xảy ra lỗi");
            }
            catch { MessageBox.Show("đã xảy ra lỗi"); }
        }

        private void buttonDeleteFood_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("bạn thực sự muốn xóa món này?", "xác thực", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    int id = int.Parse(this.textBoxFoodID.Text);
                    bool result = FoodDAO.Instance.DeleteFood(id);
                    if (result == true)
                    {
                        MessageBox.Show("xóa thành công");
                        this.dataGridViewFood.DataSource = FoodDAO.Instance.GetListFoodBySearchName(this.textBoxSearch.Text);
                        addFoodBiding();
                        if (deleteFood != null)
                            deleteFood(this, new EventArgs());
                    }
                    else
                        MessageBox.Show("đã xảy ra lỗi");
                }
            }
            catch { MessageBox.Show("đã xảy ra lỗi"); }
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }
        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }
        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string name = this.textBoxSearch.Text;
            this.dataGridViewFood.DataSource = FoodDAO.Instance.GetListFoodBySearchName(name);
            addFoodBiding();
        }

        private void buttonViewAccount_Click(object sender, EventArgs e)
        {
            this.dataGridViewAccount.DataSource = AccountDAO.Instance.GetListAccount();
            addAccountBiding();
        }

        private void buttonAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBoxDisplayName.Text != "" && this.textBoxUserName.Text != "")
                {
                    bool result = AccountDAO.Instance.InsertAccount(this.textBoxUserName.Text, this.textBoxDisplayName.Text, AccountDAO.Instance.GetIDAccountTypeByName(this.comboBoxAccountType.Text));
                    if (result)
                        MessageBox.Show("thêm tài khoản thành công, mật khẩu mặc định là 1");
                    else
                        MessageBox.Show("đã xảy ra lỗi, thêm không thành công");
                    this.dataGridViewAccount.DataSource = AccountDAO.Instance.GetListAccount();
                    addAccountBiding();
                }
                else
                    MessageBox.Show("bạn chưa điền vào ô");
            }
            catch
            {
                MessageBox.Show("tên tài khoản không được phép trùng");
            }
        }

        private void buttonEditAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("bạn muốn sửa thông tin tài khoản?", "xác nhận", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    bool result = AccountDAO.Instance.UpdateAccount(this.textBoxUserName.Text,this.textBoxDisplayName.Text, AccountDAO.Instance.GetIDAccountTypeByName(this.comboBoxAccountType.Text));
                    if (result)
                        MessageBox.Show("sửa tài khoản thành công");
                    else
                        MessageBox.Show("bạn không được thay đổi tên tài khoản");
                    this.dataGridViewAccount.DataSource = AccountDAO.Instance.GetListAccount();
                    addAccountBiding();
                }
            }
            catch
            {
                MessageBox.Show("tên tài khoản không được phép trùng");
            }
        }

        private void buttonDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("bạn muốn xóa tài khoản này?", "xác nhận", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    bool result = AccountDAO.Instance.DeleteAccount(this.textBoxUserName.Text);
                    if (result)
                        MessageBox.Show("xóa tài khoản thành công");
                    else
                        MessageBox.Show("sai tên tài khoản");
                    this.dataGridViewAccount.DataSource = AccountDAO.Instance.GetListAccount();
                    addAccountBiding();
                }
            }
            catch
            {
                MessageBox.Show("đã xảy ra lỗi");
            }
        }

        private void buttonResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("đặt lại mật khẩu mặc định cho tài khoản này", "xác nhận", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    bool result = AccountDAO.Instance.SetdefaultPassword(this.textBoxUserName.Text);
                    if (result)
                        MessageBox.Show("mật khẩu mặc định là 1");
                    else
                        MessageBox.Show("sai tên tài khoản");
                    this.dataGridViewAccount.DataSource = AccountDAO.Instance.GetListAccount();
                    addAccountBiding();
                }
            }
            catch
            {
                MessageBox.Show("đã xảy ra lỗi");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LoadListBillByDate(this.dateTimePickerFromDate.Value, this.dateTimePickerToDate.Value);
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            this.numericUpDown1.Value = 1;
        }

        private void buttonPre_Click(object sender, EventArgs e)
        {
            if (this.numericUpDown1.Value != 1)
            {
                this.numericUpDown1.Value -= 1;
            }
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            this.numericUpDown1.Value = this.numericUpDown1.Maximum;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (this.numericUpDown1.Value != this.numericUpDown1.Maximum)
            {
                this.numericUpDown1.Value += 1;
            }
        }
    }
}
