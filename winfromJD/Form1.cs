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
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static winfromJD.JSon;

namespace winfromJD
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        string url = "https://api.m.jd.com";
        public static string HttpPost(string url, string postdata, string cookies)

        {

            HttpWebRequest request = null;

            HttpWebResponse response = null;

            try
            {

                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "POST";

                byte[] data = Encoding.UTF8.GetBytes(postdata);

                request.ContentType = "application/x-www-form-urlencoded";
                request.Host = "api.m.jd.com";
                //request.Connection = "keep-alive";
                request.Referer = "https://h5.m.jd.com/babelDiy/Zeus/yj8mbcm6roENn7qhNdhiekyeqtd/index.html?sid=72c1e50b13d2b2af6260326b7cef8b7w&un_area=1_2802_54741_0";

                request.ServicePoint.ConnectionLimit = 3000;

                //电脑
                //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.83 Safari/535.11";
                //手机
                request.UserAgent = "jdapp;android;11.1.0;;;appBuild/98139;ef/1;ep/%7B%22hdid%22%3A%22JM9F1ywUPwflvMIpYPok0tt5k9kW4ArJEU3lfLhxBqw%3D%22%2C%22ts%22%3A1656050704998%2C%22ridx%22%3A-1%2C%22cipher%22%3A%7B%22od%22%3A%22%22%2C%22ad%22%3A%22Y2CzCJc5ZWU5CtHsENU0Cm%3D%3D%22%2C%22ud%22%3A%22Y2CzCJc5ZWU5CtHsENU0Cm%3D%3D%22%2C%22ov%22%3A%22CtS%3D%22%2C%22sv%22%3A%22DI4nBtO%3D%22%7D%2C%22ciphertype%22%3A5%2C%22version%22%3A%221.2.0%22%2C%22appname%22%3A%22com.jingdong.app.mall%22%7D;jdSupportDarkMode/0;Mozilla/5.0 (Linux; Android 5.1.1; SM-G9750 Build/LMY47I; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/52.0.2743.100 Mobile Safari/537.36";
                /*
                    User-Agent: 

                 */
                request.ContentLength = data.Length;

                request.Headers.Add("cookie", cookies);

                Stream newStream = request.GetRequestStream();

                newStream.Write(data, 0, data.Length);

                newStream.Close();



                response = (HttpWebResponse)request.GetResponse();

                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                string result = reader.ReadToEnd();

                reader.Close();

                request.Abort();

                response.Close();

                return result;

            }

            catch (Exception ex)

            {

                if (request != null) request.Abort();

                if (response != null) response.Close();

                return string.Empty;

            }



        }

        private string GetRequest(string url, string cookies)
        {

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            if (cookies != "")
            {
                myRequest.Headers.Add("cookie", cookies);
            }

            myRequest.Method = "GET";

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();

            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);

            string content = reader.ReadToEnd();

            reader.Close();

            return content;

        }
        private void button1_Click(object sender, EventArgs e)
        {

            url = url + "/doLuckDrawEntrance";
            string cookie = " _gia_s_local_fingerprint=62253659b83452676df16f198ec9b9ca; _gia_s_e_joint={\"eid\":\"XDY64VGYLIPSRF3BJRU2CFBSHDSXDCIQV23TXQQYNZIZ6Q6RMZLFGHX4WT4OLVDL6PNAIQX6WOHNCQPO5AX4FQMPVQ\",\"ma\":\"\",\"im\":\"\",\"os\":\"android\",\"osv\":\"\",\"ip\":\"222.90.61.69\",\"apid\":\"jdapp\",\"ia\":\"\",\"uu\":\"\",\"cv\":\"11.1.0\",\"nt\":\"UNKNOW\",\"at\":\"3\"}; 3AB9D23F7A4B3C9B=XDY64VGYLIPSRF3BJRU2CFBSHDSXDCIQV23TXQQYNZIZ6Q6RMZLFGHX4WT4OLVDL6PNAIQX6WOHNCQPO5AX4FQMPVQ; BATQW722QTLYVCRD={\"tk\":\"jdd01GIG7U7HRWYAXHQS6YWBAVPSADHJJ2YX2TVPE5SHNW4SFTVCSDUWCHIDOHLILFVBFKHZ2BDNYYB2F3GN4JCSAV2C24O5TZYJWP3GCQ6Y01234567\",\"t\":1656050613546}; pt_key=app_openAAJitUggADCwjydRB62IJCOsqE3sSmdr6-jexwKueFs6JQ6RcUaH9-iahLvZoB28CNIENku6qoM; pt_pin=jd_626c1046f14e8; pwdt_id=jd_626c1046f14e8; sid=72c1e50b13d2b2af6260326b7cef8b7w; __jda=122270672.1656047633351377718872.1656047633.1656047633.1656050613.2; __jdb=122270672.6.1656047633351377718872|2.1656050613; __jdc=122270672; pre_session=jIBVX9GN6fWbWfNc+aqduT5oggf3DP1F|4; pre_seq=10; __jdv=122270672%7Cappmarket%7Ct_2018512525_appmarket%7Ctuiguang%7C50966_0_tencent_0_0%7C1656047391000; joyytoken=50078MDFTWXVqdzAxMQ==.Ym9AXEdmakZTRmdoRBQYa2xFCCMDEUVYCWJ1Q0ZCf2gLWAliJws=.fad9b841; unpl=; __jd_ref_cls=Babel_dev_other_PrizeCoupon; mba_sid=1.40; mba_muid=1656047633351377718872.1.1656050709666";
            if (textBox1.Text != "")
            {
                //url = textBox1.Text.ToString();
            }
            else
            {
                MessageBox.Show("请输入URL");
                return;
            }
            if (cookie == "")
            {
                MessageBox.Show("请输入URL");
                return;
            }
            DateTime time = DateTime.Now;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));//当地时区
            TimeSpan ts = time - startTime;
            var timestamp = Convert.ToInt64(ts.TotalMilliseconds);
            string datatimeing = timestamp.ToString();
            string Data = "appid=XPMSGC2019" +
                "&client=m" +
                "&t=" + datatimeing +
                "&body=%7B%22platformType%22%3A%221%22%2C%22extend%22%3A%2251578F048F23A6DFE196F25CF6236E0F5C3D659DF70AB808BDF6B0496035E7660B0636A7A7C96823363FC6E3F6090BADA5444D05CCB07E1C20BB55E8E8B86771%22%2C%22random%22%3A%223650311%22%2C%22extraData%22%3A%22%7B%5C%22log%5C%22%3A%5C%221656053428109~1okyIhKwYgQMDFTWXVqdzAxMQ%3D%3D.Ym9AXEdmakZTRmdoRBQYa2xFCCMDEUVYCWJ1Q0ZCf2gLWAliJws%3D.fad9b841~5%2C1~25D6AC73BF4A855997DDDD67D5D3CAEAEB979296~1jh6efw~C~ShtBXRoOa2weEUFaWRMDbhJcAR0HcR9wZxhjAWIcCBoFAQIfQRYYE10CHQ53HHRhH2d3eR0JGwUIBBxFEB8XUAUcD3YcfWccY316GUEYRRtoHBpTQl8QCQQYFkJKFwoaBQYEBAMABAMBAQUDCQcJCQERGRZDVF0XChpAREVGRxcYFkZcVBICFlZXRkdBQEFQGxkSSFBeEwhoAxgMCBUEARQFBR0DHwBpGBNTXxICBRwTUUAXDhYFCVMCCwUIUFcDDAEBVV0BB1sCAgYEUA0FUVAABAIKUBIdEF1FFg4TdVxeTUwQWAQLAxYYE00XCgkCBQcCBgYABgkIBQkUFlpaEAkXGQQBAQQICwUJVwEKVBlXUgoEBwFRVQgAB1cMAQUKGFMBAlIEAVZRBwEJXwRUAFAECFcDAA0DCAhUA1wDCAECBQNSBgQbGRJeRFITCBEXGBZfTxcKGnNfXlVfUBR9X1obEhQWXlBEEQ8WDQkIBgkaGBJCUUEXDm8HDQUcCwIAbB4RR1sWC2IXY3UZdwgFBgUWGBNYW1RKW1lVEB8XARoAFwQSFBYBABwCGwQWHRsMCAkHCRMeEQYCBwcKBgELAwMIAQYDAQIcAAYCCwADAwQLBgEHBQoGAxoYEgAQbhkWXV5YFwoaUlZXVFVTQEATFRdRUhYKE0cRGRZXWBsPEk8HHgAcAxcYFlJfakYaDhIBAxEZFlZVGw8SSlVeVV1eCAcCBAkGAQkWHBNfWRcObwAVBRwIaRwTUF9aUxYLGwQGDQIABAIEBQwDBAlLAXMHdXBYYV8ER0J0cXZiVgF3e1BxdUx8XggNFlV2XVlVXnZAZn5%2FR2pzAVNrZ2wAVlkNcHFRbkZwX2EBcF0IfX4CalVUZwZFU1MBXnxhYRNyA2Bze3ZHcH1Ac198d2pDdXBwTXdzaF17a1BUfHFybHdcXQl7Z2l%2Fc3BrBHNnfXl9cVNId2V0c3EHZXBge0VSekMEW3dKAWJSWV54cVBlBmBbBxpkTXBgZUhfcnVdAmBldV9yfmdfYn50XgN%2FBEdzVGtGSXNdZQdjdEJdekZWc31qR2dzcWFDYlxGc3N0CVdpW0EFfWdHWXNeekl2cngLY2RtXn96VnpzdlhcV3ENW35ifA1xQmF7eHFLc1ZnAQB8WWpHdmVneHt3WHJ8X0R5eVkBXlVNZVNyelJHfWcEBnhKVnsaVFpTUwFSCQZMSxkFSk9Hd05sTFR3YEQNYmJdUW93T0BjdgMLb2FcaGBzXFtiZ3NzZHJmYXZ%2FQgBgYlhoaGIEYmBQUVZRfFxpdHBLY3txdHhtdG1XfnBzcn1yXF19bQBbbGdJXXZydWVkfgVyXmZyUnxhQmFzc2hWZ39hfmdqcVFWc11afXdfZWpkcHF%2FSgVZXAdKW1USHRBeRlMWCxsXTQ%3D%3D~07gb05u%5C%22%2C%5C%22sceneid%5C%22%3A%5C%22couponNinePointNinedraw%5C%22%7D%22%7D" +
                "&functionId=doLuckDrawEntrance" +
                "&clientVersion=1.0.0" +
                "&area=1_2802_54741_0" +
                "&eu=3636331373935656" +
                "&fv=9323432683534333";
            string json = HttpPost(url, Data, cookie);

            JavaScriptSerializer js = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
            Root list = js.Deserialize<Root>(json);
            string code = list.code;//状态 0 成功
            string message = list.message;//成功还是失败
            if (message == "成功")
            {
                string busiCode = list.busiCode;
                Result result = list.result;
                LuckyDrawData luckyDrawData = result.luckyDrawData;

                string leftUseNum = luckyDrawData.leftUseNum; //剩余几次
                string prizeName = luckyDrawData.prizeName; //商品店名
                string quota = luckyDrawData.quota; //需要多少钱
                string discount = luckyDrawData.discount; //优惠多少钱
                string couponKind = luckyDrawData.couponKind; //抽奖第几次

                textBox1.Text = "状态：" + code + ",备注" + message + "，还有" + leftUseNum + "次机会。商品：“" + prizeName + "” 、满“" + quota + "”减“" + quota + "”";

            }
            else
            {
                textBox1.Text = "状态：" + code + ",备注" + message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void jsoncs_Click(object sender, EventArgs e)
        {
            string json = this.textBox3.Text;


            JavaScriptSerializer js = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
            Root list = js.Deserialize<Root>(json);
            string code = list.code;//状态 0 成功
            string message = list.message;//成功还是失败
            string busiCode = list.busiCode;
            Result result = list.result;
            LuckyDrawData luckyDrawData = result.luckyDrawData;

            string leftUseNum = luckyDrawData.leftUseNum; //剩余几次
            string prizeName = luckyDrawData.prizeName; //商品店名
            string quota = luckyDrawData.quota; //需要多少钱
            string discount = luckyDrawData.discount; //优惠多少钱
            string couponKind = luckyDrawData.couponKind; //抽奖第几次



        }

        private void button2_Click(object sender, EventArgs e)
        {
            url = url + "/client.action";

            string cookie = "";

        }
    }
}
