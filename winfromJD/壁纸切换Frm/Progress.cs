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
    public partial class Progress : Form
    {
        public Progress()
        {
            InitializeComponent();
        }
        public void AddProgress()
        {
            progressBar1.Value = progressBar1.Value+10;
            label1.Text = (progressBar1.Value).ToString() + "%";
            label1.Refresh();
        }
    }
}
