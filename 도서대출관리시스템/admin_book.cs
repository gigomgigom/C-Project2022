using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 도서대출관리시스템
{
    public partial class admin_book : Form
    {
        public admin_book()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 홈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            admin_main admin_Main = new admin_main();
            admin_Main.ShowDialog();
        }

        private void 재고관리StripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            admin_stock admin_Stock = new admin_stock();
            admin_Stock.ShowDialog();
        }

        private void 회원관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            admin_user_management admin_User_Management = new admin_user_management();
            admin_User_Management.ShowDialog();
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            login Login = new login();
            Login.ShowDialog();
        }
    }
}
