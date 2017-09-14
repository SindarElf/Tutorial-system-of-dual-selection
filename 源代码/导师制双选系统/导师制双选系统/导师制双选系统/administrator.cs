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
    public partial class administrator : Panel
    {
        //主页面
        GroupBox GroupBoxAS = new GroupBox();
        GroupBox GroupBoxAT = new GroupBox();

        Button ButtonAzhuxiao = new Button();

        Button ButtonAS1 = new Button();
        Button ButtonAS2 = new Button();
        Button ButtonAS3 = new Button();

        Button ButtonAT1 = new Button();
        Button ButtonAT2 = new Button();
        Button ButtonAT3 = new Button();

        //添加学生账户
        Form FormAS1;
        Label LabelAS11;
        Label LabelAS12;
        Label LabelAS13;
        Label LabelAS14;
        Label LabelAS15;
        TextBox TextBoxAS11;
        TextBox TextBoxAS12;
        TextBox TextBoxAS13;
        TextBox TextBoxAS14;
        TextBox TextBoxAS15;
        Button ButtonAS1queren;

        //修改学生信息
        Form FormAS2;
        Label LabelAS21;
        Label LabelAS22;
        Label LabelAS23;
        Label LabelAS24;
        TextBox TextBoxAS21;
        TextBox TextBoxAS22;
        ComboBox ComboBoxAS21;
        Button ButtonAS2queren;

        //删除学生账户
        Form FormAS3;
        Label LabelAS31;
        Label LabelAS32;
        ComboBox ComboBoxAS31;
        Button ButtonAS3queren;

        //添加导师账户
        Form FormAT1;
        Label LabelAT11;
        Label LabelAT12;
        Label LabelAT13;
        Label LabelAT14;
        TextBox TextBoxAT11;
        TextBox TextBoxAT12;
        TextBox TextBoxAT13;
        Button ButtonAT1queren;

        //修改导师信息
        Form FormAT2;
        Label LabelAT21;
        Label LabelAT22;
        Label LabelAT23;
        TextBox TextBoxAT21;
        ComboBox ComboBoxAT21;
        Button ButtonAT2queren;

        //删除导师账户
        Form FormAT3;
        Label LabelAT31;
        Label LabelAT32;
        ComboBox ComboBoxAT31;
        Button ButtonAT3queren;
        public administrator()
        {
            InitializeComponent();
            //Panel管理员页面
            this.Dock = DockStyle.Fill;
            this.Controls.Add(ButtonAzhuxiao);
            this.BackgroundImage = Image.FromFile("C:\\Users\\Maple\\Desktop\\导师制双选系统\\1.jpg");

            //Button管理员注销
            ButtonAzhuxiao.SetBounds(700, 720, 70, 25);
            ButtonAzhuxiao.Text = "注销";
            ButtonAzhuxiao.Click += new EventHandler(ButtonAzhuxiao_click);

            //GroupBoxAS学生
            this.Controls.Add(GroupBoxAS);
            GroupBoxAS.Text = "学生信息管理";
            GroupBoxAS.SetBounds(350, 50, 800, 200);
            GroupBoxAS.Font = new Font("楷体", 15);
            GroupBoxAS.BackColor = System.Drawing.Color.Transparent;

            GroupBoxAS.Controls.Add(ButtonAS1);
            ButtonAS1.SetBounds(50, 50, 200, 100);
            ButtonAS1.Text = "添加学生账户";
            ButtonAS1.Font = new Font("楷宋", 15);
            ButtonAS1.Click += new EventHandler(ButtonAS1_click);

            GroupBoxAS.Controls.Add(ButtonAS2);
            ButtonAS2.SetBounds(300, 50, 200, 100);
            ButtonAS2.Text = "修改学生信息";
            ButtonAS2.Font = new Font("楷宋", 15);
            ButtonAS2.Click += new EventHandler(ButtonAS2_click);

            GroupBoxAS.Controls.Add(ButtonAS3);
            ButtonAS3.SetBounds(550, 50, 200, 100);
            ButtonAS3.Text = "删除学生账户";
            ButtonAS3.Font = new Font("楷宋", 15);
            ButtonAS3.Click += new EventHandler(ButtonAS3_click);

            //GroupBoxAT导师
            this.Controls.Add(GroupBoxAT);
            GroupBoxAT.Text = "导师信息管理";
            GroupBoxAT.SetBounds(350, 350, 800, 200);
            GroupBoxAT.Font = new Font("楷体", 15);
            GroupBoxAT.BackColor = System.Drawing.Color.Transparent;

            GroupBoxAT.Controls.Add(ButtonAT1);
            ButtonAT1.SetBounds(50, 50, 200, 100);
            ButtonAT1.Text = "添加导师账户";
            ButtonAT1.Font = new Font("楷宋", 15);
            ButtonAT1.Click += new EventHandler(ButtonAT1_click);

            GroupBoxAT.Controls.Add(ButtonAT2);
            ButtonAT2.SetBounds(300, 50, 200, 100);
            ButtonAT2.Text = "修改导师信息";
            ButtonAT2.Font = new Font("楷宋", 15);
            ButtonAT2.Click += new EventHandler(ButtonAT2_click);

            GroupBoxAT.Controls.Add(ButtonAT3);
            ButtonAT3.SetBounds(550, 50, 200, 100);
            ButtonAT3.Text = "删除导师账户";
            ButtonAT3.Font = new Font("楷宋", 15);
            ButtonAT3.Click += new EventHandler(ButtonAT3_click);
        }

        private void ButtonAzhuxiao_click(Object b,EventArgs e)
        {
            this.Hide();
        }
        private void ButtonAS1_click(Object b, EventArgs e)
        {
            FormAS1 = new Form();
            FormAS1.Text="添加学生账户";
            FormAS1.SetBounds(100, 100, 600, 500);

            LabelAS11 = new Label();
            FormAS1.Controls.Add(LabelAS11);
            LabelAS11.Text = "添加学生账户";
            LabelAS11.SetBounds(230, 50, 200, 30);
            LabelAS11.Font = new Font("楷宋", 15);

            LabelAS12 = new Label();
            FormAS1.Controls.Add(LabelAS12);
            LabelAS12.Text = "账号：";
            LabelAS12.SetBounds(150, 150, 100, 20);
            LabelAS12.Font = new Font("楷宋", 12);

            LabelAS13 = new Label();
            FormAS1.Controls.Add(LabelAS13);
            LabelAS13.Text = "密码：";
            LabelAS13.SetBounds(150, 200, 100, 20);
            LabelAS13.Font = new Font("楷宋", 12);

            LabelAS14 = new Label();
            FormAS1.Controls.Add(LabelAS14);
            LabelAS14.Text = "姓名：";
            LabelAS14.SetBounds(150, 250, 100, 20);
            LabelAS14.Font = new Font("楷宋", 12);

            LabelAS15 = new Label();
            FormAS1.Controls.Add(LabelAS15);
            LabelAS15.Text = "班级";
            LabelAS15.SetBounds(150, 300, 100, 20);
            LabelAS15.Font = new Font("楷宋", 12);

            TextBoxAS11 = new TextBox();
            FormAS1.Controls.Add(TextBoxAS11);
            TextBoxAS11.SetBounds(250, 150, 200, 20);
            TextBoxAS11.Font = new Font("楷宋", 10);

            TextBoxAS12 = new TextBox();
            FormAS1.Controls.Add(TextBoxAS12);
            TextBoxAS12.SetBounds(250, 200, 200, 20);
            TextBoxAS12.Font = new Font("楷宋", 10);
            TextBoxAS12.UseSystemPasswordChar = true;

            TextBoxAS13 = new TextBox();
            FormAS1.Controls.Add(TextBoxAS13);
            TextBoxAS13.SetBounds(250, 250, 200, 20);
            TextBoxAS13.Font = new Font("楷宋", 10);

            TextBoxAS14 = new TextBox();
            FormAS1.Controls.Add(TextBoxAS14);
            TextBoxAS14.SetBounds(250, 300, 200, 20);
            TextBoxAS14.Font = new Font("楷宋", 10);

            ButtonAS1queren = new Button();
            FormAS1.Controls.Add(ButtonAS1queren);
            ButtonAS1queren.SetBounds(250, 375, 70, 25);
            ButtonAS1queren.Text = "确认添加";
            ButtonAS1queren.Click+=new EventHandler(ButtonAS1queren_click);

            FormAS1.Show();
        }
        private void ButtonAS1queren_click(Object b, EventArgs e)
        {
            string sqlAS1bool = "select Sstudynumber from Student where Sstudynumber = '" + TextBoxAS11.Text + "'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter dataAS1bool = new SqlDataAdapter(sqlAS1bool, conn);
            DataTable tableAS1bool = new DataTable();
            dataAS1bool.Fill(tableAS1bool);
            if (TextBoxAS11.Text == "")
            {
                MessageBox.Show("账号不能为空");
                TextBoxAS11.Focus();
            }
            else if (tableAS1bool.Rows.Count != 0)
            {
                MessageBox.Show("此账号已被注册");
                TextBoxAS11.Focus();
            }
            else if (TextBoxAS12.Text == "")
            {
                MessageBox.Show("密码不能为空");
                TextBoxAS12.Focus();
            }
            else if (TextBoxAS13.Text == "")
            {
                MessageBox.Show("姓名不能为空");
                TextBoxAS13.Focus();
            }
            else if (TextBoxAS14.Text == "")
            {
                MessageBox.Show("班级不能为空");
                TextBoxAS14.Focus();
            }
            else
            {
                string sqlAS11 = "insert into StudentLogin values('" + TextBoxAS11.Text + "','" + TextBoxAS12.Text + "')";
                string sqlAS12 = "insert into Student values('" + TextBoxAS11.Text + "','" + TextBoxAS13.Text + "','" + TextBoxAS14.Text + "','0','0')";
                SqlDataAdapter dataAS11 = new SqlDataAdapter(sqlAS11, conn);
                DataTable tableAS11 = new DataTable();
                dataAS11.Fill(tableAS11);
                SqlDataAdapter dataAS12 = new SqlDataAdapter(sqlAS12, conn);
                DataTable tableAS12 = new DataTable();
                dataAS12.Fill(tableAS12);
                conn.Close();
                MessageBox.Show("添加成功");
                FormAS1.Close();
            }
        }
        private void ButtonAS2_click(Object b, EventArgs e)
        {
            FormAS2 = new Form();
            FormAS2.Text = "修改学生信息";
            FormAS2.SetBounds(100, 100, 600, 500);

            LabelAS21 = new Label();
            FormAS2.Controls.Add(LabelAS21);
            LabelAS21.Text = "修改学生信息";
            LabelAS21.SetBounds(230, 50, 200, 30);
            LabelAS21.Font = new Font("楷宋", 15);

            LabelAS22 = new Label();
            FormAS2.Controls.Add(LabelAS22);
            LabelAS22.Text = "学号：";
            LabelAS22.SetBounds(150, 150, 100, 20);
            LabelAS22.Font = new Font("楷宋", 12);

            LabelAS23 = new Label();
            FormAS2.Controls.Add(LabelAS23);
            LabelAS23.Text = "姓名：";
            LabelAS23.SetBounds(150, 200, 100, 20);
            LabelAS23.Font = new Font("楷宋", 12);

            LabelAS24 = new Label();
            FormAS2.Controls.Add(LabelAS24);
            LabelAS24.Text = "班级：";
            LabelAS24.SetBounds(150, 250, 100, 20);
            LabelAS24.Font = new Font("楷宋", 12);

            TextBoxAS21 = new TextBox();
            FormAS2.Controls.Add(TextBoxAS21);
            TextBoxAS21.SetBounds(250, 200, 200, 20);
            TextBoxAS21.Font = new Font("楷宋", 10);

            TextBoxAS22 = new TextBox();
            FormAS2.Controls.Add(TextBoxAS22);
            TextBoxAS22.SetBounds(250, 250, 200, 20);
            TextBoxAS22.Font = new Font("楷宋", 10);

            ComboBoxAS21 = new ComboBox();
            FormAS2.Controls.Add(ComboBoxAS21);
            ComboBoxAS21.SetBounds(250, 150, 100, 20);
            ComboBoxAS21.Font = new Font("楷宋", 10);
            ComboBoxAS21.DropDownStyle = ComboBoxStyle.DropDown;
            ComboBoxAS21.DataSource = null;
            xiugaiAS21();

            ButtonAS2queren = new Button();
            FormAS2.Controls.Add(ButtonAS2queren);
            ButtonAS2queren.SetBounds(250, 325, 70, 25);
            ButtonAS2queren.Text = "确认修改";
            ButtonAS2queren.Click += new EventHandler(ButtonAS2queren_click);

            FormAS2.Show();
        }
        private void xiugaiAS21()
        {
            string sqlxiugaiAS21 = "select Sstudynumber from Student";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter dataxiugaiAS21 = new SqlDataAdapter(sqlxiugaiAS21, conn);
            DataTable setxiugaiAS21 = new DataTable();
            dataxiugaiAS21.Fill(setxiugaiAS21);
            ComboBoxAS21.DataSource = setxiugaiAS21;
            ComboBoxAS21.DisplayMember = "Sstudynumber";
            conn.Close();
        }
        private void ButtonAS2queren_click(Object b, EventArgs e)
        {
            string sqlAS2bool = "select Sstudynumber from Student where Sstudynumber = '" + ComboBoxAS21.Text + "'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter dataAS2bool = new SqlDataAdapter(sqlAS2bool, conn);
            DataTable tableAS2bool = new DataTable();
            dataAS2bool.Fill(tableAS2bool);
            if (ComboBoxAS21.Text == "")
            {
                MessageBox.Show("学号不能为空");
            }
            else if (tableAS2bool.Rows.Count == 0)
            {
                MessageBox.Show("此学号不存在");
                conn.Close();
            }
            else if (TextBoxAS21.Text == "")
            {
                MessageBox.Show("姓名不能为空");
                TextBoxAS21.Focus();
            }
            else if (TextBoxAS22.Text == "")
            {
                MessageBox.Show("班级不能为空");
                TextBoxAS22.Focus();
            }
            else
            {
                string sqlAS21 = "update Student set Sname = '" + TextBoxAS21.Text + "',Sclass = '" + TextBoxAS22.Text + "' where Sstudynumber = '" + ComboBoxAS21.Text + "'";
                SqlDataAdapter dataAS21 = new SqlDataAdapter(sqlAS21, conn);
                DataTable tableAS21 = new DataTable();
                dataAS21.Fill(tableAS21);
                MessageBox.Show("修改成功");
                conn.Close();
                FormAS2.Close();

            }
        }
        private void ButtonAS3_click(Object b, EventArgs e)
        {
            FormAS3 = new Form();
            FormAS3.Text = "删除学生信息";
            FormAS3.SetBounds(100, 100, 600, 500);

            LabelAS31 = new Label();
            FormAS3.Controls.Add(LabelAS31);
            LabelAS31.Text = "删除学生信息";
            LabelAS31.SetBounds(230, 50, 200, 30);
            LabelAS31.Font = new Font("楷宋", 15);

            LabelAS32 = new Label();
            FormAS3.Controls.Add(LabelAS32);
            LabelAS32.Text = "学号：";
            LabelAS32.SetBounds(150, 150, 100, 20);
            LabelAS32.Font = new Font("楷宋", 12);

            ComboBoxAS31 = new ComboBox();
            FormAS3.Controls.Add(ComboBoxAS31);
            ComboBoxAS31.SetBounds(250, 150, 100, 20);
            ComboBoxAS31.Font = new Font("楷宋", 10);
            ComboBoxAS31.DropDownStyle = ComboBoxStyle.DropDown;
            ComboBoxAS31.DataSource = null;
            shanchuAS31();

            ButtonAS3queren = new Button();
            FormAS3.Controls.Add(ButtonAS3queren);
            ButtonAS3queren.SetBounds(250, 225, 70, 25);
            ButtonAS3queren.Text = "确认删除";
            ButtonAS3queren.Click += new EventHandler(ButtonAS3queren_click);

            FormAS3.Show();
        }
        private void shanchuAS31()
        {
            string sqlshanchuAS31 = "select Sstudynumber from Student";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter datashanchuAS31 = new SqlDataAdapter(sqlshanchuAS31, conn);
            DataTable setshanchuAS31 = new DataTable();
            datashanchuAS31.Fill(setshanchuAS31);
            ComboBoxAS31.DataSource = setshanchuAS31;
            ComboBoxAS31.DisplayMember = "Sstudynumber";
            conn.Close();
        }
        private void ButtonAS3queren_click(Object b, EventArgs e)
        {
            string sqlAS3bool = "select Sstudynumber from Student where Sstudynumber = '" + ComboBoxAS31.Text + "'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter dataAS3bool = new SqlDataAdapter(sqlAS3bool, conn);
            DataTable tableAS3bool = new DataTable();
            dataAS3bool.Fill(tableAS3bool);
            if (ComboBoxAS31.Text == "")
            {
                MessageBox.Show("学号不能为空");
                ComboBoxAS31.Focus();
            }
            else if (tableAS3bool.Rows.Count == 0)
            {
                MessageBox.Show("此学号不存在");
                ComboBoxAS31.Focus();
            }
            else
            {
                string sqlAS31 = "update Tutor set Tchoose=Tchoose-1 where Tworknumber in(select Tworknumber from ST where Sstudynumber = '" + ComboBoxAS31.Text + "' and STok='1')";
                string sqlAS32 = "delete from ST where Sstudynumber = '" + ComboBoxAS31.Text + "'";
                string sqlAS33 = "delete from Student where Sstudynumber = '" + ComboBoxAS31.Text + "'";
                string sqlAS34 = "delete from StudentLogin where Saccount = '" + ComboBoxAS31.Text + "'";
                SqlDataAdapter dataAS31 = new SqlDataAdapter(sqlAS31, conn);
                DataTable tableAS31 = new DataTable();
                dataAS31.Fill(tableAS31);
                SqlDataAdapter dataAS32 = new SqlDataAdapter(sqlAS32, conn);
                DataTable tableAS32 = new DataTable();
                dataAS32.Fill(tableAS32);
                SqlDataAdapter dataAS33 = new SqlDataAdapter(sqlAS33, conn);
                DataTable tableAS33 = new DataTable();
                dataAS33.Fill(tableAS33);
                SqlDataAdapter dataAS34 = new SqlDataAdapter(sqlAS34, conn);
                DataTable tableAS34 = new DataTable();
                dataAS34.Fill(tableAS34);
                conn.Close();
                MessageBox.Show("删除成功");
                FormAS3.Close();
            }
        }
        //----------------------------------------------------
        private void ButtonAT1_click(Object b, EventArgs e)
        {
            FormAT1 = new Form();
            FormAT1.Text = "添加导师账户";
            FormAT1.SetBounds(100, 100, 600, 500);

            LabelAT11 = new Label();
            FormAT1.Controls.Add(LabelAT11);
            LabelAT11.Text = "添加导师账户";
            LabelAT11.SetBounds(230, 50, 200, 30);
            LabelAT11.Font = new Font("楷宋", 15);

            LabelAT12 = new Label();
            FormAT1.Controls.Add(LabelAT12);
            LabelAT12.Text = "账号：";
            LabelAT12.SetBounds(150, 150, 100, 20);
            LabelAT12.Font = new Font("楷宋", 12);

            LabelAT13 = new Label();
            FormAT1.Controls.Add(LabelAT13);
            LabelAT13.Text = "密码：";
            LabelAT13.SetBounds(150, 200, 100, 20);
            LabelAT13.Font = new Font("楷宋", 12);

            LabelAT14 = new Label();
            FormAT1.Controls.Add(LabelAT14);
            LabelAT14.Text = "姓名：";
            LabelAT14.SetBounds(150, 250, 100, 20);
            LabelAT14.Font = new Font("楷宋", 12);

            TextBoxAT11 = new TextBox();
            FormAT1.Controls.Add(TextBoxAT11);
            TextBoxAT11.SetBounds(250, 150, 200, 20);
            TextBoxAT11.Font = new Font("楷宋", 10);

            TextBoxAT12 = new TextBox();
            FormAT1.Controls.Add(TextBoxAT12);
            TextBoxAT12.SetBounds(250, 200, 200, 20);
            TextBoxAT12.Font = new Font("楷宋", 10);
            TextBoxAT12.UseSystemPasswordChar = true;

            TextBoxAT13 = new TextBox();
            FormAT1.Controls.Add(TextBoxAT13);
            TextBoxAT13.SetBounds(250, 250, 200, 20);
            TextBoxAT13.Font = new Font("楷宋", 10);

            ButtonAT1queren = new Button();
            FormAT1.Controls.Add(ButtonAT1queren);
            ButtonAT1queren.SetBounds(250, 375, 70, 25);
            ButtonAT1queren.Text = "确认添加";
            ButtonAT1queren.Click += new EventHandler(ButtonAT1queren_click);

            FormAT1.Show();
        }
        private void ButtonAT1queren_click(Object b, EventArgs e)
        {
            string sqlAT1bool = "select Tworknumber from Tutor where Tworknumber = '" + TextBoxAT11.Text + "'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter dataAT1bool = new SqlDataAdapter(sqlAT1bool, conn);
            DataTable tableAT1bool = new DataTable();
            dataAT1bool.Fill(tableAT1bool);
            if (TextBoxAT11.Text == "")
            {
                MessageBox.Show("账号不能为空");
                TextBoxAT11.Focus();
            }
            else if (tableAT1bool.Rows.Count != 0)
            {
                MessageBox.Show("此账号已被注册");
                TextBoxAT11.Focus();
            }
            else if (TextBoxAT12.Text == "")
            {
                MessageBox.Show("密码不能为空");
                TextBoxAT12.Focus();
            }
            else if (TextBoxAT13.Text == "")
            {
                MessageBox.Show("姓名不能为空");
                TextBoxAT13.Focus();
            }
            else
            {
                string sqlAT11 = "insert into TutorLogin values('" + TextBoxAT11.Text + "','" + TextBoxAT12.Text + "')";
                string sqlAT12 = "insert into Tutor values('" + TextBoxAT11.Text + "','" + TextBoxAT13.Text + "','0','0')";
                SqlDataAdapter dataAT11 = new SqlDataAdapter(sqlAT11, conn);
                DataTable tableAT11 = new DataTable();
                dataAT11.Fill(tableAT11);
                SqlDataAdapter dataAT12 = new SqlDataAdapter(sqlAT12, conn);
                DataTable tableAT12 = new DataTable();
                dataAT12.Fill(tableAT12);
                conn.Close();
                MessageBox.Show("添加成功");
                FormAT1.Close();
            }
        }
        private void ButtonAT2_click(Object b, EventArgs e)
        {
            FormAT2 = new Form();
            FormAT2.Text = "修改导师信息";
            FormAT2.SetBounds(100, 100, 600, 500);

            LabelAT21 = new Label();
            FormAT2.Controls.Add(LabelAT21);
            LabelAT21.Text = "修改导师信息";
            LabelAT21.SetBounds(230, 50, 200, 30);
            LabelAT21.Font = new Font("楷宋", 15);

            LabelAT22 = new Label();
            FormAT2.Controls.Add(LabelAT22);
            LabelAT22.Text = "工号：";
            LabelAT22.SetBounds(150, 150, 100, 20);
            LabelAT22.Font = new Font("楷宋", 12);

            LabelAT23 = new Label();
            FormAT2.Controls.Add(LabelAT23);
            LabelAT23.Text = "姓名：";
            LabelAT23.SetBounds(150, 200, 100, 20);
            LabelAT23.Font = new Font("楷宋", 12);

            TextBoxAT21 = new TextBox();
            FormAT2.Controls.Add(TextBoxAT21);
            TextBoxAT21.SetBounds(250, 200, 200, 20);
            TextBoxAT21.Font = new Font("楷宋", 10);

            ComboBoxAT21 = new ComboBox();
            FormAT2.Controls.Add(ComboBoxAT21);
            ComboBoxAT21.SetBounds(250, 150, 100, 20);
            ComboBoxAT21.Font = new Font("楷宋", 10);
            ComboBoxAT21.DropDownStyle = ComboBoxStyle.DropDown;
            ComboBoxAT21.DataSource = null;
            xiugaiAT21();

            ButtonAT2queren = new Button();
            FormAT2.Controls.Add(ButtonAT2queren);
            ButtonAT2queren.SetBounds(250, 275, 70, 25);
            ButtonAT2queren.Text = "确认修改";
            ButtonAT2queren.Click += new EventHandler(ButtonAT2queren_click);

            FormAT2.Show();
        }
        private void xiugaiAT21()
        {
            string sqlxiugaiAT21 = "select Tworknumber from Tutor";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter dataxiugaiAT21 = new SqlDataAdapter(sqlxiugaiAT21, conn);
            DataTable setxiugaiAT21 = new DataTable();
            dataxiugaiAT21.Fill(setxiugaiAT21);
            ComboBoxAT21.DataSource = setxiugaiAT21;
            ComboBoxAT21.DisplayMember = "Tworknumber";
            conn.Close();
        }
        private void ButtonAT2queren_click(Object b, EventArgs e)
        {
            string sqlAT2bool = "select Tworknumber from Tutor where Tworknumber = '" + ComboBoxAT21.Text + "'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter dataAT2bool = new SqlDataAdapter(sqlAT2bool, conn);
            DataTable tableAT2bool = new DataTable();
            dataAT2bool.Fill(tableAT2bool);
            if (ComboBoxAT21.Text == "")
            {
                MessageBox.Show("工号不能为空");
            }
            else if (tableAT2bool.Rows.Count == 0)
            {
                MessageBox.Show("此工号不存在");
            }
            else if (TextBoxAT21.Text == "")
            {
                MessageBox.Show("姓名不能为空");
                TextBoxAT21.Focus();
            }
            else
            {
                string sqlAT21 = "update Tutor set Tname = '" + TextBoxAT21.Text + "' where Tworknumber = '" + ComboBoxAT21.Text + "'";
                SqlDataAdapter dataAT21 = new SqlDataAdapter(sqlAT21, conn);
                DataTable tableAT21 = new DataTable();
                dataAT21.Fill(tableAT21);
                MessageBox.Show("修改成功");
                conn.Close();
                FormAT2.Close();
            }
        }
        private void ButtonAT3_click(Object b, EventArgs e)
        {
            FormAT3 = new Form();
            FormAT3.Text = "删除导师信息";
            FormAT3.SetBounds(100, 100, 600, 500);

            LabelAT31 = new Label();
            FormAT3.Controls.Add(LabelAT31);
            LabelAT31.Text = "删除导师信息";
            LabelAT31.SetBounds(230, 50, 200, 30);
            LabelAT31.Font = new Font("楷宋", 15);

            LabelAT32 = new Label();
            FormAT3.Controls.Add(LabelAT32);
            LabelAT32.Text = "工号：";
            LabelAT32.SetBounds(150, 150, 100, 20);
            LabelAT32.Font = new Font("楷宋", 12);

            ComboBoxAT31 = new ComboBox();
            FormAT3.Controls.Add(ComboBoxAT31);
            ComboBoxAT31.SetBounds(250, 150, 100, 20);
            ComboBoxAT31.Font = new Font("楷宋", 10);
            ComboBoxAT31.DropDownStyle = ComboBoxStyle.DropDown;
            ComboBoxAT31.DataSource = null;
            shanchuAT31();

            ButtonAT3queren = new Button();
            FormAT3.Controls.Add(ButtonAT3queren);
            ButtonAT3queren.SetBounds(250, 225, 70, 25);
            ButtonAT3queren.Text = "确认删除";
            ButtonAT3queren.Click += new EventHandler(ButtonAT3queren_click);

            FormAT3.Show();
        }
        private void shanchuAT31()
        {
            string sqlshanchuAT31 = "select Tworknumber from Tutor";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter datashanchuAT31 = new SqlDataAdapter(sqlshanchuAT31, conn);
            DataTable setshanchuAT31 = new DataTable();
            datashanchuAT31.Fill(setshanchuAT31);
            ComboBoxAT31.DataSource = setshanchuAT31;
            ComboBoxAT31.DisplayMember = "Tworknumber";
            conn.Close();
        }
        private void ButtonAT3queren_click(Object b, EventArgs e)
        {
            string sqlAT3bool = "select Tworknumber from Tutor where Tworknumber = '" + ComboBoxAT31.Text + "'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter dataAT3bool = new SqlDataAdapter(sqlAT3bool, conn);
            DataTable tableAT3bool = new DataTable();
            dataAT3bool.Fill(tableAT3bool);
            if (ComboBoxAT31.Text == "")
            {
                MessageBox.Show("工号不能为空");
                ComboBoxAT31.Focus();
            }
            else if (tableAT3bool.Rows.Count == 0)
            {
                MessageBox.Show("此工号不存在");
                ComboBoxAT31.Focus();
            }
            else
            {
                string sqlAT31 = "update Student set Schoose='0' where Sstudynumber in(select Sstudynumber from ST where Tworknumber = '" + ComboBoxAT31.Text + "' and STok='1')";
                string sqlAT32 = "delete from ST where Tworknumber = '" + ComboBoxAT31.Text + "'";
                string sqlAT33 = "delete from Tutor where Tworknumber = '" + ComboBoxAT31.Text + "'";
                string sqlAT34 = "delete from TutorLogin where Taccount = '" + ComboBoxAT31.Text + "'";
                SqlDataAdapter dataAT31 = new SqlDataAdapter(sqlAT31, conn);
                DataTable tableAT31 = new DataTable();
                dataAT31.Fill(tableAT31);
                SqlDataAdapter dataAT32 = new SqlDataAdapter(sqlAT32, conn);
                DataTable tableAT32 = new DataTable();
                dataAT32.Fill(tableAT32);
                SqlDataAdapter dataAT33 = new SqlDataAdapter(sqlAT33, conn);
                DataTable tableAT33 = new DataTable();
                dataAT33.Fill(tableAT33);
                SqlDataAdapter dataAT34 = new SqlDataAdapter(sqlAT34, conn);
                DataTable tableAT34 = new DataTable();
                dataAT34.Fill(tableAT34);
                conn.Close();
                MessageBox.Show("删除成功");
                FormAT3.Close();
            }
        }

        public administrator(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
