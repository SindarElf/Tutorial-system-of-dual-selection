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
    public partial class student : Panel
    {
        //2
        Button Button2xiugai = new Button();
        Form Formmima;
        Label Labelxiugaimima;
        Label Labelold;
        Label Labelnew;
        Label Labelnewqueren;
        TextBox TextBoxold;
        TextBox TextBoxnew;
        TextBox TextBoxnewqueren;
        Button Buttonmimaqueren;

        Button Button2zhuxiao = new Button();
        TabControl TabControlstudent = new TabControl();
        TabPage TabPage2zhiyuan = new TabPage();
        TabPage TabPage2ziliao = new TabPage();
        TabPage TabPage2xiaoxi = new TabPage();

        //21
        GroupBox GroupBox2kexuan = new GroupBox();
        GroupBox GroupBox2queren = new GroupBox();
        GroupBox GroupBox2list = new GroupBox();
        Label Label2queren1 = new Label();
        Label Label2queren2 = new Label();
        DataGridView DataGridView2kexuan = new DataGridView();
        DataGridView DataGridView2list = new DataGridView();
        ComboBox ComboBox2queren = new ComboBox();
        Button Button2queren = new Button();

        //22
        GroupBox GroupBox2Sziliao = new GroupBox();
        GroupBox GroupBox2Tziliao = new GroupBox();
        Label bLabel2Snumber;

        Label aLabel2bool = new Label();

        //23
        GroupBox GroupBox2yaoqing = new GroupBox();
        GroupBox GroupBox2jieshou = new GroupBox();
        DataGridView DataGridView2yaoqing = new DataGridView();
        Label Label2jieshou = new Label();
        ComboBox ComboBox2jieshou = new ComboBox();
        Button Button2jieshou = new Button();
        public student()
        {
            InitializeComponent();
            //Panel学生页面
            
            this.Dock = DockStyle.Fill;
            this.Controls.Add(TabControlstudent);
            this.Controls.Add(Button2zhuxiao);
            this.Controls.Add(Button2xiugai);

            //Button学生修改密码
            Button2xiugai.SetBounds(100, 720, 70, 25);
            Button2xiugai.Text = "修改密码";
            Button2xiugai.Click += new EventHandler(Button2xiugai_click);

            //Button学生注销
            Button2zhuxiao.SetBounds(700, 720, 70, 25);
            Button2zhuxiao.Text = "注销";
            Button2zhuxiao.Click += new EventHandler(Button2zhuxiao_click);

            //TabControl学生志愿、个人资料、消息
            TabControlstudent.SetBounds(0,0,1525,700);
            TabControlstudent.Controls.Add(TabPage2ziliao);
            TabControlstudent.Controls.Add(TabPage2zhiyuan);
            TabControlstudent.Controls.Add(TabPage2xiaoxi);
            TabControlstudent.SelectedIndexChanged += new EventHandler(TabControlstudent_SelectedIndexChanged);

            //TabPagezhiyuan学生志愿TAB页面---------------------------------
            TabPage2zhiyuan.Name = "tab2zhiyuan";
            TabPage2zhiyuan.Text = "志愿选择";
            TabPage2zhiyuan.BackgroundImage = Image.FromFile("C:\\Users\\Maple\\Desktop\\导师制双选系统\\1.jpg");
            

            TabPage2zhiyuan.Controls.Add(GroupBox2kexuan);
            GroupBox2kexuan.Text = "可选导师列表";
            GroupBox2kexuan.SetBounds(100, 50, 600, 200);
            GroupBox2kexuan.Font = new Font("楷体", 15);
            GroupBox2kexuan.BackColor = System.Drawing.Color.Transparent;
            

            TabPage2zhiyuan.Controls.Add(GroupBox2queren);
            GroupBox2queren.Text = "确认";
            GroupBox2queren.SetBounds(800, 50, 500, 200);
            GroupBox2queren.Font = new Font("楷体", 15);
            GroupBox2queren.BackColor = System.Drawing.Color.Transparent;

            TabPage2zhiyuan.Controls.Add(GroupBox2list);
            GroupBox2list.Text = "导师列表";
            GroupBox2list.SetBounds(450, 350, 700, 300);
            GroupBox2list.Font = new Font("楷体", 15);
            GroupBox2list.BackColor = System.Drawing.Color.Transparent;
            

            GroupBox2queren.Controls.Add(Label2queren1);
            Label2queren1.Text = "可以志愿选择多名导师，若重复多选，请重复确认。但每名学生最多只能拥有一名导师教学。";
            Label2queren1.SetBounds(30, 50, 200, 150);
            Label2queren1.Font = new Font("楷宋", 12);
            Label2queren1.BackColor = System.Drawing.Color.Transparent;
           

            GroupBox2queren.Controls.Add(Label2queren2);
            Label2queren2.Text = "工号：";
            Label2queren2.SetBounds(250, 50, 50, 30);
            Label2queren2.Font = new Font("楷宋", 10);
            Label2queren2.BackColor = System.Drawing.Color.Transparent;
            

            GroupBox2kexuan.Controls.Add(DataGridView2kexuan);
            DataGridView2kexuan.ReadOnly = true;
            DataGridView2kexuan.Font=new Font("楷体", 12);
            DataGridView2kexuan.BorderStyle = BorderStyle.None;
            DataGridView2kexuan.BackgroundColor = Color.GhostWhite;
            DataGridView2kexuan.Dock=DockStyle.Fill;
            DataGridView2kexuan.DataSource = null;
            DataGridView2kexuan.AutoGenerateColumns = false;
            DataGridView2kexuan.ColumnCount = 3;
            kexuan2();

            GroupBox2list.Controls.Add(DataGridView2list);
            DataGridView2list.ReadOnly = true;
            DataGridView2list.Font = new Font("楷体", 12);
            DataGridView2list.BorderStyle = BorderStyle.None;
            DataGridView2list.BackgroundColor = Color.GhostWhite;
            DataGridView2list.Dock = DockStyle.Fill;
            DataGridView2list.DataSource = null;
            DataGridView2list.AutoGenerateColumns = false;
            DataGridView2list.ColumnCount = 3;
            list2();

            GroupBox2queren.Controls.Add(ComboBox2queren);
            ComboBox2queren.SetBounds(310, 47, 100, 50);
            ComboBox2queren.Font = new Font("楷宋", 10);
            ComboBox2queren.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox2queren.DataSource = null;
            queren2();

            GroupBox2queren.Controls.Add(Button2queren);
            Button2queren.SetBounds(320, 100, 60, 25);
            Button2queren.Text = "确认";
            Button2queren.Font = new Font("楷宋", 10);
            Button2queren.Click += new EventHandler(Button2queren_click);

            //TabPageziliao学生个人资料TAB页面-----------------------
            TabPage2ziliao.Name = "tab2ziliao";
            TabPage2ziliao.Text = "个人资料";
            TabPage2ziliao.BackgroundImage = Image.FromFile("C:\\Users\\Maple\\Desktop\\导师制双选系统\\1.jpg");
            
            //个人资料
            TabPage2ziliao.Controls.Add(GroupBox2Sziliao);
            GroupBox2Sziliao.Text = "个人资料";
            GroupBox2Sziliao.SetBounds(100, 50, 1300, 200);
            GroupBox2Sziliao.Font = new Font("楷体", 15);
            GroupBox2Sziliao.BackColor = System.Drawing.Color.Transparent;

            readbLabel2S();

            //导师资料
            TabPage2ziliao.Controls.Add(GroupBox2Tziliao);
            GroupBox2Tziliao.Text = "导师资料";
            GroupBox2Tziliao.SetBounds(100, 300, 1300, 200);
            GroupBox2Tziliao.Font = new Font("楷体", 15);
            GroupBox2Tziliao.BackColor = System.Drawing.Color.Transparent;
            

            readbLabel2T();

            //TabPage学生消息TAB页面
            TabPage2xiaoxi.Name = "tab2xiaoxi";
            TabPage2xiaoxi.Text = "消息";
            TabPage2xiaoxi.BackgroundImage = Image.FromFile("C:\\Users\\Maple\\Desktop\\导师制双选系统\\1.jpg");
            

            TabPage2xiaoxi.Controls.Add(GroupBox2yaoqing);
            GroupBox2yaoqing.Text = "导师邀请";
            GroupBox2yaoqing.SetBounds(100, 50, 800, 500);
            GroupBox2yaoqing.Font = new Font("楷体", 15);
            GroupBox2yaoqing.BackColor = System.Drawing.Color.Transparent;
            

            TabPage2xiaoxi.Controls.Add(GroupBox2jieshou);
            GroupBox2jieshou.Text = "接受邀请";
            GroupBox2jieshou.SetBounds(950, 50, 450, 500);
            GroupBox2jieshou.Font = new Font("楷体", 15);
            GroupBox2jieshou.BackColor = System.Drawing.Color.Transparent;

            GroupBox2yaoqing.Controls.Add(DataGridView2yaoqing);
            DataGridView2yaoqing.ReadOnly = true;
            DataGridView2yaoqing.Font = new Font("楷体", 12);
            DataGridView2yaoqing.BorderStyle = BorderStyle.None;
            DataGridView2yaoqing.BackgroundColor = Color.GhostWhite;
            DataGridView2yaoqing.Dock = DockStyle.Fill;
            DataGridView2yaoqing.DataSource = null;
            DataGridView2yaoqing.AutoGenerateColumns = false;
            DataGridView2yaoqing.ColumnCount = 3;
            yaoqing2();

            GroupBox2jieshou.Controls.Add(Label2jieshou);
            Label2jieshou.Text = "工号：";
            Label2jieshou.SetBounds(100, 150, 50, 30);
            Label2jieshou.Font = new Font("楷宋", 10);
            Label2jieshou.BackColor = System.Drawing.Color.Transparent;

            GroupBox2jieshou.Controls.Add(ComboBox2jieshou);
            ComboBox2jieshou.SetBounds(160, 147, 100, 50);
            ComboBox2jieshou.Font = new Font("楷宋", 10);
            ComboBox2jieshou.DropDownStyle = ComboBoxStyle.DropDownList;
            jieshou2();

            GroupBox2jieshou.Controls.Add(Button2jieshou);
            Button2jieshou.SetBounds(165, 200, 60, 25);
            Button2jieshou.Text = "确定";
            Button2jieshou.Font = new Font("楷宋", 10);
            Button2jieshou.Click += new EventHandler(Button2jieshou_click);
        }
        private void kexuan2()
        {
            string sql2kexuan = "select Tworknumber,Tname,Tchoose from Tutor where Tchoose != '5'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data2kexuan = new SqlDataAdapter(sql2kexuan, conn);
            DataSet set2kexuan = new DataSet();
            data2kexuan.Fill(set2kexuan, "Tutor");
            DataGridView2kexuan.DataSource = set2kexuan;
            DataGridView2kexuan.DataMember = "Tutor";
            //设置表的列头文字
            DataGridView2kexuan.Columns[0].HeaderText= "工号";
            DataGridView2kexuan.Columns[1].HeaderText = "姓名";
            DataGridView2kexuan.Columns[2].HeaderText = "已选学生数量";
            //录入数据
            DataGridView2kexuan.Columns[0].DataPropertyName = set2kexuan.Tables[0].Columns[0].ToString();
            DataGridView2kexuan.Columns[1].DataPropertyName = set2kexuan.Tables[0].Columns[1].ToString();
            DataGridView2kexuan.Columns[2].DataPropertyName = set2kexuan.Tables[0].Columns[2].ToString();
            //设置列宽
            DataGridView2kexuan.Columns[0].Width = 180;
            DataGridView2kexuan.Columns[1].Width = 190;
            DataGridView2kexuan.Columns[2].Width = 180;
            conn.Close();
        }
        private void list2()
        {
            string sql2list = "select Tworknumber,Tname,Tchoose from Tutor";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data2list = new SqlDataAdapter(sql2list, conn);
            DataSet set2list = new DataSet();
            data2list.Fill(set2list, "Tutor");
            DataGridView2list.DataSource = set2list;
            DataGridView2list.DataMember = "Tutor";
            //设置表的列头文字
            DataGridView2list.Columns[0].HeaderText = "工号";
            DataGridView2list.Columns[1].HeaderText = "姓名";
            DataGridView2list.Columns[2].HeaderText = "已选学生数量";
            //录入数据
            DataGridView2list.Columns[0].DataPropertyName = set2list.Tables[0].Columns[0].ToString();
            DataGridView2list.Columns[1].DataPropertyName = set2list.Tables[0].Columns[1].ToString();
            DataGridView2list.Columns[2].DataPropertyName = set2list.Tables[0].Columns[2].ToString();
            //设置列宽*/
            DataGridView2list.Columns[0].Width = 210;
            DataGridView2list.Columns[1].Width = 230;
            DataGridView2list.Columns[2].Width = 210;
            conn.Close();
        }

        private void queren2()
        {
            string sql2queren = "select Tworknumber from Tutor where Tchoose != '5'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data2queren = new SqlDataAdapter(sql2queren, conn);
            DataTable set2queren = new DataTable();
            data2queren.Fill(set2queren);
            ComboBox2queren.DataSource = set2queren;
            ComboBox2queren.DisplayMember = "Tworknumber";
            conn.Close();
            
        }
        private void Button2zhuxiao_click(Object b, EventArgs e)
        {
            string sql2Buttonzhuxiao = "update Student set Syes = '0' where Syes= '1'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data2Buttonzhuxiao = new SqlDataAdapter(sql2Buttonzhuxiao, conn);
            DataTable set2Buttonzhuxiao = new DataTable();
            data2Buttonzhuxiao.Fill(set2Buttonzhuxiao);
            conn.Close();
            this.Hide();
        }
        private void Button2queren_click(Object b, EventArgs e)
        {
            string sql2bool = "select ST.Sstudynumber from ST join Student on ST.Sstudynumber=Student.Sstudynumber where Syes='1' and ST.Tworknumber ="+ComboBox2queren.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data2bool = new SqlDataAdapter(sql2bool, conn);
            DataTable table2bool = new DataTable();
            data2bool.Fill(table2bool);
            if (table2bool.Rows.Count == 0)
            {
                string sql2Button2queren1 = "insert into ST values('" + bLabel2Snumber.Text + "','"+ComboBox2queren.Text+"','1','0','0')";
                SqlDataAdapter dataButton2queren1 = new SqlDataAdapter(sql2Button2queren1, conn);
                DataTable set2Button2queren1 = new DataTable();
                dataButton2queren1.Fill(set2Button2queren1);
                MessageBox.Show("选取成功");
            }
            if (table2bool.Rows.Count != 0)
            {
                string sql2Button2queren2 = "update ST set SgetT = '1' where Sstudynumber in (select Sstudynumber from Student where Syes = '1') and Tworknumber = " + ComboBox2queren.Text;
                SqlDataAdapter data2Button2queren2 = new SqlDataAdapter(sql2Button2queren2, conn);
                DataTable set2Button2queren2 = new DataTable();
                data2Button2queren2.Fill(set2Button2queren2);
                conn.Close();
                MessageBox.Show("选取成功");
            }
        }

        private void readbLabel2S()
        {
            GroupBox2Sziliao.Controls.Clear();
            Label aLabel2Sname = new Label();
            Label aLabel2Snumber = new Label();
            Label aLabel2Sclass = new Label();
            Label bLabel2Sname = new Label();
            bLabel2Snumber = new Label();
            Label bLabel2Sclass = new Label();
            //--
            GroupBox2Sziliao.Controls.Add(aLabel2Sname);
            aLabel2Sname.Text = "姓名：";
            aLabel2Sname.SetBounds(80, 50, 70, 16);
            aLabel2Sname.Font = new Font("楷体", 13);
            aLabel2Sname.BackColor = System.Drawing.Color.Transparent;
            

            GroupBox2Sziliao.Controls.Add(aLabel2Snumber);
            aLabel2Snumber.Text = "学号：";
            aLabel2Snumber.SetBounds(80, 90, 70, 16);
            aLabel2Snumber.Font = new Font("楷体", 13);
            aLabel2Snumber.BackColor = System.Drawing.Color.Transparent;
            

            GroupBox2Sziliao.Controls.Add(aLabel2Sclass);
            aLabel2Sclass.Text = "班级：";
            aLabel2Sclass.SetBounds(80, 130, 70, 16);
            aLabel2Sclass.Font = new Font("楷体", 13);
            aLabel2Sclass.BackColor = System.Drawing.Color.Transparent;


            GroupBox2Sziliao.Controls.Add(bLabel2Sname);
            bLabel2Sname.SetBounds(160, 50, 100, 16);
            bLabel2Sname.Font = new Font("楷体", 13);
            bLabel2Sname.BackColor = System.Drawing.Color.Transparent;
            

            GroupBox2Sziliao.Controls.Add(bLabel2Snumber);
            bLabel2Snumber.SetBounds(160, 90, 100, 16);
            bLabel2Snumber.Font = new Font("楷体", 13);
            bLabel2Snumber.BackColor = System.Drawing.Color.Transparent;
            

            GroupBox2Sziliao.Controls.Add(bLabel2Sclass);
            bLabel2Sclass.SetBounds(160, 130, 100, 16);
            bLabel2Sclass.Font = new Font("楷体", 13);
            bLabel2Sclass.BackColor = System.Drawing.Color.Transparent;
           
            //--
            string sql2readLabel2S = "select * from Student where Syes = '1'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlCommand DataLabel2S=new SqlCommand(sql2readLabel2S,conn);
            SqlDataReader DataReadbLabel2S = DataLabel2S.ExecuteReader();
            while (DataReadbLabel2S.Read())
            {
                bLabel2Sname.Text += DataReadbLabel2S["Sname"];
                bLabel2Snumber.Text += DataReadbLabel2S["Sstudynumber"];
                bLabel2Sclass.Text += DataReadbLabel2S["Sclass"];
            }
            conn.Close();
            DataLabel2S.Dispose();
        }

        private void readbLabel2T()
        {
            GroupBox2Tziliao.Controls.Clear();
            Label aLabel2Tname = new Label();
            Label aLabel2Tnumber = new Label();
            Label bLabel2Tname = new Label();
            Label bLabel2Tnumber = new Label();
            //--
            GroupBox2Tziliao.Controls.Add(aLabel2Tname);
            aLabel2Tname.Text = "姓名：";
            aLabel2Tname.SetBounds(80, 50, 70, 16);
            aLabel2Tname.Font = new Font("楷体", 13);
            aLabel2Tname.BackColor = System.Drawing.Color.Transparent;
            

            GroupBox2Tziliao.Controls.Add(aLabel2Tnumber);
            aLabel2Tnumber.Text = "工号：";
            aLabel2Tnumber.SetBounds(80, 90, 70, 16);
            aLabel2Tnumber.Font = new Font("楷体", 13);
            aLabel2Tnumber.BackColor = System.Drawing.Color.Transparent;
           

            GroupBox2Tziliao.Controls.Add(bLabel2Tname);
            bLabel2Tname.SetBounds(160, 50, 100, 16);
            bLabel2Tname.Font = new Font("楷体", 13);
            bLabel2Tname.BackColor = System.Drawing.Color.Transparent;
          
            GroupBox2Tziliao.Controls.Add(bLabel2Tnumber);
            bLabel2Tnumber.SetBounds(160, 90, 100, 16);
            bLabel2Tnumber.Font = new Font("楷体", 13);
            bLabel2Tnumber.BackColor = System.Drawing.Color.Transparent;
            
            //--
            string sql2readLabel2T = "select * from Tutor join ST on ST.Tworknumber=Tutor.Tworknumber join Student on ST.Sstudynumber=Student.Sstudynumber where Syes = '1' and STok='1'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlCommand DataLabel2T = new SqlCommand(sql2readLabel2T, conn);
            SqlDataReader DataReadbLabel2T = DataLabel2T.ExecuteReader();
            while (DataReadbLabel2T.Read())
            {
                bLabel2Tname.Text += DataReadbLabel2T["Tname"];
                bLabel2Tnumber.Text += DataReadbLabel2T["Tworknumber"];
            }
            conn.Close();
            DataLabel2T.Dispose();
        }
        private void yaoqing2()
        {
            string sql2yaoqing = "select Tutor.Tworknumber,Tname,Tchoose from Tutor join ST on ST.Tworknumber=Tutor.Tworknumber join Student on ST.Sstudynumber=Student.Sstudynumber where Syes='1' and TgetS='1' and Tchoose!='5' and STok!='1'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data2yaoqing = new SqlDataAdapter(sql2yaoqing, conn);
            DataSet set2yaoqing = new DataSet();
            data2yaoqing.Fill(set2yaoqing, "Tutor");
            DataGridView2yaoqing.DataSource = set2yaoqing;
            DataGridView2yaoqing.DataMember = "Tutor";
            //设置表的列头文字
            DataGridView2yaoqing.Columns[0].HeaderText = "工号";
            DataGridView2yaoqing.Columns[1].HeaderText = "姓名";
            DataGridView2yaoqing.Columns[2].HeaderText = "已选学生数量";
            //录入数据
            DataGridView2yaoqing.Columns[0].DataPropertyName = set2yaoqing.Tables[0].Columns[0].ToString();
            DataGridView2yaoqing.Columns[1].DataPropertyName = set2yaoqing.Tables[0].Columns[1].ToString();
            DataGridView2yaoqing.Columns[2].DataPropertyName = set2yaoqing.Tables[0].Columns[2].ToString();
            //设置列宽*/
            DataGridView2yaoqing.Columns[0].Width = 245;
            DataGridView2yaoqing.Columns[1].Width = 260;
            DataGridView2yaoqing.Columns[2].Width = 245;
            conn.Close();
        }
        private void jieshou2()
        {
            ComboBox2jieshou.DataSource = null;
            ComboBox2jieshou.Items.Clear();
            string sql2jieshou = "select Tutor.Tworknumber from Tutor join ST on ST.Tworknumber=Tutor.Tworknumber join Student on ST.Sstudynumber=Student.Sstudynumber where Syes='1' and TgetS='1' and Tchoose!='5'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data2jieshou = new SqlDataAdapter(sql2jieshou, conn);
            DataTable set2jieshou = new DataTable();
            data2jieshou.Fill(set2jieshou);
            ComboBox2jieshou.DataSource = set2jieshou;
            ComboBox2jieshou.DisplayMember = "Tworknumber";
            conn.Close();
        }
        private void Button2jieshou_click(Object b, EventArgs e)
        {
            //1
            string sql2Button2jieshou = "update ST set STok = '1' where Sstudynumber in (select Sstudynumber from Student where Syes = '1') and Tworknumber = " + ComboBox2jieshou.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data2Button2jieshou = new SqlDataAdapter(sql2Button2jieshou, conn);
            DataTable set2Button2jieshou = new DataTable();
            data2Button2jieshou.Fill(set2Button2jieshou);
            conn.Close();
            //2
            string Button2a = "update Student set Schoose = '1' where Syes = '1'";
            SqlConnection conna = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conna.Open();
            SqlDataAdapter dataButton2a = new SqlDataAdapter(Button2a, conna);
            DataTable setButton2a = new DataTable();
            dataButton2a.Fill(setButton2a);
            conn.Close();
            //3
            string Button2b = "update Tutor set Tchoose=Tchoose+1 where Tworknumber = '"+ComboBox2jieshou.Text+"'";
            SqlConnection connb = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            connb.Open();
            SqlDataAdapter dataButton2b = new SqlDataAdapter(Button2b, conn);
            DataTable setButton2b = new DataTable();
            dataButton2b.Fill(setButton2b);
            conn.Close();
            MessageBox.Show("导师选取成功！");
            Spanel();
        }
        private void TabControlstudent_SelectedIndexChanged(Object b, EventArgs e)
        {
            if (TabControlstudent.SelectedTab.Name == "tab2ziliao")
            {
                readbLabel2T();
            }
            if (TabControlstudent.SelectedTab.Name == "tab2zhiyuan")
            {
                Spanel();
            }
            if (TabControlstudent.SelectedTab.Name == "tab2xiaoxi")
            {
                Spanel();
            }
        }
        private void Spanel()
        {
            string Tab2bool = "select Sstudynumber from Student where Syes = '1' and Schoose = '1'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter dataTab2bool = new SqlDataAdapter(Tab2bool, conn);
            DataTable tableTab2bool = new DataTable();
            dataTab2bool.Fill(tableTab2bool);
            if (tableTab2bool.Rows.Count != 0)
            {
                
                Label LabelSman = new Label();
                LabelSman.BackColor = System.Drawing.Color.Transparent;
                LabelSman.Text = "已有导师，无法进行操作";
                LabelSman.SetBounds(550, 250, 400, 100);
                LabelSman.Font = new Font("楷体", 20);
                Panel PanelSman = new Panel();
                PanelSman.BackgroundImage = Image.FromFile("C:\\Users\\Maple\\Desktop\\导师制双选系统\\1.jpg");
                if (TabControlstudent.SelectedTab.Name == "tab2zhiyuan")
                {
                    TabPage2zhiyuan.Controls.Add(PanelSman);
                    PanelSman.BringToFront();
                }
                if (TabControlstudent.SelectedTab.Name == "tab2xiaoxi")
                {
                    
                    TabPage2xiaoxi.Controls.Add(PanelSman);
                    PanelSman.BringToFront();
                }
                PanelSman.Dock = DockStyle.Fill;
                PanelSman.Controls.Add(LabelSman);
                
            }
            else { }
        }
        private void Button2xiugai_click(Object b, EventArgs e)
        {
            Formmima = new Form();
            Formmima.Text = "更改密码";
            Formmima.SetBounds(100, 100, 600, 500);

            Labelxiugaimima = new Label();
            Formmima.Controls.Add(Labelxiugaimima);
            Labelxiugaimima.Text = "更改密码";
            Labelxiugaimima.SetBounds(230, 50, 200, 30);
            Labelxiugaimima.Font = new Font("楷宋", 15);

            Labelold = new Label();
            Formmima.Controls.Add(Labelold);
            Labelold.Text = "旧密码";
            Labelold.SetBounds(150, 150, 100, 20);
            Labelold.Font = new Font("楷宋", 12);

            Labelnew = new Label();
            Formmima.Controls.Add(Labelnew);
            Labelnew.Text = "新密码";
            Labelnew.SetBounds(150, 200, 100, 20);
            Labelnew.Font = new Font("楷宋", 12);

            Labelnewqueren = new Label();
            Formmima.Controls.Add(Labelnewqueren);
            Labelnewqueren.Text = "确认密码";
            Labelnewqueren.SetBounds(150, 250, 100, 20);
            Labelnew.Font = new Font("楷宋", 12);

            TextBoxold = new TextBox();
            Formmima.Controls.Add(TextBoxold);
            TextBoxold.SetBounds(250, 150, 200, 20);
            TextBoxold.Font = new Font("楷宋", 10);
            TextBoxold.UseSystemPasswordChar = true;

            TextBoxnew = new TextBox();
            Formmima.Controls.Add(TextBoxnew);
            TextBoxnew.SetBounds(250, 200, 200, 20);
            TextBoxnew.Font = new Font("楷宋", 10);
            TextBoxnew.UseSystemPasswordChar = true;

            TextBoxnewqueren = new TextBox();
            Formmima.Controls.Add(TextBoxnewqueren);
            TextBoxnewqueren.SetBounds(250, 250, 200, 20);
            TextBoxnewqueren.Font = new Font("楷宋", 10);
            TextBoxnewqueren.UseSystemPasswordChar = true;

            Buttonmimaqueren = new Button();
            Formmima.Controls.Add(Buttonmimaqueren);
            Buttonmimaqueren.SetBounds(250, 325, 70, 25);
            Buttonmimaqueren.Text = "确认修改";
            Buttonmimaqueren.Click += new EventHandler(Buttonmimaqueren_click);

            Formmima.Show();
        }
        private void Buttonmimaqueren_click(Object b, EventArgs e)
        {
            if (TextBoxold.Text == "")
            {
                MessageBox.Show("旧密码不能为空");
                TextBoxold.Focus();
            }
            else if(TextBoxnew.Text=="")
            {
                MessageBox.Show("新密码不能为空");
                TextBoxnew.Focus();
            }
            else if (TextBoxnewqueren.Text == "")
            {
                MessageBox.Show("确认密码不能为空");
                TextBoxnewqueren.Focus();
            }
            else
            {
                List<string>oldsend=new List<string>();
                string sqlold="select * from StudentLogin where Saccount = '"+bLabel2Snumber.Text+"'";
                SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
                conn.Open();
                SqlDataAdapter dataold = new SqlDataAdapter(sqlold, conn);
                DataTable tableold = new DataTable();
                dataold.Fill(tableold);
                foreach (DataRow row in tableold.Rows)
                {
                    oldsend.Add(row["Spassword"].ToString());
                }
                string[] oldget = oldsend.ToArray();

                for (int i = 0; i < oldget.Length; i++)
                {
                    if (oldget[i].Equals(TextBoxold.Text))
                    {
                        if (TextBoxnewqueren.Text.Equals(TextBoxnew.Text))
                        {
                            string sqlnew = "update StudentLogin set Spassword = '" + TextBoxnewqueren.Text + "' where Saccount = '" + bLabel2Snumber.Text + "'";
                            SqlDataAdapter datanew = new SqlDataAdapter(sqlnew, conn);
                            DataTable tablenew = new DataTable();
                            datanew.Fill(tablenew);
                            conn.Close();

                            MessageBox.Show("密码更改成功");
                            Formmima.Close();
                        }
                        else
                        {
                            MessageBox.Show("新密码输入不一致");
                            TextBoxnew.Text = "";
                            TextBoxnewqueren.Text = "";
                        }
                    }
                    else 
                    {
                        MessageBox.Show("旧密码错误");
                        TextBoxold.Text = "";
                    }
                }
            }
        }
        public student(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
