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

namespace winfromJD
{
    public partial class DNF领取奖励 : Form
    {
        public DNF领取奖励()
        {
            InitializeComponent();
        }
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
                request.Host = "x6m5.ams.game.qq.com";
                //request.Connection = "keep-alive";
                request.Referer = "https://x6m5.ams.game.qq.com/ams/postMessage_noflash.html";
                request.ServicePoint.ConnectionLimit = 3000;

                //电脑              User-Agent: 
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.0.0 Safari/537.36";
                //手机
                //request.UserAgent = "jdapp;android;11.1.0;;;appBuild/98139;ef/1;ep/%7B%22hdid%22%3A%22JM9F1ywUPwflvMIpYPok0tt5k9kW4ArJEU3lfLhxBqw%3D%22%2C%22ts%22%3A1656050704998%2C%22ridx%22%3A-1%2C%22cipher%22%3A%7B%22od%22%3A%22%22%2C%22ad%22%3A%22Y2CzCJc5ZWU5CtHsENU0Cm%3D%3D%22%2C%22ud%22%3A%22Y2CzCJc5ZWU5CtHsENU0Cm%3D%3D%22%2C%22ov%22%3A%22CtS%3D%22%2C%22sv%22%3A%22DI4nBtO%3D%22%7D%2C%22ciphertype%22%3A5%2C%22version%22%3A%221.2.0%22%2C%22appname%22%3A%22com.jingdong.app.mall%22%7D;jdSupportDarkMode/0;Mozilla/5.0 (Linux; Android 5.1.1; SM-G9750 Build/LMY47I; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/52.0.2743.100 Mobile Safari/537.36";
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

            string url = "https://x6m5.ams.game.qq.com/ams/ame/amesvr?ameVersion=0.3&sServiceType=dnf&iActivityId=472448&sServiceDepartment=group_3&sSDID=f634b526722cb3c43e83397fcfa904fe&sMiloTag=AMS-MILO-472448-860229-o1440211944-" + DateTimeUtil.DateTimeToLongTimeStamp(DateTime.Now).ToString() + "-PFW2gi&isXhrPost=true";
            string cookie = "RK=08fJCrTRc6; ptcz=d05b5707aa5e5c29296a2498b90e2394682aada7632d2dafc197dd0d2e803d4b; pgv_pvid=1919030512; eas_sid=T1c6l5V5k7r7r6y8d7W2c8O7t8; ptui_loginuin=1440211944; ied_qq=o1440211944; pt_sms_phone=176******13; pgv_info=ssid=s3034047823; _qpsvr_localtk=0.9019453209691193; uin=o1440211944; skey=@6PxC9rPJN; p_uin=o1440211944; pt4_token=XhRlE3Lmw0LT8fVaMom6GyndKNfg7FLjqzkfOaDaaIM_; p_skey=ldplEcSbee1d56M-joVTriLrg5qW-rplLg3q4CjHOc0_; IED_LOG_INFO2=userUin%3D1440211944%26nickName%3D%2525E9%252598%2525BF%2525E6%2525B4%25258B%26nickname%3D%25E9%2598%25BF%25E6%25B4%258B%26userLoginTime%3D"+ DateTimeUtil.DateTimeToTimeStamp(DateTime.Now).ToString() + "%26logtype%3Dqq%26loginType%3Dqq%26uin%3D1440211944; dnfqqcomrouteLine=a20220526kol_a20220526kol_a20220526kol; tokenParams=%3FsInvite%3D8571faf607388f6b1f027e233e5fca47";
            string Data = "gameId=" +
                "&sArea=" +
                "&iSex=" +
                "&sRoleId=" +
                "&iGender=" +
                "&sServiceType=dnf" +
                "&objCustomMsg=" +
                "&areaname=" +
                "&roleid=" +
                "&rolelevel=" +
                "&rolename=" +
                "&areaid=" +
                "&iActivityId=472448" +
                "&iFlowId=860229" +
                "&g_tk=1426192057" +
                "&e_code=0" +
                "&g_code=0" +
                "&eas_url=http%3A%2F%2Fdnf.qq.com%2Fcp%2Fa20220526kol%2F" +
                "&eas_refer=http%3A%2F%2Fnoreferrer%2F%3Freqid%3D45bb1d54-e6c7-4e25-9a2e-5574b650e833%26version%3D26" +
                "&xhr=1" +
                "&sServiceDepartment=group_3" +
                "&xhrPostKey=xhr_165630207577274";
                string json = UnicodeString.UnicodeToString(HttpPost(url, Data, cookie));
            
        }
    }
}
