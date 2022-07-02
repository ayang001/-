using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winfromJD.壁纸切换Frm;

namespace winfromJD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            切换();
        }
        private void 切换() 
        {
            label1.Text = "在线预览";
            壁纸切换 frm2 = new 壁纸切换(); //实例化一个子窗口

            //设置子窗口不显示为顶级窗口

            frm2.TopLevel = false;

            //设置子窗口的样式，没有上面的标题栏

            frm2.FormBorderStyle = FormBorderStyle.None;

            //填充

            frm2.Dock = DockStyle.Fill;

            //清空Panel里面的控件

            this.panel3.Controls.Clear();

            //加入控件

            this.panel3.Controls.Add(frm2);

            //让窗体显示

            frm2.Show();
        }

         /// <summary>
         /// 计算时间
         /// </summary>
         /// <param name="dateStart"></param>
         /// <param name="dateEnd"></param>
         /// <returns></returns>
        private int DateDiff(DateTime dateStart, DateTime dateEnd)
        {
            DateTime start = Convert.ToDateTime(dateStart.ToShortDateString());
            DateTime end = Convert.ToDateTime(dateEnd.ToShortDateString());
            TimeSpan sp = end.Subtract(start);
            return sp.Days;
        } 
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (DateTime.Now > DateTime.Parse("2022/08/01"))
            {
                MessageBox.Show("版本过期！");
                return;
            }
            
            切换();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "关于";

            关于 frm2 = new 关于(); //实例化一个子窗口
            //设置子窗口不显示为顶级窗口                  
            frm2.TopLevel = false;                    
            //设置子窗口的样式，没有上面的标题栏
            frm2.FormBorderStyle = FormBorderStyle.None;
            //填充
            frm2.Dock = DockStyle.Fill;
            //清空Panel里面的控件
            this.panel3.Controls.Clear();
            //加入控件
            this.panel3.Controls.Add(frm2);
            //让窗体显示
            frm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
