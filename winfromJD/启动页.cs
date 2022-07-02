using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winfromJD
{
    public partial class 启动页 : Form
    {
        public 启动页()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DNF领取奖励 DNF = new DNF领取奖励();
            DNF.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            壁纸切换 qh = new 壁纸切换();
            qh.ShowDialog();
        }
    }
}
