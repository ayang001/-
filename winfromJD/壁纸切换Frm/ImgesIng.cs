using DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winfromJD.Hepler;
using MessageBox = System.Windows.Forms.MessageBox;

namespace winfromJD.壁纸切换Frm
{
    public partial class ImgesIng : Form
    {
        string img;
        public ImgesIng(string key)
        {
            InitializeComponent();
            img = key;
        }
        IniFiles ini = new IniFiles(Application.StartupPath + @"\MyConfig.ini");//Application.StartupPath只适用于winform窗体程序

        private void ImgesIng_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            pictureBox1.Image = new Bitmap((new System.Net.WebClient()).OpenRead(img));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImgesIng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string times = ini.IniReadValue("壁纸切换", "is壁纸");
            壁纸切换 bz = new 壁纸切换();

            if (times == "0")
            {
                string images = img;
                int index = images.LastIndexOf('/');
                //从下⼀个索引开始截取
                string images_name = images.Substring(index + 1);

                string strPath = "D:\\自动切换壁纸";
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }
                //照片另存
                strPath = strPath + "\\" + images_name;
                bz.GetFileFromNetUrl(images, strPath);
                //list.Add(strPath);
                int oo = win32images.SetWallpaper(strPath);
                File.Delete(strPath);
                MessageBox.Show("设置成功！");
            }
            else
            {
                MessageBox.Show("缺少配置文件，请重新启动");
                return;
            }
            this.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
        }
    }
}
