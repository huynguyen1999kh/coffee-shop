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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            this.textBoxUserName.Text = "HuyUIT";
            this.textBoxPassword.Text = "astroboy19";
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string userName = this.textBoxUserName.Text;
            string passWord = this.textBoxPassword.Text;
            if (login(userName,passWord))
            {
                Account account = AccountDAO.Instance.GetAccountByUserName(userName);
                fTableManager tableManager = new fTableManager(account);
                this.Hide();
                tableManager.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("sai tên tài khoản hoặc mật khẩu");
            }
        }

        bool login(string userName, string passWord)
        {
            return AccountDAO.Instance.login(userName,passWord);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "thoát" ,MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
