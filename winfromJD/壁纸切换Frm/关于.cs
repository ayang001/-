using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winfromJD.壁纸切换Frm
{
    public partial class 关于 : Form
    {
        public 关于()
        {
            InitializeComponent();
        }

        private void 关于_Load(object sender, EventArgs e)
        {
            label1.Text = "该软件免费，个人开发，就是嫌换壁纸麻烦，才搞得。暂时没啥说的";
            label2.Text = @"1.0.0.0   切换壁纸  

1.1.0.0   自定义秒数切换壁纸

1.2.0.0   更新种类

2.0.0.0   修改UI，增加预览界面

3.0.0.0   2.0 的UI太丑，看不下去，切换UI";
        }
    }
}
