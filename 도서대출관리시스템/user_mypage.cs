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
    public partial class user_mypage : Form
    {
        public user_mypage()
        {
            InitializeComponent();
        }

        private void 홈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            user_main user_main = new user_main();
            user_main.ShowDialog();
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            login login1 = new login();
            login1.ShowDialog();
        }
    }
}
