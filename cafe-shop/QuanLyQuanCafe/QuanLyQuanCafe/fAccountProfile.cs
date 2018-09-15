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
    public partial class fAccountProfile : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }
        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
            changeAccount(loginAccount);
        }

        void changeAccount(Account acc)
        {
            this.textBoxUserName.Text = loginAccount.UserName;
            this.textBoxDisplayName.Text = loginAccount.DisplayName;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void updateAccount()
        {
            string displayName = this.textBoxDisplayName.Text;
            string userName = this.textBoxUserName.Text;
            string password = this.textBoxPassword.Text;
            string confirmpassword = this.textBoxConfirmPassword.Text;
            string newpassword = this.textBoxNewPassword.Text;

            if (!newpassword.Equals(confirmpassword))
                MessageBox.Show("mật khẩu xác thực phải trùng với mật khẩu mới");
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpassword) == true)
                    MessageBox.Show("cập nhật thành công");
                else
                    MessageBox.Show("cập nhật không thành công");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            updateAccount();
        }

    }
}
