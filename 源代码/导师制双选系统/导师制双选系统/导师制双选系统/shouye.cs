using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 导师制双选系统
{
    public partial class shouye : Panel
    {
        //1
        TabControl TabControlshouye = new TabControl();
        TabPage TabPage1shouye = new TabPage();
        TabPage TabPage1chaxun = new TabPage();

        //11
        Label Labelmain = new Label();
        Label Labeluser = new Label();
        Label Labelzhanghao = new Label();
        Label Labelmima = new Label();
        ComboBox ComboBoxuser = new ComboBox();
        TextBox TextBoxzhanghao = new TextBox();
        TextBox TextBoxmima = new TextBox();
        Button Buttondenglu = new Button();

        //12
        Label Labelchaxun1 = new Label();
        Label Labelchaxun2 = new Label();
        Label Labelchaxun3 = new Label();
        ComboBox ComboBoxchaxun1 = new ComboBox();
        ComboBox ComboBoxchaxun2 = new ComboBox();
        TextBox TextBoxchaxun = new TextBox();
        Button Buttonchaxun = new Button();
        GroupBox GroupBoxchaxun = new GroupBox();
        


        public shouye()
        {
            InitializeComponent();
            //Panel首页
            this.Dock = DockStyle.Fill;
            this.Controls.Add(TabControlshouye);

            //TabControl首页和查询
            TabControlshouye.Dock = DockStyle.Fill;
            TabControlshouye.Controls.Add(TabPage1shouye);
            TabControlshouye.Controls.Add(TabPage1chaxun);

            //TabPage1shouye首页TAB页面
            TabPage1shouye.Text = "首页";
            TabPage1shouye.BackgroundImage = Image.FromFile("C:\\Users\\Maple\\Desktop\\导师制双选系统\\1.jpg");

            TabPage1shouye.Controls.Add(Labelmain);
            Labelmain.Text = "导师制双选系统";
            Labelmain.SetBounds(650, 100, 250, 50);
            Labelmain.Font = new Font("楷体", 20);
            Labelmain.BackColor = System.Drawing.Color.Transparent;

            TabPage1shouye.Controls.Add(Labeluser);
            Labeluser.Text = "用户：";
            Labeluser.SetBounds(600, 200, 100, 50);
            Labeluser.Font = new Font("楷体", 15);
            Labeluser.BackColor = System.Drawing.Color.Transparent;

            TabPage1shouye.Controls.Add(Labelzhanghao);
            Labelzhanghao.Text = "账号：";
            Labelzhanghao.SetBounds(600, 250, 100, 50);
            Labelzhanghao.Font = new Font("楷体", 15);
            Labelzhanghao.BackColor = System.Drawing.Color.Transparent;

            TabPage1shouye.Controls.Add(Labelmima);
            Labelmima.Text = "密码：";
            Labelmima.SetBounds(600, 300, 100, 50);
            Labelmima.Font = new Font("楷体", 15);
            Labelmima.BackColor = System.Drawing.Color.Transparent;

            TabPage1shouye.Controls.Add(ComboBoxuser);
            ComboBoxuser.SetBounds(700, 200, 100, 50);
            ComboBoxuser.Font = new Font("楷宋", 12);
            ComboBoxuser.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxuser.Items.Insert(0, "学生");
            ComboBoxuser.Items.Insert(1, "导师");
            ComboBoxuser.Items.Insert(2, "管理员");

            TabPage1shouye.Controls.Add(TextBoxzhanghao);
            TextBoxzhanghao.SetBounds(700, 250, 200, 50);
            TextBoxzhanghao.Font = new Font("楷宋", 10);

            TabPage1shouye.Controls.Add(TextBoxmima);
            TextBoxmima.SetBounds(700, 300, 200, 50);
            TextBoxmima.UseSystemPasswordChar = true;

            TabPage1shouye.Controls.Add(Buttondenglu);
            Buttondenglu.SetBounds(720, 350, 70, 25);
            Buttondenglu.Text = "登录";
            Buttondenglu.Click += new EventHandler(Buttondenglu_click);

            //TabPage1chaxun查询TAB页面
            TabPage1chaxun.Text = "查询";
            TabPage1chaxun.BackgroundImage = Image.FromFile("C:\\Users\\Maple\\Desktop\\导师制双选系统\\1.jpg");


            TabPage1chaxun.Controls.Add(Labelchaxun1);
            Labelchaxun1.Text = "选择用户类型：";
            Labelchaxun1.SetBounds(500, 100, 150, 50);
            Labelchaxun1.Font = new Font("楷体", 15);
            Labelchaxun1.BackColor = System.Drawing.Color.Transparent;

            TabPage1chaxun.Controls.Add(Labelchaxun2);
            Labelchaxun2.Text = "选择查询类别：";
            Labelchaxun2.SetBounds(500, 150, 150, 50);
            Labelchaxun2.Font = new Font("楷体", 15);
            Labelchaxun2.BackColor = System.Drawing.Color.Transparent;

            TabPage1chaxun.Controls.Add(Labelchaxun3);
            Labelchaxun3.Text = "请输入：";
            Labelchaxun3.SetBounds(500, 200, 150, 50);
            Labelchaxun3.Font = new Font("楷体", 15);
            Labelchaxun3.BackColor = System.Drawing.Color.Transparent;

            TabPage1chaxun.Controls.Add(ComboBoxchaxun1);
            ComboBoxchaxun1.SetBounds(650, 100, 100, 50);
            ComboBoxchaxun1.Font = new Font("楷宋", 10);
            ComboBoxchaxun1.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxchaxun1.Items.Insert(0, "学生");
            ComboBoxchaxun1.Items.Insert(1, "导师");

            TabPage1chaxun.Controls.Add(ComboBoxchaxun2);
            ComboBoxchaxun2.SetBounds(650, 150, 200, 50);
            ComboBoxchaxun2.Font = new Font("楷宋", 10);
            ComboBoxchaxun2.DropDownStyle = ComboBoxStyle.DropDownList;

            ComboBoxchaxun1.SelectedIndexChanged += new EventHandler(chaxunchanged);
            ComboBoxchaxun2.SelectedIndexChanged += new EventHandler(chaxunchanged2);

            TabPage1chaxun.Controls.Add(TextBoxchaxun);
            TextBoxchaxun.SetBounds(650, 200, 200, 50);
            TextBoxchaxun.Font = new Font("楷宋", 10);

            TabPage1chaxun.Controls.Add(Buttonchaxun);
            Buttonchaxun.SetBounds(625, 250, 60, 30);
            Buttonchaxun.Text = "查询";
            Buttonchaxun.Font = new Font("楷宋", 10);
            Buttonchaxun.Click += new EventHandler(Buttonchaxun_click);

            TabPage1chaxun.Controls.Add(GroupBoxchaxun);
            GroupBoxchaxun.Text = "查询列表";
            GroupBoxchaxun.SetBounds(300, 300, 800, 200);
            GroupBoxchaxun.Font = new Font("楷体", 15);
            GroupBoxchaxun.BackColor = System.Drawing.Color.Transparent;

        }

        private void Buttondenglu_click(Object b, EventArgs e)
        {
            //无
            if (ComboBoxuser.Text == "")
            {
                MessageBox.Show("请选择登录用户");
            }

            //学生
            if (ComboBoxuser.Text == "学生")
            {
                if (TextBoxzhanghao.Text == "")
                {
                    MessageBox.Show("用户名不能为空");
                    TextBoxzhanghao.Focus();
                }
                else if (TextBoxmima.Text == "")
                {
                    MessageBox.Show("密码不能为空");
                    TextBoxmima.Focus();
                }
                else
                {
                    List<string> list1 = new List<string>();
                    List<string> list2 = new List<string>();
                    string sql = "select * from StudentLogin order by Saccount ASC";
                    SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        list1.Add(row["Saccount"].ToString());
                        list2.Add(row["Spassword"].ToString());
                    }
                    String[] s1 = list1.ToArray();
                    String[] s2 = list2.ToArray();

                    for (int i = 0; i < s1.Length; i++)
                    {
                        if (s1[i].Equals(TextBoxzhanghao.Text))
                        {
                            if (s2[i].Equals(TextBoxmima.Text))
                            {
                                string ups = "update Student set Syes = '1' where Sstudynumber=" + TextBoxzhanghao.Text;
                                SqlDataAdapter a1 = new SqlDataAdapter(ups, conn);
                                DataTable d1 = new DataTable();
                                a1.Fill(d1);

                                conn.Close();
                                //学生页面
                                student studentpageshow = new student();
                                TabPage1shouye.Controls.Add(studentpageshow);
                                studentpageshow.BringToFront();

                                TextBoxzhanghao.Text = "";
                                TextBoxmima.Text = "";
                                break;
                            }
                            else
                            {
                                MessageBox.Show("用户名或者密码错误！");
                                TextBoxzhanghao.Text = "";
                                TextBoxmima.Text = "";
                                TextBoxzhanghao.Focus();
                                return;
                            }
                        }
                    }
                }
            }

            //导师
            if (ComboBoxuser.Text == "导师")
            {
                if (TextBoxzhanghao.Text == "")
                {
                    MessageBox.Show("用户名不能为空");
                    TextBoxzhanghao.Focus();
                }
                else if (TextBoxmima.Text == "")
                {
                    MessageBox.Show("密码不能为空");
                    TextBoxmima.Focus();
                }
                else
                {
                    List<string> list1 = new List<string>();
                    List<string> list2 = new List<string>();

                    string sql = "select * from TutorLogin order by Taccount ASC";

                    SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        list1.Add(row["Taccount"].ToString());
                        list2.Add(row["Tpassword"].ToString());
                    }
                    String[] s1 = list1.ToArray();
                    String[] s2 = list2.ToArray();

                    for (int i = 0; i < s1.Length; i++)
                    {
                        if (s1[i].Equals(TextBoxzhanghao.Text))
                        {
                            if (s2[i].Equals(TextBoxmima.Text))
                            {
                                string upt = "update Tutor set Tyes = '1' where Tworknumber=" + TextBoxzhanghao.Text;
                                SqlDataAdapter b1 = new SqlDataAdapter(upt, conn);
                                DataTable d2 = new DataTable();
                                b1.Fill(d2);

                                conn.Close();

                                //导师页面
                                tutor tutorpageshow = new tutor();
                                TabPage1shouye.Controls.Add(tutorpageshow);
                                tutorpageshow.BringToFront();

                                TextBoxzhanghao.Text = "";
                                TextBoxmima.Text = "";
                                break;
                            }
                            else
                            {
                                MessageBox.Show("用户名或者密码错误！");
                                TextBoxzhanghao.Text = "";
                                TextBoxmima.Text = "";
                                TextBoxzhanghao.Focus();
                                return;
                            }
                        }
                    }
                }
            }

            //管理员
            if (ComboBoxuser.Text == "管理员")
            {
                if (TextBoxzhanghao.Text == "")
                {
                    MessageBox.Show("用户名不能为空");
                    TextBoxzhanghao.Focus();
                }
                else if (TextBoxmima.Text == "")
                {
                    MessageBox.Show("密码不能为空");
                    TextBoxmima.Focus();
                }
                else
                {
                    List<string> list1 = new List<string>();
                    List<string> list2 = new List<string>();
                    string sql = "select * from AdLogin order by Aaccount ASC";
                    SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        list1.Add(row["Aaccount"].ToString());
                        list2.Add(row["Apassword"].ToString());
                    }
                    String[] s1 = list1.ToArray();
                    String[] s2 = list2.ToArray();

                    for (int i = 0; i < s1.Length; i++)
                    {
                        if (s1[i].Equals(TextBoxzhanghao.Text))
                        {
                            if (s2[i].Equals(TextBoxmima.Text))
                            {
                                conn.Close();
                                //学生页面
                                administrator administratorpageshow = new administrator();
                                TabPage1shouye.Controls.Add(administratorpageshow);
                                administratorpageshow.BringToFront();

                                TextBoxzhanghao.Text = "";
                                TextBoxmima.Text = "";
                                break;
                            }
                            else
                            {
                                MessageBox.Show("用户名或者密码错误！");
                                TextBoxzhanghao.Text = "";
                                TextBoxmima.Text = "";
                                TextBoxzhanghao.Focus();
                                return;
                            }
                        }
                    }
                }
            }
        }
        //----------------------------
        private void chaxunchanged(Object b, EventArgs e)
        {

            ComboBoxchaxun2.Items.Clear();
            TextBoxchaxun.Text = "";
            if (ComboBoxchaxun1.Text == "学生")
            {
                ComboBoxchaxun2.Items.Insert(0, "学号（如：20143018）");
                ComboBoxchaxun2.Items.Insert(1, "姓名（如：李杨）");
                ComboBoxchaxun2.Items.Insert(2, "班级（如：信1405-1）");
            }
            if (ComboBoxchaxun1.Text == "导师")
            {
                ComboBoxchaxun2.Items.Insert(0, "工号（如：01）");
                ComboBoxchaxun2.Items.Insert(1, "姓名（如：莱因哈特）");
            }
        }
        private void chaxunchanged2(Object b, EventArgs e)
        {
            TextBoxchaxun.Text = "";
        }
        private void Buttonchaxun_click(Object b, EventArgs e)
        {
            if (ComboBoxchaxun1.Text == "")
            {
                MessageBox.Show("用户类型不能为空");
            }
            else if (ComboBoxchaxun2.Text == "")
            {
                MessageBox.Show("查询类别不能为空");
            }
            else if (TextBoxchaxun.Text == "")
            {
                MessageBox.Show("请输入查询数据");
                TextBoxchaxun.Focus();
            }
            else if (ComboBoxchaxun2.Text == "学号（如：20143018）")
            {
                GroupBoxchaxun.Controls.Clear();
                DataGridView chaxunSnumber = new DataGridView();
                GroupBoxchaxun.Controls.Add(chaxunSnumber);
                chaxunSnumber.ReadOnly = true;
                chaxunSnumber.Font = new Font("楷体", 12);
                chaxunSnumber.BorderStyle = BorderStyle.None;
                chaxunSnumber.BackgroundColor = Color.GhostWhite;
                chaxunSnumber.Dock = DockStyle.Fill;
                chaxunSnumber.DataSource = null;
                chaxunSnumber.AutoGenerateColumns = false;
                chaxunSnumber.ColumnCount = 4;
                string Sxuehao = "select Sstudynumber,Sname,Sclass,Schoose from Student where Sstudynumber like '%" + TextBoxchaxun.Text + "%'";
                SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
                conn.Open();
                SqlDataAdapter dataSxuehao = new SqlDataAdapter(Sxuehao, conn);
                DataSet setSxuehao = new DataSet();
                dataSxuehao.Fill(setSxuehao, "Sxuehao");
                chaxunSnumber.DataSource = setSxuehao;
                chaxunSnumber.DataMember = "Sxuehao";
                //设置表的列头文字
                chaxunSnumber.Columns[0].HeaderText = "学号";
                chaxunSnumber.Columns[1].HeaderText = "姓名";
                chaxunSnumber.Columns[2].HeaderText = "班级";
                chaxunSnumber.Columns[3].HeaderText = "已选导师数量";
                //录入数据
                chaxunSnumber.Columns[0].DataPropertyName = setSxuehao.Tables[0].Columns[0].ToString();
                chaxunSnumber.Columns[1].DataPropertyName = setSxuehao.Tables[0].Columns[1].ToString();
                chaxunSnumber.Columns[2].DataPropertyName = setSxuehao.Tables[0].Columns[2].ToString();
                chaxunSnumber.Columns[3].DataPropertyName = setSxuehao.Tables[0].Columns[3].ToString();
                //设置列宽
                chaxunSnumber.Columns[0].Width = 180;
                chaxunSnumber.Columns[1].Width = 190;
                chaxunSnumber.Columns[2].Width = 180;
                chaxunSnumber.Columns[3].Width = 180;
                conn.Close();
            }
            else if (ComboBoxchaxun2.Text == "姓名（如：李杨）")
            {
                GroupBoxchaxun.Controls.Clear();
                DataGridView chaxunSname = new DataGridView();
                GroupBoxchaxun.Controls.Add(chaxunSname);
                chaxunSname.ReadOnly = true;
                chaxunSname.Font = new Font("楷体", 12);
                chaxunSname.BorderStyle = BorderStyle.None;
                chaxunSname.BackgroundColor = Color.GhostWhite;
                chaxunSname.Dock = DockStyle.Fill;
                chaxunSname.DataSource = null;
                chaxunSname.AutoGenerateColumns = false;
                chaxunSname.ColumnCount = 4;
                string Sxuehao = "select Sstudynumber,Sname,Sclass,Schoose from Student where Sname like '%" + TextBoxchaxun.Text + "%'";
                SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
                conn.Open();
                SqlDataAdapter dataSxuehao = new SqlDataAdapter(Sxuehao, conn);
                DataSet setSxuehao = new DataSet();
                dataSxuehao.Fill(setSxuehao, "Sxuehao");
                chaxunSname.DataSource = setSxuehao;
                chaxunSname.DataMember = "Sxuehao";
                //设置表的列头文字
                chaxunSname.Columns[0].HeaderText = "学号";
                chaxunSname.Columns[1].HeaderText = "姓名";
                chaxunSname.Columns[2].HeaderText = "班级";
                chaxunSname.Columns[3].HeaderText = "已选导师数量";
                //录入数据
                chaxunSname.Columns[0].DataPropertyName = setSxuehao.Tables[0].Columns[0].ToString();
                chaxunSname.Columns[1].DataPropertyName = setSxuehao.Tables[0].Columns[1].ToString();
                chaxunSname.Columns[2].DataPropertyName = setSxuehao.Tables[0].Columns[2].ToString();
                chaxunSname.Columns[3].DataPropertyName = setSxuehao.Tables[0].Columns[3].ToString();
                //设置列宽
                chaxunSname.Columns[0].Width = 180;
                chaxunSname.Columns[1].Width = 190;
                chaxunSname.Columns[2].Width = 180;
                chaxunSname.Columns[3].Width = 180;
                conn.Close();
            }
            else if (ComboBoxchaxun2.Text == "班级（如：信1405-1）")
            {
                GroupBoxchaxun.Controls.Clear();
                DataGridView chaxunSclass = new DataGridView();
                GroupBoxchaxun.Controls.Add(chaxunSclass);
                chaxunSclass.ReadOnly = true;
                chaxunSclass.Font = new Font("楷体", 12);
                chaxunSclass.BorderStyle = BorderStyle.None;
                chaxunSclass.BackgroundColor = Color.GhostWhite;
                chaxunSclass.Dock = DockStyle.Fill;
                chaxunSclass.DataSource = null;
                chaxunSclass.AutoGenerateColumns = false;
                chaxunSclass.ColumnCount = 4;
                string Sxuehao = "select Sstudynumber,Sname,Sclass,Schoose from Student where Sclass like '%" + TextBoxchaxun.Text + "%'";
                SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
                conn.Open();
                SqlDataAdapter dataSxuehao = new SqlDataAdapter(Sxuehao, conn);
                DataSet setSxuehao = new DataSet();
                dataSxuehao.Fill(setSxuehao, "Sxuehao");
                chaxunSclass.DataSource = setSxuehao;
                chaxunSclass.DataMember = "Sxuehao";
                //设置表的列头文字
                chaxunSclass.Columns[0].HeaderText = "学号";
                chaxunSclass.Columns[1].HeaderText = "姓名";
                chaxunSclass.Columns[2].HeaderText = "班级";
                chaxunSclass.Columns[3].HeaderText = "已选导师数量";
                //录入数据
                chaxunSclass.Columns[0].DataPropertyName = setSxuehao.Tables[0].Columns[0].ToString();
                chaxunSclass.Columns[1].DataPropertyName = setSxuehao.Tables[0].Columns[1].ToString();
                chaxunSclass.Columns[2].DataPropertyName = setSxuehao.Tables[0].Columns[2].ToString();
                chaxunSclass.Columns[3].DataPropertyName = setSxuehao.Tables[0].Columns[3].ToString();
                //设置列宽
                chaxunSclass.Columns[0].Width = 180;
                chaxunSclass.Columns[1].Width = 190;
                chaxunSclass.Columns[2].Width = 180;
                chaxunSclass.Columns[3].Width = 180;
                conn.Close();
            }
            else if (ComboBoxchaxun2.Text == "工号（如：01）")
            {
                GroupBoxchaxun.Controls.Clear();
                DataGridView chaxunTnumber = new DataGridView();
                GroupBoxchaxun.Controls.Add(chaxunTnumber);
                chaxunTnumber.ReadOnly = true;
                chaxunTnumber.Font = new Font("楷体", 12);
                chaxunTnumber.BorderStyle = BorderStyle.None;
                chaxunTnumber.BackgroundColor = Color.GhostWhite;
                chaxunTnumber.Dock = DockStyle.Fill;
                chaxunTnumber.DataSource = null;
                chaxunTnumber.AutoGenerateColumns = false;
                chaxunTnumber.ColumnCount = 4;
                string Sxuehao = "select Tworknumber,Tname,Tchoose from Tutor where Tworknumber like '%" + TextBoxchaxun.Text + "%'";
                SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
                conn.Open();
                SqlDataAdapter dataSxuehao = new SqlDataAdapter(Sxuehao, conn);
                DataSet setSxuehao = new DataSet();
                dataSxuehao.Fill(setSxuehao, "Sxuehao");
                chaxunTnumber.DataSource = setSxuehao;
                chaxunTnumber.DataMember = "Sxuehao";
                //设置表的列头文字
                chaxunTnumber.Columns[0].HeaderText = "工号";
                chaxunTnumber.Columns[1].HeaderText = "姓名";
                chaxunTnumber.Columns[2].HeaderText = "已选学员数量"; 
                //录入数据
                chaxunTnumber.Columns[0].DataPropertyName = setSxuehao.Tables[0].Columns[0].ToString();
                chaxunTnumber.Columns[1].DataPropertyName = setSxuehao.Tables[0].Columns[1].ToString();
                chaxunTnumber.Columns[2].DataPropertyName = setSxuehao.Tables[0].Columns[2].ToString();
                //设置列宽
                chaxunTnumber.Columns[0].Width = 240;
                chaxunTnumber.Columns[1].Width = 250;
                chaxunTnumber.Columns[2].Width = 240;
                conn.Close();
            }
            else if (ComboBoxchaxun2.Text == "姓名（如：莱因哈特）")
            {
                GroupBoxchaxun.Controls.Clear();
                DataGridView chaxunTname = new DataGridView();
                GroupBoxchaxun.Controls.Add(chaxunTname);
                chaxunTname.ReadOnly = true;
                chaxunTname.Font = new Font("楷体", 12);
                chaxunTname.BorderStyle = BorderStyle.None;
                chaxunTname.BackgroundColor = Color.GhostWhite;
                chaxunTname.Dock = DockStyle.Fill;
                chaxunTname.DataSource = null;
                chaxunTname.AutoGenerateColumns = false;
                chaxunTname.ColumnCount = 4;
                string Sxuehao = "select Tworknumber,Tname,Tchoose from Tutor where Tname like '%" + TextBoxchaxun.Text + "%'";
                SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
                conn.Open();
                SqlDataAdapter dataSxuehao = new SqlDataAdapter(Sxuehao, conn);
                DataSet setSxuehao = new DataSet();
                dataSxuehao.Fill(setSxuehao, "Sxuehao");
                chaxunTname.DataSource = setSxuehao;
                chaxunTname.DataMember = "Sxuehao";
                //设置表的列头文字
                chaxunTname.Columns[0].HeaderText = "工号";
                chaxunTname.Columns[1].HeaderText = "姓名";
                chaxunTname.Columns[2].HeaderText = "已选学员数量";
                //录入数据
                chaxunTname.Columns[0].DataPropertyName = setSxuehao.Tables[0].Columns[0].ToString();
                chaxunTname.Columns[1].DataPropertyName = setSxuehao.Tables[0].Columns[1].ToString();
                chaxunTname.Columns[2].DataPropertyName = setSxuehao.Tables[0].Columns[2].ToString();
                //设置列宽
                chaxunTname.Columns[0].Width = 240;
                chaxunTname.Columns[1].Width = 250;
                chaxunTname.Columns[2].Width = 240;
                conn.Close();
            }
        }
        public shouye(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
