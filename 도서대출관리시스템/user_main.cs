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
    public partial class user_main : Form
    {
        string booksql;
        string id_code;
        DBClass dbc = new DBClass();
        public user_main()
        {
            InitializeComponent();
            dbc.DB_ObjCreate();
            dbc.DB_Open();
            dbc.DB_Access();
        }
        private void main_Load(object sender, EventArgs e)
        {
            list_search("");
            lent_id();
            booklist();
            this.Left = 0;
            this.Top = 0;
        }
        public void sql_execute(String sqlstr, DataSet dsstr)    //사용자 함수 정의
        {
            dbc.DCom.CommandText = sqlstr;
            dbc.DA.SelectCommand = dbc.DCom;
            dbc.DA.Fill(dsstr, "book");
            dsstr.Tables["book"].Clear();
            //***** 방법1 :DS를 하나만 정의한 상태에서 기존의 DS의 book만 제거
            //*****  sql_execute()의 방법1은 DS를 하나만 정의할 경우로 테이블 단위로 클리어 한다.
            //dbc.DS.Clear(); 
            //위의 DS를 지우면 dataGridView2까지 클리어 되어서 안 됨! 
            // 이 경우는 dataGridView마다 다른 DS를 사용할 것
            dbc.DA.Fill(dsstr, "book");
            int i;
            i = 0;
            while (i < dsstr.Tables["book"].Rows.Count)
            {
                DataRow currRow = dsstr.Tables["book"].Rows[i];
                if (currRow[4].ToString() == "")  //대여한 회원이 없으면 book테이블의 b_lent필드타입은 varchar(20)
                    currRow[4] = "가능";
                else    ////대여한 회원이 있으면
                    currRow[4] = "불가능";

                i = i + 1;
            }
            dataGridView1.DataSource = dsstr.Tables["book"].DefaultView;
            book_header();     //함수 호출 
        }
        public void booklist()
        {
            booksql = "select * from book";
            sql_execute(booksql, dbc.DS);
        }
        public void book_header()
        {
            dataGridView1.Columns[0].HeaderText = "코드";
            dataGridView1.Columns[1].HeaderText = "제목";
            dataGridView1.Columns[2].HeaderText = "저자";
            dataGridView1.Columns[3].HeaderText = "출판사";
            dataGridView1.Columns[4].HeaderText = "대출 여부";

            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
        }
        public void lent_id()
        {
            booksql = "select rent_num,rent_date,rtn_date from rent";
            sql_execute2(booksql, dbc.DS);
        }
        public void sql_execute2(String sqlstr, DataSet dsstr1)    //사용자 함수 정의
        {
            dbc.DCom.CommandText = sqlstr;
            dbc.DA.SelectCommand = dbc.DCom;

            dbc.DA.Fill(dsstr1, "rent");
            dsstr1.Tables["rent"].Clear();
            dbc.DA.Fill(dsstr1, "rent");

            dataGridView2.DataSource = dsstr1.Tables["rent"].DefaultView;

            lentm_header();
        }
        public void lentm_header()
        {
            dataGridView2.Columns[0].HeaderText = "번호";
            dataGridView2.Columns[1].HeaderText = "제목";
            dataGridView2.Columns[2].HeaderText = "대여일";


            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Columns[1].Width = 80;
            dataGridView2.Columns[2].Width = 80;

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                MessageBox.Show("검색 미입력");
            else
                list_search(textBox1.Text.Trim());
        }  
        public void list_search(String Find) //검색 기능
        {
            if(Find =="")
            {
                booksql = "select * from book ORDER BY isbn ASC";
                sql_execute(booksql, dbc.DS);
            }
            else if (Find != "")
            {
                booksql = "select * from book where bo_nm Like '%" + Find + "%'";
                
                sql_execute(booksql, dbc.DS);
                if (dbc.DS.Tables["book"].Rows.Count == 0)
                {
                    MessageBox.Show("해당 도서가 없습니다.");
                    booksql = "select * from book ORDER BY bo_nm ASC";
                    sql_execute(booksql, dbc.DS);
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            list_search("");
        }
        private void 홈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            user_main user_main = new user_main();
            user_main.ShowDialog();
        }

        private void 마이페이지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            user_mypage user_mypage = new user_mypage();
            user_mypage.ShowDialog();
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            login login = new login();
            login.ShowDialog();
        }
    }
}