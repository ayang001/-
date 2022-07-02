
using DotNet.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using winfromJD.Hepler;
using winfromJD.壁纸切换Frm;
using MessageBox = System.Windows.Forms.MessageBox;

namespace winfromJD
{
    public partial class 壁纸切换 : Form
    {
        public 壁纸切换()
        {
            InitializeComponent();
            ini.IniWriteValue("壁纸切换", "切换时间", time.ToString());
            ini.IniWriteValue("壁纸切换", "is壁纸", "0");
        }
        private bool ztcx = true; //暂停程序//开始
        private bool bctp = true; //是否保存壁纸
        private int time = 10;//切换时间，默认为10秒
        Hashtable ht = new Hashtable();
        string cid = string.Empty;
        IniFiles ini = new IniFiles(Application.StartupPath + @"\MyConfig.ini");//Application.StartupPath只适用于winform窗体程序
        private void button1_Click(object sender, EventArgs e)
        {
            开始切换壁纸();

        }


        private void 开始切换壁纸()
        {
            if (listView1.SelectedItems.Count < 1)
                return;

            //string colunmName = listView1.Columns[0].Text;//获取第一列的标题名称

            //获取选择行第一列的值

            string colunmVal1 = listView1.SelectedItems[0].SubItems[0].Text;


            foreach (DictionaryEntry item in ht)
            {
                if (item.Value.ToString() == colunmVal1)
                {
                    cid = item.Key.ToString();
                }
            }
            //MessageBox.Show("选中了" + colunmVal1+"，值为:"+ cid);
            //return;
            if (button1.Text == "开始")
            {
                ztcx = true;
                button1.Text = "暂停";
                label2.Text = "状态：运行中";
            }
            else if (button1.Text == "暂停")
            {
                ztcx = false;
                button1.Text = "开始";
                label2.Text = "状态：暂停中";
            }
            Thread th = new Thread(new ThreadStart(this.Execute));
            th.Start();
        }
        private void Execute()
        {
            while (ztcx == true)
            {
                getImages(cid);
            }
        }

        string images = "";
        int x = 0;

        public void getImages(string cid)
        {
            string usl = "https://bz.hzwdd.cn/api.php?cid=" + cid + "&start=" + x.ToString() + "&count=10";
            x = x + 1;
            string cookie = "tt_webid=7071436691819480584; lang_set=zh; MONITOR_WEB_ID=d1b45f9e-8ddc-4392-b00c-8b79f38c671e; _ga=GA1.2.1707514111.1646447178; ttcid=009f1aa66f954a208c8a9eaa662cb22b17; mobile_set=no; _gid=GA1.2.1111310753.1646615116; _csrf_token=5ce203464173488c02b85bd43588c709; Hm_lvt_330d168f9714e3aa16c5661e62c00232=1646447170,1646462154,1646469623,1646625046; Hm_lpvt_330d168f9714e3aa16c5661e62c00232=1646625046; s_v_web_id=verify_l0g61cyy_UlUtd84P_4hdp_46rK_AEdb_7LOAQJK4RcPv; _gat_gtag_UA_121535331_1=1; msToken=PLWeopb7xg7iY1YDtVWQMh_pztfS9NrPbkkBO8zuHxDcxNIxIxbdROa9WpseBploUhwPriUqmUOsbkvWyuT9_FubaDZq68gNUQozvTRrxfqNREXagPpwgA==; tt_scid=FzyTZG4IF2opvw2SrxdOdM5Me7XKwK2mZWDIPCqzA7Rp0m3Q7Vl5sC3to1tos4DA6cca";
            string listurl = GetPost.HttpPost(usl, "", cookie);
            JObject jo = (JObject)JsonConvert.DeserializeObject(listurl);
            //string zone = jo["data"]["list"].ToString();
            JToken zone1 = jo["data"]["list"];
            foreach (JToken item in zone1)
            {
                if (ztcx == false)
                    return;
                string category = item["category"].ToString();//图片分类
                string tag = item["tag"].ToString();//图片解释
                labbzlx.Text = category;
                labbzxq.Text = tag;
                images = item["url"].ToString();

                //
                //pictureBox1.Image = new Bitmap((new System.Net.WebClient()).OpenRead(images));
                //pictureBox1.Image     =     Image.FromStream(System.Net.WebRequest.Create("").GetResponse().GetResponseStream());  


                //先求出最后出现这个字符的下标
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
                GetFileFromNetUrl(images, strPath);
                //list.Add(strPath);
                int img = win32images.SetWallpaper(strPath);
                if (!isbctp.Checked == true)
                {
                    File.Delete(strPath);
                }
                if (ini.ExistINIFile())
                {
                    int times = int.Parse(ini.IniReadValue("壁纸切换", "切换时间"));
                    Thread.Sleep(times * 1000); //单位为毫秒
                }
                else
                {
                    MessageBox.Show("缺少配置文件，请重新启动");
                    return;
                }



            }


        }
        /// <summary>
        /// 根据Url下载文件到本地
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="strPath">绝对路径+文件名</param>
        public void GetFileFromNetUrl(string url, string strPath)
        {
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                req.Method = "GET";
                //获得用户名密码的Base64编码  添加Authorization到HTTP头 不需要的账号密码的可以注释下面两行代码
                //string code = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "userName", "passWord")));
                //req.Headers.Add("Authorization", "Basic " + code);
                byte[] fileBytes;
                using (WebResponse webRes = req.GetResponse())
                {
                    int length = (int)webRes.ContentLength;
                    HttpWebResponse response = webRes as HttpWebResponse;
                    Stream stream = response.GetResponseStream();

                    //读取到内存
                    MemoryStream stmMemory = new MemoryStream();
                    byte[] buffer = new byte[length];
                    int i;
                    //将字节逐个放入到Byte中
                    while ((i = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stmMemory.Write(buffer, 0, i);
                    }
                    fileBytes = stmMemory.ToArray();//文件流Byte，需要文件流可直接return，不需要下面的保存代码
                    stmMemory.Close();

                    MemoryStream m = new MemoryStream(fileBytes);
                    //string file = string.Format("F:\\666666666666.pdf");//可根据文件类型自定义后缀
                    FileStream fs = new FileStream(strPath, FileMode.OpenOrCreate);
                    m.WriteTo(fs);
                    m.Close();
                    fs.Close();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            bctp = isbctp.Checked;
            string txtshijian = textBox1.Text.Trim().ToString();
            if (IsNumber(txtshijian))
            {
                time = int.Parse(txtshijian);
                ini.IniWriteValue("壁纸切换", "切换时间", time.ToString());
                ini.IniWriteValue("壁纸切换", "is壁纸","0");

                MessageBox.Show("配置保存成功！");
            }
            else
            {
                MessageBox.Show("切换壁纸时间请输入数字");
            }
        }
        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        public static bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }

        private void 壁纸切换_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("是否关闭“壁纸切换”？", "提示", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)//点击“是”按钮
            {
                System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("壁纸切换");
                foreach (System.Diagnostics.Process p in process)
                {
                    p.Kill();
                }
                e.Cancel = false;//事件的取消为假，关闭窗体

            }
            else
            {
                e.Cancel = true;//事件的取消为真，不关闭窗体
            }
        }

        private void 壁纸切换_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;//不使用委托
            DotNet.Utilities.ChineseCalendar ds = new DotNet.Utilities.ChineseCalendar(DateTime.Now);
            label3.Text = ds.GetChineseHour(DateTime.Now);
            加载壁纸列表();
            listView1.Items[5].Selected = true;
            ini.IniWriteValue("壁纸切换", "切换时间", time.ToString());
            listView1.Items.Add("最新壁纸");
            ht.Add("360", "最新壁纸");
            getImagesing("26");


        }
        private void 加载壁纸列表()
        {

            string usl = "https://bz.hzwdd.cn/api.php?cid=360tags";
            string listurl = GetPost.GetRequest(usl, "");
            JObject jo = (JObject)JsonConvert.DeserializeObject(listurl);
            //string zone = jo["data"]["list"].ToString();
            JToken zone1 = jo["data"];

            int i = 0;
            foreach (JToken item in zone1)
            {
                string old_id = item["old_id"].ToString();//id
                string category = item["category"].ToString();//名称
                listView1.Items.Add(category);
                ht.Add(old_id, category);


                //生成按钮
                Button b1 = new Button();
                b1 = new Button();
                b1.AutoSize = true;
                b1.Text = category;
                b1.Click += numberButton_Click;
                b1.Tag = old_id;
                //n.SizeMode = PictureBoxSizeMode.Zoom;
                this.flowLayoutPanel2.Controls.Add(b1);
                i++;
            }
        }
        /// <summary>
        ///动态生成按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void numberButton_Click(object sender, EventArgs e)
        {
            //Thread fThread = new Thread(new ThreadStart(Progres));//开辟一个新的线程
            //fThread.Start();
            //Thread thread = new Thread(new ParameterizedThreadStart(Progres));
            //string o = "hello";
            //thread.Start((object)o);
            Button b = sender as Button;
            if (b != null)
            {
                string key = b.Tag.ToString();
                getImagesing(key);
            }
        }


        void imges设为壁纸(object sender, EventArgs e) 
        {
            PictureBox b = sender as PictureBox;
            if (b == null)
            {
                MessageBox.Show("设置壁纸失败！");
                return;
            }
            DialogResult r = MessageBox.Show("是否切换为“"+ b.Name.ToString() +"”？", "提示", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)//点击“是”按钮
            {

                string images = b.Tag.ToString();

                //先求出最后出现这个字符的下标
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
                GetFileFromNetUrl(images, strPath);
                //list.Add(strPath);
                int img = win32images.SetWallpaper(strPath);
                if (!isbctp.Checked == true)
                {
                    File.Delete(strPath);
                }
                else
                {
                    MessageBox.Show("缺少配置文件，请重新启动");
                    return;
                }                                             

            }

            
        }

        /// <summary>
        /// 打开页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ImgesIngLoad(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            if (p != null)
            {

                

                string key = p.Tag.ToString();
                ImgesIng img = new ImgesIng(key);
                p.Focus();
                //暂时放弃，根据图片自适应窗体大小
                //int he = 1980 - 1980 / 5;
                //int wi = 1080 - 1080 / 5;

                //img.StartPosition = FormStartPosition.Manual;
                ////Rectangle rect = Screen.GetWorkingArea(this);
                ////img.ClientSize = new System.Drawing.Size(rect.Width- rect.Width/5, rect.Height - rect.Height/5); // 显示器宽高
                //img.ClientSize = new System.Drawing.Size(he, wi); //X1 为宽度，Y1为高度  

                //var screen = Screen.FromPoint(new Point(Cursor.Position.X, Cursor.Position.Y));
                //var x = (1980 - he) / 2;
                //var y = (1080 - wi) / 2;

                //img.Location = new Point(y, x);
                //MainOrViceScreen(img);



                img.ShowDialog();
                // ...
            }
        }

        

        public void getImagesing(string cid)
        {
            Progress progress = new Progress();
            progress.Show();
            
            flowLayoutPanel1.Controls.Clear();
            string usl = "https://bz.hzwdd.cn/api.php?cid=" + cid + "&start=" + x.ToString() + "&count=10";
            x = x + 1;
            string cookie = "tt_webid=7071436691819480584; lang_set=zh; MONITOR_WEB_ID=d1b45f9e-8ddc-4392-b00c-8b79f38c671e; _ga=GA1.2.1707514111.1646447178; ttcid=009f1aa66f954a208c8a9eaa662cb22b17; mobile_set=no; _gid=GA1.2.1111310753.1646615116; _csrf_token=5ce203464173488c02b85bd43588c709; Hm_lvt_330d168f9714e3aa16c5661e62c00232=1646447170,1646462154,1646469623,1646625046; Hm_lpvt_330d168f9714e3aa16c5661e62c00232=1646625046; s_v_web_id=verify_l0g61cyy_UlUtd84P_4hdp_46rK_AEdb_7LOAQJK4RcPv; _gat_gtag_UA_121535331_1=1; msToken=PLWeopb7xg7iY1YDtVWQMh_pztfS9NrPbkkBO8zuHxDcxNIxIxbdROa9WpseBploUhwPriUqmUOsbkvWyuT9_FubaDZq68gNUQozvTRrxfqNREXagPpwgA==; tt_scid=FzyTZG4IF2opvw2SrxdOdM5Me7XKwK2mZWDIPCqzA7Rp0m3Q7Vl5sC3to1tos4DA6cca";
            string listurl = GetPost.HttpPost(usl, "", cookie);
            JObject jo = (JObject)JsonConvert.DeserializeObject(listurl);
            JToken zone1 = jo["data"]["list"];
            foreach (JToken item in zone1)
            {
                if (ztcx == false)
                    return;
                string category = item["category"].ToString();//图片分类
                string images = item["url"].ToString();//路径
                string tag = item["tag"].ToString();//图片解释
                //生成图片
                PictureBox b1 = new PictureBox();
                b1.Height = 300;
                b1.Width = 500;
                b1.Text = tag;
                b1.Name = tag;
                b1.Image = new Bitmap((new System.Net.WebClient()).OpenRead(images));
                b1.SizeMode = PictureBoxSizeMode.Zoom;
                b1.ContextMenuStrip = contextMenuStrip2;
                b1.Tag = images;
                toolTip1.SetToolTip(b1, tag);//鼠标放上去提示文字
                b1.Click +=  ImgesIngLoad;
                b1.DoubleClick += imges设为壁纸;
                //b1.BorderStyle = BorderStyle.FixedSingle;暂时不要边框
                //b1.MouseEnter += 鼠标进入;
                //b1.MouseLeave += 鼠标退出;
                this.flowLayoutPanel1.Controls.Add(b1);
                progress.AddProgress();
            }
            progress.Close();

        }
        void 鼠标进入(object sender, EventArgs e)
        {
            Button bu = new Button();
            bu.Text = "设为壁纸";
            bu.Location =new Point(0,0);
            bu.Click += 图像按钮;
            bu.BringToFront();
            PictureBox b = sender as PictureBox;
            b.Controls.Add(bu);
            
        }

        void 鼠标退出(object sender, EventArgs e)
        {
            PictureBox b = sender as PictureBox;
            b.Controls.Clear();
        }
        void 图像按钮(object sender, EventArgs e)
        {
            MessageBox.Show("11");
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            开始切换壁纸();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "暂停")
            {
                ztcx = false;
                button1.Text = "开始";
                label2.Text = "状态：暂停中";
            };
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            
            int count = 10;
            PictureBox[] n = new PictureBox[count];
            for (int i = 0; i < count; i++)
            {
                n[i] = new PictureBox();
                n[i].AutoSize = true;
                n[i].Image = new Bitmap((new System.Net.WebClient()).OpenRead(images));
                n[i].SizeMode = PictureBoxSizeMode.Zoom;

                this.flowLayoutPanel1.Controls.Add(n[i]);
            }
        }
        //系统右键
        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("懒得写帮助。");
        }
        /// <summary>
        /// 图片右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            PictureBox b = sender as PictureBox;
            if (b == null)
            {
                MessageBox.Show("设置壁纸失败！");
                return;
            }
            DialogResult r = MessageBox.Show("是否切换为“" + b.Name.ToString() + "”？", "提示", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)//点击“是”按钮
            {

                string images = b.Tag.ToString();

                //先求出最后出现这个字符的下标
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
                GetFileFromNetUrl(images, strPath);
                //list.Add(strPath);
                int img = win32images.SetWallpaper(strPath);
                if (!isbctp.Checked == true)
                {
                    File.Delete(strPath);
                }
                else
                {
                    MessageBox.Show("缺少配置文件，请重新启动");
                    return;
                }

            }
        }

        /// <summary>
        /// 默认主窗体screen=0  screen=1 副屏   主副屏幕窗体选择
        /// </summary>
        /// <param name="form"></param>
        /// <param name="screen"></param>
        public static void MainOrViceScreen(Form form, int screen = 0)
        {
            //Screen [] d = Screen.AllScreens;
            //if (!Screen.AllScreens[screen].Primary)
            //    screen = 1;


            if (Screen.AllScreens.Length <= 1)
                return;
            if (Screen.AllScreens.Length < screen)
                return;

            form.StartPosition = FormStartPosition.Manual;
            form.Location = new System.Drawing.Point(Screen.AllScreens[screen].Bounds.X, Screen.AllScreens[screen].Bounds.Y);
        }

    }
}
