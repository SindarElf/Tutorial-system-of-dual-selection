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
    public partial class tutor : Panel
    {
        //2
        Button Button3xiugai = new Button();
        Form Formmima3;
        Label Labelxiugaimima3;
        Label Labelold3;
        Label Labelnew3;
        Label Labelnewqueren3;
        TextBox TextBoxold3;
        TextBox TextBoxnew3;
        TextBox TextBoxnewqueren3;
        Button Buttonmimaqueren3;


        Button Button3zhuxiao = new Button();
        TabControl TabControltutor = new TabControl();
        TabPage TabPage3zhiyuan = new TabPage();
        TabPage TabPage3ziliao = new TabPage();
        TabPage TabPage3xiaoxi = new TabPage();

        //21
        GroupBox GroupBox3kexuan = new GroupBox();
        GroupBox GroupBox3queren = new GroupBox();
        GroupBox GroupBox3list = new GroupBox();
        Label Label3queren1 = new Label();
        Label Label3queren2 = new Label();
        
        
        ComboBox ComboBox3queren = new ComboBox();
        Button Button3queren = new Button();

        //22
        GroupBox GroupBox3Tziliao = new GroupBox();
        GroupBox GroupBox3Sziliao = new GroupBox();

        Label bLabel3Tnumber;
        

        //23
        GroupBox GroupBox3yaoqing = new GroupBox();
        GroupBox GroupBox3jieshou = new GroupBox();
        
        Label Label3jieshou = new Label();
        ComboBox ComboBox3jieshou = new ComboBox();
        Button Button3jieshou = new Button();
        public tutor()
        {
            InitializeComponent();
            //Panel学生页面
            this.Dock = DockStyle.Fill;
            this.Controls.Add(TabControltutor);
            this.Controls.Add(Button3zhuxiao);
            this.Controls.Add(Button3xiugai);

            //Button导师修改密码
            Button3xiugai.SetBounds(100, 720, 70, 25);
            Button3xiugai.Text = "修改密码";
            Button3xiugai.Click += new EventHandler(Button3xiugai_click);

            //Button导师注销
            Button3zhuxiao.SetBounds(700, 720, 70, 25);
            Button3zhuxiao.Text = "注销";
            Button3zhuxiao.Click += new EventHandler(Button3zhuxiao_click);

            //TabControl导师志愿、个人资料、消息
            TabControltutor.SetBounds(0, 0, 1525, 700);
            TabControltutor.Controls.Add(TabPage3ziliao);
            TabControltutor.Controls.Add(TabPage3zhiyuan);
            TabControltutor.Controls.Add(TabPage3xiaoxi);
            TabControltutor.SelectedIndexChanged += new EventHandler(TabControltutor_SelectedIndexChanged);

            //TabPagezhiyuan导师志愿TAB页面---------------------------------
            TabPage3zhiyuan.Name = "tab3zhiyuan";
            TabPage3zhiyuan.Text = "选择学员";
            TabPage3zhiyuan.BackgroundImage = Image.FromFile("C:\\Users\\Maple\\Desktop\\导师制双选系统\\1.jpg");

            TabPage3zhiyuan.Controls.Add(GroupBox3kexuan);
            GroupBox3kexuan.Text = "可选学生列表";
            GroupBox3kexuan.SetBounds(100, 50, 600, 200);
            GroupBox3kexuan.Font = new Font("楷体", 15);
            GroupBox3kexuan.BackColor = System.Drawing.Color.Transparent;

            TabPage3zhiyuan.Controls.Add(GroupBox3queren);
            GroupBox3queren.Text = "确认";
            GroupBox3queren.SetBounds(800, 50, 500, 200);
            GroupBox3queren.Font = new Font("楷体", 15);
            GroupBox3queren.BackColor = System.Drawing.Color.Transparent;

            TabPage3zhiyuan.Controls.Add(GroupBox3list);
            GroupBox3list.Text = "学生列表";
            GroupBox3list.SetBounds(450, 350, 700, 300);
            GroupBox3list.Font = new Font("楷体", 15);
            GroupBox3list.BackColor = System.Drawing.Color.Transparent;

            GroupBox3queren.Controls.Add(Label3queren1);
            Label3queren1.Text = "最多可选择五名学员，若多次选择，请重复选择。";
            Label3queren1.SetBounds(30, 50, 200, 150);
            Label3queren1.Font = new Font("楷宋", 12);
            Label3queren1.BackColor = System.Drawing.Color.Transparent;

            GroupBox3queren.Controls.Add(Label3queren2);
            Label3queren2.Text = "学号：";
            Label3queren2.SetBounds(250, 50, 50, 30);
            Label3queren2.Font = new Font("楷宋", 10);
            Label3queren2.BackColor = System.Drawing.Color.Transparent;

            
            kexuan3();

            
            list3();

            GroupBox3queren.Controls.Add(ComboBox3queren);
            ComboBox3queren.SetBounds(310, 47, 100, 50);
            ComboBox3queren.Font = new Font("楷宋", 10);
            ComboBox3queren.DropDownStyle = ComboBoxStyle.DropDownList;
            queren3();

            GroupBox3queren.Controls.Add(Button3queren);
            Button3queren.SetBounds(320, 100, 60, 25);
            Button3queren.Text = "确认";
            Button3queren.Font = new Font("楷宋", 10);
            Button3queren.Click += new EventHandler(Button3queren_click);

            //TabPageziliao导师个人资料TAB页面-----------------------
            TabPage3ziliao.Name = "tab3ziliao";
            TabPage3ziliao.Text = "个人资料";
            TabPage3ziliao.BackgroundImage = Image.FromFile("C:\\Users\\Maple\\Desktop\\导师制双选系统\\1.jpg");
            //个人资料
            TabPage3ziliao.Controls.Add(GroupBox3Tziliao);
            GroupBox3Tziliao.Text = "个人资料";
            GroupBox3Tziliao.SetBounds(100, 50, 1300, 200);
            GroupBox3Tziliao.Font = new Font("楷体", 15);
            GroupBox3Tziliao.BackColor = System.Drawing.Color.Transparent;

            readbLabel3T();

            //学员资料
            TabPage3ziliao.Controls.Add(GroupBox3Sziliao);
            GroupBox3Sziliao.Text = "学员资料";
            GroupBox3Sziliao.SetBounds(100, 300, 1300, 200);
            GroupBox3Sziliao.Font = new Font("楷体", 15);
            GroupBox3Sziliao.BackColor = System.Drawing.Color.Transparent;

            Sziliao();

            //TabPage导师消息TAB页面
            TabPage3xiaoxi.Name = "tab3xiaoxi";
            TabPage3xiaoxi.Text = "消息";
            TabPage3xiaoxi.BackgroundImage = Image.FromFile("C:\\Users\\Maple\\Desktop\\导师制双选系统\\1.jpg");

            TabPage3xiaoxi.Controls.Add(GroupBox3yaoqing);
            GroupBox3yaoqing.Text = "学生申请";
            GroupBox3yaoqing.SetBounds(100, 50, 800, 500);
            GroupBox3yaoqing.Font = new Font("楷体", 15);
            GroupBox3yaoqing.BackColor = System.Drawing.Color.Transparent;

            TabPage3xiaoxi.Controls.Add(GroupBox3jieshou);
            GroupBox3jieshou.Text = "接受申请";
            GroupBox3jieshou.SetBounds(950, 50, 450, 500);
            GroupBox3jieshou.Font = new Font("楷体", 15);
            GroupBox3jieshou.BackColor = System.Drawing.Color.Transparent;

            
            yaoqing3();

            GroupBox3jieshou.Controls.Add(Label3jieshou);
            Label3jieshou.Text = "学号：";
            Label3jieshou.SetBounds(100, 150, 50, 30);
            Label3jieshou.Font = new Font("楷宋", 10);
            Label3jieshou.BackColor = System.Drawing.Color.Transparent;

            GroupBox3jieshou.Controls.Add(ComboBox3jieshou);
            ComboBox3jieshou.SetBounds(160, 147, 100, 50);
            ComboBox3jieshou.Font = new Font("楷宋", 10);
            ComboBox3jieshou.DropDownStyle = ComboBoxStyle.DropDownList;

            jieshou3();

            GroupBox3jieshou.Controls.Add(Button3jieshou);
            Button3jieshou.SetBounds(165, 200, 60, 25);
            Button3jieshou.Text = "确定";
            Button3jieshou.Font = new Font("楷宋", 10);
            Button3jieshou.Click += new EventHandler(Button3jieshou_click);
        }
        private void kexuan3()
        {
            GroupBox3kexuan.Controls.Clear();
            DataGridView DataGridView3kexuan = new DataGridView();
            //--
            GroupBox3kexuan.Controls.Add(DataGridView3kexuan);
            DataGridView3kexuan.ReadOnly = true;
            DataGridView3kexuan.Font = new Font("楷体", 12);
            DataGridView3kexuan.BorderStyle = BorderStyle.None;
            DataGridView3kexuan.BackgroundColor = Color.GhostWhite;
            DataGridView3kexuan.Dock = DockStyle.Fill;
            DataGridView3kexuan.DataSource = null;
            DataGridView3kexuan.AutoGenerateColumns = false;
            DataGridView3kexuan.ColumnCount = 3;
            //--
            string sql3kexuan = "select Sstudynumber,Sname,Sclass from Student where Schoose != '1'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data3kexuan = new SqlDataAdapter(sql3kexuan, conn);
            DataSet set3kexuan = new DataSet();
            data3kexuan.Fill(set3kexuan, "Student");
            DataGridView3kexuan.DataSource = set3kexuan;
            DataGridView3kexuan.DataMember = "Student";
            //设置表的列头文字
            DataGridView3kexuan.Columns[0].HeaderText = "学号";
            DataGridView3kexuan.Columns[1].HeaderText = "姓名";
            DataGridView3kexuan.Columns[2].HeaderText = "班级";
            //录入数据
            DataGridView3kexuan.Columns[0].DataPropertyName = set3kexuan.Tables[0].Columns[0].ToString();
            DataGridView3kexuan.Columns[1].DataPropertyName = set3kexuan.Tables[0].Columns[1].ToString();
            DataGridView3kexuan.Columns[2].DataPropertyName = set3kexuan.Tables[0].Columns[2].ToString();
            //设置列宽*/
            DataGridView3kexuan.Columns[0].Width = 180;
            DataGridView3kexuan.Columns[1].Width = 190;
            DataGridView3kexuan.Columns[2].Width = 180;
            conn.Close();
        }
        private void list3()
        {
            GroupBox3list.Controls.Clear();
            DataGridView DataGridView3list = new DataGridView();
            //--
            GroupBox3list.Controls.Add(DataGridView3list);
            DataGridView3list.ReadOnly = true;
            DataGridView3list.Font = new Font("楷体", 12);
            DataGridView3list.BorderStyle = BorderStyle.None;
            DataGridView3list.BackgroundColor = Color.GhostWhite;
            DataGridView3list.Dock = DockStyle.Fill;
            DataGridView3list.DataSource = null;
            DataGridView3list.AutoGenerateColumns = false;
            DataGridView3list.ColumnCount = 4;
            //--
            string sql3list = "select Sstudynumber,Sname,Sclass,Schoose from Student";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data3list = new SqlDataAdapter(sql3list, conn);
            DataSet set3list = new DataSet();
            data3list.Fill(set3list, "Student");
            DataGridView3list.DataSource = set3list;
            DataGridView3list.DataMember = "Student";
            //设置表的列头文字
            DataGridView3list.Columns[0].HeaderText = "学号";
            DataGridView3list.Columns[1].HeaderText = "姓名";
            DataGridView3list.Columns[2].HeaderText = "班级";
            DataGridView3list.Columns[3].HeaderText = "已选导师数量";
            //录入数据
            DataGridView3list.Columns[0].DataPropertyName = set3list.Tables[0].Columns[0].ToString();
            DataGridView3list.Columns[1].DataPropertyName = set3list.Tables[0].Columns[1].ToString();
            DataGridView3list.Columns[2].DataPropertyName = set3list.Tables[0].Columns[2].ToString();
            DataGridView3list.Columns[3].DataPropertyName = set3list.Tables[0].Columns[3].ToString();
            //设置列宽*/
            DataGridView3list.Columns[0].Width = 162;
            DataGridView3list.Columns[1].Width = 162;
            DataGridView3list.Columns[2].Width = 162;
            DataGridView3list.Columns[3].Width = 162;
            conn.Close();
        }

        private void queren3()
        {
            ComboBox3queren.DataSource = null;
            ComboBox3queren.Items.Clear();
            string sql3queren = "select Sstudynumber from Student where Schoose != '1'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data3queren = new SqlDataAdapter(sql3queren, conn);
            DataTable set3queren = new DataTable();
            data3queren.Fill(set3queren);
            ComboBox3queren.DataSource = set3queren;
            ComboBox3queren.DisplayMember = "Sstudynumber";
            conn.Close();

        }
        private void Button3zhuxiao_click(Object b, EventArgs e)
        {
            string sql3Buttonzhuxiao = "update Tutor set Tyes = '0' where Tyes= '1'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data3Buttonzhuxiao = new SqlDataAdapter(sql3Buttonzhuxiao, conn);
            DataTable set3Buttonzhuxiao = new DataTable();
            data3Buttonzhuxiao.Fill(set3Buttonzhuxiao);
            conn.Close();
            this.Hide();
        }
        private void Button3queren_click(Object b, EventArgs e)
        {
            string sql3bool = "select ST.Tworknumber from ST join Tutor on ST.Tworknumber=Tutor.Tworknumber where Tyes='1' and ST.Sstudynumber =" + ComboBox3queren.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data3bool = new SqlDataAdapter(sql3bool, conn);
            DataTable table3bool = new DataTable();
            data3bool.Fill(table3bool);
            if (table3bool.Rows.Count == 0)
            {
                string sql3Button3queren1 = "insert into ST values('" + ComboBox3queren.Text + "','" + bLabel3Tnumber.Text + "','0','1','0')";
                SqlDataAdapter dataButton3queren1 = new SqlDataAdapter(sql3Button3queren1, conn);
                DataTable set3Button3queren1 = new DataTable();
                dataButton3queren1.Fill(set3Button3queren1);
                MessageBox.Show("选取成功");
            }
            if (table3bool.Rows.Count != 0)
            {
                string sql3Button3queren2 = "update ST set TgetS = '1' where Tworknumber in (select Tworknumber from Tutor where Tyes = '1') and Sstudynumber = " + ComboBox3queren.Text;
                SqlDataAdapter data3Button3queren2 = new SqlDataAdapter(sql3Button3queren2, conn);
                DataTable set3Button3queren2 = new DataTable();
                data3Button3queren2.Fill(set3Button3queren2);
                conn.Close();
                MessageBox.Show("选取成功");
            }
        }

        private void readbLabel3T()
        {
            GroupBox3Tziliao.Controls.Clear();
            Label aLabel3Tname = new Label();
            Label aLabel3Tnumber = new Label();
            Label bLabel3Tname = new Label();
            bLabel3Tnumber = new Label();
            //--
            GroupBox3Tziliao.Controls.Add(aLabel3Tname);
            aLabel3Tname.Text = "姓名：";
            aLabel3Tname.SetBounds(80, 50, 70, 16);
            aLabel3Tname.Font = new Font("楷体", 13);
            aLabel3Tname.BackColor = System.Drawing.Color.Transparent;

            GroupBox3Tziliao.Controls.Add(aLabel3Tnumber);
            aLabel3Tnumber.Text = "工号：";
            aLabel3Tnumber.SetBounds(80, 90, 70, 16);
            aLabel3Tnumber.Font = new Font("楷体", 13);
            aLabel3Tnumber.BackColor = System.Drawing.Color.Transparent;

            GroupBox3Tziliao.Controls.Add(bLabel3Tname);
            bLabel3Tname.SetBounds(160, 50, 100, 16);
            bLabel3Tname.Font = new Font("楷体", 13);
            bLabel3Tname.BackColor = System.Drawing.Color.Transparent;

            GroupBox3Tziliao.Controls.Add(bLabel3Tnumber);
            bLabel3Tnumber.SetBounds(160, 90, 100, 16);
            bLabel3Tnumber.Font = new Font("楷体", 13);
            bLabel3Tnumber.BackColor = System.Drawing.Color.Transparent;
            //--
            string sql3readLabel3T = "select * from Tutor where Tyes = '1'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlCommand DataLabel3T = new SqlCommand(sql3readLabel3T, conn);
            SqlDataReader DataReadbLabel3T = DataLabel3T.ExecuteReader();
            while (DataReadbLabel3T.Read())
            {
                bLabel3Tname.Text += DataReadbLabel3T["Tname"];
                bLabel3Tnumber.Text += DataReadbLabel3T["Tworknumber"];
            }
            conn.Close();
            DataLabel3T.Dispose();
        }
        private void Sziliao()
        {
            GroupBox3Sziliao.Controls.Clear();
            DataGridView DataGridView3Sziliao = new DataGridView();
            //--
            GroupBox3Sziliao.Controls.Add(DataGridView3Sziliao);
            DataGridView3Sziliao.ReadOnly = true;
            DataGridView3Sziliao.Font = new Font("楷体", 12);
            DataGridView3Sziliao.BorderStyle = BorderStyle.None;
            DataGridView3Sziliao.BackgroundColor = Color.GhostWhite;
            DataGridView3Sziliao.Dock = DockStyle.Fill;
            DataGridView3Sziliao.DataSource = null;
            DataGridView3Sziliao.AutoGenerateColumns = false;
            DataGridView3Sziliao.ColumnCount = 3;
            //--
            string sqlSziliao = "select Student.Sstudynumber,Sname,Sclass from Student join ST on ST.Sstudynumber=Student.Sstudynumber join Tutor on ST.Tworknumber=Tutor.Tworknumber where Tyes='1' and STok='1'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter dataSziliao = new SqlDataAdapter(sqlSziliao, conn);
            DataSet setSziliao = new DataSet();
            dataSziliao.Fill(setSziliao, "Student");
            DataGridView3Sziliao.DataSource = setSziliao;
            DataGridView3Sziliao.DataMember = "Student";
            //设置表的列头文字
            DataGridView3Sziliao.Columns[0].HeaderText = "学号";
            DataGridView3Sziliao.Columns[1].HeaderText = "姓名";
            DataGridView3Sziliao.Columns[2].HeaderText = "班级";
            //录入数据
            DataGridView3Sziliao.Columns[0].DataPropertyName = setSziliao.Tables[0].Columns[0].ToString();
            DataGridView3Sziliao.Columns[1].DataPropertyName = setSziliao.Tables[0].Columns[1].ToString();
            DataGridView3Sziliao.Columns[2].DataPropertyName = setSziliao.Tables[0].Columns[2].ToString();
            //设置列宽*/
            DataGridView3Sziliao.Columns[0].Width = 210;
            DataGridView3Sziliao.Columns[1].Width = 230;
            DataGridView3Sziliao.Columns[2].Width = 210;
            conn.Close();
        }
        private void yaoqing3()
        {
            GroupBox3yaoqing.Controls.Clear();
            DataGridView DataGridView3yaoqing = new DataGridView();
            GroupBox3yaoqing.Controls.Add(DataGridView3yaoqing);
            DataGridView3yaoqing.ReadOnly = true;
            DataGridView3yaoqing.Font = new Font("楷体", 12);
            DataGridView3yaoqing.BorderStyle = BorderStyle.None;
            DataGridView3yaoqing.BackgroundColor = Color.GhostWhite;
            DataGridView3yaoqing.Dock = DockStyle.Fill;
            DataGridView3yaoqing.DataSource = null;
            DataGridView3yaoqing.AutoGenerateColumns = false;
            DataGridView3yaoqing.ColumnCount = 3;

            string sql3yaoqing = "select Student.Sstudynumber,Sname,Sclass from Student join ST on ST.Sstudynumber=Student.Sstudynumber join Tutor on ST.Tworknumber=Tutor.Tworknumber where Tyes='1' and SgetT='1' and Schoose!='1'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data3yaoqing = new SqlDataAdapter(sql3yaoqing, conn);
            DataSet set3yaoqing = new DataSet();
            data3yaoqing.Fill(set3yaoqing, "Tutor");
            DataGridView3yaoqing.DataSource = set3yaoqing;
            DataGridView3yaoqing.DataMember = "Tutor";
            //设置表的列头文字
            DataGridView3yaoqing.Columns[0].HeaderText = "学号";
            DataGridView3yaoqing.Columns[1].HeaderText = "姓名";
            DataGridView3yaoqing.Columns[2].HeaderText = "班级";
            //录入数据
            DataGridView3yaoqing.Columns[0].DataPropertyName = set3yaoqing.Tables[0].Columns[0].ToString();
            DataGridView3yaoqing.Columns[1].DataPropertyName = set3yaoqing.Tables[0].Columns[1].ToString();
            DataGridView3yaoqing.Columns[2].DataPropertyName = set3yaoqing.Tables[0].Columns[2].ToString();
            //设置列宽*/
            DataGridView3yaoqing.Columns[0].Width = 245;
            DataGridView3yaoqing.Columns[1].Width = 260;
            DataGridView3yaoqing.Columns[2].Width = 245;
            conn.Close();
        }
        private void jieshou3()
        {
            ComboBox3jieshou.DataSource = null;
            ComboBox3jieshou.Items.Clear();
            string sql3jieshou = "select Student.Sstudynumber from Student join ST on ST.Sstudynumber=Student.Sstudynumber join Tutor on ST.Tworknumber=Tutor.Tworknumber where Tyes='1' and SgetT='1' and Schoose!='1'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data3jieshou = new SqlDataAdapter(sql3jieshou, conn);
            DataTable set3jieshou = new DataTable();
            data3jieshou.Fill(set3jieshou);
            ComboBox3jieshou.DataSource = set3jieshou;
            ComboBox3jieshou.DisplayMember = "Sstudynumber";
            conn.Close();
        }
        private void Button3jieshou_click(Object b, EventArgs e)
        {
            //1
            string sql3Button3jieshou = "update ST set STok = '1' where Tworknumber in (select Tworknumber from Tutor where Tyes = '1') and Sstudynumber = " + ComboBox3jieshou.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter data3Button3jieshou = new SqlDataAdapter(sql3Button3jieshou, conn);
            DataTable set3Button3jieshou = new DataTable();
            data3Button3jieshou.Fill(set3Button3jieshou);
            conn.Close();
            //2
            string Button3a = "update Student set Schoose = '1' where Sstudynumber = '" + ComboBox3jieshou.Text+"'";
            SqlConnection conna = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conna.Open();
            SqlDataAdapter dataButton3a = new SqlDataAdapter(Button3a, conna);
            DataTable setButton3a = new DataTable();
            dataButton3a.Fill(setButton3a);
            conn.Close();
            //3
            string Button3b = "update Tutor set Tchoose=Tchoose+1 where Tyes = '1'";
            SqlConnection connb = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            connb.Open();
            SqlDataAdapter dataButton3b = new SqlDataAdapter(Button3b, conn);
            DataTable setButton3b = new DataTable();
            dataButton3b.Fill(setButton3b);
            conn.Close();

            MessageBox.Show("学员选取成功！");
            jieshou3();
            yaoqing3();
            list3();
            Tpanel();
        }

        private void TabControltutor_SelectedIndexChanged(Object b, EventArgs e)
        {
            if (TabControltutor.SelectedTab.Name == "tab3ziliao")
            {
                Sziliao();
            }
            if (TabControltutor.SelectedTab.Name == "tab3zhiyuan")
            {
                Tpanel();
                list3();
                kexuan3();
                queren3();
            }
            if (TabControltutor.SelectedTab.Name == "tab3xiaoxi")
            {
                Tpanel();
            }
        }
        private void Tpanel()
        {
            string Tab3bool = "select Tworknumber from Tutor where Tyes = '1' and Tchoose = '5'";
            SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
            conn.Open();
            SqlDataAdapter dataTab3bool = new SqlDataAdapter(Tab3bool, conn);
            DataTable tableTab3bool = new DataTable();
            dataTab3bool.Fill(tableTab3bool);
            if (tableTab3bool.Rows.Count != 0)
            {

                Label LabelTman = new Label();
                LabelTman.BackColor = System.Drawing.Color.Transparent;
                LabelTman.Text = "学员已满，无法进行操作";
                LabelTman.SetBounds(550, 250, 400, 100);
                LabelTman.Font = new Font("楷体", 20);
                Panel PanelTman = new Panel();
                PanelTman.BackgroundImage = Image.FromFile("C:\\Users\\Maple\\Desktop\\导师制双选系统\\1.jpg");
                if (TabControltutor.SelectedTab.Name == "tab3zhiyuan")
                {
                    TabPage3zhiyuan.Controls.Add(PanelTman);
                    PanelTman.BringToFront();
                }
                if (TabControltutor.SelectedTab.Name == "tab3xiaoxi")
                {

                    TabPage3xiaoxi.Controls.Add(PanelTman);
                    PanelTman.BringToFront();
                }
                PanelTman.Dock = DockStyle.Fill;
                PanelTman.Controls.Add(LabelTman);

            }
            else { }
        }

        private void Button3xiugai_click(Object b, EventArgs e)
        {
            Formmima3 = new Form();
            Formmima3.Text = "更改密码";
            Formmima3.SetBounds(100, 100, 600, 500);

            Labelxiugaimima3 = new Label();
            Formmima3.Controls.Add(Labelxiugaimima3);
            Labelxiugaimima3.Text = "更改密码";
            Labelxiugaimima3.SetBounds(230, 50, 200, 30);
            Labelxiugaimima3.Font = new Font("楷宋", 15);

            Labelold3 = new Label();
            Formmima3.Controls.Add(Labelold3);
            Labelold3.Text = "旧密码";
            Labelold3.SetBounds(150, 150, 100, 20);
            Labelold3.Font = new Font("楷宋", 12);

            Labelnew3 = new Label();
            Formmima3.Controls.Add(Labelnew3);
            Labelnew3.Text = "新密码";
            Labelnew3.SetBounds(150, 200, 100, 20);
            Labelnew3.Font = new Font("楷宋", 12);

            Labelnewqueren3 = new Label();
            Formmima3.Controls.Add(Labelnewqueren3);
            Labelnewqueren3.Text = "确认密码";
            Labelnewqueren3.SetBounds(150, 250, 100, 20);
            Labelnew3.Font = new Font("楷宋", 12);

            TextBoxold3 = new TextBox();
            Formmima3.Controls.Add(TextBoxold3);
            TextBoxold3.SetBounds(250, 150, 200, 20);
            TextBoxold3.Font = new Font("楷宋", 10);
            TextBoxold3.UseSystemPasswordChar = true;

            TextBoxnew3 = new TextBox();
            Formmima3.Controls.Add(TextBoxnew3);
            TextBoxnew3.SetBounds(250, 200, 200, 20);
            TextBoxnew3.Font = new Font("楷宋", 10);
            TextBoxnew3.UseSystemPasswordChar = true;

            TextBoxnewqueren3 = new TextBox();
            Formmima3.Controls.Add(TextBoxnewqueren3);
            TextBoxnewqueren3.SetBounds(250, 250, 200, 20);
            TextBoxnewqueren3.Font = new Font("楷宋", 10);
            TextBoxnewqueren3.UseSystemPasswordChar = true;

            Buttonmimaqueren3 = new Button();
            Formmima3.Controls.Add(Buttonmimaqueren3);
            Buttonmimaqueren3.SetBounds(250, 325, 70, 25);
            Buttonmimaqueren3.Text = "确认修改";
            Buttonmimaqueren3.Click += new EventHandler(Buttonmimaqueren3_click);

            Formmima3.Show();
        }

        private void Buttonmimaqueren3_click(Object b, EventArgs e)
        {
            if (TextBoxold3.Text == "")
            {
                MessageBox.Show("旧密码不能为空");
                TextBoxold3.Focus();
            }
            else if (TextBoxnew3.Text == "")
            {
                MessageBox.Show("新密码不能为空");
                TextBoxnew3.Focus();
            }
            else if (TextBoxnewqueren3.Text == "")
            {
                MessageBox.Show("确认密码不能为空");
                TextBoxnewqueren3.Focus();
            }
            else
            {
                List<string> oldsend3 = new List<string>();
                string sqlold3 = "select * from TutorLogin where Taccount = '" + bLabel3Tnumber.Text + "'";
                SqlConnection conn = new SqlConnection(@"Data Source=MAPLE\MAPLE;Initial Catalog=TutorSystem;User ID=20143018;Password=20143018");
                conn.Open();
                SqlDataAdapter dataold3 = new SqlDataAdapter(sqlold3, conn);
                DataTable tableold3 = new DataTable();
                dataold3.Fill(tableold3);
                foreach (DataRow row3 in tableold3.Rows)
                {
                    oldsend3.Add(row3["Tpassword"].ToString());
                }
                string[] oldget3 = oldsend3.ToArray();

                for (int i = 0; i < oldget3.Length; i++)
                {
                    if (oldget3[i].Equals(TextBoxold3.Text))
                    {
                        if (TextBoxnewqueren3.Text.Equals(TextBoxnew3.Text))
                        {
                            string sqlnew3 = "update TutorLogin set Tpassword = '" + TextBoxnewqueren3.Text + "' where Taccount = '" + bLabel3Tnumber.Text + "'";
                            SqlDataAdapter datanew3 = new SqlDataAdapter(sqlnew3, conn);
                            DataTable tablenew3 = new DataTable();
                            datanew3.Fill(tablenew3);
                            conn.Close();

                            MessageBox.Show("密码更改成功");
                            Formmima3.Close();
                        }
                        else
                        {
                            MessageBox.Show("新密码输入不一致");
                            TextBoxnew3.Text = "";
                            TextBoxnewqueren3.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("旧密码错误");
                        TextBoxold3.Text = "";
                    }
                }
            }
        }
        public tutor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
